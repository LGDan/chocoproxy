Imports System.IO

Public Class Settings
    Public ExcludeFromLog As String = ""
    Public BaseURL As String = "http://localhost:44111/"
    Public ConsoleLogging As Boolean = True
    Public DisplayLogo As Boolean = True
    Public DisplaySettings As Boolean = True
    Public PackageCacheLocation As String = Directory.GetCurrentDirectory() & "/cache/pkg"
    Public ObjectCacheLocation As String = Directory.GetCurrentDirectory() & "/cache/obj"
    Public CacheTime As TimeSpan = TimeSpan.FromHours(24)
End Class
