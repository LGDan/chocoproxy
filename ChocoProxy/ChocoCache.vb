Imports System.IO
Imports System.Text

Public Class ChocoCache

    Private _cache As New Hashtable
    Private _onDisk As Boolean
    Private _objectExpiry As TimeSpan
    Private _parentProxy As ChocoProxy
    Dim objCacheLocation As String
    Dim hashProvider As Security.Cryptography.SHA256 = Security.Cryptography.SHA256.Create()

    Sub New(parentProxy As ChocoProxy, expiry As TimeSpan, Optional onDisk As Boolean = False)
        _onDisk = onDisk
        _objectExpiry = expiry
        _parentProxy = parentProxy
        objCacheLocation = parentProxy.objCacheLocation
        If onDisk Then
            If Not IO.Directory.Exists(objCacheLocation) Then
                IO.Directory.CreateDirectory(objCacheLocation)
            End If

        End If
    End Sub

#Region "Advanced Cache"
    Function AdvancedCache(objectIdentifier As String, GetNewObject As Func(Of Object)) As Object
        Dim obj As Object = Nothing
        If GetFromAdvancedCache(objectIdentifier, obj) Then
            Return obj
        Else
            Dim co As New ChocoAdvancedCachedObject(GetNewObject, _objectExpiry)
            _cache.Add(objectIdentifier, co)
            Return co
        End If
    End Function
    Private Function GetFromAdvancedCache(objectIdentifier As String, ByRef obj As Object) As Boolean
        If _cache.ContainsKey(objectIdentifier) Then
            Dim co As ChocoAdvancedCachedObject = _cache(objectIdentifier)
            If Not co.IsValid() Then
                co.Refresh()
            End If
            obj = co
            Return True
        Else
            Return False
        End If
    End Function
    Class ChocoAdvancedCachedObject

        Dim cacheTime As DateTime
        Dim Expiry As TimeSpan
        Dim getNewObject As Func(Of Object)
        Dim obj As Object
        Dim lastAccessed As DateTime

        Function IsValid() As Boolean
            Return (cacheTime.Add(Expiry) > Now)
        End Function

        Function Refresh() As Boolean
            Try
                obj = getNewObject.Invoke()
                cacheTime = Now()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Sub New(GetNewObject As Func(Of Object), Expiry As TimeSpan)
            Me.Expiry = Expiry
        End Sub

        Function GetObject() As Object
            lastAccessed = Now()
            Return obj
        End Function


    End Class
#End Region

#Region "Simple Cache"
    Function GetFromSimpleCache(objectIdentifier As String) As Object
        objectIdentifier = S256(objectIdentifier)
        If _cache.ContainsKey(objectIdentifier) Then
            Dim co As ChocoSimpleCachedObject = _cache(objectIdentifier)
            If co.IsValid() Then
                LogText("Cache HIT " & objectIdentifier)
                Return co.GetObject()
            Else
                _cache.Remove(objectIdentifier)
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
    Function AddToSimpleCache(objectIdentifier As String, obj As Object)
        objectIdentifier = S256(objectIdentifier)
        If _cache.ContainsKey(objectIdentifier) Then
            Return False
        Else
            Dim co As New ChocoSimpleCachedObject(obj, _objectExpiry)
            LogText("Cached " & objectIdentifier)
            _cache.Add(objectIdentifier, co)
            Return True
        End If
    End Function
    Function SimpleCheckCache(objectIdentifier As String) As Boolean
        objectIdentifier = S256(objectIdentifier)
        If _cache.ContainsKey(objectIdentifier) Then
            Dim co As ChocoSimpleCachedObject = _cache(objectIdentifier)
            If Not co.IsValid Then
                LogText("Cache MISS (Expired) " & objectIdentifier)
                _cache.Remove(objectIdentifier)
                Return False
            Else
                Return True
            End If
        Else
            LogText("Cache MISS (NULL)" & objectIdentifier)
            Return False
        End If
    End Function
    Class ChocoSimpleCachedObject

        Dim cacheTime As DateTime
        Dim Expiry As TimeSpan
        Private obj As Object
        Dim lastAccessed As DateTime
        Dim hits As Long

        Function IsValid() As Boolean
            Return (cacheTime.Add(Expiry) < Now)
        End Function

        Sub New(obj As Object, Expiry As TimeSpan)
            Me.obj = obj
            Me.Expiry = Expiry
        End Sub

        Function GetObject() As Object
            lastAccessed = Now()
            hits += 1
            Return obj
        End Function

    End Class
#End Region

    Function S256(input) As String
        Dim hash() As Byte = hashProvider.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(input))
        Dim sb As New StringBuilder
        For Each b As Byte In hash
            sb.Append(Hex(b).PadLeft(2, "0"))
        Next
        Return sb.ToString().ToLower()
    End Function

    Function CachedItemToDisk(kv)

    End Function

    Function DiskToCachedItem(k)

    End Function

End Class
