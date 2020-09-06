Imports System
Imports System.IO

Module Program

    Dim logExclude As New List(Of String)
    Dim ws As WebServer
    Dim cp As ChocoProxy
    Dim a As API
    Dim ccl As ConsoleCommandLine

    Dim baseurl As String
    Dim globalSettings As New Hashtable

    Sub Main(args As String())
        Logo()
        LoadSettings()
        DisplaySettings()
        'logExclude.AddRange({"GetFromSimpleCache", "SimpleCheckCache", "AddToSimpleCache", "PackageDirector", "ConfigureRoutes"})
        baseurl = "http://localhost:44111/"
        ws = New WebServer(baseurl)
        cp = New ChocoProxy(ws)
        a = New API(ws, cp)
        ccl = New ConsoleCommandLine(a)

        ws.StartServer()
        'Do
        '    Console.Write("ChocoProxy > ")
        '    Console.WriteLine(MenuHandler(Console.ReadLine()))
        'Loop
    End Sub

    Sub LogText(text As String)
        If globalSettings("ConsoleLogging") Then
            Dim st As New StackTrace
            Dim callerName As String = st.GetFrame(1).GetMethod().Name
            If Not logExclude.Contains(callerName) Then
                Console.WriteLine(Format(Now(), "[HH:mm:ss] ") & "[" & callerName & "] " & text)
            End If
        End If
    End Sub



    Sub Logo()
        Console.ForegroundColor = ConsoleColor.DarkBlue
        Console.BackgroundColor = ConsoleColor.Cyan
        Console.WriteLine(" |                      | ")
        Console.WriteLine(" |    ChocoProxy V0.1   | ")
        Console.WriteLine(" |                      | ")
        Console.WriteLine(" |_   ____   . ___. _._.| ")
        Console.ForegroundColor = ConsoleColor.DarkBlue
        Console.BackgroundColor = ConsoleColor.DarkRed
        Console.WriteLine(" | '''   |'-' '  | '    | ")
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(" |_______|_______|______| ")
        Console.WriteLine("/        \       /       \")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.BackgroundColor = ConsoleColor.Black
        Console.WriteLine()
    End Sub

    Sub DisplaySettings()
        Dim maxSettingWidth As Integer = 7
        Dim maxValueWidth As Integer = 5
        For Each kv As DictionaryEntry In globalSettings
            If kv.Key.ToString().Length > maxSettingWidth Then maxSettingWidth = kv.Key.ToString().Length
            If kv.Value.ToString().Length > maxValueWidth Then maxValueWidth = kv.Value.ToString().Length
        Next
        maxSettingWidth += 1
        maxValueWidth += 1
        For i As Integer = 1 To (maxSettingWidth + 1 + maxValueWidth + 1)
            Console.Write("-")
        Next
        Console.WriteLine()
        Console.WriteLine("Setting".PadRight(maxSettingWidth) & "|" & "Value".PadRight(maxValueWidth) & "|")
        For i As Integer = 1 To (maxSettingWidth + 1 + maxValueWidth + 1)
            Console.Write("-")
        Next
        Console.WriteLine()
        For Each kv As DictionaryEntry In globalSettings
            Console.WriteLine(kv.Key.ToString().PadRight(maxSettingWidth) & ":" & kv.Value.ToString().PadRight(maxValueWidth) & "|")
        Next
        For i As Integer = 1 To (maxSettingWidth + 1 + maxValueWidth + 1)
            Console.Write("-")
        Next
        Console.WriteLine()
        Console.WriteLine()
    End Sub

    Sub LoadSettings()
        If IO.File.Exists("chocoproxy.cfg") Then

        Else
            globalSettings.Add("LogExclude", "")
            globalSettings.Add("BaseURL", "http://localhost:44111/")
            globalSettings.Add("ConsoleLogging", True)
        End If
    End Sub

End Module

