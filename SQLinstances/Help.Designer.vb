<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Help
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
        Me.H1 = New System.Windows.Forms.Label()
        Me.H2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'H1
        '
        Me.H1.AutoSize = True
        Me.H1.Location = New System.Drawing.Point(56, 44)
        Me.H1.Name = "H1"
        Me.H1.Size = New System.Drawing.Size(227, 13)
        Me.H1.TabIndex = 0
        Me.H1.Text = "About SQL DB server Evidence - version 2.05 "
        '
        'H2
        '
        Me.H2.AutoSize = True
        Me.H2.Location = New System.Drawing.Point(29, 71)
        Me.H2.Name = "H2"
        Me.H2.Size = New System.Drawing.Size(306, 13)
        Me.H2.TabIndex = 1
        Me.H2.Text = "Created by Shamusi Lasisi ©2015 Ceskomoravsky Cement, a.s."
        '
        'Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 169)
        Me.Controls.Add(Me.H2)
        Me.Controls.Add(Me.H1)
        Me.MaximizeBox = False
        Me.Name = "Help"
        Me.Text = "SQL DB server Evidence"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents H1 As System.Windows.Forms.Label
    Friend WithEvents H2 As System.Windows.Forms.Label
End Class
