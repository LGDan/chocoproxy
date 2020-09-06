Imports System.Net

Public Class API

    Private _parentWebServer As WebServer
    Public Property ParentWebServer() As WebServer
        Get
            Return _parentWebServer
        End Get
        Set(ByVal value As WebServer)
            _parentWebServer = value
        End Set
    End Property

    Private _parentChocoProxy As ChocoProxy
    Public Property ParentChocoProxy() As ChocoProxy
        Get
            Return _parentChocoProxy
        End Get
        Set(ByVal value As ChocoProxy)
            _parentChocoProxy = value
        End Set
    End Property

    Sub New(ws As WebServer, cp As ChocoProxy)
        ParentWebServer = ws
        ParentChocoProxy = cp
        ws.AddRoute("^/cpapi", AddressOf WebToAPIInvoke)
    End Sub

    Function WebToAPIInvoke(ctx As HttpListenerContext)
        Try
            Dim areaName As String = ctx.Request.Url.Segments(2).Trim("/")
            Dim methodName As String = ctx.Request.Url.Segments(3).Trim("/")
            Dim params As Hashtable = QueryParameterParser(ctx.Request.Url.Query)

            Using sw As New IO.StreamWriter(ctx.Response.OutputStream)
                sw.WriteLine(ApiMethodExecutor(areaName, methodName, params))
            End Using
        Catch ex As Exception

        End Try


    End Function

    Function ApiMethodExecutor(areaName As String, methodName As String, params As Hashtable) As String
        Dim Type = GetType(API)
        Dim methods = Type.GetMethods().Where(Function(t) t.Name.StartsWith("API_" & areaName & "_" & methodName))
        For Each m In methods
            Dim mParams() As Reflection.ParameterInfo = m.GetParameters()
            Dim allParamsSatisfied As Boolean = True
            For Each p As Reflection.ParameterInfo In mParams
                If Not params.ContainsKey(p.Name) Then
                    allParamsSatisfied = False
                End If
            Next
            If allParamsSatisfied Then
                Dim paramList As New List(Of Object)
                For Each p As Reflection.ParameterInfo In mParams
                    paramList.Add(params(p.Name))
                Next
                Return m.Invoke(Me, paramList.ToArray())
            End If
        Next
    End Function

    Function QueryParameterParser(queryString As String) As Hashtable
        Dim rawString As String = queryString.Substring(1)
        Dim kvPairs() As String = rawString.Split("&")
        Dim ht As New Hashtable
        For Each kv In kvPairs
            ht.Add(System.Web.HttpUtility.UrlDecode(kv.Split("=")(0)), System.Web.HttpUtility.UrlDecode(kv.Split("=")(1)))
        Next
        Return ht
    End Function

    <HelpMessage(HelpMessage:="Thing")>
    Function API_sccm_powershell(packageName As String) As String
        Dim pkgFeed As Packages.feed = ParentChocoProxy.OfficialPackageMetadataGet(packageName)

        Dim applicationPS As String = "
New-CMApplication `
    -Name ""Choco-" & pkgFeed.entry.properties.Title & """ `
    -Description """ & pkgFeed.entry.summary.Value & """ `
    -Publisher """ & pkgFeed.entry.author.name & """ `
    -SoftwareVersion """ & pkgFeed.entry.properties.Version & """ `
    -OptionalReference ""Reference"" `
    -ReleaseDate """ & pkgFeed.updated & """ `
    -AutoInstall $True `
    -Owner ""Administrator"" `
    -SupportContact ""Administrator"" `
    -LocalizedName """ & pkgFeed.entry.properties.Title & """ `
    -UserDocumentation """ & pkgFeed.entry.properties.ProjectUrl & """ `
    -LinkText ""For more information, see https://contoso.com/content"" `
    -LocalizedDescription """ & pkgFeed.entry.summary.Value & """ `
    -Keyword """ & pkgFeed.entry.properties.Tags.Value & """ `
    -PrivacyUrl ""https://contoso.com/library/privacy"" `
    -IsFeatured $False `
    -IconLocationFile ""C:\Users\administrator\Desktop\icon.png"" `
    -DisplaySupersedenceInApplicationCatalog $True
