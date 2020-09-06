Imports System
Imports System.IO

Module Program

    Dim MainSettings As Settings
    Dim ws As WebServer
    Dim cp As ChocoProxy
    Dim a As API
    Dim ccl As ConsoleCommandLine


    ''' <summary>
    ''' Initialise all components and start the server.
    ''' </summary>
    ''' <param name="args">Not Implemented (yet)</param>
    Sub Main(args As String())
        LoadSettings()
        Logo()
        DisplaySettings()

        ws = New WebServer(MainSettings.BaseURL)
        cp = New ChocoProxy(ws, MainSettings.CacheTime, MainSettings.PackageCacheLocation, MainSettings.ObjectCacheLocation)
        a = New API(ws, cp)
        ccl = New ConsoleCommandLine(a)

        ws.StartServer()
    End Sub

    ''' <summary>
    ''' Main logging function. Prefixes log lines with date and the name of the calling method for easier tracing/debugging.
    ''' </summary>
    ''' <param name="text">Message to log.</param>
    Sub LogText(text As String)
        If MainSettings.ConsoleLogging Then
            Dim st As New StackTrace
            Dim callerName As String = st.GetFrame(1).GetMethod().Name
            If Not MainSettings.ExcludeFromLog.Contains(callerName) Then
                Console.WriteLine(Format(Now(), "[HH:mm:ss] ") & "[" & callerName & "] " & text)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Display the ASCII logo to the console.
    ''' </summary>
    Sub Logo()
        If Not MainSettings.ConsoleLogging Then Exit Sub
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

    ''' <summary>
    ''' Output the current application settings to a table in the console.
    ''' </summary>
    Sub DisplaySettings()
        If Not MainSettings.DisplaySettings Then Exit Sub
        Dim maxSettingWidth As Integer = 7
        Dim maxValueWidth As Integer = 5
        For Each f In GetType(Settings).GetFields()
            If f.Name.Length > maxSettingWidth Then maxSettingWidth = f.Name.Length
            If f.GetValue(MainSettings).ToString.Length > maxValueWidth Then maxValueWidth = f.GetValue(MainSettings).ToString.Length
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
        For Each f In GetType(Settings).GetFields()
            Console.WriteLine(f.Name.PadRight(maxSettingWidth) & ":" & f.GetValue(MainSettings).ToString().PadRight(maxValueWidth) & "|")
        Next
        For i As Integer = 1 To (maxSettingWidth + 1 + maxValueWidth + 1)
            Console.Write("-")
        Next
        Console.WriteLine()
        Console.WriteLine()
    End Sub

    ''' <summary>
    ''' Load application settings from config.xml, and create it with defaults if it does not exist.
    ''' </summary>
    Sub LoadSettings()
        Dim x As New Xml.Serialization.XmlSerializer(GetType(Settings))
        If Not IO.File.Exists("config.xml") Then
            Using f As New FileStream("config.xml", FileMode.Create)
                x.Serialize(f, New Settings)
            End Using
        End If
        Using f As New FileStream("config.xml", FileMode.Open)
            MainSettings = x.Deserialize(f)
        End Using
    End Sub

End Module

