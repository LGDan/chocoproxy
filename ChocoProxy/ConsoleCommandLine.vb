Public Class ConsoleCommandLine

    Private _ParentAPI As API
    Public Property ParentAPI() As API
        Get
            Return _ParentAPI
        End Get
        Set(ByVal value As API)
            _ParentAPI = value
        End Set
    End Property
    Sub New(a As API)
        ParentAPI = a
    End Sub

    Function MenuHandler(input As String) As String
        Try
            Dim areaName As String = input.Split(" ")(0)
            Dim methodName As String = input.Split(" ")(1)
            'Dim params As New Hashtable = 
        Catch ex As Exception

        End Try
    End Function
    Public Class ConsoleCommand
        Sub New(command As String, arguments As List(Of ConsoleCommandArgument), help As String)

        End Sub
    End Class
    Public Class ConsoleCommandArgument
        Sub New(name As String, typeRestriction As Type, help As String)

        End Sub
    End Class
End Class
