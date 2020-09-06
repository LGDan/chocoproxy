Namespace Packages

    ' NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.w3.org/2005/Atom", IsNullable:=False)>
    Partial Public Class feed

        Private titleField As feedTitle

        Private idField As String

        Private updatedField As Date

        Private linkField As feedLink

        Private entryField As feedEntry

        Private baseField As String

        '''<remarks/>
        Public Property title() As feedTitle
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property updated() As Date
            Get
                Return Me.updatedField
            End Get
            Set
                Me.updatedField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property link() As feedLink
            Get
                Return Me.linkField
            End Get
            Set
                Me.linkField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property entry() As feedEntry
            Get
                Return Me.entryField
            End Get
            Set
                Me.entryField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://www.w3.org/XML/1998/namespace")>
        Public Property base() As String
            Get
                Return Me.baseField
            End Get
            Set
                Me.baseField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedTitle

        Private typeField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedLink

        Private relField As String

        Private titleField As String

        Private hrefField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property rel() As String
            Get
                Return Me.relField
            End Get
            Set
                Me.relField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property title() As String
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property href() As String
            Get
                Return Me.hrefField
            End Get
            Set
                Me.hrefField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedEntry

        Private idField As String

        Private titleField As feedEntryTitle

        Private summaryField As feedEntrySummary

        Private updatedField As Date

        Private authorField As feedEntryAuthor

        Private linkField() As feedEntryLink

        Private categoryField As feedEntryCategory

        Private contentField As feedEntryContent

        Private propertiesField As properties

        '''<remarks/>
        Public Property id() As String
            Get
                Return Me.idField
            End Get
            Set
                Me.idField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property title() As feedEntryTitle
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property summary() As feedEntrySummary
            Get
                Return Me.summaryField
            End Get
            Set
                Me.summaryField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property updated() As Date
            Get
                Return Me.updatedField
            End Get
            Set
                Me.updatedField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property author() As feedEntryAuthor
            Get
                Return Me.authorField
            End Get
            Set
                Me.authorField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute("link")>
        Public Property link() As feedEntryLink()
            Get
                Return Me.linkField
            End Get
            Set
                Me.linkField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property category() As feedEntryCategory
            Get
                Return Me.categoryField
            End Get
            Set
                Me.categoryField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property content() As feedEntryContent
            Get
                Return Me.contentField
            End Get
            Set
                Me.contentField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property properties() As properties
            Get
                Return Me.propertiesField
            End Get
            Set
                Me.propertiesField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedEntryTitle

        Private typeField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedEntrySummary

        Private typeField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedEntryAuthor

        Private nameField As String

        '''<remarks/>
        Public Property name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedEntryLink

        Private relField As String

        Private titleField As String

        Private hrefField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property rel() As String
            Get
                Return Me.relField
            End Get
            Set
                Me.relField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property title() As String
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property href() As String
            Get
                Return Me.hrefField
            End Get
            Set
                Me.hrefField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedEntryCategory

        Private termField As String

        Private schemeField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property term() As String
            Get
                Return Me.termField
            End Get
            Set
                Me.termField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property scheme() As String
            Get
                Return Me.schemeField
            End Get
            Set
                Me.schemeField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2005/Atom")>
    Partial Public Class feedEntryContent

        Private typeField As String

        Private srcField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property src() As String
            Get
                Return Me.srcField
            End Get
            Set
                Me.srcField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", IsNullable:=False)>
    Partial Public Class properties

        Private versionField As String

        Private titleField As String

        Private descriptionField As String

        Private tagsField As Tags

        Private copyrightField As Copyright

        Private createdField As Created

        Private dependenciesField As Object

        Private downloadCountField As DownloadCount

        Private versionDownloadCountField As VersionDownloadCount

        Private galleryDetailsUrlField As String

        Private reportAbuseUrlField As String

        Private iconUrlField As String

        Private isLatestVersionField As IsLatestVersion

        Private isAbsoluteLatestVersionField As IsAbsoluteLatestVersion

        Private isPrereleaseField As IsPrerelease

        Private languageField As Language

        Private publishedField As Published

        Private licenseUrlField As String

        Private requireLicenseAcceptanceField As RequireLicenseAcceptance

        Private packageHashField As String

        Private packageHashAlgorithmField As String

        Private packageSizeField As PackageSize

        Private projectUrlField As String

        Private releaseNotesField As String

        Private projectSourceUrlField As String

        Private packageSourceUrlField As String

        Private docsUrlField As Object

        Private mailingListUrlField As Object

        Private bugTrackerUrlField As Object

        Private isApprovedField As IsApproved

        Private packageStatusField As String

        Private packageSubmittedStatusField As String

        Private packageTestResultUrlField As String

        Private packageTestResultStatusField As String

        Private packageTestResultStatusDateField As PackageTestResultStatusDate

        Private packageValidationResultStatusField As String

        Private packageValidationResultDateField As PackageValidationResultDate

        Private packageCleanupResultDateField As PackageCleanupResultDate

        Private packageReviewedDateField As PackageReviewedDate

        Private packageApprovedDateField As PackageApprovedDate

        Private packageReviewerField As PackageReviewer

        Private isDownloadCacheAvailableField As IsDownloadCacheAvailable

        Private downloadCacheStatusField As String

        Private downloadCacheDateField As DownloadCacheDate

        Private downloadCacheField As DownloadCache

        Private packageScanStatusField As String

        Private packageScanResultDateField As PackageScanResultDate

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Version() As String
            Get
                Return Me.versionField
            End Get
            Set
                Me.versionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Title() As String
            Get
                Return Me.titleField
            End Get
            Set
                Me.titleField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Tags() As Tags
            Get
                Return Me.tagsField
            End Get
            Set
                Me.tagsField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Copyright() As Copyright
            Get
                Return Me.copyrightField
            End Get
            Set
                Me.copyrightField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Created() As Created
            Get
                Return Me.createdField
            End Get
            Set
                Me.createdField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Dependencies() As Object
            Get
                Return Me.dependenciesField
            End Get
            Set
                Me.dependenciesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property DownloadCount() As DownloadCount
            Get
                Return Me.downloadCountField
            End Get
            Set
                Me.downloadCountField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property VersionDownloadCount() As VersionDownloadCount
            Get
                Return Me.versionDownloadCountField
            End Get
            Set
                Me.versionDownloadCountField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property GalleryDetailsUrl() As String
            Get
                Return Me.galleryDetailsUrlField
            End Get
            Set
                Me.galleryDetailsUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property ReportAbuseUrl() As String
            Get
                Return Me.reportAbuseUrlField
            End Get
            Set
                Me.reportAbuseUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property IconUrl() As String
            Get
                Return Me.iconUrlField
            End Get
            Set
                Me.iconUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property IsLatestVersion() As IsLatestVersion
            Get
                Return Me.isLatestVersionField
            End Get
            Set
                Me.isLatestVersionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property IsAbsoluteLatestVersion() As IsAbsoluteLatestVersion
            Get
                Return Me.isAbsoluteLatestVersionField
            End Get
            Set
                Me.isAbsoluteLatestVersionField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property IsPrerelease() As IsPrerelease
            Get
                Return Me.isPrereleaseField
            End Get
            Set
                Me.isPrereleaseField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Language() As Language
            Get
                Return Me.languageField
            End Get
            Set
                Me.languageField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property Published() As Published
            Get
                Return Me.publishedField
            End Get
            Set
                Me.publishedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property LicenseUrl() As String
            Get
                Return Me.licenseUrlField
            End Get
            Set
                Me.licenseUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property RequireLicenseAcceptance() As RequireLicenseAcceptance
            Get
                Return Me.requireLicenseAcceptanceField
            End Get
            Set
                Me.requireLicenseAcceptanceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageHash() As String
            Get
                Return Me.packageHashField
            End Get
            Set
                Me.packageHashField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageHashAlgorithm() As String
            Get
                Return Me.packageHashAlgorithmField
            End Get
            Set
                Me.packageHashAlgorithmField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageSize() As PackageSize
            Get
                Return Me.packageSizeField
            End Get
            Set
                Me.packageSizeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property ProjectUrl() As String
            Get
                Return Me.projectUrlField
            End Get
            Set
                Me.projectUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property ReleaseNotes() As String
            Get
                Return Me.releaseNotesField
            End Get
            Set
                Me.releaseNotesField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property ProjectSourceUrl() As String
            Get
                Return Me.projectSourceUrlField
            End Get
            Set
                Me.projectSourceUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageSourceUrl() As String
            Get
                Return Me.packageSourceUrlField
            End Get
            Set
                Me.packageSourceUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property DocsUrl() As Object
            Get
                Return Me.docsUrlField
            End Get
            Set
                Me.docsUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property MailingListUrl() As Object
            Get
                Return Me.mailingListUrlField
            End Get
            Set
                Me.mailingListUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property BugTrackerUrl() As Object
            Get
                Return Me.bugTrackerUrlField
            End Get
            Set
                Me.bugTrackerUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property IsApproved() As IsApproved
            Get
                Return Me.isApprovedField
            End Get
            Set
                Me.isApprovedField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageStatus() As String
            Get
                Return Me.packageStatusField
            End Get
            Set
                Me.packageStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageSubmittedStatus() As String
            Get
                Return Me.packageSubmittedStatusField
            End Get
            Set
                Me.packageSubmittedStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageTestResultUrl() As String
            Get
                Return Me.packageTestResultUrlField
            End Get
            Set
                Me.packageTestResultUrlField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageTestResultStatus() As String
            Get
                Return Me.packageTestResultStatusField
            End Get
            Set
                Me.packageTestResultStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageTestResultStatusDate() As PackageTestResultStatusDate
            Get
                Return Me.packageTestResultStatusDateField
            End Get
            Set
                Me.packageTestResultStatusDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageValidationResultStatus() As String
            Get
                Return Me.packageValidationResultStatusField
            End Get
            Set
                Me.packageValidationResultStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageValidationResultDate() As PackageValidationResultDate
            Get
                Return Me.packageValidationResultDateField
            End Get
            Set
                Me.packageValidationResultDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageCleanupResultDate() As PackageCleanupResultDate
            Get
                Return Me.packageCleanupResultDateField
            End Get
            Set
                Me.packageCleanupResultDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageReviewedDate() As PackageReviewedDate
            Get
                Return Me.packageReviewedDateField
            End Get
            Set
                Me.packageReviewedDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageApprovedDate() As PackageApprovedDate
            Get
                Return Me.packageApprovedDateField
            End Get
            Set
                Me.packageApprovedDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageReviewer() As PackageReviewer
            Get
                Return Me.packageReviewerField
            End Get
            Set
                Me.packageReviewerField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property IsDownloadCacheAvailable() As IsDownloadCacheAvailable
            Get
                Return Me.isDownloadCacheAvailableField
            End Get
            Set
                Me.isDownloadCacheAvailableField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property DownloadCacheStatus() As String
            Get
                Return Me.downloadCacheStatusField
            End Get
            Set
                Me.downloadCacheStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property DownloadCacheDate() As DownloadCacheDate
            Get
                Return Me.downloadCacheDateField
            End Get
            Set
                Me.downloadCacheDateField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property DownloadCache() As DownloadCache
            Get
                Return Me.downloadCacheField
            End Get
            Set
                Me.downloadCacheField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageScanStatus() As String
            Get
                Return Me.packageScanStatusField
            End Get
            Set
                Me.packageScanStatusField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices")>
        Public Property PackageScanResultDate() As PackageScanResultDate
            Get
                Return Me.packageScanResultDateField
            End Get
            Set
                Me.packageScanResultDateField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class Tags

        Private spaceField As String

        Private valueField As String

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://www.w3.org/XML/1998/namespace")>
        Public Property space() As String
            Get
                Return Me.spaceField
            End Get
            Set
                Me.spaceField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class Copyright

        Private nullField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property null() As Boolean
            Get
                Return Me.nullField
            End Get
            Set
                Me.nullField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class Created

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class DownloadCount

        Private typeField As String

        Private valueField As UInteger

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As UInteger
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class VersionDownloadCount

        Private typeField As String

        Private valueField As UInteger

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As UInteger
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class IsLatestVersion

        Private typeField As String

        Private valueField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Boolean
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class IsAbsoluteLatestVersion

        Private typeField As String

        Private valueField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Boolean
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class IsPrerelease

        Private typeField As String

        Private valueField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Boolean
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class Language

        Private nullField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property null() As Boolean
            Get
                Return Me.nullField
            End Get
            Set
                Me.nullField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class Published

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class RequireLicenseAcceptance

        Private typeField As String

        Private valueField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Boolean
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageSize

        Private typeField As String

        Private valueField As UInteger

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As UInteger
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class IsApproved

        Private typeField As String

        Private valueField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Boolean
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageTestResultStatusDate

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageValidationResultDate

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageCleanupResultDate

        Private typeField As String

        Private nullField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property null() As Boolean
            Get
                Return Me.nullField
            End Get
            Set
                Me.nullField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageReviewedDate

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageApprovedDate

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageReviewer

        Private nullField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property null() As Boolean
            Get
                Return Me.nullField
            End Get
            Set
                Me.nullField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class IsDownloadCacheAvailable

        Private typeField As String

        Private valueField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Boolean
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class DownloadCacheDate

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class DownloadCache

        Private nullField As Boolean

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property null() As Boolean
            Get
                Return Me.nullField
            End Get
            Set
                Me.nullField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable:=False)>
    Partial Public Class PackageScanResultDate

        Private typeField As String

        Private valueField As Date

        '''<remarks/>
        <System.Xml.Serialization.XmlAttributeAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Qualified, [Namespace]:="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")>
        Public Property type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlTextAttribute()>
        Public Property Value() As Date
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class


End Namespace