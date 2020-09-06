Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization

Public Class ChocoProxy

    Dim memCache As New ChocoCache(TimeSpan.FromHours(24))
    Dim pkgCacheLocation As String = Directory.GetCurrentDirectory() & "/cache/pkg"
    Dim pkgDownloadQueue As New Queue(Of String)
    Dim pkgDownloadThread As New Threading.Thread(AddressOf PackageDownloader)
    Dim associatedWebServer As WebServer
    Dim stringReplacements As New Hashtable

    Sub New(ws As WebServer)
        stringReplacements.Add("https://chocolatey.org/api/v2", ws.baseUrl & "api/v2")
        ConfigureRoutes(ws)
        associatedWebServer = ws
        pkgDownloadThread.Start()
    End Sub

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
    Sub PackageDirector(c As HttpListenerContext)
        Dim packageUrlRegex As New Text.RegularExpressions.Regex("^\/api\/v2\/package\/(.+)\/(.+)$")
        Dim m As Match = packageUrlRegex.Match(c.Request.Url.LocalPath)
        Dim packageName As String = m.Groups(1).Value
        Dim packageVersion As String = m.Groups(2).Value
        Dim newLocation As String = associatedWebServer.baseUrl & "pkg/" & packageName & "." & packageVersion & ".nupkg"
        LogText("Directing to " & newLocation)
        Package302Found(c, newLocation)
    End Sub

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

    Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

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
    Sub Passthrough(c As HttpListenerContext)
        Using sw As New IO.StreamWriter(c.Response.OutputStream)
            c.Response.ContentType = "application/xml;charset=utf-8"
            Dim responseBody As String = ChocoAPICacheGet(c.Request.Url.PathAndQuery)
            sw.Write(responseBody)
        End Using
    End Sub
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
    Function ChocoAPICacheGet(path) As String
        If Not memCache.SimpleCheckCache(path) Then
            memCache.AddToSimpleCache(path, ChocoAPIGet(path))
        End If
        Return memCache.GetFromSimpleCache(path)
    End Function
    Public Function OfficialPackageMetadataGet(packageName As String) As Packages.feed
        If Not memCache.SimpleCheckCache("packagemeta." & packageName) Then
            Dim rawXML As String = ChocoAPICacheGet("/api/v2/Packages()?$filter=(tolower(Id)%20eq%20'" & packageName & "')%20and%20IsLatestVersion")
            memCache.AddToSimpleCache("packagemeta." & packageName, XmlConvert.DeserializeObject(Of Packages.feed)(rawXML))
        End If
        Return memCache.GetFromSimpleCache("packagemeta." & packageName)
    End Function
    Function OfficialPackageVersionGet(packageName As String) As String
        Return OfficialPackageMetadataGet(packageName).entry.properties.Version
    End Function
#End Region

#Region "Official Site Interactions"
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
    Function OfficialPackageDownloadUrlBuilder(packageName As String, packageVersion As String)
        Return "https://packages.chocolatey.org/" & packageName & "." & packageVersion & ".nupkg"
    End Function
#End Region

End Class


