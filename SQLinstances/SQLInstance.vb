Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace SQLInstances

    Public Class InstanceDetails
        Private instanceID As Integer
        Private instance_servername As String
        Private instance_name As String
        Private dbproductname As String
        Private versionnumber As String
        Private dbproductservicepack As String
        Private dbproductedition As String
        Private dbproductarchitecture As String
        Private dbproductclustered As Boolean
        Private dbproductlanguage As String
        Private dbproductcollation As String
        Private dbservicemode As String
        Private dbservicestate As String
        Private dbservicemonitored As Boolean
        Private dbproductnotes As String
        Private dbdatalocation As String
        Private dbloglocation As String
        Private dbbackupslocation As String
        Private dbreplication As Boolean
        Private dbbackupedbysdodb As Boolean
        Private sdobackupteaminfo As Boolean
        Private installeddate As DateTime
        Private installedby As String
        Private removeddate As System.Nullable(Of DateTime)
        Private removedby As String
        Private recordchanged As DateTime
        Private recordchangedby As String
        Private netapp As Boolean
        Private netapp_primary_storage As String
        Private netapp_secondary_storage As String
        Private sql_licensed As Boolean
        Private sql_ticketnumber As String
        Private sql_requestor As String
        Private sql_appowner As String
        Private sql_appgroup As String
        Private sql_contact As String
        Private sql_dnsalias As String
        Private sql_windows_cluster_name As String
        Private sql_licensetype As String
        Private sql_license_qty As Integer
        Private sql_license_coverage As String




        Public Property SQLInstanceID() As Integer
            Get
                Return instanceID
            End Get
            Set(value As Integer)
                instanceID = value
            End Set
        End Property

        Public Property SQLInstance_ServerName() As String
            Get
                Return instance_servername
            End Get
            Set(value As String)
                instance_servername = value
            End Set
        End Property

        Public Property SQLInstance_Name() As String
            Get
                Return instance_name
            End Get
            Set(value As String)
                instance_name = value
            End Set
        End Property

        Public Property SQLProductName() As String
            Get
                Return dbproductname
            End Get
            Set(value As String)
                dbproductname = value
            End Set
        End Property

        Public Property SQLBuildNumber() As String
            Get
                Return versionnumber
            End Get
            Set(value As String)
                versionnumber = value
            End Set
        End Property

        Public Property SQLProductServicePack() As String
            Get
                Return dbproductservicepack
            End Get
            Set(value As String)
                dbproductservicepack = value
            End Set
        End Property


        Public Property SQLProductEdition() As String
            Get
                Return dbproductedition
            End Get
            Set(value As String)
                dbproductedition = value
            End Set
        End Property


        Public Property SQLProductArchitecture() As String
            Get
                Return dbproductarchitecture
            End Get
            Set(value As String)
                dbproductarchitecture = value
            End Set
        End Property


        Public Property SQLClustered() As Boolean
            Get
                Return dbproductclustered
            End Get
            Set(value As Boolean)
                dbproductclustered = value
            End Set
        End Property


        Public Property SQLProductLanguage() As String
            Get
                Return dbproductlanguage
            End Get
            Set(value As String)
                dbproductlanguage = value
            End Set
        End Property

        Public Property SQLProductCollation() As String
            Get
                Return dbproductcollation
            End Get
            Set(value As String)
                dbproductcollation = value
            End Set
        End Property

        Public Property SQLServerServiceMode() As String
            Get
                Return dbservicemode
            End Get
            Set(value As String)
                dbservicemode = value
            End Set
        End Property

        Public Property SQLServerServiceState() As String
            Get
                Return dbservicestate
            End Get
            Set(value As String)
                dbservicestate = value
            End Set
        End Property

        Public Property SQLServerMonitored() As Boolean
            Get
                Return dbservicemonitored
            End Get
            Set(value As Boolean)
                dbservicemonitored = value
            End Set
        End Property

        Public Property SQLServerNotes() As String
            Get
                Return dbproductnotes
            End Get
            Set(value As String)
                dbproductnotes = value
            End Set
        End Property

        Public Property SQLDataLocationPath() As String
            Get
                Return dbdatalocation
            End Get
            Set(value As String)
                dbdatalocation = value
            End Set
        End Property

        Public Property SQLLogsLocationPath() As String
            Get
                Return dbloglocation
            End Get
            Set(value As String)
                dbloglocation = value
            End Set
        End Property

        Public Property SQLServerBackupPath() As String
            Get
                Return dbbackupslocation
            End Get
            Set(value As String)
                dbbackupslocation = value
            End Set
        End Property

        Public Property SQLServerReplicated() As Boolean
            Get
                Return dbreplication
            End Get
            Set(value As Boolean)
                dbreplication = value
            End Set
        End Property


        Public Property SQLServerBackedUpBySDODB() As Boolean
            Get
                Return dbbackupedbysdodb
            End Get
            Set(value As Boolean)
                dbbackupedbysdodb = value
            End Set
        End Property


        Public Property SQLBackupSDOBackup() As Boolean
            Get
                Return sdobackupteaminfo
            End Get
            Set(value As Boolean)
                sdobackupteaminfo = value
            End Set
        End Property


        Public Property SQLInstallationDate() As DateTime
            Get
                Return installeddate
            End Get
            Set(value As DateTime)
                installeddate = value
            End Set
        End Property


        Public Property SQLServerInstalledBy() As String
            Get
                Return installedby
            End Get
            Set(value As String)
                installedby = value
            End Set
        End Property

        Public Property SQLRemovedDate() As System.Nullable(Of DateTime)
            Get
                Return removeddate
            End Get
            Set(value As System.Nullable(Of DateTime))
                removeddate = value
            End Set
        End Property


        Public Property SQLRemovedBy() As String
            Get
                Return removedby
            End Get
            Set(value As String)
                removedby = value
            End Set
        End Property

        Public Property SQLRecordChanged() As DateTime
            Get
                Return recordchanged
            End Get
            Set(value As DateTime)
                recordchanged = value
            End Set
        End Property


        Public Property SQLRecordChangedBy() As String
            Get
                Return recordchangedby
            End Get
            Set(value As String)
                recordchangedby = value
            End Set
        End Property

        Public Property SQLNetAppStorage() As Boolean
            Get
                Return netapp
            End Get
            Set(value As Boolean)
                netapp = value
            End Set
        End Property


        Public Property SQLNetAppPrimaryStorage() As String
            Get
                Return netapp_primary_storage
            End Get
            Set(value As String)
                netapp_primary_storage = value
            End Set
        End Property


        Public Property SQLNetAppSecondaryStorage() As String
            Get
                Return netapp_secondary_storage
            End Get
            Set(value As String)
                netapp_secondary_storage = value
            End Set
        End Property


        Public Property SQLServerLicensed() As Boolean
            Get
                Return sql_licensed
            End Get
            Set(value As Boolean)
                sql_licensed = value
            End Set
        End Property

        Public Property SQLTicketNumber() As String
            Get
                Return sql_ticketnumber
            End Get
            Set(value As String)
                sql_ticketnumber = value
            End Set
        End Property


        Public Property SQLRequestor() As String
            Get
                Return sql_requestor
            End Get
            Set(value As String)
                sql_requestor = value
            End Set
        End Property

        Public Property SQLAppOwner() As String
            Get
                Return sql_appowner
            End Get
            Set(value As String)
                sql_appowner = value
            End Set
        End Property
        Public Property SQLAppGroup() As String
            Get
                Return sql_appgroup
            End Get
            Set(value As String)
                sql_appgroup = value
            End Set
        End Property

        Public Property SQLContact() As String
            Get
                Return sql_contact
            End Get
            Set(value As String)
                sql_contact = value
            End Set
        End Property

        Public Property SQLDNSAlias() As String
            Get
                Return sql_dnsalias
            End Get
            Set(value As String)
                sql_dnsalias = value
            End Set
        End Property


        Public Property SQLClusterName() As String
            Get
                Return sql_windows_cluster_name
            End Get
            Set(value As String)
                sql_windows_cluster_name = value
            End Set
        End Property

        Public Property SQLLicenseType() As String
            Get
                Return sql_licensetype
            End Get
            Set(value As String)
                sql_licensetype = value
            End Set
        End Property

        Public Property SQLLicenseQTY() As Integer
            Get
                Return sql_license_qty
            End Get
            Set(value As Integer)
                sql_license_qty = value
            End Set
        End Property

        Public Property SQLLicenseCoverage() As String
            Get
                Return sql_license_coverage
            End Get
            Set(value As String)
                sql_license_coverage = value
            End Set
        End Property

       


    End Class
End Namespace