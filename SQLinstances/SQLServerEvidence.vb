Imports SQLinstances.SQLInstances
Imports System.Data.SqlClient
Imports SQLinstances.SQLInstances.SQLForm
Imports SQLinstances.SQLInstances.ViewDetailsForm

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Imports System.Text

Imports System.Data
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Threading.Tasks
Imports System.Net.Sockets

Public Class SQLServerEvidence
    Dim totalrecords As Integer
    Dim index As Integer = 0
    Dim table As New DataTable
    Dim Properties As Object

    Private Sub AddNewServerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewServerToolStripMenuItem.Click
        EditSQLServers.Show()
    End Sub

    Private Sub AddNewDBInstanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddNewDBInstanceToolStripMenuItem.Click
        SQLInstances.SQLForm.Show()
    End Sub

    Private Sub ShowAllServersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowAllServersToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SearchForDatabaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub SQLServerEvidence_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'DG.RowsDefaultCellStyle.BackColor = Color.LightGray
        'DG.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        lblSearchDB.Visible = False
        btSearchDB.Visible = False
        tbsearchDB.Visible = False


        GetServerInfo()
        'AutoCompleteTestBox()


        listCapacity()


    End Sub



    Private Sub cbsearchforDB_Click(sender As Object, e As System.EventArgs) Handles cbsearchforDB.Click
        If cbsearchforDB.Checked = True Then
            lblSearchDB.Visible = True
            btSearchDB.Visible = True
            tbsearchDB.Visible = True
        Else
            lblSearchDB.Visible = False
            btSearchDB.Visible = False
            tbsearchDB.Visible = False

        End If





    End Sub







    Private Sub SearchDB(InstanceServerName As String)
        Try

            Dim sqldetail As New SQLInstances.ServerInstance()
            sqldetail.SERVERdb_name = tbsearchDB.Text.ToString()
            Dim ds As New DataSet()



            ds = EditServerDataAccess.SearchDBInstance(sqldetail)
            DG.DataSource = ds.Tables(0)
            DG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            totalRecords = ds.Tables(0).Rows.Count
            ' Create New Styles for DataGrid View.
            Dim columnHeaderStyle As New DataGridViewCellStyle()
            Dim cellsStyle As New DataGridViewCellStyle()
            'ds.Clear()
            'ds.Dispose()
            'Me.DG.Columns(1).Frozen = True
            ' Hide SQL Server Instance ID
            'DG.Columns(0).Visible = False


            '' Hide everything from column # 7
            'For i As Integer = 8 To dataGridView2.ColumnCount - 1
            '    dataGridView2.Columns(i).Visible = False
            'Next
            ' Rename Header Texts
            DG.Columns(0).HeaderText = "SERVER NAME"
            DG.Columns(1).HeaderText = "DB NAME"
            DG.Columns(2).HeaderText = "INSTANCE NAME"
            DG.Columns(4).HeaderText = "PRODUCT"
            DG.Columns(5).HeaderText = "DB created"
            DG.Columns(6).HeaderText = "BACKUP LOCATION"
            'DG.Columns(6).HeaderText = "BACKUP LOCATION"


            lblrecord.Text = "Total records: " & totalrecords
        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try


    End Sub



    'Sub grideviewFORM()

    '    'dataGridView2.Rows.Clear()
    '    Dim i As Integer
    '    Dim Sqlcom As String = "select * from [SDODB_ServerEvidence].[dbo].[SDODB_Instances]"
    '    Dim appdefaults As New My.MySettings()
    '    Dim sDBserver As String = appdefaults.dbserver.ToString()
    '    Dim sDatabase As String = appdefaults.databasename.ToString()
    '    Dim sUser As String = appdefaults.login.ToString()
    '    Dim sPassword As String = appdefaults.password.ToString()
    '    Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
    '    con.Open()

    '    Dim sel As String = "select * from [SDODB_ServerEvidence].[dbo].[SDODB_Instances]where [ID] = (select top 1 [ID] from [SDODB_ServerEvidence].[dbo].[SDODB_Instances] ORDER BY ID DESC)"
    '    Dim cmdSql As New SqlCommand(sel, con)
    '    cmdSql.CommandType = CommandType.Text
    '    Dim sda As New SqlDataAdapter(cmdSql)
    '    sda.SelectCommand = cmdSql

    '    'With cmdSql
    '    '    .Parameters.Add("@Sale_Date", SqlDbType.DateTime).Value = DateTimePicker1.Text
    '    'End With

    '    Dim ds As New DataSet()
    '    sda.Fill(ds)

    '    dataGridView1.DataSource = ds.Tables("SaleInfo")

    '    dataGridView1.DataSource = ds.Tables(0)
    '    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    '    dataGridView1.Columns(1).HeaderText = "SERVER NAME"
    '    dataGridView1.Columns(2).HeaderText = "INSTANCE"

    '    con.Close()
    'End Sub




    Private Sub btSearchDB_Click(sender As System.Object, e As System.EventArgs) Handles btSearchDB.Click
        DG.Columns.Clear()
        'DG.Refresh()
        SearchDB(tbsearchDB.Text.ToString())
    End Sub


    Private Sub GetServerInfo()
        Dim table As New DataTable
        Dim appdefaults As New My.MySettings()
        Dim sDBserver As String = appdefaults.dbserver.ToString()
        Dim sDatabase As String = appdefaults.databasename.ToString()
        Dim sUser As String = appdefaults.login.ToString()
        Dim sPassword As String = appdefaults.password.ToString()
        Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
        con.Open()

        Dim strSQL As String = "select  [instanceID],[SERVERNAME],[DatabaseInstanceName],[InscopeSDODB],[COUNTRY],[ServerSTATUS],[DatabaseProduct],[DBEdition],[DatabaseVersion],[Monitored],[APP_OWNER],[CONTACT_PERSON] FROM [SDODB_ServerEvidence].[dbo].[usr_DefaultWebView]"
        Dim cmd As New SqlCommand(strSQL, con)
        'cmd.Parameters.AddWithValue("Parameter1", strName)

        Dim reader As SqlDataReader = cmd.ExecuteReader
        table.Load(reader)
        With DG
            .DataSource = table

        End With


        ''''''' Image and added column 
        Dim imageCol As New DataGridViewImageColumn
        imageCol.Name = "Server Status"
        'imageCol.DataPropertyName = "InscopeSDODB1"
        'DG.Columns.Add(imageCol)
        Dim dt As New DataTable

        dt = table

        dt.Columns.Add("Server Status", System.Type.GetType("System.Byte[]"))
        'For Each row As DataRow In dt.Rows
        '    DoIconImages(row, MyIcons)
        'Next

        Dim trueImg As New Bitmap(My.Resources._true)
        Dim falseImg As New Bitmap(My.Resources._false)

        For Each row As DataGridViewRow In DG.Rows
            If row.Cells("ServerSTATUS").Value IsNot Nothing Then
                If row.Cells("ServerSTATUS").Value = "Active" Then
                    ' Cells[12] is the position of the cell in the row
                    row.Cells(12).Value = trueImg
                Else
                    row.Cells(12).Value = falseImg
                End If
            End If
        Next

        ''''''' End Image and added column 




        totalrecords = table.Rows.Count
        lblrecord.Text = "Total records: " & totalrecords
        'Me.DG.Columns(1).Frozen = True
        DG.Columns(0).Visible = False
       



        'imagecolum()

        '------------------------------------------------
        'to show edit button in datagrid
        'Dim btn As New DataGridViewButtonColumn()
        'DG.Columns.Add(btn)
        'btn.HeaderText = "Edit Server"
        'btn.Text = "Edit"
        'btn.Name = "btn"
        'btn.UseColumnTextForButtonValue = True
        'Dim btn1 As New DataGridViewButtonColumn()
        'DG.Columns.Add(btn1)
        'btn1.HeaderText = "Edit DB Instance"
        'btn1.Text = "Edit"
        'btn1.Name = "btn"
        'btn1.UseColumnTextForButtonValue = True
        '-------------------------------------------
        reader.Close()
        con.Close()
        cmd.Dispose()

    End Sub

    Private Sub AddorRemoved_servers()
        Dim table As New DataTable
        Dim appdefaults As New My.MySettings()
        Dim sDBserver As String = appdefaults.dbserver.ToString()
        Dim sDatabase As String = appdefaults.databasename.ToString()
        Dim sUser As String = appdefaults.login.ToString()
        Dim sPassword As String = appdefaults.password.ToString()
        Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
        con.Open()

        Dim strSQL As String = "SELECT * FROM dbo.usr_DefaultWebView"
        Dim cmd As New SqlCommand(strSQL, con)
        'cmd.Parameters.AddWithValue("Parameter1", strName)

        Dim reader As SqlDataReader = cmd.ExecuteReader
        table.Load(reader)
        With DG

            .DataSource = table

        End With

        reader.Close()
        con.Close()
        cmd.Dispose()

    End Sub

    Private Sub AutoCompleteTestBox()
        Dim table As New DataTable
        Dim appdefaults As New My.MySettings()
        Dim sDBserver As String = appdefaults.dbserver.ToString()
        Dim sDatabase As String = appdefaults.databasename.ToString()
        Dim sUser As String = appdefaults.login.ToString()
        Dim sPassword As String = appdefaults.password.ToString()
        Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
        con.Open()

        Dim cmd As New SqlCommand("select  [SERVERNAME] FROM [SDODB_ServerEvidence].[dbo].[usr_AllServers]", con)

        Dim sda As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        sda.Fill(ds)
        cmd.ExecuteNonQuery()

        Dim r As DataRow

        FSN.AutoCompleteCustomSource.Clear()
        For Each r In ds.Tables(0).Rows
            FSN.AutoCompleteCustomSource.Add(r.Item(0).ToString)

        Next

        con.Close()
        cmd.Dispose()


    End Sub



    Private Sub ADDEDREMOVEDServersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ADDEDREMOVEDServersToolStripMenuItem.Click

    End Sub

    Private Sub FSN_TextChanged(sender As System.Object, e As System.EventArgs) Handles FSN.TextChanged
        lblrecord.Text = String.Empty
        Dim table As New DataTable
        Dim appdefaults As New My.MySettings()
        Dim sDBserver As String = appdefaults.dbserver.ToString()
        Dim sDatabase As String = appdefaults.databasename.ToString()
        Dim sUser As String = appdefaults.login.ToString()
        Dim sPassword As String = appdefaults.password.ToString()
        Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
        con.Open()

        Dim cmd As New SqlCommand("select [instanceID],[SERVERNAME],[DatabaseInstanceName],[InscopeSDODB],[COUNTRY],[ServerSTATUS],[DatabaseProduct],[DBEdition],[DatabaseVersion],[Monitored],[APP_OWNER],[CONTACT_PERSON] FROM [SDODB_ServerEvidence].[dbo].[usr_DefaultWebView]", con)

        Dim sda As New SqlDataAdapter(cmd)
        Dim ds As New DataTable
        'Dim ds As New DataSet()
        sda.Fill(ds)
        cmd.ExecuteNonQuery()


        'Dim Servername As String
        'Servername = FSN.Text
        'DG.DataSource = ds.Tables(0).DefaultView
        'ds.Tables(0).DefaultView.RowFilter = "Servername = '" & Servername & "'"

        Dim DVI As New DataView(ds)
        DVI.RowFilter = String.Format("SERVERNAME Like '%{0}%'", FSN.Text)
        DG.DataSource = DVI
        DG.Columns(0).Visible = False

        ''''''' Image and added column 
        Dim imageCol As New DataGridViewImageColumn
        imageCol.Name = "Server Status"

        ds.Columns.Add("Server Status", System.Type.GetType("System.Byte[]"))

        Dim trueImg As New Bitmap(My.Resources._true)
        Dim falseImg As New Bitmap(My.Resources._false)

        For Each row As DataGridViewRow In DG.Rows
            If row.Cells("ServerSTATUS").Value IsNot Nothing Then
                If row.Cells("ServerSTATUS").Value = "Active" Then
                    ' Cells[12] is the position of the cell in the row
                    row.Cells(12).Value = trueImg
                Else
                    row.Cells(12).Value = falseImg
                End If
            End If
        Next
        ''''''' End Image and added column 


        con.Close()


    End Sub

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
            Dim Explorer As New SQLInstances.ViewDetailsForm()
            Explorer.Show()
            ' Run GO with specifying address

            'Process.Start(address)
            Explorer.Go(address)


        Catch generatedExceptionName As System.UriFormatException
            Return
        End Try


    End Sub

    Private Sub DG_CellMouseUp(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DG.CellMouseUp
        'Right clicks
        Try
            If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.RowIndex > -1 Then
                Dim m As New ContextMenuStrip()
                DG.ClearSelection()
                DG.Rows(e.RowIndex).Selected = True

                index = e.RowIndex
                DG.CurrentCell = DG.Rows(e.RowIndex).Cells(1)

                ContextMenuStrip1.Show(DG, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)

                'AddHandler ContextMenuStrip1.ItemClicked, AddressOf SQLForm.Edit_from_mainForm
                'AddHandler ContextMenuStrip1.ItemClicked, AddressOf EditSQLServers.EditServer_from_mainForm

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error!")
        End Try
    End Sub
    Private Sub DG_DoubleClick(sender As Object, e As System.EventArgs) Handles DG.DoubleClick
        NavigateUrl("http://deusdheid0031/sdodbevidence/DBInstanceDetails.asp?id=" & CInt(DG.CurrentRow.Cells(0).Value))
    End Sub

    Private Sub DG_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DG.MouseClick
        '' Check if Right-click as been done on DataGrid view.
        '' Chose row over which has ben done
        '' Show Context menu and trigger required action

        'If e.Button = MouseButtons.Right Then
        '    Dim m As New ContextMenu()
        '    Dim currentMouseOverRow As Integer = DG.HitTest(e.X, e.Y).RowIndex

        '    If currentMouseOverRow >= 0 Then
        '        ' Add Context Menu and event handlers
        '        DG.ClearSelection()
        '        DG.Rows(currentMouseOverRow).Selected = True
        '        'm.MenuItems.Add(New MenuItem("Edit DB Evidence", New EventHandler(AddressOf btnEdit_Click)))


        '    End If

        '    m.Show(DG, New Point(e.X, e.Y))
        'End If
    End Sub

    Private Sub DG_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DG.RowPostPaint
        'If (e.RowIndex) < (Me.DG.Rows.Count - 1) Then
        '    ' DataGridView Change colors based on values DBSERVICEMODE = Disabled and DBSERVICESTATE = Stopped / Mark red because those are turned off.
        '    Dim gvr As DataGridViewRow = Me.DG.Rows(e.RowIndex)
        '    If (gvr.Cells("Monitored").Value) = "0" Then
        '        gvr.DefaultCellStyle.BackColor = Color.Pink
        '        ' Will check if Removed date and removedby collumns are filled up, then it means server was decommissioned.

        '    End If
        'End If
    End Sub

    Private Sub DG_RowPrePaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DG.RowPrePaint

    End Sub


    Private Sub AddNewServerToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AddNewServerToolStripMenuItem1.Click
        EditSQLServers.Show()
    End Sub

    Private Sub AddDBInstanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddDBInstanceToolStripMenuItem.Click
        SQLInstances.SQLForm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub DG_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellContentClick

    End Sub




    Private Sub ContextMenuStrip1_Click(sender As Object, e As System.EventArgs) Handles ContextMenuStrip1.Click

        AddHandler ContextMenuStrip1.ItemClicked, AddressOf SQLForm.Edit_from_mainForm
        'AddHandler ContextMenuStrip1.ItemClicked, AddressOf EditSQLServers.EditServer_from_mainForm



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ScoreCardCapacity.SelectedIndexChanged
   
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub listCapacity()

        Dim table As New DataTable
        Dim appdefaults As New My.MySettings()
        Dim sDBserver As String = appdefaults.dbserver.ToString()
        Dim sDatabase As String = appdefaults.databasename.ToString()
        Dim sUser As String = appdefaults.login.ToString()
        Dim sPassword As String = appdefaults.password.ToString()
        Dim con As New SqlConnection("Data Source=" + sDBserver + ";Initial Catalog=" + sDatabase + ";User ID=" + sUser + ";Password=" + sPassword)
        con.Open()

        Dim strSQL As String = "select * from [dbo].[usr_ScoreCards_Capacity]"
        Dim cmd As New SqlCommand(strSQL, con)
        'cmd.Parameters.AddWithValue("Parameter1", strName)

        Dim reader As SqlDataReader = cmd.ExecuteReader
        table.Load(reader)
        'With DG
        '    .DataSource = table

        'End With


        'While (reader.Read)

        'ScoreCardCapacity.Items.Add(reader.Item("value"))
        'ScoreCardCapacity.Items.Add(reader.Item("Number"))
        For Each row In table.Rows
            Dim sItemTemp As String
            sItemTemp = String.Format("{0}" & vbTab & "{1}", row("value"), row("Number")) & vbTab
            ScoreCardCapacity.Items.Add(sItemTemp)

        Next

        'End While





        reader.Close()
        con.Close()
        cmd.Dispose()

    End Sub

    Private Sub btnrefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnrefresh.Click
        DG.Columns.Clear()
        GetServerInfo()
    End Sub

    Private Sub lblrecord_Click(sender As System.Object, e As System.EventArgs) Handles lblrecord.Click

    End Sub

    'Public Sub imagecolum()
    '    ' Hiding checkbox values
    '    ' inscopeSDODB is the name of the column in which Checkbox values are displayed
    '    ' So change it according to your database
    '    DG.Columns("ServerSTATUS").Visible = False
    '    Dim imageCol As New DataGridViewImageColumn
    '    imageCol.Name = "SERVER STATE"
    '    imageCol.SortMode = DataGridViewColumnSortMode.Automatic
    '    DG.Columns.Add(imageCol)
    '    'Dim trueImg As Bitmap, falseImg As Bitmap

    '    Dim trueImg As New Bitmap(My.Resources._true)
    '    Dim falseImg As New Bitmap(My.Resources._false)

    '    'trueImg = DirectCast(Image.FromFile(Application.StartupPath + "\Images\true.png"), Bitmap)
    '    'falseImg = DirectCast(Image.FromFile(Application.StartupPath + "\Images\false.png"), Bitmap)
    '    For Each row As DataGridViewRow In DG.Rows

    '        If row.Cells("ServerSTATUS").Value IsNot Nothing Then
    '            If row.Cells("ServerSTATUS").Value = "Active" Then
    '                ' Cells[12] is the position of the cell in the row
    '                row.Cells(12).Value = trueImg
    '            Else
    '                row.Cells(12).Value = falseImg
    '            End If
    '        End If
    '        '#End Region
    '    Next

    'End Sub

    Private Sub EditSQLInstanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditSQLInstanceToolStripMenuItem.Click


        SQLForm.Show()
    End Sub

    'Private Sub EditServerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditServerToolStripMenuItem.Click

    '    EditSQLServers.Show()
    'End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Help.Show()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub
End Class