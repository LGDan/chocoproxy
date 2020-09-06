Imports System.Net
Imports System.Text.RegularExpressions

Public Class WebServer

    Dim hl As New Net.HttpListener()
    Dim iasQ As New Queue(Of IAsyncResult)
    Dim contextProcessorThread As New Threading.Thread(AddressOf ContextProcessor)
    Dim routes As New Dictionary(Of Regex, Action(Of Net.HttpListenerContext))
    Public baseUrl As String

    Sub New(prefix As String)
        baseUrl = prefix
        hl.Prefixes.Add(prefix)
    End Sub

    Sub AddRoute(routeRegex As String, method As Action(Of Net.HttpListenerContext))
        routes.Add(New Regex(routeRegex, RegexOptions.Compiled, TimeSpan.FromMilliseconds(10)), method)
    End Sub

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

    Public Sub StopServer()
        hl.Stop()
    End Sub

    Private Sub ContextProcessor()
        Do
            While iasQ.Count < 10
                Dim ias = hl.BeginGetContext(AddressOf RouteProcessor, Nothing)
                iasQ.Enqueue(ias)
            End While
            Threading.Thread.Sleep(10)
        Loop
    End Sub

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

    Sub ErrorResponse(ctx As HttpListenerContext, errorString As String)
        LogText(errorString)
        Using sw As New IO.StreamWriter(ctx.Response.OutputStream)
            sw.WriteLine(errorString)
        End Using
    End Sub

End Class
