Imports System.Net
Imports System.Text.RegularExpressions

Public Class WebServer

    Dim hl As New Net.HttpListener()
    Dim iasQ As New Queue(Of IAsyncResult)
    Dim contextProcessorThread As New Threading.Thread(AddressOf ContextProcessor)
    Dim routes As New Dictionary(Of Regex, Action(Of Net.HttpListenerContext))
    Public baseUrl As String

    ''' <summary>
    ''' Create a new instance of the ChocoProxy web server.
    ''' </summary>
    ''' <param name="prefix">What address to listen on. Must be in the format of http://address:port/ </param>
    Sub New(prefix As String)
        baseUrl = prefix
        hl.Prefixes.Add(prefix)
    End Sub

    ''' <summary>
    ''' Point a URL pattern at a method in code that will process the httplistenercontext.
    ''' </summary>
    ''' <param name="routeRegex">Regex string to match the URL endpoint. This only matches the /abc/def part of the URL, not the /abc/def?x=y</param>
    ''' <param name="method">The method to call when the matching URL is requested.</param>
    Sub AddRoute(routeRegex As String, method As Action(Of Net.HttpListenerContext))
        routes.Add(New Regex(routeRegex, RegexOptions.Compiled, TimeSpan.FromMilliseconds(10)), method)
    End Sub

    ''' <summary>
    ''' Start the web server.
    ''' </summary>
    Public Sub StartServer()
        LogText("Starting Web Server...")
        Try
            hl.Start()
            LogText("Web server started.")
            contextProcessorThread.Start()
        Catch ex As Exception
            LogText("Error Starting Web Server: " & vbCrLf & ex.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' Stop the web server.
    ''' </summary>
    Public Sub StopServer()
        hl.Stop()
    End Sub

    ''' <summary>
    ''' Start a backlog of threads ready to process client requests. Currently hard-coded to 10.
    ''' TODO: Make this a setting.
    ''' </summary>
    Private Sub ContextProcessor()
        Do
            While iasQ.Count < 10
                Dim ias = hl.BeginGetContext(AddressOf RouteProcessor, Nothing)
                iasQ.Enqueue(ias)
            End While
            Threading.Thread.Sleep(10)
        Loop
    End Sub

    ''' <summary>
    ''' When a request comes in, check the URL against defined routes and execute the corresponding method.
    ''' </summary>
    Private Sub RouteProcessor()
        Try
            Dim ctx = hl.EndGetContext(iasQ.Dequeue)
            If routes.Count = 0 Then
                ErrorResponse(ctx, "No routes defined.")
            Else
                Dim matchedRoutes = routes.Where(Function(r) r.Key.IsMatch(ctx.Request.Url.LocalPath))
                If matchedRoutes.Count = 0 Then
                    ErrorResponse(ctx, "No routes matched.")
                    LogText("No Route Matched: " & ctx.Request.Url.LocalPath)
                Else
                    Try
                        matchedRoutes.First().Value.Invoke(ctx)
                    Catch ex As Exception
                        LogText("Unhandled error in route function " & matchedRoutes.First().Value.Method.Name & vbCrLf & ex.ToString())
                    End Try
                End If
            End If
            ctx.Response.Close()
        Catch ex As Exception
            LogText("Error processing routes: " & vbCrLf & ex.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' Deliver an error message in response to a request.
    ''' </summary>
    ''' <param name="ctx"></param>
    ''' <param name="errorString"></param>
    Sub ErrorResponse(ctx As HttpListenerContext, errorString As String)
        LogText(errorString)
        Using sw As New IO.StreamWriter(ctx.Response.OutputStream)
            sw.WriteLine(errorString)
        End Using
    End Sub

End Class
