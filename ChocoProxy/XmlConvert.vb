Imports System.IO
Imports System.Xml.Serialization

Module XmlConvert
    Function SerializeObject(Of T)(ByVal dataObject As T) As String
        If dataObject Is Nothing Then
            Return String.Empty
        End If

        Try

            Using stringWriter As StringWriter = New System.IO.StringWriter()
                Dim serializer = New XmlSerializer(GetType(T))
                serializer.Serialize(stringWriter, dataObject)
                Return stringWriter.ToString()
            End Using

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Function DeserializeObject(Of T As New)(ByVal xml As String) As T
        If String.IsNullOrEmpty(xml) Then
            Return New T()
        End If

        Try

            Using stringReader = New StringReader(xml)
                Dim serializer = New XmlSerializer(GetType(T))
                Return CType(serializer.Deserialize(stringReader), T)
            End Using

        Catch ex As Exception
            Return New T()
        End Try
    End Function
End Module