
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace SQLInstances
    ''' <summary>
    ''' Web Page Details Form
    ''' </summary>
    Partial Public Class ViewDetailsForm
        Inherits Form

        ''' <summary>
        ''' Pops up with new WebPage View
        ''' </summary>
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub ViewDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub

        Private Sub webBrowser_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs)
            ' Whatever goes here when navigated.
        End Sub
        ''' <summary>
        ''' Go to webpage ulr
        ''' </summary>
        ''' <param name="url">url address</param>
        Public Sub Go(url As String)
            Try
                webBrowser1.Navigate(url)
            Catch e As UriFormatException
                MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End Sub
   
        
        Private Sub webBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webBrowser1.DocumentCompleted
            ' Whatever goes here when Document Completed.
        End Sub

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewDetailsForm))
            Me.webBrowser1 = New System.Windows.Forms.WebBrowser()
            Me.SuspendLayout()
            '
            'webBrowser1
            '
            Me.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.webBrowser1.Location = New System.Drawing.Point(0, 0)
            Me.webBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
            Me.webBrowser1.Name = "webBrowser1"
            Me.webBrowser1.Size = New System.Drawing.Size(1042, 790)
            Me.webBrowser1.TabIndex = 1
            Me.webBrowser1.Url = New System.Uri("", System.UriKind.Relative)
            '
            'ViewDetailsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1042, 790)
            Me.Controls.Add(Me.webBrowser1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ViewDetailsForm"
            Me.Text = "ViewDetailsForm"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents webBrowser1 As System.Windows.Forms.WebBrowser


    End Class
End Namespace


