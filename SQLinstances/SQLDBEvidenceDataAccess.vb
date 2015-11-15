Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Threading.Tasks
Imports System.Net.Sockets
Namespace SQLInstances
    Public Class SQLDBEvidenceDataAccess
        Public Property ConnectionString() As String
        Public Property conn() As SqlConnection
        Public Property LastError() As String
        Public Delegate Sub SqlInfoMessageEventHandler(Message As String)
        Public Event SQLInfoMessage As SqlInfoMessageEventHandler
        Public Delegate Sub SQLStateChangeHandler(State As System.Data.ConnectionState)
        Public Event SQLStateChanged As SQLStateChangeHandler
        'Friend Function Connect() As Boolean
        '    Dim tConnectAsync As New Task(Function() ConnectAsync())
        '    tConnectAsync.Start()
        '    Return True
        'End Function
        'Private Sub ConnectAsync()
        '    If Not String.IsNullOrWhiteSpace(ConnectionString) Then
        '        conn = New SqlConnection(ConnectionString)
        '        conn.Open()
        '        'conn.InfoMessage += conn_InfoMessage()
        '        'conn.StateChange += conn_StateChange()
        '        Select Case conn.State
        '            Case System.Data.ConnectionState.Broken
        '                RaiseEvent SQLStateChanged(conn.State)
        '                Exit Select
        '            Case System.Data.ConnectionState.Closed
        '                RaiseEvent SQLStateChanged(conn.State)
        '                Exit Select
        '            Case System.Data.ConnectionState.Connecting
        '                RaiseEvent SQLStateChanged(conn.State)
        '                Exit Select
        '            Case System.Data.ConnectionState.Executing
        '                RaiseEvent SQLStateChanged(conn.State)
        '                Exit Select
        '            Case System.Data.ConnectionState.Fetching
        '                RaiseEvent SQLStateChanged(conn.State)
        '                Exit Select
        '            Case System.Data.ConnectionState.Open
        '                RaiseEvent SQLStateChanged(conn.State)
        '                Exit Select
        '            Case Else
        '                RaiseEvent SQLStateChanged(conn.State)
        '                Exit Select
        '        End Select
        '    End If
        'End Sub
        Sub conn_StateChange(sender As Object, e As System.Data.StateChangeEventArgs)
            RaiseEvent SQLStateChanged(e.CurrentState)
        End Sub
        Sub conn_InfoMessage(sender As Object, e As SqlInfoMessageEventArgs)
            RaiseEvent SQLInfoMessage(e.Message)
        End Sub
        Public Function SelectSQLInstances() As DataSet

            Dim queryString As String = "SELECT * FROM [SDODB_ServerEvidence].[dbo].[SDODB_Instances] ORDER BY [INSTANCE_SERVERNAME], [INSTANCENAME]"
            Dim cmd As New SqlCommand(queryString, conn)
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            Try
                sda.Fill(ds)
                cmd.ExecuteNonQuery()
                Return ds
            Catch ex As InvalidOperationException
                Me.LastError = ex.Message
            Catch ex As Exception
                Me.LastError = ex.Message
            Finally
                sda.Dispose()
                cmd.Dispose()
            End Try
            Return Nothing
        End Function
        Public Function SelectSingleRecord(SQLInfo As InstanceDetails) As DataRow
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
            con.Open()
            Dim cmd As New SqlCommand("SELECT * FROM [SDODB_ServerEvidence].[dbo].[SDODB_Instances] WHERE [ID] = @SQLInstanceID", con)
            cmd.Parameters.AddWithValue("@SQLInstanceID", SqlDbType.Int).Value = If(DirectCast(SQLInfo.SQLInstanceID, Object), 0)
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            sda.Fill(ds)
            cmd.ExecuteNonQuery()
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    Return row
                Next
            End If
            con.Close()
            Return Nothing
        End Function
        Public Function SearchSQLInstance(SQLInfo As InstanceDetails) As DataSet
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
            con.Open()
            Dim cmd As New SqlCommand("SELECT * FROM [SDODB_ServerEvidence].[dbo].[SDODB_Instances] WHERE [INSTANCE_SERVERNAME] LIKE @SQLInstance_ServerName ORDER BY [INSTANCE_SERVERNAME], [INSTANCENAME]", con)
            cmd.Parameters.AddWithValue("@SQLInstance_ServerName", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLInstance_ServerName, Object), "%")
            Dim sda As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            sda.Fill(ds)
            cmd.ExecuteNonQuery()
            con.Close()
            Return ds
        End Function
        Public Function UpdateSQLInstanceTable(SQLInfo As InstanceDetails) As String
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim Message As String
            Try
                Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
                con.Open()
                Dim cmd As New SqlCommand("UPDATE [SDODB_ServerEvidence].[dbo].[SDODB_Instances] SET [INSTANCE_SERVERNAME] = @SQLInstance_ServerName,[INSTANCENAME] = @SQLInstance_Name,[DBPRODUCTNAME] = @SQLProductName,[VERSIONNUMBER] = @SQLBuildNumber,[DBPRODUCTSERVICEPACK] = @SQLProductServicePack,[DBPRODUCTEDITION] = @SQLProductEdition,[DBPRODUCTARCHITECTURE] = @SQLProductArchitecture,[DBPRODUCTCLUSTERED] = @SQLClustered,[DBPRUDUCTLANGUAGE] = @SQLProductLanguage,[DBPRODUCTCOLLATION] = @SQLProductCollation,[DBSERVICEMODE] = @SQLServerServiceMode,[DBSERVICESTATE] = @SQLServerServiceState,[DBSERVICEMOMMONITORED] = @SQLServerMonitored,[DBPRODUCTNOTES] = @SQLServerNotes,[DBDATALOCATION] = @SQLDataLocationPath,[DBLOGLOCATION] = @SQLLogsLocationPath,[DBBACKUPSLOCATION] = @SQLServerBackupPath,[DBREPLICATION] = @SQLServerReplicated,[DBBACKUPEDBYSDODB] = @SQLServerBackedUpBySDODB,[SDOBACKUPTEAMINFO] = @SQLBackupSDOBackup,[INSTALLEDDATE] = @SQLInstallationDate,[INSTALLEDBY] = @SQLServerInstalledBy,[REMOVEDDATE] = @SQLRemovedDate,[REMOVEDBY] = @SQLRemovedBy,[RECORDCHANGED] = @SQLRecordChanged,[RECORDCHANGEDBY] = @SQLRecordChangedBy,[NETAPP] = @SQLNetAppStorage,[NETAPP_PRIMARY_STORAGE] = @SQLNetAppPrimaryStorage,[NETAPP_SECONDARY_STORAGE] = @SQLNetAppSecondaryStorage,[SQL_LICENSED] = @SQLServerLicensed, [TICKET_NUMBER] = @SQLTicketNumber, [REQUESTOR] = @SQLRequestor, [APP_OWNER] = @SQLAppOwner, [APP_GROUP] = @SQLAppGroup,[CONTACT_PERSON] = @SQLContactPerson, [DNS_ALIAS] = @SQLDNSAlias, [SQL_CLUSTER_NETWORK_NAME] = @SQLWindowsClusterName, [SQL_LICENSETYPE] = @SQLLicenseType, [SQL_LICENSEQTY_CALS] = @SQLLicenseQTY, [SQL_LICENSECOVERAGE] = @SQLLicenseCoverage WHERE [ID]   = @SQLInstanceID", con)
                cmd.Parameters.AddWithValue("@SQLInstanceID", SQLInfo.SQLInstanceID)
                cmd.Parameters.AddWithValue("@SQLInstance_ServerName", SQLInfo.SQLInstance_ServerName)
                cmd.Parameters.AddWithValue("@SQLInstance_Name", SQLInfo.SQLInstance_Name)
                cmd.Parameters.AddWithValue("@SQLProductName", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLProductName, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLBuildNumber", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLBuildNumber, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLProductServicePack", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLProductServicePack, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLProductEdition", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLProductEdition, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLProductArchitecture", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLProductArchitecture, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLClustered", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SQLClustered, Object), False)
                cmd.Parameters.AddWithValue("@SQLProductLanguage", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLProductLanguage, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLProductCollation", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLProductCollation, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLServerServiceMode", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLServerServiceMode, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLServerServiceState", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLServerServiceState, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLServerMonitored", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SQLServerMonitored, Object), False)
                cmd.Parameters.AddWithValue("@SQLServerNotes", SqlDbType.Text).Value = If(DirectCast(SQLInfo.SQLServerNotes, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLDataLocationPath", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLDataLocationPath, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLLogsLocationPath", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLLogsLocationPath, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLServerBackupPath", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLServerBackupPath, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLServerReplicated", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SQLServerReplicated, Object), False)
                cmd.Parameters.AddWithValue("@SQLServerBackedUpBySDODB", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SQLServerBackedUpBySDODB, Object), False)
                cmd.Parameters.AddWithValue("@SQLBackupSDOBackup", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SQLBackupSDOBackup, Object), False)
                cmd.Parameters.AddWithValue("@SQLInstallationDate", SqlDbType.DateTime).Value = If(DirectCast(SQLInfo.SQLInstallationDate, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLServerInstalledBy", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLServerInstalledBy, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLRemovedDate", SqlDbType.DateTime).Value = If(DirectCast(SQLInfo.SQLRemovedDate, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLRemovedBy", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLRemovedBy, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLRecordChanged", SqlDbType.DateTime).Value = If(DirectCast(SQLInfo.SQLRecordChanged, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLRecordChangedBy", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLRecordChangedBy, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLNetAppStorage", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SQLNetAppStorage, Object), False)
                cmd.Parameters.AddWithValue("@SQLNetAppPrimaryStorage", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLNetAppPrimaryStorage, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLNetAppSecondaryStorage", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLNetAppSecondaryStorage, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLServerLicensed", SqlDbType.Bit).Value = If(DirectCast(SQLInfo.SQLServerLicensed, Object), False)
                cmd.Parameters.AddWithValue("@SQLTicketNumber", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLTicketNumber, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLRequestor", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLRequestor, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLAppOwner", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLAppOwner, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLAppGroup", SqlDbType.VarChar).Value = If(DirectCast(SQLInfo.SQLAppGroup, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLContactPerson", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLContact, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLDNSAlias", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLDNSAlias, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLWindowsClusterName", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLClusterName, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLLicenseType", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLLicenseType, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLLicenseQTY", SqlDbType.Int).Value = If(DirectCast(SQLInfo.SQLLicenseQTY, Object), DBNull.Value)
                cmd.Parameters.AddWithValue("@SQLLicenseCoverage", SqlDbType.NVarChar).Value = If(DirectCast(SQLInfo.SQLLicenseCoverage, Object), DBNull.Value)
                cmd.ExecuteNonQuery()
                con.Close()
                'Message = "Successfully Updated!"
                'Return Message
                MessageBox.Show("record inserted Successfully", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                'Return ex.Message.ToString()
                MsgBox("ERROR" & vbLf & ex.Message)
            Catch ex As Exception
                'Return ex.Message.ToString()
                MsgBox("ERROR" & vbLf & ex.Message)
            End Try
        End Function
        Public Function InsertSQLInstance(SQLInfo As InstanceDetails) As String
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            'Dim Message As String
            Try
                Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
                con.Open()
                Dim cmd As New SqlCommand("INSERT INTO [SDODB_ServerEvidence].[dbo].[SDODB_Instances] ([INSTANCE_SERVERNAME],[INSTANCENAME],[DBPRODUCTNAME],[VERSIONNUMBER],[DBPRODUCTSERVICEPACK],[DBPRODUCTEDITION],[DBPRODUCTARCHITECTURE],[DBPRODUCTCLUSTERED],[DBPRUDUCTLANGUAGE],[DBPRODUCTCOLLATION],[DBSERVICEMODE],[DBSERVICESTATE],[DBSERVICEMOMMONITORED],[DBPRODUCTNOTES],[DBDATALOCATION],[DBLOGLOCATION],[DBBACKUPSLOCATION],[DBREPLICATION],[DBBACKUPEDBYSDODB],[SDOBACKUPTEAMINFO],[INSTALLEDDATE],[INSTALLEDBY],[NETAPP],[NETAPP_PRIMARY_STORAGE],[NETAPP_SECONDARY_STORAGE],[SQL_LICENSED], [TICKET_NUMBER],[REQUESTOR], [APP_OWNER],[APP_GROUP],[CONTACT_PERSON],[DNS_ALIAS], [SQL_CLUSTER_NETWORK_NAME], [SQL_LICENSETYPE],[SQL_LICENSEQTY_CALS], [SQL_LICENSECOVERAGE]) VALUES (@SQLInstance_ServerName,@SQLInstance_Name,@SQLProductName,@SQLBuildNumber,@SQLProductServicePack,@SQLProductEdition,@SQLProductArchitecture,@SQLClustered,@SQLProductLanguage,@SQLProductCollation,@SQLServerServiceMode,@SQLServerServiceState,@SQLServerMonitored,@SQLServerNotes,@SQLDataLocationPath,@SQLLogsLocationPath,@SQLServerBackupPath,@SQLServerReplicated,@SQLServerBackedUpBySDODB,@SQLBackupSDOBackup,@SQLInstallationDate,@SQLServerInstalledBy,@SQLNetAppStorage,@SQLNetAppPrimaryStorage,@SQLNetAppSecondaryStorage,@SQLServerLicensed, @SQLTicketNumber, @SQLRequestor, @SQLAppOwner,@SQLAppGroup ,@SQLContactPerson, @SQLDNSAlias, @SQLWindowsClusterName, @SQLLicenseType, @SQLLicenseQTY, @SQLLicenseCoverage)", con)
                cmd.Parameters.AddWithValue("@SQLInstance_ServerName", SQLInfo.SQLInstance_ServerName)
                cmd.Parameters.AddWithValue("@SQLInstance_Name", SQLInfo.SQLInstance_Name)
                cmd.Parameters.AddWithValue("@SQLProductName", SQLInfo.SQLProductName)
                cmd.Parameters.AddWithValue("@SQLBuildNumber", SQLInfo.SQLBuildNumber)
                cmd.Parameters.AddWithValue("@SQLProductServicePack", SQLInfo.SQLProductServicePack)
                cmd.Parameters.AddWithValue("@SQLProductEdition", SQLInfo.SQLProductEdition)
                cmd.Parameters.AddWithValue("@SQLProductArchitecture", SQLInfo.SQLProductArchitecture)
                cmd.Parameters.AddWithValue("@SQLClustered", SQLInfo.SQLClustered)
                cmd.Parameters.AddWithValue("@SQLProductLanguage", SQLInfo.SQLProductLanguage)
                cmd.Parameters.AddWithValue("@SQLProductCollation", SQLInfo.SQLProductCollation)
                cmd.Parameters.AddWithValue("@SQLServerServiceMode", SQLInfo.SQLServerServiceMode)
                cmd.Parameters.AddWithValue("@SQLServerServiceState", SQLInfo.SQLServerServiceState)
                cmd.Parameters.AddWithValue("@SQLServerMonitored", SQLInfo.SQLServerMonitored)
                cmd.Parameters.AddWithValue("@SQLServerNotes", SQLInfo.SQLServerNotes)
                cmd.Parameters.AddWithValue("@SQLDataLocationPath", SQLInfo.SQLDataLocationPath)
                cmd.Parameters.AddWithValue("@SQLLogsLocationPath", SQLInfo.SQLLogsLocationPath)
                cmd.Parameters.AddWithValue("@SQLServerBackupPath", SQLInfo.SQLServerBackupPath)
                cmd.Parameters.AddWithValue("@SQLServerReplicated", SQLInfo.SQLServerReplicated)
                cmd.Parameters.AddWithValue("@SQLServerBackedUpBySDODB", SQLInfo.SQLServerBackedUpBySDODB)
                cmd.Parameters.AddWithValue("@SQLBackupSDOBackup", SQLInfo.SQLBackupSDOBackup)
                cmd.Parameters.AddWithValue("@SQLInstallationDate", SQLInfo.SQLInstallationDate)
                cmd.Parameters.AddWithValue("@SQLServerInstalledBy", SQLInfo.SQLServerInstalledBy)
                cmd.Parameters.AddWithValue("@SQLNetAppStorage", SQLInfo.SQLNetAppStorage)
                cmd.Parameters.AddWithValue("@SQLNetAppPrimaryStorage", SQLInfo.SQLNetAppPrimaryStorage)
                cmd.Parameters.AddWithValue("@SQLNetAppSecondaryStorage", SQLInfo.SQLNetAppSecondaryStorage)
                cmd.Parameters.AddWithValue("@SQLServerLicensed", SQLInfo.SQLServerLicensed)
                cmd.Parameters.AddWithValue("@SQLTicketNumber", SQLInfo.SQLTicketNumber)
                cmd.Parameters.AddWithValue("@SQLRequestor", SQLInfo.SQLRequestor)
                cmd.Parameters.AddWithValue("@SQLAppOwner", SQLInfo.SQLAppOwner)
                cmd.Parameters.AddWithValue("@SQLAppGroup", SQLInfo.SQLAppGroup)
                cmd.Parameters.AddWithValue("@SQLContactPerson", SQLInfo.SQLContact)
                cmd.Parameters.AddWithValue("@SQLDNSAlias", SQLInfo.SQLDNSAlias)
                cmd.Parameters.AddWithValue("@SQLWindowsClusterName", SQLInfo.SQLClusterName)
                cmd.Parameters.AddWithValue("@SQLLicenseType", SQLInfo.SQLLicenseType)
                cmd.Parameters.AddWithValue("@SQLLicenseQTY", SQLInfo.SQLLicenseQTY)
                cmd.Parameters.AddWithValue("@SQLLicenseCoverage", SQLInfo.SQLLicenseCoverage)
                Dim result As Integer = cmd.ExecuteNonQuery()
                If result >= 1 Then
                    'Message = SQLInfo.SQLInstance_ServerName + "\\" + SQLInfo.SQLInstance_Name + "Details inserted successfully"
                    MessageBox.Show("record inserted Successfully", "Process Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    'Message = SQLInfo.SQLInstance_ServerName + "\\" + SQLInfo.SQLInstance_Name + " Details not inserted successfully"
                    MessageBox.Show("Failed to insert record")
                End If
                con.Close()
                'Return Message

            Catch ex As SqlException
                'Message = "Error: " + ex.Message.ToString()
                'Return Message

                MsgBox("ERROR" & vbLf & ex.Message)
            Catch ex As Exception
                'Message = "Error : " + ex.Message
                'Return Message

                MsgBox("ERROR" & vbLf & ex.Message)
            End Try
        End Function
        Public Function DeleteSQLInstance(SQLInfo As InstanceDetails) As Boolean
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Try
                Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
                con.Open()
                Dim cmd As New SqlCommand("DELETE FROM [SDODB_ServerEvidence].[dbo].[SDODB_Instances] WHERE ID=@SQLInstanceID", con)
                cmd.Parameters.AddWithValue("@SQLInstanceID", SQLInfo.SQLInstanceID)
                cmd.ExecuteNonQuery()
                con.Close()
                Return True
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQL Error")
                Return False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error")
                Return False
            End Try
        End Function
    End Class
End Namespace

