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
Imports SQLinstances.SQLInstances

Public Class EditSQLServers

    Private Sub btnS_Server_Click(sender As System.Object, e As System.EventArgs) Handles btnS_Server.Click
        finddata_2(tbFServer.Text.ToString())
    End Sub

    Private EditServerDataAccess As New EditServerDataAccess()
    ' Class to communicate with SQL Server database
    Private appdefaults As New My.MySettings()
    ' Read Default App Settings

    Private Sub finddata_2(InstanceServerName As String)
        Try
            Dim sqldetail As New SQLInstances.ServerInstance()
            sqldetail.SERVERservername = tbFServer.Text.ToString()
            Dim ds As New DataSet()
           

                ds = EditServerDataAccess.SearchServerInstance(sqldetail)
                dataGridView2.DataSource = ds.Tables(0)
                dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
          
                    ' Create New Styles for DataGrid View.
                    Dim columnHeaderStyle As New DataGridViewCellStyle()
                    Dim cellsStyle As New DataGridViewCellStyle()

                    Me.dataGridView2.Columns(1).Frozen = True
                    ' Hide SQL Server Instance ID
                    dataGridView2.Columns(0).Visible = False


                    '' Hide everything from column # 7
                    'For i As Integer = 8 To dataGridView2.ColumnCount - 1
                    '    dataGridView2.Columns(i).Visible = False
                    'Next
                    ' Rename Header Texts
                    dataGridView2.Columns(1).HeaderText = "SERVER NAME"
                    dataGridView2.Columns(2).HeaderText = "IP ADDRESS"
                    dataGridView2.Columns(3).HeaderText = "COUNTRY"
                    dataGridView2.Columns(4).HeaderText = "RESPONSIBILITY"
                    dataGridView2.Columns(5).HeaderText = "STATUS"
                    dataGridView2.Columns(6).HeaderText = "LOCATION"




                    'Dim wi As WindowsIdentity = WindowsIdentity.GetCurrent()
                    '' Identify current user - It is used for further records
                    'tbUpdatedBy.Text = wi.Name.ToString()
                    '' Update textbox with Current User
                    '' Update TextBox with Current DateTime
                    ''               }
                    ''                     
                    'tbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
       

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try


    End Sub




    Private Sub dataGridView2_MouseClick(sender As Object, e As MouseEventArgs) Handles dataGridView2.MouseClick
        ' Check if Right-click as been done on DataGrid view.
        ' Chose row over which has ben done
        ' Show Context menu and trigger required action

        If e.Button = MouseButtons.Right Then
            Dim m As New ContextMenu()
            Dim currentMouseOverRow As Integer = dataGridView2.HitTest(e.X, e.Y).RowIndex

            If currentMouseOverRow >= 0 Then
                ' Add Context Menu and event handlers
                dataGridView2.ClearSelection()
                dataGridView2.Rows(currentMouseOverRow).Selected = True
                m.MenuItems.Add(New MenuItem("Edit", New EventHandler(AddressOf btnEdit_Click)))
                'm.MenuItems.Add(New MenuItem("Update", New EventHandler(AddressOf btnUpdate_Click)))
            End If

            m.Show(dataGridView2, New Point(e.X, e.Y))
        End If
    End Sub


    Public Sub btnEdit_Click(sender As Object, e As EventArgs)
        ' Get SQL Instance Details
        Dim sqldetail As New SQLInstances.ServerInstance()
        ' Select Unique ID of the server
        sqldetail.SERVERserverID = Convert.ToInt32(dataGridView2.SelectedCells(0).Value)
        Dim record As DataRow = EditServerDataAccess.SelectSingleRecord(sqldetail)


        tbSQLServerName_1.Text = record("servername").ToString()
        tbIPaddress.Text = record("serveripaddress").ToString()
        tbCountryCode.Text = record("country").ToString()
        cbSDORes.Text = record("responsibility").ToString()
        cbStatus.Text = record("status").ToString()
        tblocation.Text = record("location").ToString()
        cbImportance.Text = record("criticity").ToString()
        tbServerNotes.Text = record("notes").ToString()
        chbServerRes.Checked = Convert.ToBoolean(record("sdodbscope"))
        cbServerMonitored.Checked = Convert.ToBoolean(record("mommonitored"))
        cbServertype.Checked = Convert.ToBoolean(record("virtual"))
        cbClustered.Checked = Convert.ToBoolean(record("SERVERCLUSTERED"))
        cbOSName.Text = record("SERVEROS").ToString()
        tblangauge.Text = record("SERVERLANGUAGE").ToString()
        tbSP.Text = record("SERVEROSSP").ToString()
        cbOSArch.Text = record("OSARCHITECTURE").ToString()
        tbCPU.Text = record("OSCPUCOUNT").ToString()
        tbLPC.Text = record("OSLOGICALPROCESSORS").ToString()
        tbMHZ.Text = record("CPUFREQUENCY").ToString()
        tbRAM.Text = record("SYSTEMMEMORYGB").ToString()
        cbOSEdition.Text = record("SERVEREDITION").ToString()
        tbVCN.Text = record("VMWARE_CLUSTER").ToString()
        tbVIC.Text = record("VMWARE_VIC").ToString()
    End Sub

    Private Sub btnEdit_Click()
        Throw New NotImplementedException
    End Sub


    Private Sub tbFServer_KeyUp(sender As Object, e As KeyEventArgs)
        ' If ENTER is pressed on textbox then automatically will find the server name.
        If e.KeyCode = Keys.Enter Then
            finddata_2(tbFServer.Text.ToString())
        End If
    End Sub

    Public Sub cleanForm()
        ' Reset Mandatory GroupBox 
        For Each cntrl As Control In GpOSName.Controls

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
        'For Each cntrl As Control In gbSQLServerInfo.Controls

        '    If cntrl.[GetType]() = GetType(TextBox) Then
        '        If (cntrl.Name <> "tbUpdatedBy") And (cntrl.Name <> "tbDateTime") Then
        '            cntrl.Text = String.Empty
        '        End If
        '    End If
        '    If cntrl.[GetType]() = GetType(CheckBox) Then
        '        DirectCast(cntrl, CheckBox).Checked = False
        '    End If
        '    If cntrl.[GetType]() = GetType(ComboBox) Then
        '        'cntrl.ResetText();
        '        DirectCast(cntrl, ComboBox).SelectedIndex = -1

        '    End If
        'Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        cleanForm()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If dataGridView2 IsNot Nothing AndAlso dataGridView2.CurrentRow IsNot Nothing Then
            If MessageBox.Show("Do you want to update SQL Server Name: " + dataGridView2.CurrentRow.Cells(1).Value.ToString() + vbLf & "Be carefull you are always updating record of selected ROW!!!", "Confirm Update", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    'Nullable<DateTime> _dateSample;
                    Dim sqldetail As New SQLInstances.ServerInstance()

                    sqldetail.SERVERserverID = CInt(dataGridView2.CurrentRow.Cells(0).Value)
                    sqldetail.SERVERservername = tbSQLServerName_1.Text.ToString()
                    sqldetail.SERVERserveripaddress = tbIPaddress.Text.ToString()
                    sqldetail.SERVERcountry = tbCountryCode.Text.ToString()
                    sqldetail.SERVERresponsibility = cbSDORes.Text.ToString()
                    sqldetail.SERVERstatus = cbStatus.Text.ToString()
                    sqldetail.SERVERlocation = tblocation.Text.ToString()
                    sqldetail.SERVERcriticity = cbImportance.Text.ToString()
                    sqldetail.SERVERnotes = tbServerNotes.Text.ToString()
                    sqldetail.SERVERsdodbscope = chbServerRes.Checked
                    sqldetail.SERVERmommonitored = cbServerMonitored.Checked
                    sqldetail.SERVERvirtual = cbServertype.Checked
                    sqldetail.SERVERSERVERCLUSTERED = cbClustered.Checked
                    sqldetail.SERVERSERVEROS = cbOSName.Text.ToString()
                    sqldetail.SERVERSERVERLANGUAGE = tblangauge.Text.ToString()
                    sqldetail.SERVERSERVEROSSP = tbSP.Text.ToString()
                    sqldetail.SERVEROSARCHITECTURE = cbOSArch.Text.ToString()
                    sqldetail.SERVERCPUFREQUENCY = tbCPU.Text.ToString()
                    sqldetail.SERVEROSCPUCOUNT = tbLPC.Text.ToString()
                    sqldetail.SERVEROSLOGICALPROCESSORS = tbMHZ.Text.ToString()
                    sqldetail.SERVERSYSTEMMEMORYGB = tbRAM.Text.ToString()
                    sqldetail.SERVERSERVEREDITION = cbOSEdition.Text.ToString()
                    sqldetail.SERVERVMWARE_CLUSTER = tbVCN.Text.ToString()
                    sqldetail.SERVERVMWARE_VIC = tbVIC.Text.ToString()

                    ' Ensure that there is not empty date in the form. Causing issues during UPDATE!


                    EditServerDataAccess.UpdateServerInstanceTable(sqldetail)
                    MessageBox.Show("Your data have been sucessfully Updated!", "Success")
                    ' cleanup form
                    cleanForm()
                    ' refresh data
                    'showdata()
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error!")
                End Try
            End If

        ElseIf SQLServerEvidence.DG.CurrentRow.Cells(0).Value Then

            If MessageBox.Show("Do you want to update SQL Server Name: " + SQLServerEvidence.DG.CurrentRow.Cells(1).Value.ToString() + vbLf & "Be carefull you are always updating record of selected ROW!!!", "Confirm Update", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    'Nullable<DateTime> _dateSample;
                    Dim sqldetail As New SQLInstances.ServerInstance()

                    'sqldetail.SERVERserverID = CInt(SQLServerEvidence.DG.CurrentRow.Cells(0).Value)
                    'sqldetail.SERVERserverID = CInt(SQLServerEvidence.DG.CurrentRow.Cells(0).Value) "Select ss.id from SDODB_Instances SI cross apply SDODB_Servers as SS where ss.servername =  si.INSTANCE_SERVERNAME and ss.SERVERNAME = 'tbSQLServerName_1.Text.ToString()'"
                    sqldetail.SERVERservername = tbSQLServerName_1.Text.ToString()
                    sqldetail.SERVERserveripaddress = tbIPaddress.Text.ToString()
                    sqldetail.SERVERcountry = tbCountryCode.Text.ToString()
                    sqldetail.SERVERresponsibility = cbSDORes.Text.ToString()
                    sqldetail.SERVERstatus = cbStatus.Text.ToString()
                    sqldetail.SERVERlocation = tblocation.Text.ToString()
                    sqldetail.SERVERcriticity = cbImportance.Text.ToString()
                    sqldetail.SERVERnotes = tbServerNotes.Text.ToString()
                    sqldetail.SERVERsdodbscope = chbServerRes.Checked
                    sqldetail.SERVERmommonitored = cbServerMonitored.Checked
                    sqldetail.SERVERvirtual = cbServertype.Checked
                    sqldetail.SERVERSERVERCLUSTERED = cbClustered.Checked
                    sqldetail.SERVERSERVEROS = cbOSName.Text.ToString()
                    sqldetail.SERVERSERVERLANGUAGE = tblangauge.Text.ToString()
                    sqldetail.SERVERSERVEROSSP = tbSP.Text.ToString()
                    sqldetail.SERVEROSARCHITECTURE = cbOSArch.Text.ToString()
                    sqldetail.SERVERCPUFREQUENCY = tbCPU.Text.ToString()
                    sqldetail.SERVEROSCPUCOUNT = tbLPC.Text.ToString()
                    sqldetail.SERVEROSLOGICALPROCESSORS = tbMHZ.Text.ToString()
                    sqldetail.SERVERSYSTEMMEMORYGB = tbRAM.Text.ToString()
                    sqldetail.SERVERSERVEREDITION = cbOSEdition.Text.ToString()
                    sqldetail.SERVERVMWARE_CLUSTER = tbVCN.Text.ToString()
                    sqldetail.SERVERVMWARE_VIC = tbVIC.Text.ToString()

                    ' Ensure that there is not empty date in the form. Causing issues during UPDATE!


                    EditServerDataAccess.UpdateServerInstanceTable(sqldetail)
                    MessageBox.Show("Your data have been sucessfully Updated!", "Success")
                    ' cleanup form
                    cleanForm()
                    ' refresh data
                    'showdata()
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error!")
                End Try
            End If
        End If

    End Sub

  
  
    Private Sub btnInsert_Click(sender As System.Object, e As System.EventArgs) Handles btnInsert.Click
        ' This will insert new data from WinForm to Database!
        ' It is not perfectly treat ... if you find some issues in inserting empty data into database, you have to fix it here!
        ' Validation is functional only on EMPTY STRINGS See ValidateTheForm() function.
        If ValidateTheForm() = True Then
            If MessageBox.Show("Add New SQL Server " + tbSQLServerName_1.Text.ToString(), "Confirm Insert", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Dim sqldetail As New SQLInstances.ServerInstance()


                sqldetail.SERVERservername = tbSQLServerName_1.Text.ToString()
                sqldetail.SERVERserveripaddress = tbIPaddress.Text.ToString()
                sqldetail.SERVERcountry = tbCountryCode.Text.ToString()
                sqldetail.SERVERresponsibility = cbSDORes.Text.ToString()
                sqldetail.SERVERstatus = cbStatus.Text.ToString()
                sqldetail.SERVERlocation = tblocation.Text.ToString()
                sqldetail.SERVERcriticity = cbImportance.Text.ToString()
                sqldetail.SERVERnotes = tbServerNotes.Text.ToString()
                sqldetail.SERVERsdodbscope = chbServerRes.Checked
                sqldetail.SERVERmommonitored = cbServerMonitored.Checked
                sqldetail.SERVERvirtual = cbServertype.Checked
                sqldetail.SERVERSERVERCLUSTERED = cbClustered.Checked
                sqldetail.SERVERSERVEROS = cbOSName.Text.ToString()
                sqldetail.SERVERSERVERLANGUAGE = tblangauge.Text.ToString()
                sqldetail.SERVERSERVEROSSP = tbSP.Text.ToString()
                sqldetail.SERVEROSARCHITECTURE = cbOSArch.Text.ToString()
                sqldetail.SERVERCPUFREQUENCY = tbCPU.Text.ToString()
                sqldetail.SERVEROSCPUCOUNT = tbLPC.Text.ToString()
                sqldetail.SERVEROSLOGICALPROCESSORS = tbMHZ.Text.ToString()
                sqldetail.SERVERSYSTEMMEMORYGB = tbRAM.Text.ToString()
                sqldetail.SERVERSERVEREDITION = cbOSEdition.Text.ToString()
                sqldetail.SERVERVMWARE_CLUSTER = tbVCN.Text.ToString()
                sqldetail.SERVERVMWARE_VIC = tbVIC.Text.ToString()
                Try
                    EditServerDataAccess.InsertServer(sqldetail)
                    grideview()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error")
                End Try
                'MessageBox.Show("Your record has been successfully inserted!", "Success")
                ' Clean The Form
                cleanForm()
                ' refresh data in data view.
            End If
        End If

    End Sub
    Public Function ValidateTheForm() As Boolean
        ' Get the list of all textboxes and check if those are not empty.
        Dim TextBoxCheck As TextBox() = {tbSQLServerName_1, tbIPaddress}
        For i As Integer = 0 To TextBoxCheck.Length - 1
            If TextBoxCheck(i).Text = String.Empty Then
                MessageBox.Show("You have forgot to fill some data!" & vbLf & "You will be now placed to missing textbox!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxCheck(i).Focus()
                Return False

            End If
        Next
        ' Check the comboboxes and ensure that those are not empty.
        Dim ComboCheck As ComboBox() = {cbOSName}
        For y As Integer = 0 To ComboCheck.Length - 1
            If String.IsNullOrEmpty(ComboCheck(y).Text) Then
                MessageBox.Show("You have forgot to fill some data!" & vbLf & "You will be now placed to missing combobox!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ComboCheck(y).Focus()
                Return False
            End If
        Next

        Return True
    End Function
   
    Private Sub btnS_Server_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Sub grideview()

        'dataGridView2.Rows.Clear()
        Dim i As Integer
        Dim Sqlcom As String = "select * from [SDODB_ServerEvidence].[dbo].[SDODB_Servers]"
        Dim appdefaults As New My.MySettings()
        Dim sDBserver As String = appdefaults.dbserver.ToString()
        Dim sDatabase As String = appdefaults.databasename.ToString()
        Dim sUser As String = appdefaults.login.ToString()
        Dim sPassword As String = appdefaults.password.ToString()
        Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
        con.Open()

        Dim sel As String = "select * from [SDODB_ServerEvidence].[dbo].[SDODB_Servers] where [ID] = (select top 1 [ID] from [SDODB_ServerEvidence].[dbo].[SDODB_Servers] ORDER BY ID DESC)"
        Dim cmdSql As New SqlCommand(sel, con)
        cmdSql.CommandType = CommandType.Text
        Dim sda As New SqlDataAdapter(cmdSql)
        sda.SelectCommand = cmdSql

        'With cmdSql
        '    .Parameters.Add("@Sale_Date", SqlDbType.DateTime).Value = DateTimePicker1.Text
        'End With

        Dim ds As New DataSet()
        sda.Fill(ds)

        dataGridView2.DataSource = ds.Tables("SaleInfo")

        dataGridView2.DataSource = ds.Tables(0)
        dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dataGridView2.Columns(1).HeaderText = "SERVER NAME"
        dataGridView2.Columns(2).HeaderText = "IP ADDRESS"

        con.Close()
    End Sub

    Private Sub EditSQLServers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        cbSDORes.SelectedIndex = 2
        cbStatus.SelectedIndex = 0
        cbImportance.SelectedIndex = 1
        cbOSArch.SelectedIndex = 0
        cbOSEdition.SelectedIndex = 1
    End Sub

    Private Sub FillsData_Click(sender As System.Object, e As System.EventArgs) Handles FillsData.Click
        'Dim WMIDetails As New clsWMI()
        'tbCPU.Text = WMIDetails.LogicalProcessor

        Dim getdata As New GetServerData
        tbCPU.Text = getdata.LogicalProcessors
        tbSP.Text = getdata.ServicePackVersion
        tbRAM.Text = getdata.PhysicalMemory
        cbOSName.Text = getdata.VersionName
        tbLPC.Text = getdata.LogicalProcessors
        tbMHZ.Text = getdata.Mhz
        tbVIC.Text = getdata.VIC
        tbVCN.Text = getdata.VMHost
        tbServerNotes.Text = getdata.SDEnumber
        tbIPaddress.Text = getdata.IP
        tbCountryCode.Text = getdata.country
        tblocation.Text = getdata.location
    End Sub



    Public Sub EditServer_from_mainForm()


        ' Get SQL Instance Details
        Dim sqldetail As New SQLInstances.ServerInstance()
        ' Select Unique ID of the server
        sqldetail.SERVERservername = Convert.ToString(SQLServerEvidence.DG.SelectedCells(1).Value)
        'sqldetail.SERVERserverID = Convert.ToInt32(SQLServerEvidence.DG.SelectedCells(0).Value)
        Dim record As DataRow = EditServerDataAccess.SelectSingleServerRecord(sqldetail)

        tbSQLServerName_1.Text = record("servername").ToString()
        tbIPaddress.Text = record("serveripaddress").ToString()
        tbCountryCode.Text = record("country").ToString()
        cbSDORes.Text = record("responsibility").ToString()
        cbStatus.Text = record("status").ToString()
        tblocation.Text = record("location").ToString()
        cbImportance.Text = record("criticity").ToString()
        tbServerNotes.Text = record("notes").ToString()
        chbServerRes.Checked = Convert.ToBoolean(record("sdodbscope"))
        cbServerMonitored.Checked = Convert.ToBoolean(record("mommonitored"))
        cbServertype.Checked = Convert.ToBoolean(record("virtual"))
        cbClustered.Checked = Convert.ToBoolean(record("SERVERCLUSTERED"))
        cbOSName.Text = record("SERVEROS").ToString()
        tblangauge.Text = record("SERVERLANGUAGE").ToString()
        tbSP.Text = record("SERVEROSSP").ToString()
        cbOSArch.Text = record("OSARCHITECTURE").ToString()
        tbCPU.Text = record("OSCPUCOUNT").ToString()
        tbLPC.Text = record("OSLOGICALPROCESSORS").ToString()
        tbMHZ.Text = record("CPUFREQUENCY").ToString()
        tbRAM.Text = record("SYSTEMMEMORYGB").ToString()
        cbOSEdition.Text = record("SERVEREDITION").ToString()
        tbVCN.Text = record("VMWARE_CLUSTER").ToString()
        tbVIC.Text = record("VMWARE_VIC").ToString()



    End Sub
End Class