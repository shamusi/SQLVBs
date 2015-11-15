
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.Security.Principal
Imports System.Net
Imports System.Configuration
Imports System.IO
Imports System.Threading.Tasks
Imports System.Data.SqlClient

Imports SQLInstances


Namespace SQLInstances
    ''' <summary>
    ''' Default Page
    ''' </summary>
    Partial Public Class SQLForm
        Inherits Form



        Private SQLDBEvidenceDataAccess As New SQLDBEvidenceDataAccess()
        ' Class to communicate with SQL Server database
        Private appdefaults As New My.MySettings()
        ' Read Default App Settings

        Public Delegate Sub UpdateLogDelegate(txt As String)

        ''' <summary>
        ''' Default Form
        ''' </summary>
        Public Sub New()
            ' Initialize all components 
            'showdata(); // Refresh data in DataGridView
            'objService.Close();
            InitializeComponent()
        End Sub
        ''' <summary>
        ''' Is Going To Populated DataGrid view with all data from database.
        ''' IT is also going to check if there is something wrong with ServiceReference Connection.
        ''' </summary>
        Private Sub showdata()
            ' To show the data in the DataGridView


            ' LoadTheData
            Try

                ' Create an unbound DataGridView by declaring a column count.


                Dim ds As New DataSet()
                ds = SQLDBEvidenceDataAccess.SelectSQLInstances()
                dataGridView1.DataSource = ds.Tables(0)

                ' Create New Styles for DataGrid View.
                Dim columnHeaderStyle As New DataGridViewCellStyle()
                Dim cellsStyle As New DataGridViewCellStyle()


                ' Hide SQL Server Instance ID
                dataGridView1.Columns(0).Visible = False
                Me.dataGridView1.Columns(0).Frozen = True

                ' Hide everything from column # 7
                For i As Integer = 8 To dataGridView1.ColumnCount - 1
                    dataGridView1.Columns(i).Visible = False
                Next
                ' Rename Header Texts
                dataGridView1.Columns(1).HeaderText = "Server Name"
                dataGridView1.Columns(2).HeaderText = "Instance Name"
                dataGridView1.Columns(3).HeaderText = "Product Name"
                dataGridView1.Columns(4).HeaderText = "Version"
                dataGridView1.Columns(5).HeaderText = "Service Pack"
                dataGridView1.Columns(6).HeaderText = "Edition"
                dataGridView1.Columns(7).HeaderText = "Platform"

                ' Change the style of Header Columns
                columnHeaderStyle.BackColor = Color.Beige
                columnHeaderStyle.Font = New Font("Verdana", 8, FontStyle.Bold)

                ' Change Style of all Cells
                cellsStyle.BackColor = Color.WhiteSmoke
                cellsStyle.Font = New Font("Verdana", 8, FontStyle.Regular)

                ' Format datagridview
                dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle
                dataGridView1.DefaultCellStyle = cellsStyle
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Dim wi As WindowsIdentity = WindowsIdentity.GetCurrent()
                ' Identify current user - It is used for further records
                tbUpdatedBy.Text = wi.Name.ToString()
                ' Update textbox with Current User
                ' Update TextBox with Current DateTime
                '               }
                '                     
                tbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm")



            Catch ex As Exception

                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try


        End Sub

        ''' <summary>
        ''' The SQL Database Connection has changed.
        ''' </summary>
        ''' <param name="State"></param>
        Private Sub SQL_SQLStateChanged(State As ConnectionState)
            Select Case State
                Case ConnectionState.Broken
                    ' NEED TO FINALIZE
                    Exit Select
                Case ConnectionState.Closed
                    ' NEED TO FINALIZE
                    Exit Select
                Case ConnectionState.Connecting
                    ' NEED TO FINALIZE
                    Exit Select
                Case ConnectionState.Executing
                    ' NEED TO FINALIZE
                    Exit Select
                Case ConnectionState.Fetching
                    ' NEED TO FINALIZE
                    Exit Select
                Case ConnectionState.Open
                    ' NEED TO FINALIZE
                    Exit Select
                Case Else
                    ' NEED TO FINALIZE
                    Exit Select
            End Select
        End Sub
        Private Sub SQL_SQLInfoMessage(Message As String)
            Log(Message)
        End Sub

        ''' <summary>
        ''' Display Logging Messages to Admin
        ''' </summary>
        ''' <param name="Message"></param>
        Private Sub Log(Message As String)
            If Me.rtbConOut.InvokeRequired Then
                Dim d As New UpdateLogDelegate(AddressOf Log)
                Me.rtbConOut.Invoke(d, New Object() {Message})
            Else
                rtbConOut.AppendText(Message + Environment.NewLine)
                rtbConOut.Focus()
            End If
        End Sub

        ''' <summary>
        ''' Will Find data based on InstanceServerName in database
        ''' </summary>
        ''' <param name="InstanceServerName">String SQL Server Name</param>
        Private Sub finddata(InstanceServerName As String)
            Try
                Dim sqldetail As New InstanceDetails()
                sqldetail.SQLInstance_ServerName = tbFindServer.Text.ToString()
                Dim ds As New DataSet()
                ds = SQLDBEvidenceDataAccess.SearchSQLInstance(sqldetail)
                dataGridView1.DataSource = ds.Tables(0)
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)


                ' Create New Styles for DataGrid View.
                Dim columnHeaderStyle As New DataGridViewCellStyle()
                Dim cellsStyle As New DataGridViewCellStyle()

                Me.dataGridView1.Columns(1).Frozen = True
                ' Hide SQL Server Instance ID
                dataGridView1.Columns(0).Visible = False


                '' Hide everything from column # 7
                'For i As Integer = 8 To dataGridView1.ColumnCount - 1
                '    dataGridView1.Columns(i).Visible = False
                'Next
                ' Rename Header Texts
                dataGridView1.Columns(1).HeaderText = "SERVER NAME"
                dataGridView1.Columns(2).HeaderText = "INSTANCE NAME"
                dataGridView1.Columns(3).HeaderText = "PRODUCT NAME"
                dataGridView1.Columns(4).HeaderText = "VERSION"
                dataGridView1.Columns(5).HeaderText = "SERVICE PACK"
                dataGridView1.Columns(6).HeaderText = "EDITION"
                dataGridView1.Columns(7).HeaderText = "PLATFORM"


                '' Format datagridview
                'dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle
                'dataGridView1.DefaultCellStyle = cellsStyle
                'dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Dim wi As WindowsIdentity = WindowsIdentity.GetCurrent()
                ' Identify current user - It is used for further records
                tbUpdatedBy.Text = wi.Name.ToString()
                ' Update textbox with Current User
                ' Update TextBox with Current DateTime
                '               }
                '                     
                tbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm")



            Catch ex As Exception

                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try


        End Sub

        ''' <summary>
        ''' Will delete selected row in DataGrid view.
        ''' You can remove the Instance. 
        ''' Should be reviewed since we want to have servers in evidence even when removed.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            Dim sqldetail As New InstanceDetails()

            If dataGridView1.Rows.Count > 1 Then
                If MessageBox.Show("Really Want To Delete " + dataGridView1.CurrentRow.Cells("INSTANCE_SERVERNAME").Value.ToString() + " ?", "Confirm Delete", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                    Dim dt As New DataTable()
                    sqldetail.SQLInstanceID = CInt(dataGridView1.CurrentRow.Cells("ID").Value)

                    Try
                        SQLDBEvidenceDataAccess.DeleteSQLInstance(sqldetail)
                        ' To Delete the data
                        MessageBox.Show("Record has been successfully deleted, your data will be refreshed", "Success")

                        ' Refresh Data
                        showdata()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString(), "Error")

                    End Try
                End If
            End If

        End Sub
        ''' <summary>
        ''' This will update selected record, works only when EDIT button is pressed before.
        ''' Running UPDATE configuration upon database, be sure what row is currently selected in DATAGRID, otherwise you will update different server.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
     

                    If dataGridView1 IsNot Nothing AndAlso dataGridView1.CurrentRow IsNot Nothing Then
                        If MessageBox.Show("Do you want to update SQL Instance Name: " + dataGridView1.CurrentRow.Cells(2).Value.ToString() + vbLf & " on Server : " + dataGridView1.CurrentRow.Cells(1).Value.ToString() + vbLf & "Be carefull you are always updating record of selected ROW!!!", "Confirm Update", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                            Try
                                'Nullable<DateTime> _dateSample;
                                Dim sqldetail As New InstanceDetails()


                                sqldetail.SQLInstanceID = CInt(dataGridView1.CurrentRow.Cells(0).Value)
                                'sqldetail.SQLInstanceID = CInt(SQLServerEvidence.DG.CurrentRow.Cells(0).Value)
                                sqldetail.SQLInstance_ServerName = tbSQLServerName.Text.ToString()
                                sqldetail.SQLInstance_Name = tbSQLInstanceName.Text.ToString()
                                sqldetail.SQLProductName = cbSQLProductName.Text.ToString()
                                sqldetail.SQLBuildNumber = tbSQLBuildNumber.Text.ToString()
                                sqldetail.SQLProductServicePack = cbSQLServicePack.Text.ToString()
                                sqldetail.SQLProductEdition = cbSQLEdition.Text.ToString()
                                sqldetail.SQLProductArchitecture = cbSQLArchitecture.Text.ToString()
                                sqldetail.SQLClustered = chbSQLClustered.Checked
                                sqldetail.SQLProductLanguage = tbProductLanguage.Text.ToString()
                                sqldetail.SQLProductCollation = tbSQLCollation.Text.ToString()
                                sqldetail.SQLServerServiceMode = cbServiceMode.Text.ToString()
                                sqldetail.SQLServerServiceState = cbServiceState.Text.ToString()
                                sqldetail.SQLServerMonitored = chbSQLMonitored.Checked
                                sqldetail.SQLServerNotes = tbSQLNotes.Text.ToString()
                                sqldetail.SQLDataLocationPath = tbDefaultSQLData.Text.ToString()
                                sqldetail.SQLLogsLocationPath = tbDefaultSQLLogs.Text.ToString()
                                sqldetail.SQLServerBackupPath = tbSQLBackupPath.Text.ToString()
                                sqldetail.SQLServerReplicated = chbReplicated.Checked
                                sqldetail.SQLServerBackedUpBySDODB = chbBackedUp.Checked
                                sqldetail.SQLBackupSDOBackup = chbSDOBackupInformed.Checked
                                sqldetail.SQLInstallationDate = DateTime.Parse(tbInstalledDate.Text)
                                sqldetail.SQLServerInstalledBy = tbInstalledBy.Text.ToString()
                                ' Ensure that there is not empty date in the form. Causing issues during UPDATE!
                                If tbRemovedDate.Text.ToString() <> "" Then
                                    sqldetail.SQLRemovedDate = DateTime.Parse(tbRemovedDate.Text)
                                Else
                                    sqldetail.SQLRemovedDate = Nothing
                                End If
                                sqldetail.SQLRemovedBy = tbRemovedBy.Text.ToString()
                                sqldetail.SQLRecordChanged = DateTime.Now
                                sqldetail.SQLRecordChangedBy = tbUpdatedBy.Text.ToString()
                                sqldetail.SQLNetAppStorage = chbNetApp.Checked
                                sqldetail.SQLNetAppPrimaryStorage = tbNetAppPrimary.Text.ToString()
                                sqldetail.SQLNetAppSecondaryStorage = tbNetAppSecondary.Text.ToString()
                                sqldetail.SQLServerLicensed = chbLicense.Checked
                                sqldetail.SQLTicketNumber = tbTicketNumber.Text.ToString()
                                sqldetail.SQLRequestor = tbRequestor.Text.ToString()
                                sqldetail.SQLAppOwner = tbAppOwner.Text.ToString()
                                sqldetail.SQLAppGroup = tbAppGroup.Text.ToString()
                                sqldetail.SQLContact = tbContact.Text.ToString()
                                sqldetail.SQLDNSAlias = tbDNSAlias.Text.ToString()
                                sqldetail.SQLClusterName = tbWindowsClusterName.Text.ToString()
                                sqldetail.SQLLicenseType = cbLicenseType.Text.ToString()
                                sqldetail.SQLLicenseQTY = Convert.ToInt32(tbLicenseQTY.Text)
                                sqldetail.SQLLicenseCoverage = cbLicenseOwner.Text.ToString()

                                SQLDBEvidenceDataAccess.UpdateSQLInstanceTable(sqldetail)
                                MessageBox.Show("Your data have been sucessfully Updated!", "Success")
                                ' cleanup form
                                cleanForm()
                                ' refresh data
                                showdata()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message.ToString(), "Error!")
                            End Try
                        End If
            ElseIf SQLServerEvidence.DG.CurrentRow.Cells(0).Value Then
                If MessageBox.Show("Do you want to update SQL Instance Name: " + SQLServerEvidence.DG.CurrentRow.Cells(2).Value.ToString() + vbLf & " on Server : " + SQLServerEvidence.DG.CurrentRow.Cells(1).Value.ToString() + vbLf & "Be carefull you are always updating record of selected ROW!!!", "Confirm Update", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then

                    Try
                        'Nullable<DateTime> _dateSample;
                        Dim sqldetail As New InstanceDetails()



                        sqldetail.SQLInstanceID = CInt(SQLServerEvidence.DG.CurrentRow.Cells(0).Value)
                        sqldetail.SQLInstance_ServerName = tbSQLServerName.Text.ToString()
                        sqldetail.SQLInstance_Name = tbSQLInstanceName.Text.ToString()
                        sqldetail.SQLProductName = cbSQLProductName.Text.ToString()
                        sqldetail.SQLBuildNumber = tbSQLBuildNumber.Text.ToString()
                        sqldetail.SQLProductServicePack = cbSQLServicePack.Text.ToString()
                        sqldetail.SQLProductEdition = cbSQLEdition.Text.ToString()
                        sqldetail.SQLProductArchitecture = cbSQLArchitecture.Text.ToString()
                        sqldetail.SQLClustered = chbSQLClustered.Checked
                        sqldetail.SQLProductLanguage = tbProductLanguage.Text.ToString()
                        sqldetail.SQLProductCollation = tbSQLCollation.Text.ToString()
                        sqldetail.SQLServerServiceMode = cbServiceMode.Text.ToString()
                        sqldetail.SQLServerServiceState = cbServiceState.Text.ToString()
                        sqldetail.SQLServerMonitored = chbSQLMonitored.Checked
                        sqldetail.SQLServerNotes = tbSQLNotes.Text.ToString()
                        sqldetail.SQLDataLocationPath = tbDefaultSQLData.Text.ToString()
                        sqldetail.SQLLogsLocationPath = tbDefaultSQLLogs.Text.ToString()
                        sqldetail.SQLServerBackupPath = tbSQLBackupPath.Text.ToString()
                        sqldetail.SQLServerReplicated = chbReplicated.Checked
                        sqldetail.SQLServerBackedUpBySDODB = chbBackedUp.Checked
                        sqldetail.SQLBackupSDOBackup = chbSDOBackupInformed.Checked
                        sqldetail.SQLInstallationDate = DateTime.Parse(tbInstalledDate.Text)
                        sqldetail.SQLServerInstalledBy = tbInstalledBy.Text.ToString()
                        ' Ensure that there is not empty date in the form. Causing issues during UPDATE!
                        If tbRemovedDate.Text.ToString() <> "" Then
                            sqldetail.SQLRemovedDate = DateTime.Parse(tbRemovedDate.Text)
                        Else
                            sqldetail.SQLRemovedDate = Nothing
                        End If
                        sqldetail.SQLRemovedBy = tbRemovedBy.Text.ToString()
                        sqldetail.SQLRecordChanged = DateTime.Now
                        sqldetail.SQLRecordChangedBy = tbUpdatedBy.Text.ToString()
                        sqldetail.SQLNetAppStorage = chbNetApp.Checked
                        sqldetail.SQLNetAppPrimaryStorage = tbNetAppPrimary.Text.ToString()
                        sqldetail.SQLNetAppSecondaryStorage = tbNetAppSecondary.Text.ToString()
                        sqldetail.SQLServerLicensed = chbLicense.Checked
                        sqldetail.SQLTicketNumber = tbTicketNumber.Text.ToString()
                        sqldetail.SQLRequestor = tbRequestor.Text.ToString()
                        sqldetail.SQLAppOwner = tbAppOwner.Text.ToString()
                        sqldetail.SQLAppGroup = tbAppGroup.Text.ToString()
                        sqldetail.SQLContact = tbContact.Text.ToString()
                        sqldetail.SQLDNSAlias = tbDNSAlias.Text.ToString()
                        sqldetail.SQLClusterName = tbWindowsClusterName.Text.ToString()
                        sqldetail.SQLLicenseType = cbLicenseType.Text.ToString()
                        sqldetail.SQLLicenseQTY = Convert.ToInt32(tbLicenseQTY.Text)
                        sqldetail.SQLLicenseCoverage = cbLicenseOwner.Text.ToString()

                        SQLDBEvidenceDataAccess.UpdateSQLInstanceTable(sqldetail)
                        MessageBox.Show("Your data have been sucessfully Updated!", "Success")
                        ' cleanup form
                        cleanForm()
                        ' refresh data
                        showdata()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString(), "Error!")
                    End Try
                End If
            End If

        End Sub



        ''' <summary>
        ''' This will populate data from datagrid view into form.
        ''' If Database Table will change you have to consider to change this data as well
        ''' Will probably require better solution for that.
        ''' Please link appropriate data with appropriate textboxes or other objects
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            ' Get SQL Instance Details
            Dim sqldetail As New InstanceDetails()
            ' Select Unique ID of the server

            sqldetail.SQLInstanceID = Convert.ToInt32(dataGridView1.SelectedCells(0).Value)
            'sqldetail.SQLInstanceID = Convert.ToInt32(SQLServerEvidence.DG.SelectedCells(0).Value)

            Dim record As DataRow = SQLDBEvidenceDataAccess.SelectSingleRecord(sqldetail)



            tbSQLServerName.Text = record("INSTANCE_SERVERNAME").ToString()
            tbSQLInstanceName.Text = record("INSTANCENAME").ToString()
            cbSQLProductName.Text = record("DBPRODUCTNAME").ToString()
            tbSQLBuildNumber.Text = record("VERSIONNUMBER").ToString()
            cbSQLServicePack.Text = record("DBPRODUCTSERVICEPACK").ToString()
            cbSQLEdition.Text = record("DBPRODUCTEDITION").ToString()
            cbSQLArchitecture.Text = record("DBPRODUCTARCHITECTURE").ToString()
            chbSQLClustered.Checked = Convert.ToBoolean(record("DBPRODUCTCLUSTERED"))
            tbProductLanguage.Text = record("DBPRUDUCTLANGUAGE").ToString()
            tbSQLCollation.Text = record("DBPRODUCTCOLLATION").ToString()
            cbServiceMode.Text = record("DBSERVICEMODE").ToString()
            cbServiceState.Text = record("DBSERVICESTATE").ToString()
            chbSQLMonitored.Checked = Convert.ToBoolean(record("DBSERVICEMOMMONITORED"))
            tbSQLNotes.Text = record("DBPRODUCTNOTES").ToString()
            tbDefaultSQLData.Text = record("DBDATALOCATION").ToString()
            tbDefaultSQLLogs.Text = record("DBLOGLOCATION").ToString()
            tbSQLBackupPath.Text = record("DBBACKUPSLOCATION").ToString()
            chbReplicated.Checked = Convert.ToBoolean(record("DBREPLICATION"))
            chbBackedUp.Checked = Convert.ToBoolean(record("DBBACKUPEDBYSDODB"))
            chbSDOBackupInformed.Checked = Convert.ToBoolean(record("SDOBACKUPTEAMINFO"))
            tbInstalledDate.Text = record("INSTALLEDDATE").ToString()
            tbInstalledBy.Text = record("INSTALLEDBY").ToString()
            tbRemovedDate.Text = record("REMOVEDDATE").ToString()
            tbRemovedBy.Text = record("REMOVEDBY").ToString()
            chbNetApp.Checked = Convert.ToBoolean(record("NETAPP"))
            tbNetAppPrimary.Text = record("NETAPP_PRIMARY_STORAGE").ToString()
            tbNetAppSecondary.Text = record("NETAPP_SECONDARY_STORAGE").ToString()
            chbLicense.Checked = Convert.ToBoolean(record("SQL_LICENSED"))
            tbTicketNumber.Text = record("TICKET_NUMBER").ToString()
            tbRequestor.Text = record("REQUESTOR").ToString()
            tbAppOwner.Text = record("APP_OWNER").ToString()
            tbAppGroup.Text = record("APP_GROUP").ToString()
            tbContact.Text = record("CONTACT_PERSON").ToString()
            tbDNSAlias.Text = record("DNS_ALIAS").ToString()
            tbWindowsClusterName.Text = record("SQL_CLUSTER_NETWORK_NAME").ToString()
            cbLicenseType.Text = record("SQL_LICENSETYPE").ToString()
            tbLicenseQTY.Text = record("SQL_LICENSEQTY_CALS").ToString()
            cbLicenseOwner.Text = record("SQL_LICENSECOVERAGE").ToString()

            '
            '             * 
            '             * Will Only work when data are gathered from DATAGRID and all rows are included.
            '             * Does not offer much flexibility to hide rows or so.
            '             * 
            '             * 
            '            int i = dataGridView1.SelectedCells[0].RowIndex;
            '            tbSQLServerName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            '            tbSQLInstanceName.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            '            cbSQLProductName.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            '            tbSQLBuildNumber.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            '            cbSQLServicePack.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            '            cbSQLEdition.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            '            cbSQLArchitecture.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            '            chbSQLClustered.Checked = (bool)dataGridView1.Rows[i].Cells[8].Value;
            '            tbProductLanguage.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            '            tbSQLCollation.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            '            cbServiceMode.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
            '            cbServiceState.Text = dataGridView1.Rows[i].Cells[12].Value.ToString();
            '            chbSQLMonitored.Checked = (bool)dataGridView1.Rows[i].Cells[13].Value;
            '            tbSQLNotes.Text = dataGridView1.Rows[i].Cells[14].Value.ToString();
            '            tbDefaultSQLData.Text = dataGridView1.Rows[i].Cells[15].Value.ToString();
            '            tbDefaultSQLLogs.Text = dataGridView1.Rows[i].Cells[16].Value.ToString();
            '            tbSQLBackupPath.Text = dataGridView1.Rows[i].Cells[17].Value.ToString();
            '            chbReplicated.Checked = (bool)dataGridView1.Rows[i].Cells[18].Value;
            '            chbBackedUp.Checked = (bool)dataGridView1.Rows[i].Cells[19].Value;
            '            chbSDOBackupInformed.Checked = (bool)dataGridView1.Rows[i].Cells[20].Value;
            '            tbInstalledDate.Text = dataGridView1.Rows[i].Cells[21].Value.ToString();
            '            tbInstalledBy.Text = dataGridView1.Rows[i].Cells[22].Value.ToString();
            '            tbRemovedDate.Text = dataGridView1.Rows[i].Cells[23].Value.ToString();
            '            tbRemovedBy.Text = dataGridView1.Rows[i].Cells[24].Value.ToString();
            '            chbNetApp.Checked = (bool)dataGridView1.Rows[i].Cells[27].Value;
            '            tbNetAppPrimary.Text = dataGridView1.Rows[i].Cells[28].Value.ToString();
            '            tbNetAppSecondary.Text = dataGridView1.Rows[i].Cells[29].Value.ToString();
            '            chbLicense.Checked = (bool)dataGridView1.Rows[i].Cells[30].Value;
            '            tbTicketNumber.Text = dataGridView1.Rows[i].Cells[31].Value.ToString();
            '            tbRequestor.Text = dataGridView1.Rows[i].Cells[32].Value.ToString();
            '            tbAppOwner.Text = dataGridView1.Rows[i].Cells[33].Value.ToString();
            '            tbContact.Text = dataGridView1.Rows[i].Cells[34].Value.ToString();
            '            tbDNSAlias.Text = dataGridView1.Rows[i].Cells[35].Value.ToString();
            '            tbWindowsClusterName.Text = dataGridView1.Rows[i].Cells[36].Value.ToString();
            '            cbLicenseType.Text = dataGridView1.Rows[i].Cells[37].Value.ToString();
            '            tbLicenseQTY.Text = dataGridView1.Rows[i].Cells[38].Value.ToString();
            '            cbLicenseOwner.Text = dataGridView1.Rows[i].Cells[39].Value.ToString();
            '            

        End Sub
        ''' <summary>
        ''' Will check the status of checkbox and disable or enable two textboxes asking for NetApp info.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub chbNetApp_CheckedChanged(sender As Object, e As EventArgs) Handles chbNetApp.CheckedChanged
            ' Will setup NetApp TextBox to disabled state when NetApp is not in used.
            ' During this both textbox are not editable. 
            If chbNetApp.Checked = False Then
                tbNetAppPrimary.Enabled = False
                tbNetAppSecondary.Enabled = False
            Else
                tbNetAppPrimary.Enabled = True
                tbNetAppSecondary.Enabled = True
            End If
        End Sub



        ''' <summary>
        ''' Will insert new SQL Server Instance into database
        ''' This is just simple INSERT operation, getting values from WINFORM textboxes and other objects.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
            ' This will insert new data from WinForm to Database!
            ' It is not perfectly treat ... if you find some issues in inserting empty data into database, you have to fix it here!
            ' Validation is functional only on EMPTY STRINGS See ValidateTheForm() function.
            If ValidateTheForm() = True Then
                If MessageBox.Show("Add New SQL Instance " + tbSQLInstanceName.Text.ToString() + " to Server : " + tbSQLServerName.Text.ToString(), "Confirm Insert", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                    Dim sqldetail As New InstanceDetails()
                    sqldetail.SQLInstance_ServerName = tbSQLServerName.Text
                    sqldetail.SQLInstance_Name = tbSQLInstanceName.Text
                    sqldetail.SQLProductName = cbSQLProductName.Text
                    sqldetail.SQLBuildNumber = tbSQLBuildNumber.Text
                    sqldetail.SQLProductServicePack = cbSQLServicePack.Text
                    sqldetail.SQLProductEdition = cbSQLEdition.Text
                    sqldetail.SQLProductArchitecture = cbSQLArchitecture.Text
                    sqldetail.SQLClustered = chbSQLClustered.Checked
                    sqldetail.SQLProductLanguage = tbProductLanguage.Text
                    sqldetail.SQLProductCollation = tbSQLCollation.Text
                    sqldetail.SQLServerServiceMode = cbServiceMode.Text
                    sqldetail.SQLServerServiceState = cbServiceState.Text
                    sqldetail.SQLServerMonitored = chbSQLMonitored.Checked
                    sqldetail.SQLServerNotes = tbSQLNotes.Text
                    sqldetail.SQLDataLocationPath = tbDefaultSQLData.Text
                    sqldetail.SQLLogsLocationPath = tbDefaultSQLLogs.Text
                    sqldetail.SQLServerBackupPath = tbSQLBackupPath.Text
                    sqldetail.SQLServerReplicated = chbReplicated.Checked
                    sqldetail.SQLServerBackedUpBySDODB = chbBackedUp.Checked
                    sqldetail.SQLBackupSDOBackup = chbSDOBackupInformed.Checked
                    sqldetail.SQLInstallationDate = DateTime.Now
                    ' Check if the Installed By is filled up, if not use Current User.
                    If tbInstalledBy.Text = String.Empty Then
                        sqldetail.SQLServerInstalledBy = tbUpdatedBy.Text
                    Else
                        sqldetail.SQLServerInstalledBy = tbInstalledBy.Text
                    End If
                    sqldetail.SQLNetAppStorage = chbNetApp.Checked
                    sqldetail.SQLNetAppPrimaryStorage = tbNetAppPrimary.Text
                    sqldetail.SQLNetAppSecondaryStorage = tbNetAppSecondary.Text
                    sqldetail.SQLServerLicensed = chbLicense.Checked
                    sqldetail.SQLTicketNumber = tbTicketNumber.Text
                    sqldetail.SQLRequestor = tbRequestor.Text
                    sqldetail.SQLAppOwner = tbAppOwner.Text
                    sqldetail.SQLAppGroup = tbAppGroup.Text
                    sqldetail.SQLContact = tbContact.Text
                    sqldetail.SQLDNSAlias = tbDNSAlias.Text
                    sqldetail.SQLClusterName = tbWindowsClusterName.Text
                    sqldetail.SQLLicenseType = cbLicenseType.Text
                    If tbLicenseQTY.Text = String.Empty Then
                        sqldetail.SQLLicenseQTY = 0
                    Else
                        sqldetail.SQLLicenseQTY = Convert.ToInt32(tbLicenseQTY.Text)
                    End If
                    sqldetail.SQLLicenseCoverage = cbLicenseOwner.Text
                    Try
                        SQLDBEvidenceDataAccess.InsertSQLInstance(sqldetail)
                        grideview()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error")
                    End Try
                    'MessageBox.Show("Your record has been successfully inserted!", "Success")
                    ' Clean The Form
                    cleanForm()
                    ' refresh data in data view.

                    showdata()
                End If
            End If


        End Sub

        ''' <summary>
        ''' Shows message when you close application.
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub SQLForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            RemoveHandler SQLDBEvidenceDataAccess.SQLInfoMessage, AddressOf SQL_SQLInfoMessage
            RemoveHandler SQLDBEvidenceDataAccess.SQLStateChanged, AddressOf SQL_SQLStateChanged
            ' Popup message regarding closing app
            MessageBox.Show("Exiting Application!", "Closing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ' will close the Reference service when form closed!

        End Sub

        Private Sub SQLForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            ''Dim SQLLogin As New LoginWindow()
            ''Dim dr As DialogResult = SQLLogin.ShowDialog()
            ''If dr = System.Windows.Forms.DialogResult.OK Then
            'cleanForm()

            'Dim servername As String = "wk28"
            'Dim databasename As String = "SDODB_ServerEvidence"
            'Dim UserName As String = "SDODBWEBEDITOR"
            'Dim password As String = "Abc,123"
            'SQLDBEvidenceDataAccess.ConnectionString = "Data Source=" + servername + ";Initial Catalog=" + databasename + ";User ID=" + UserName + ";Password=" + password

            'AddHandler SQLDBEvidenceDataAccess.SQLInfoMessage, AddressOf SQL_SQLInfoMessage
            'AddHandler SQLDBEvidenceDataAccess.SQLStateChanged, AddressOf SQL_SQLStateChanged
            ''SQLDBEvidenceDataAccess.ConnectionString = "Data Source=" + SQLLogin.ServerName + ";Initial Catalog=" + SQLLogin.DatabaseName + ";User ID=" + SQLLogin.UserName + ";Password=" + SQLLogin.Password
            'SQLDBEvidenceDataAccess.ConnectionString = "Data Source=" + servername + ";Initial Catalog=" + databasename + ";User ID=" + UserName + ";Password=" + password
            ''If SQLDBEvidenceDataAccess.Connect() Then
            '' LoadTheData
            ''try
            ''{

            '' Create an unbound DataGridView by declaring a column count.
            'Dim ds As New DataSet()
            'ds = SQLDBEvidenceDataAccess.SelectSQLInstances()
            'dataGridView1.DataSource = ds.Tables(0)

            '' Create New Styles for DataGrid View.
            'Dim columnHeaderStyle As New DataGridViewCellStyle()
            'Dim cellsStyle As New DataGridViewCellStyle()


            '' Hide SQL Server Instance ID
            'dataGridView1.Columns(0).Visible = False
            'Me.dataGridView1.Columns(0).Frozen = True
            '' freeze column

            '' Hide everything from column # 7
            'For i As Integer = 8 To dataGridView1.ColumnCount - 1
            '    dataGridView1.Columns(i).Visible = False
            'Next
            '' Rename Header Texts
            'dataGridView1.Columns(1).HeaderText = "Server Name"
            'dataGridView1.Columns(2).HeaderText = "Instance Name"
            'dataGridView1.Columns(3).HeaderText = "Product Name"
            'dataGridView1.Columns(4).HeaderText = "Version"
            'dataGridView1.Columns(5).HeaderText = "Service Pack"
            'dataGridView1.Columns(6).HeaderText = "Edition"
            'dataGridView1.Columns(7).HeaderText = "Platform"

            '' Change the style of Header Columns
            'columnHeaderStyle.BackColor = Color.Beige
            'columnHeaderStyle.Font = New Font("Verdana", 8, FontStyle.Bold)

            '' Change Style of all Cells
            'cellsStyle.BackColor = Color.WhiteSmoke
            'cellsStyle.Font = New Font("Verdana", 8, FontStyle.Regular)


            '' Format datagridview
            'dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle
            'dataGridView1.DefaultCellStyle = cellsStyle
            'dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            Dim wi As WindowsIdentity = WindowsIdentity.GetCurrent()
            ' Identify current user - It is used for further records
            tbUpdatedBy.Text = wi.Name.ToString()
            ' Update textbox with Current User
            ' Update TextBox with Current DateTime
            '               }
            '                         
            tbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            cbServiceMode.SelectedIndex = 1
            cbServiceState.SelectedIndex = 0
            cbSQLProductName.SelectedIndex = 4
            cbSQLEdition.SelectedIndex = 0
            cbSQLArchitecture.SelectedIndex = 0
            cbLicenseType.SelectedIndex = 1
            cbLicenseOwner.SelectedIndex = 0
            tbInstalledDate.Visible = False
            tbInstalledBy.Visible = False

            'catch (Exception ex)
            '{
            '    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            '    this.Close();
            '}
            '}
            'else
            '{
            '    MessageBox.Show("I cannot connect to the server!\n\rClosing Application");
            '    this.Close();
            '}
            'End If
            'Else
            'MessageBox.Show("SQL Server Error : ", SQLDBEvidenceDataAccess.LastError)
            'Me.Close()
            'End If
        End Sub

        ''' <summary>
        ''' Will manually refresh data in DataGrid view.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnRefreshData_Click(sender As Object, e As EventArgs) Handles btnRefreshData.Click
            ' Reload data in DataGridView
            showdata()
            ' Cleanup the form
            cleanForm()
            ' Popup message, that data was reloaded.
            MessageBox.Show("Data view has been refreshed!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub

        ''' <summary>
        ''' Will Search for Server name based on the value in textbox.
        ''' You can use wildcards for SQL Server %,? etc. To filter. LIKE is used.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnSearchServer_Click(sender As Object, e As EventArgs) Handles btnSearchServer.Click
            finddata(tbFindServer.Text.ToString())

        End Sub

        ''' <summary>
        ''' Is going to try to look for servername in the database. When enter keyboard button is pressed.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub tbFindServer_KeyUp(sender As Object, e As KeyEventArgs) Handles tbFindServer.KeyUp
            ' If ENTER is pressed on textbox then automatically will find the server name.
            If e.KeyCode = Keys.Enter Then
                finddata(tbFindServer.Text.ToString())
            End If
        End Sub


        'Private Sub tbSQLServerName_KeyDown(sender As Object, e As KeyEventArgs)
        '    ' Hidden option
        '    ' If Pressed combination of keys CTRL+I+D then Delete button and some other text boxes will activate.
        '    ' Please do it with caution ! this is just for testing purposes.
        '    If e.Control AndAlso e.Alt AndAlso e.KeyCode = Keys.D Then
        '        If btnDelete.Enabled = True Xor tbRemovedDate.Visible = True Xor tbRemovedBy.Visible = True Then
        '            btnDelete.Enabled = False
        '            lblRemovedBy.Visible = False
        '            lblRemovedDate.Visible = False
        '            tbRemovedBy.Visible = False
        '            tbRemovedDate.Visible = False
        '        Else

        '            btnDelete.Enabled = True
        '            lblRemovedBy.Visible = True
        '            lblRemovedDate.Visible = True
        '            tbRemovedBy.Visible = True
        '            tbRemovedDate.Visible = True
        '        End If
        '    End If
        'End Sub

        Private Sub dataGridView1_ColumnNameChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dataGridView1.ColumnNameChanged
          
        End Sub


        ''' <summary>
        ''' Will Change the collors of rows based on some values in those collumns.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub dataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dataGridView1.RowPostPaint

            If (e.RowIndex) < (Me.dataGridView1.Rows.Count - 1) Then
                ' DataGridView Change colors based on values DBSERVICEMODE = Disabled and DBSERVICESTATE = Stopped / Mark red because those are turned off.
                Dim gvr As DataGridViewRow = Me.dataGridView1.Rows(e.RowIndex)
                If (gvr.Cells("DBSERVICEMODE").Value.ToString()) = "Disabled" AndAlso (gvr.Cells("DBSERVICESTATE").Value.ToString()) = "Stopped" Then
                    gvr.DefaultCellStyle.BackColor = Color.OrangeRed
                    ' Will check if Removed date and removedby collumns are filled up, then it means server was decommissioned.
                ElseIf (gvr.Cells("REMOVEDDATE").Value.ToString()) <> String.Empty Xor (gvr.Cells("REMOVEDBY").Value.ToString()) <> String.Empty Then
                    gvr.DefaultCellStyle.BackColor = Color.Pink
                    ' This will mark all the rows where product is "Microsoft SQL Server 2000" or Version Number contains 8.0 with yellow color.
                ElseIf (gvr.Cells("DBPRODUCTNAME").Value.ToString()) = "Microsoft SQL Server 2000" Xor (String.Compare("8.0", gvr.Cells("VERSIONNUMBER").Value.ToString())) = 0 Then
                    gvr.DefaultCellStyle.BackColor = Color.Yellow

                End If
            End If
        End Sub

        ' Will navigate to web page and checks if the webpage is in proper format.

        Private Sub NavigateUrl(address As [String])
            If [String].IsNullOrEmpty(address) Then
                Return
            End If
            If address.Equals("about:blank") Then
                Return
            End If
            If Not address.StartsWith("http://") AndAlso Not address.StartsWith("https://") Then
                address = "http://" + address
            End If
            Try
                ' Initialize and open another FORM
                Dim Explorer As New ViewDetailsForm()
                Explorer.Show()
                ' Run GO with specifying address

                Explorer.Go(address)
            Catch generatedExceptionName As System.UriFormatException
                Return
            End Try


        End Sub







        ''' <summary>
        ''' Doublicklick on row in datagrid view will open new form with Browser window and will open page related to SQL Server Instance
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub dataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles dataGridView1.DoubleClick

            NavigateUrl("http://deusdheid0031/sdodbevidence/DBInstanceDetails.asp?id=" & CInt(dataGridView1.CurrentRow.Cells(0).Value))
        
        End Sub
        ''' <summary>
        ''' FUNCTION WHICH IS GOING TO CLEAR EVERYTHING WHAT IS ON THE WINFORM.
        ''' HAVE TO CROSSCHECK THE FUNCTIONALITY, TO AVOID DELETING SOME NECESSARY INFO.
        ''' </summary>
        Public Sub cleanForm()
            ' Reset Mandatory GroupBox 
            For Each cntrl As Control In gbMandatoryInfo.Controls

                If cntrl.[GetType]() = GetType(TextBox) Then
                    cntrl.Text = String.Empty
                End If
                If cntrl.[GetType]() = GetType(CheckBox) Then
                    DirectCast(cntrl, CheckBox).Checked = False
                End If
                If cntrl.[GetType]() = GetType(ComboBox) Then
                    'cntrl.ResetText();
                    DirectCast(cntrl, ComboBox).SelectedIndex = -1

                End If
            Next
            ' Reset SQL Details GroupBox
            For Each cntrl As Control In gbSQLServerInfo.Controls

                If cntrl.[GetType]() = GetType(TextBox) Then
                    If (cntrl.Name <> "tbUpdatedBy") And (cntrl.Name <> "tbDateTime") Then
                        cntrl.Text = String.Empty
                    End If
                End If
                If cntrl.[GetType]() = GetType(CheckBox) Then
                    DirectCast(cntrl, CheckBox).Checked = False
                End If
                If cntrl.[GetType]() = GetType(ComboBox) Then
                    'cntrl.ResetText();
                    DirectCast(cntrl, ComboBox).SelectedIndex = -1

                End If
            Next
        End Sub
        ''' <summary>
        ''' Button which clears whole form
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnClearForm_Click(sender As Object, e As EventArgs) Handles btnClearForm.Click
            ' Cleanup form
            cleanForm()

        End Sub

        Private Sub lblNotice_Click(sender As Object, e As EventArgs)

        End Sub
        ''' <summary>
        ''' Disable/Enable Form Objects whenever checkbox is checked or not.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub chbSQLClustered_CheckedChanged(sender As Object, e As EventArgs) Handles chbSQLClustered.CheckedChanged
            ' Will setup NetApp TextBox to disabled state when NetApp is not in used.
            ' During this both textbox are not editable. 
            If chbSQLClustered.Checked = False Then

                tbWindowsClusterName.Enabled = False
            Else

                tbWindowsClusterName.Enabled = True
            End If
        End Sub

        ''' <summary>
        ''' Handle DataGrid Errors
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="anError"></param>
        Private Sub DataGridView1_DataError(sender As Object, anError As DataGridViewDataErrorEventArgs)

            MessageBox.Show("Error happened " + anError.Context.ToString())

            If anError.Context = DataGridViewDataErrorContexts.Commit Then
                MessageBox.Show("Commit error")
            End If
            If anError.Context = DataGridViewDataErrorContexts.CurrentCellChange Then
                MessageBox.Show("Cell change")
            End If
            If anError.Context = DataGridViewDataErrorContexts.Parsing Then
                MessageBox.Show("parsing error")
            End If
            If anError.Context = DataGridViewDataErrorContexts.LeaveControl Then
                MessageBox.Show("leave control error")
            End If

            If TypeOf (anError.Exception) Is ConstraintException Then
                Dim view As DataGridView = DirectCast(sender, DataGridView)
                view.Rows(anError.RowIndex).ErrorText = "an error"
                view.Rows(anError.RowIndex).Cells(anError.ColumnIndex).ErrorText = "an error"

                anError.ThrowException = False
            End If
        End Sub
        ''' <summary>
        ''' Will try to validate form for empty data.
        ''' </summary>
        ''' <returns>Boolean</returns>
        Public Function ValidateTheForm() As Boolean
            ' Get the list of all textboxes and check if those are not empty.
            Dim TextBoxCheck As TextBox() = {tbSQLServerName, tbSQLInstanceName, tbSQLBuildNumber, tbSQLCollation, tbProductLanguage, tbRequestor, _
             tbContact, tbAppOwner, tbAppGroup, tbTicketNumber}
            For i As Integer = 0 To TextBoxCheck.Length - 1
                If TextBoxCheck(i).Text = String.Empty Then
                    MessageBox.Show("You have forgot to fill some data!" & vbLf & "You will be now placed to missing textbox!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextBoxCheck(i).Focus()
                    Return False

                End If
            Next
            ' Check the comboboxes and ensure that those are not empty.
            Dim ComboCheck As ComboBox() = {cbSQLProductName, cbSQLServicePack, cbSQLEdition, cbSQLArchitecture, cbServiceMode, cbServiceState}
            For y As Integer = 0 To ComboCheck.Length - 1
                If String.IsNullOrEmpty(ComboCheck(y).Text) Then
                    MessageBox.Show("You have forgot to fill some data!" & vbLf & "You will be now placed to missing combobox!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ComboCheck(y).Focus()
                    Return False
                End If
            Next

            Return True
        End Function
        ''' <summary>
        ''' Will Show Context Menu with Some required actions
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub dataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles dataGridView1.MouseClick
            ' Check if Right-click as been done on DataGrid view.
            ' Chose row over which has ben done
            ' Show Context menu and trigger required action

            If e.Button = MouseButtons.Right Then
                Dim m As New ContextMenu()
                Dim currentMouseOverRow As Integer = dataGridView1.HitTest(e.X, e.Y).RowIndex

                If currentMouseOverRow >= 0 Then
                    ' Add Context Menu and event handlers
                    dataGridView1.ClearSelection()
                    dataGridView1.Rows(currentMouseOverRow).Selected = True
                    m.MenuItems.Add(New MenuItem("Edit", New EventHandler(AddressOf btnEdit_Click)))
                    'm.MenuItems.Add(New MenuItem("Update", New EventHandler(AddressOf btnUpdate_Click)))
                    'm.MenuItems.Add(New MenuItem("Delete", New EventHandler(AddressOf btnDelete_Click)))
                End If

                m.Show(dataGridView1, New Point(e.X, e.Y))
            End If
        End Sub

        Private Sub tbFindServer_TextChanged(sender As Object, e As EventArgs) Handles tbFindServer.TextChanged
            'finddata(tbFindServer.Text.ToString());
        End Sub

        Private Sub picboxAddServer_Click(sender As Object, e As EventArgs)
            NavigateUrl("http://deusdheid0031/CMDB/CMDBInsert.aspx")
        End Sub

        
        Private Sub tbSQLNotes_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbSQLNotes.TextChanged

        End Sub

      
        'Private Sub SQLForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '    Me.dataGridView1.Width = 0.3 * Me.Width
        '    Me.dataGridView1.Height = 0.3 * Me.Height
        'End Sub
    
        Private Sub dataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        End Sub

       

        Private Sub tbAppOwner_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbAppOwner.TextChanged

        End Sub



        Sub grideview()

            'dataGridView2.Rows.Clear()
            Dim i As Integer
            Dim Sqlcom As String = "select * from [SDODB_ServerEvidence].[dbo].[SDODB_Instances]"
            Dim appdefaults As New My.MySettings()
            Dim sDBserver As String = appdefaults.dbserver.ToString()
            Dim sDatabase As String = appdefaults.databasename.ToString()
            Dim sUser As String = appdefaults.login.ToString()
            Dim sPassword As String = appdefaults.password.ToString()
            Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
            con.Open()

            Dim sel As String = "select * from [SDODB_ServerEvidence].[dbo].[SDODB_Instances] where [ID] = (select top 1 [ID] from [SDODB_ServerEvidence].[dbo].[SDODB_Instances] ORDER BY ID DESC)"
            Dim cmdSql As New SqlCommand(sel, con)
            cmdSql.CommandType = CommandType.Text
            Dim sda As New SqlDataAdapter(cmdSql)
            sda.SelectCommand = cmdSql

            'With cmdSql
            '    .Parameters.Add("@Sale_Date", SqlDbType.DateTime).Value = DateTimePicker1.Text
            'End With

            Dim ds As New DataSet()
            sda.Fill(ds)

            dataGridView1.DataSource = ds.Tables("SaleInfo")

            dataGridView1.DataSource = ds.Tables(0)
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dataGridView1.Columns(1).HeaderText = "SERVER NAME"
            dataGridView1.Columns(2).HeaderText = "INSTANCE"

            con.Close()
        End Sub


        Public Sub Edit_from_mainForm()
            ' Get SQL Instance Details
            Dim sqldetail As New InstanceDetails()
            ' Select Unique ID of the server

            sqldetail.SQLInstanceID = Convert.ToInt32(SQLServerEvidence.DG.SelectedCells(0).Value)
            Dim record As DataRow = SQLDBEvidenceDataAccess.SelectSingleRecord(sqldetail)


            tbSQLServerName.Text = record("INSTANCE_SERVERNAME").ToString()
            tbSQLInstanceName.Text = record("INSTANCENAME").ToString()
            cbSQLProductName.Text = record("DBPRODUCTNAME").ToString()
            tbSQLBuildNumber.Text = record("VERSIONNUMBER").ToString()
            cbSQLServicePack.Text = record("DBPRODUCTSERVICEPACK").ToString()
            cbSQLEdition.Text = record("DBPRODUCTEDITION").ToString()
            cbSQLArchitecture.Text = record("DBPRODUCTARCHITECTURE").ToString()
            chbSQLClustered.Checked = Convert.ToBoolean(record("DBPRODUCTCLUSTERED"))
            tbProductLanguage.Text = record("DBPRUDUCTLANGUAGE").ToString()
            tbSQLCollation.Text = record("DBPRODUCTCOLLATION").ToString()
            cbServiceMode.Text = record("DBSERVICEMODE").ToString()
            cbServiceState.Text = record("DBSERVICESTATE").ToString()
            chbSQLMonitored.Checked = Convert.ToBoolean(record("DBSERVICEMOMMONITORED"))
            tbSQLNotes.Text = record("DBPRODUCTNOTES").ToString()
            tbDefaultSQLData.Text = record("DBDATALOCATION").ToString()
            tbDefaultSQLLogs.Text = record("DBLOGLOCATION").ToString()
            tbSQLBackupPath.Text = record("DBBACKUPSLOCATION").ToString()
            chbReplicated.Checked = Convert.ToBoolean(record("DBREPLICATION"))
            chbBackedUp.Checked = Convert.ToBoolean(record("DBBACKUPEDBYSDODB"))
            chbSDOBackupInformed.Checked = Convert.ToBoolean(record("SDOBACKUPTEAMINFO"))
            tbInstalledDate.Text = record("INSTALLEDDATE").ToString()
            tbInstalledBy.Text = record("INSTALLEDBY").ToString()
            tbRemovedDate.Text = record("REMOVEDDATE").ToString()
            tbRemovedBy.Text = record("REMOVEDBY").ToString()
            chbNetApp.Checked = Convert.ToBoolean(record("NETAPP"))
            tbNetAppPrimary.Text = record("NETAPP_PRIMARY_STORAGE").ToString()
            tbNetAppSecondary.Text = record("NETAPP_SECONDARY_STORAGE").ToString()
            chbLicense.Checked = Convert.ToBoolean(record("SQL_LICENSED"))
            tbTicketNumber.Text = record("TICKET_NUMBER").ToString()
            tbRequestor.Text = record("REQUESTOR").ToString()
            tbAppOwner.Text = record("APP_OWNER").ToString()
            tbAppGroup.Text = record("APP_GROUP").ToString()
            tbContact.Text = record("CONTACT_PERSON").ToString()
            tbDNSAlias.Text = record("DNS_ALIAS").ToString()
            tbWindowsClusterName.Text = record("SQL_CLUSTER_NETWORK_NAME").ToString()
            cbLicenseType.Text = record("SQL_LICENSETYPE").ToString()
            tbLicenseQTY.Text = record("SQL_LICENSEQTY_CALS").ToString()
            cbLicenseOwner.Text = record("SQL_LICENSECOVERAGE").ToString()
        End Sub

    End Class
End Namespace


