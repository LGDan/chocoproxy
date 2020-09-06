Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization

Public Class ChocoProxy

    Dim memCache As ChocoCache
    Public pkgCacheLocation As String
    Public objCacheLocation As String
    Dim pkgDownloadQueue As New Queue(Of String)
    Dim pkgDownloadThread As New Threading.Thread(AddressOf PackageDownloader)
    Dim associatedWebServer As WebServer
    Dim stringReplacements As New Hashtable

    ''' <summary>
    ''' Create a new instance of ChocoProxy's main proxing subsystem.
    ''' </summary>
    ''' <param name="ws">The web server instance to be serviced by this proxy.</param>
    ''' <param name="cacheTime">How long to keep objects in the cache for. Default is 24 Hours.</param>
    ''' <param name="pkgCacheLocation">Where to keep downloaded .nupkg files.</param>
    ''' <param name="objectCacheLocation">Where to keep cached API data. This is only used if the option to cache to disk is provided.</param>
    Sub New(ws As WebServer, cacheTime As TimeSpan, pkgCacheLocation As String, objectCacheLocation As String)
        Me.pkgCacheLocation = pkgCacheLocation
        Me.objCacheLocation = objCacheLocation
        memCache = New ChocoCache(Me, cacheTime)
        stringReplacements.Add("https://chocolatey.org/api/v2", ws.baseUrl & "api/v2")
        ConfigureRoutes(ws)
        associatedWebServer = ws
        pkgDownloadThread.Start()
    End Sub

    ''' <summary>
    ''' Add all the potential API calls for Chocolatey as routes to the web server router.
    ''' </summary>
    ''' <param name="ws">The web server instance to be serviced by this proxy.</param>
    Sub ConfigureRoutes(ws As WebServer)
        ws.AddRoute("\/api\/v2\/Packages\(\)", Sub(c)
                                                   PassthroughReplace(c, stringReplacements)
                                               End Sub)
        ws.AddRoute("\/api\/v2\/Search\(\)", Sub(c)
                                                 PassthroughReplace(c, stringReplacements)
                                             End Sub)
        ws.AddRoute("^\/api\/v2\/\$metadata$", Sub(c)
                                                   Passthrough(c)
                                               End Sub)
        ws.AddRoute("^\/api\/v2\/package\/(.+)\/(.+)$", Sub(c)
                                                            PackageDirector(c)
                                                        End Sub)
        ws.AddRoute("^/pkg/(.+).nupkg$", Sub(c)
                                             PackageProvider(c)
                                         End Sub)
        ws.AddRoute("^\/api\/v2/$", Sub(c)
                                        Passthrough(c)
                                    End Sub)
        ws.AddRoute("^\/api\/v2$", Sub(c)
                                       Passthrough(c)
                                   End Sub)
        LogText("Routes Configured.")
    End Sub


#Region "Package Delivery"
    ''' <summary>
    ''' The package director tells Chocolatey where to look to download the .nupkg it's looking for.
    ''' </summary>
    ''' <param name="c">httpListenerContext that needs directing.</param>
    Sub PackageDirector(c As HttpListenerContext)
        Dim packageUrlRegex As New Text.RegularExpressions.Regex("^\/api\/v2\/package\/(.+)\/(.+)$")
        Dim m As Match = packageUrlRegex.Match(c.Request.Url.LocalPath)
        Dim packageName As String = m.Groups(1).Value
        Dim packageVersion As String = m.Groups(2).Value
        Dim newLocation As String = associatedWebServer.baseUrl & "pkg/" & packageName & "." & packageVersion & ".nupkg"
        LogText("Directing to " & newLocation)
        Package302Found(c, newLocation)
    End Sub

    ''' <summary>
    ''' The package provider actually sends the .nupkg file to the client, either from the cache or direct from Chocolatey, caching it in the process.
    ''' </summary>
    ''' <param name="c">httpListenerContext that needs to download the package.</param>
    Sub PackageProvider(c As HttpListenerContext)
        Dim pkgName As String = c.Request.Url.Segments().Last()
        If IO.File.Exists(pkgCacheLocation & "/" & pkgName) Then
            LogText("Delivering " & pkgName & " to client " & c.Request.RemoteEndPoint.ToString)
            WriteFile(c, pkgCacheLocation & "/" & pkgName)
        Else
            WriteProxy(c, "https://packages.chocolatey.org/" & pkgName, pkgName)
            pkgDownloadQueue.Enqueue("https://packages.chocolatey.org/" & pkgName)
        End If
    End Sub

    ''' <summary>
    ''' Easy wrapper to deliver a file on disk to a client.
    ''' </summary>
    ''' <param name="ctx">httpListenerContext that needs to download the file.</param>
    ''' <param name="filePath">Full filesystem path to file to send.</param>
    Sub WriteFile(ctx As HttpListenerContext, filePath As String)
        Dim response = ctx.Response
        Using fs As FileStream = File.OpenRead(filePath)
            Dim filename As String = Path.GetFileName(filePath)
            response.ContentLength64 = fs.Length
            response.SendChunked = False
            response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet
            response.AddHeader("Content-disposition", "attachment; filename=" & filename)
            Dim buffer As Byte() = New Byte(65535) {}
            Dim read As Integer

            Using bw As BinaryWriter = New BinaryWriter(response.OutputStream)

                While (InlineAssignHelper(read, fs.Read(buffer, 0, buffer.Length))) > 0
                    bw.Write(buffer, 0, read)
                    bw.Flush()
                End While

                bw.Close()
            End Using

            response.StatusCode = CInt(HttpStatusCode.OK)
            response.StatusDescription = "OK"
            response.OutputStream.Close()
        End Using
    End Sub

    ''' <summary>
    ''' Nasty hack of a function to assign a value to a variable, and return that assigned value at the same time.
    ''' VB.Net won't let you do it natively, but C# does.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="target"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    ''' <summary>
    ''' Returns a HTTP protocol level redirect to the client.
    ''' </summary>
    ''' <param name="c"></param>
    ''' <param name="NewLocation"></param>
    Sub Package302Found(c As HttpListenerContext, NewLocation As String)
        c.Response.StatusCode = 302
        c.Response.StatusDescription = "Found"
        c.Response.Headers.Add("Location", NewLocation)
        Using sw As New StreamWriter(c.Response.OutputStream)
            sw.WriteLine("<html><head><title>Object moved</title></head><body><h2>Object moved to <a href=""" & NewLocation & """>here</a>.</h2></body></html>")
        End Using
    End Sub
#End Region

#Region "API Access"
    ''' <summary>
    ''' Proxies a request to the Chocolatey API, and caches the response.
    ''' </summary>
    ''' <param name="c">httpListenerContext that needs a response.</param>
    Sub Passthrough(c As HttpListenerContext)
        Using sw As New IO.StreamWriter(c.Response.OutputStream)
            c.Response.ContentType = "application/xml;charset=utf-8"
            Dim responseBody As String = ChocoAPICacheGet(c.Request.Url.PathAndQuery)
            sw.Write(responseBody)
        End Using
    End Sub

    ''' <summary>
    ''' Proxies a request to the Chocolatey API, caches the response, but replaces all instances of provided strings with something else. Good for swapping URLs.
    ''' </summary>
    ''' <param name="c">httpListenerContext that needs a response.</param>
    ''' <param name="replaceTable">Hashtable containg values to replace as the key, and what to replace with as the value.</param>
    Sub PassthroughReplace(c As HttpListenerContext, replaceTable As Hashtable)
        Using sw As New IO.StreamWriter(c.Response.OutputStream)
            c.Response.ContentType = "application/xml;charset=utf-8"
            Dim responseBody As String = ChocoAPICacheGet(c.Request.Url.PathAndQuery)
            For Each kv As DictionaryEntry In replaceTable
                responseBody = responseBody.Replace(kv.Key, kv.Value)
            Next
            sw.Write(responseBody)
        End Using
    End Sub

    ''' <summary>
    ''' Gets a resource from the Chocolatey API, and caches the response.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Function ChocoAPICacheGet(path) As String
        If Not memCache.SimpleCheckCache(path) Then
            memCache.AddToSimpleCache(path, ChocoAPIGet(path))
        End If
        Return memCache.GetFromSimpleCache(path)
    End Function

    ''' <summary>
    ''' Gets package metadata from the Chocolatey API, caches the response, and deserialises it to a .NET Object for easy access.
    ''' </summary>
    ''' <param name="packageName">Name of Chocolatey package to get metadata for.</param>
    ''' <returns></returns>
    Public Function OfficialPackageMetadataGet(packageName As String) As Packages.feed
        If Not memCache.SimpleCheckCache("packagemeta." & packageName) Then
            Dim rawXML As String = ChocoAPICacheGet("/api/v2/Packages()?$filter=(tolower(Id)%20eq%20'" & packageName & "')%20and%20IsLatestVersion")
            memCache.AddToSimpleCache("packagemeta." & packageName, XmlConvert.DeserializeObject(Of Packages.feed)(rawXML))
        End If
        Return memCache.GetFromSimpleCache("packagemeta." & packageName)
    End Function

#End Region

#Region "Official Site Interactions"
    ''' <summary>
    ''' Get a resource from the Chocolatey API.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Function ChocoAPIGet(path) As String
        LogText("Getting " & path)
        Try
            Dim wreq As WebRequest = WebRequest.CreateHttp("https://chocolatey.org" & path)
            wreq.Headers.Add(HttpRequestHeader.UserAgent, "NuGet/0.10.15.0 (Microsoft Windows NT 10.0.18363.0)")
            wreq.Headers.Add(HttpRequestHeader.Host, "chocolatey.org")
            Dim wres As WebResponse = wreq.GetResponse()
            Dim responseBody As String = ""
            Using sr As New IO.StreamReader(wres.GetResponseStream())
                responseBody = sr.ReadToEnd()
            End Using
            Return responseBody
        Catch ex As Exception
            LogText("ERR: " & ex.ToString() & " ## path = " & path)
        End Try
    End Function

    ''' <summary>
    ''' A Thread subroutine to monitor the download queue and download packages to the cache.
    ''' </summary>
    Sub PackageDownloader()
        Dim downloader As New WebClient
        Do
            While pkgDownloadQueue.Count = 0
                Threading.Thread.Sleep(10)
            End While
            Dim pkgUrl As New Uri(pkgDownloadQueue.Dequeue())
            Dim pkgFileName As String = pkgUrl.Segments(1)
            Dim partialDownloadLocation As String = pkgCacheLocation & "/" & pkgFileName & ".partial"
            Dim downloadLocation As String = pkgCacheLocation & "/" & pkgFileName
            If Not IO.File.Exists(downloadLocation) Then
                LogText("Downloading " & pkgFileName)
                downloader.DownloadFile(pkgUrl.OriginalString, partialDownloadLocation)
                IO.File.Move(partialDownloadLocation, downloadLocation)
                LogText("Complete: " & pkgFileName)
            End If
        Loop
    End Sub

    ''' <summary>
    ''' Proxies a large file download.
    ''' </summary>
    ''' <param name="c"></param>
    ''' <param name="url"></param>
    ''' <param name="pkgName"></param>
    Sub WriteProxy(c As HttpListenerContext, url As String, pkgName As String)
        LogText("Proxying direct from chocolatey: " & pkgName & " to client " & c.Request.RemoteEndPoint.ToString)
        Dim response = c.Response
        Dim wreq As WebRequest = WebRequest.Create(url)
        wreq.Headers.Add("User-Agent", c.Request.Headers("User-Agent"))
        wreq.Headers.Add("NuGet-Operation", c.Request.Headers("NuGet-Operation"))
        Dim wres As WebResponse = wreq.GetResponse()

        Using fs As IO.Stream = wres.GetResponseStream()
            Dim filename As String = pkgName
            response.ContentLength64 = wres.Headers(HttpResponseHeader.ContentLength)
            response.SendChunked = False
            response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet
            response.AddHeader("Content-disposition", "attachment; filename=" & filename)
            Dim buffer As Byte() = New Byte(65535) {}
            Dim read As Integer

            Using bw As BinaryWriter = New BinaryWriter(response.OutputStream)

                While (InlineAssignHelper(read, fs.Read(buffer, 0, buffer.Length))) > 0
                    bw.Write(buffer, 0, read)
                    bw.Flush()
                End While

                bw.Close()
            End Using

            response.StatusCode = CInt(HttpStatusCode.OK)
            response.StatusDescription = "OK"
            response.OutputStream.Close()
        End Using
    End Sub

#End Region

End Class


