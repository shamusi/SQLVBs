<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLServerEvidence
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SQLServerEvidence))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewServerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddDBInstanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewDBInstanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADDEDREMOVEDServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cbsearchforDB = New System.Windows.Forms.CheckBox()
        Me.btSearchDB = New System.Windows.Forms.Button()
        Me.tbsearchDB = New System.Windows.Forms.TextBox()
        Me.lblSearchDB = New System.Windows.Forms.Label()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ScoreCardCapacity = New System.Windows.Forms.ListBox()
        Me.FSN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditSQLInstanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblrecord = New System.Windows.Forms.Label()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem1, Me.ReportToolStripMenuItem1, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1292, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem1
        '
        Me.MenuToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewServerToolStripMenuItem1, Me.AddDBInstanceToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem1.Name = "MenuToolStripMenuItem1"
        Me.MenuToolStripMenuItem1.Size = New System.Drawing.Size(45, 20)
        Me.MenuToolStripMenuItem1.Text = "Menu"
        '
        'AddNewServerToolStripMenuItem1
        '
        Me.AddNewServerToolStripMenuItem1.Name = "AddNewServerToolStripMenuItem1"
        Me.AddNewServerToolStripMenuItem1.Size = New System.Drawing.Size(154, 22)
        Me.AddNewServerToolStripMenuItem1.Text = "Add New Server"
        '
        'AddDBInstanceToolStripMenuItem
        '
        Me.AddDBInstanceToolStripMenuItem.Name = "AddDBInstanceToolStripMenuItem"
        Me.AddDBInstanceToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AddDBInstanceToolStripMenuItem.Text = "Add DB Instance"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ReportToolStripMenuItem1
        '
        Me.ReportToolStripMenuItem1.Name = "ReportToolStripMenuItem1"
        Me.ReportToolStripMenuItem1.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem1.Text = "Report"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ViewHelpToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ViewHelpToolStripMenuItem
        '
        Me.ViewHelpToolStripMenuItem.Name = "ViewHelpToolStripMenuItem"
        Me.ViewHelpToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ViewHelpToolStripMenuItem.Text = "View Help"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'AddNewServerToolStripMenuItem
        '
        Me.AddNewServerToolStripMenuItem.Name = "AddNewServerToolStripMenuItem"
        Me.AddNewServerToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.AddNewServerToolStripMenuItem.Text = "Add New Server"
        '
        'AddNewDBInstanceToolStripMenuItem
        '
        Me.AddNewDBInstanceToolStripMenuItem.Name = "AddNewDBInstanceToolStripMenuItem"
        Me.AddNewDBInstanceToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.AddNewDBInstanceToolStripMenuItem.Text = "Add New DB Instance"
        '
        'ShowAllServersToolStripMenuItem
        '
        Me.ShowAllServersToolStripMenuItem.Name = "ShowAllServersToolStripMenuItem"
        Me.ShowAllServersToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ShowAllServersToolStripMenuItem.Text = "Exit"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDEDREMOVEDServersToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'ADDEDREMOVEDServersToolStripMenuItem
        '
        Me.ADDEDREMOVEDServersToolStripMenuItem.Name = "ADDEDREMOVEDServersToolStripMenuItem"
        Me.ADDEDREMOVEDServersToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.ADDEDREMOVEDServersToolStripMenuItem.Text = "ADDED/REMOVED Servers"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(715, 39)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(321, 20)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "SDODB Database Servers Evidence "
        '
        'cbsearchforDB
        '
        Me.cbsearchforDB.AutoSize = True
        Me.cbsearchforDB.Location = New System.Drawing.Point(16, 19)
        Me.cbsearchforDB.Name = "cbsearchforDB"
        Me.cbsearchforDB.Size = New System.Drawing.Size(124, 17)
        Me.cbsearchforDB.TabIndex = 2
        Me.cbsearchforDB.Text = "Search for Database"
        Me.cbsearchforDB.UseVisualStyleBackColor = True
        '
        'btSearchDB
        '
        Me.btSearchDB.Location = New System.Drawing.Point(150, 68)
        Me.btSearchDB.Name = "btSearchDB"
        Me.btSearchDB.Size = New System.Drawing.Size(75, 23)
        Me.btSearchDB.TabIndex = 3
        Me.btSearchDB.Text = "Search"
        Me.btSearchDB.UseVisualStyleBackColor = True
        '
        'tbsearchDB
        '
        Me.tbsearchDB.Location = New System.Drawing.Point(117, 42)
        Me.tbsearchDB.Name = "tbsearchDB"
        Me.tbsearchDB.Size = New System.Drawing.Size(154, 20)
        Me.tbsearchDB.TabIndex = 4
        '
        'lblSearchDB
        '
        Me.lblSearchDB.AutoSize = True
        Me.lblSearchDB.Location = New System.Drawing.Point(2, 45)
        Me.lblSearchDB.Name = "lblSearchDB"
        Me.lblSearchDB.Size = New System.Drawing.Size(109, 13)
        Me.lblSearchDB.TabIndex = 5
        Me.lblSearchDB.Text = "looking for database :"
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AllowUserToOrderColumns = True
        Me.DG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle2
        Me.DG.Location = New System.Drawing.Point(296, 105)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG.Size = New System.Drawing.Size(984, 559)
        Me.DG.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ScoreCardCapacity)
        Me.GroupBox1.Controls.Add(Me.FSN)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblSearchDB)
        Me.GroupBox1.Controls.Add(Me.tbsearchDB)
        Me.GroupBox1.Controls.Add(Me.cbsearchforDB)
        Me.GroupBox1.Controls.Add(Me.btSearchDB)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 463)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SDO DB Evidence"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 242)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "ScoreCards Overview"
        '
        'ScoreCardCapacity
        '
        Me.ScoreCardCapacity.BackColor = System.Drawing.SystemColors.Menu
        Me.ScoreCardCapacity.Enabled = False
        Me.ScoreCardCapacity.FormattingEnabled = True
        Me.ScoreCardCapacity.Location = New System.Drawing.Point(36, 258)
        Me.ScoreCardCapacity.Name = "ScoreCardCapacity"
        Me.ScoreCardCapacity.Size = New System.Drawing.Size(209, 199)
        Me.ScoreCardCapacity.TabIndex = 9
        '
        'FSN
        '
        Me.FSN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.FSN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.FSN.Location = New System.Drawing.Point(117, 97)
        Me.FSN.Name = "FSN"
        Me.FSN.Size = New System.Drawing.Size(154, 20)
        Me.FSN.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Find Server Name:"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditSQLInstanceToolStripMenuItem, Me.EditServerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 48)
        '
        'EditSQLInstanceToolStripMenuItem
        '
        Me.EditSQLInstanceToolStripMenuItem.Image = Global.SQLinstances.My.Resources.Resources.edit
        Me.EditSQLInstanceToolStripMenuItem.Name = "EditSQLInstanceToolStripMenuItem"
        Me.EditSQLInstanceToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditSQLInstanceToolStripMenuItem.Text = "Edit SQL Instance"
        '
        'EditServerToolStripMenuItem
        '
        Me.EditServerToolStripMenuItem.Image = Global.SQLinstances.My.Resources.Resources.edit
        Me.EditServerToolStripMenuItem.Name = "EditServerToolStripMenuItem"
        Me.EditServerToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditServerToolStripMenuItem.Text = "Edit Server"
        '
        'lblrecord
        '
        Me.lblrecord.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblrecord.AutoSize = True
        Me.lblrecord.Location = New System.Drawing.Point(1145, 679)
        Me.lblrecord.Name = "lblrecord"
        Me.lblrecord.Size = New System.Drawing.Size(42, 13)
        Me.lblrecord.TabIndex = 9
        Me.lblrecord.Text = "Record"
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnrefresh.Location = New System.Drawing.Point(309, 670)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 24)
        Me.btnrefresh.TabIndex = 10
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Image = Global.SQLinstances.My.Resources.Resources.database2
        Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'SQLServerEvidence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1292, 696)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.lblrecord)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SQLServerEvidence"
        Me.Text = "SQLServerEvidence"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewDBInstanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllServersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cbsearchforDB As System.Windows.Forms.CheckBox
    Friend WithEvents btSearchDB As System.Windows.Forms.Button
    Friend WithEvents tbsearchDB As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchDB As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FSN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADDEDREMOVEDServersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MenuToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewServerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddDBInstanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditSQLInstanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblrecord As System.Windows.Forms.Label
    Friend WithEvents ScoreCardCapacity As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnrefresh As System.Windows.Forms.Button
    Friend WithEvents EditServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewHelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
