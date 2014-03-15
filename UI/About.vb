Public Class AboutDialog
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Text1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(28, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(196, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Text2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(28, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(28, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(196, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Text3"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(204, 99)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "OK"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(28, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(196, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Text2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AboutDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(320, 134)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "AboutDialog"
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Event Handlers"
    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = String.Format("Program Name: {0}", Application.ProductName)
        Label2.Text = String.Format("Company: {0}", Application.CompanyName)
        Label5.Text = String.Format("Version: {0}", Application.ProductVersion)
        Label4.Text = "Copyright 2006, All rights reserved"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
#End Region

End Class