"
        Dim deploymentTypePS As String = "
Set-CMDeploymentType `
   [-AdministratorComment ""This deployment was created automatically with ChocoProxy.""] `
   [-EnableBranchCache <Boolean>] `
   [-EnableContentLocationFallback <Boolean>] `
   -ApplicationName ""Choco-" & pkgFeed.entry.properties.Title & """ `
   [-ContentLocation <String>] `
   -DeploymentTypeName <String> `
   [-DetectDeploymentTypeByCustomScript] `
   [-EstimatedInstallationTimeMins <Int32>] `
   [-InstallationBehaviorType <InstallationBehaviorType>] `
   [-InstallationProgram <String>] `
   [-InstallationProgramVisibility <UserInteractionMode>] `
   [-InstallationStartIn <String>] `
   [-Language <String[]>] `
   [-LogonRequirementType <LogonRequirementType>] `
   [-MaximumAllowedRunTimeMins <Int32>] `
   [-MsiOrScriptInstaller] `
   [-NewDeploymentTypeName <String>] `
   [-OnSlowNetworkMode <ContentHandlingMode>] `
   [-PersistContentInClientCache <Boolean>] `
   [-ProductCode <String>] `
   [-RebootBehavior <RebootBehavior>] `
   [-RequireUserInteraction <Boolean>] `
   [-Force32BitInstaller <Boolean>] `
   [-Force32BitDetectionScript <Boolean>] `
   [-ScriptContent <String>] `
   [-ScriptType <ScriptLanguage>] `
   [-UninstallProgram <String>] `
   [-UninstallStartIn <String>] `
   [-AddRequirement <Rule[]>] `
   [-RemoveRequirement <Rule[]>] `
   [-ClearRequirements] `
   [-SourceUpdateProductCode <String>] `
   [-PassThru] `
   [-DisableWildcardHandling] `
   [-ForceWildcardHandling] `
   [-WhatIf] `
   [-Confirm] `
   [<CommonParameters>] `
"

        Dim deploymentPS As String = "
Set-CMApplicationDeployment `
   -ApplicationName ""Choco-" & packageName & """ `
   -Comment $null `
   -RequireApproval $False `
   -PreDeploy $False `
   -SendWakeUpPacket $False `
   -UseMeteredNetwork $False `
   #[-TimeBaseOn <TimeType>]
   #[-AvailableDateTime <DateTime>]
   #[-DeadlineDateTime <DateTime>]
   #[-UserNotification <UserNotificationType>]
   #[-OverrideServiceWindow <Boolean>]
   #[-RebootOutsideServiceWindow <Boolean>]
   #[-PersistOnWriteFilterDevice <Boolean>]
   #[-CreateAlertBaseOnPercentSuccess <Boolean>]
   #[-SuccessParameterValue <Int32>]
   #[-PostponeDateTime <DateTime>]
   #[-CreateAlertBaseOnPercentFailure <Boolean>]
   #[-FailParameterValue <Int32>]
   #[-EnableMomAlert <Boolean>]
   #[-RaiseMomAlertsOnFailure <Boolean>]
   #[-EnableSoftDeadline <Boolean>]
   #[-ReplaceToastNotificationWithDialog <Boolean>]
   #[-AllowRepairApp <Boolean>]
   #[-PassThru]
   [-CollectionName <String>]
   [-CollectionId <String>]
   [-Collection <IResultObject>]
   [-DisableWildcardHandling]
   [-ForceWildcardHandling]
   [-WhatIf]
   [-Confirm]
   [<CommonParameters>]
"


        Return applicationPS & vbCrLf & deploymentTypePS & vbCrLf & deploymentPS
    End Function

End Class


<AttributeUsage(AttributeTargets.Method)>
Public Class HelpMessageAttribute
    Inherits Attribute
    Private _message As String
    Public Property HelpMessage() As String
        Get
            Return _message
        End Get
        Set(ByVal value As String)
            _message = value
        End Set
    End Property
End Class