Public Class ColorsForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Board1.MakeMove("d1")
        Me.Board1.MakeMove("d2")
        Me.Board1.MakeMove("c1")
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents P2LightColorButton As System.Windows.Forms.Button
    Friend WithEvents P2DarkColorButton As System.Windows.Forms.Button
    Friend WithEvents P1LightColorButton As System.Windows.Forms.Button
    Friend WithEvents P1DarkColorButton As System.Windows.Forms.Button
    Friend WithEvents ShadowColorButton As System.Windows.Forms.Button
    Friend WithEvents BoardColorButton As System.Windows.Forms.Button
    Friend WithEvents BgColorButton As System.Windows.Forms.Button
    Friend WithEvents Board1 As C4.UI.Board
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents xCancelButton As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.P2LightColorButton = New System.Windows.Forms.Button
        Me.P2DarkColorButton = New System.Windows.Forms.Button
        Me.P1LightColorButton = New System.Windows.Forms.Button
        Me.P1DarkColorButton = New System.Windows.Forms.Button
        Me.ShadowColorButton = New System.Windows.Forms.Button
        Me.BoardColorButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.BgColorButton = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.OkButton = New System.Windows.Forms.Button
        Me.xCancelButton = New System.Windows.Forms.Button
        Me.Board1 = New C4.UI.Board
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.P2LightColorButton, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.P2DarkColorButton, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.P1LightColorButton, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.P1DarkColorButton, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ShadowColorButton, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.BoardColorButton, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.BgColorButton, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Board1, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(10, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(510, 312)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'P2LightColorButton
        '
        Me.P2LightColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.P2LightColorButton.Location = New System.Drawing.Point(126, 272)
        Me.P2LightColorButton.Name = "P2LightColorButton"
        Me.P2LightColorButton.Size = New System.Drawing.Size(36, 31)
        Me.P2LightColorButton.TabIndex = 8
        Me.P2LightColorButton.UseVisualStyleBackColor = True
        '
        'P2DarkColorButton
        '
        Me.P2DarkColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.P2DarkColorButton.Location = New System.Drawing.Point(126, 230)
        Me.P2DarkColorButton.Name = "P2DarkColorButton"
        Me.P2DarkColorButton.Size = New System.Drawing.Size(36, 29)
        Me.P2DarkColorButton.TabIndex = 8
        Me.P2DarkColorButton.UseVisualStyleBackColor = True
        '
        'P1LightColorButton
        '
        Me.P1LightColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.P1LightColorButton.Location = New System.Drawing.Point(126, 188)
        Me.P1LightColorButton.Name = "P1LightColorButton"
        Me.P1LightColorButton.Size = New System.Drawing.Size(36, 29)
        Me.P1LightColorButton.TabIndex = 8
        Me.P1LightColorButton.UseVisualStyleBackColor = True
        '
        'P1DarkColorButton
        '
        Me.P1DarkColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.P1DarkColorButton.Location = New System.Drawing.Point(126, 146)
        Me.P1DarkColorButton.Name = "P1DarkColorButton"
        Me.P1DarkColorButton.Size = New System.Drawing.Size(36, 29)
        Me.P1DarkColorButton.TabIndex = 8
        Me.P1DarkColorButton.UseVisualStyleBackColor = True
        '
        'ShadowColorButton
        '
        Me.ShadowColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShadowColorButton.Location = New System.Drawing.Point(126, 104)
        Me.ShadowColorButton.Name = "ShadowColorButton"
        Me.ShadowColorButton.Size = New System.Drawing.Size(36, 29)
        Me.ShadowColorButton.TabIndex = 8
        Me.ShadowColorButton.UseVisualStyleBackColor = True
        '
        'BoardColorButton
        '
        Me.BoardColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BoardColorButton.Location = New System.Drawing.Point(126, 62)
        Me.BoardColorButton.Name = "BoardColorButton"
        Me.BoardColorButton.Size = New System.Drawing.Size(36, 29)
        Me.BoardColorButton.TabIndex = 8
        Me.BoardColorButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = My.Resources.ColorFormBackground
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = My.Resources.ColorFormBoard
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = My.Resources.ColorFormShadow
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = My.Resources.ColorFormP1Dark
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = My.Resources.ColorFormP1Light
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = My.Resources.ColorFormP2Dark
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 284)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = My.Resources.ColorFormP2Light
        '
        'BgColorButton
        '
        Me.BgColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BgColorButton.Location = New System.Drawing.Point(126, 20)
        Me.BgColorButton.Name = "BgColorButton"
        Me.BgColorButton.Size = New System.Drawing.Size(36, 29)
        Me.BgColorButton.TabIndex = 7
        Me.BgColorButton.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(210, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(297, 17)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Preview Pane"
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(350, 357)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(99, 23)
        Me.OkButton.TabIndex = 2
        Me.OkButton.Text = My.Resources.DialogOK
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'xCancelButton
        '
        Me.xCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xCancelButton.Location = New System.Drawing.Point(462, 357)
        Me.xCancelButton.Name = "xCancelButton"
        Me.xCancelButton.Size = New System.Drawing.Size(99, 23)
        Me.xCancelButton.TabIndex = 3
        Me.xCancelButton.Text = My.Resources.DialogCancel
        Me.xCancelButton.UseVisualStyleBackColor = True
        '
        'Board1
        '
        Me.Board1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Board1.BoardColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Board1.Location = New System.Drawing.Point(210, 20)
        Me.Board1.Name = "Board1"
        Me.Board1.OutlineColor = System.Drawing.Color.LightGray
        Me.Board1.P1DarkColor = System.Drawing.Color.Red
        Me.Board1.P1LightColor = System.Drawing.Color.LightPink
        Me.Board1.P2DarkColor = System.Drawing.Color.Blue
        Me.Board1.P2LightColor = System.Drawing.Color.LightBlue
        Me.TableLayoutPanel1.SetRowSpan(Me.Board1, 7)
        Me.Board1.Size = New System.Drawing.Size(297, 289)
        Me.Board1.TabIndex = 9
        '
        'OptionsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(575, 391)
        Me.Controls.Add(Me.xCancelButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsForm"
        Me.Text = My.Resources.ColorsFormTitle
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private Class Data"
    Private _BackgroundColor As Color
    Private _ShadowColor As Color
    Private _BoardColor As Color
    Private _Player1DarkColor As Color
    Private _Player1LightColor As Color
    Private _Player2DarkColor As Color
    Private _Player2LightColor As Color
#End Region

#Region "Public Properties"
    Public Property BackgroundColor() As Color
        Get
            Return _BackgroundColor
        End Get
        Set(ByVal value As Color)
            _BackgroundColor = value
            BgColorButton.BackColor = value
            Board1.BackColor = value
        End Set
    End Property

    Public Property ShadowColor() As Color
        Get
            Return _ShadowColor
        End Get
        Set(ByVal value As Color)
            _ShadowColor = value
            ShadowColorButton.BackColor = value
            Board1.OutlineColor = value
        End Set
    End Property

    Public Property BoardColor() As Color
        Get
            Return _BoardColor
        End Get
        Set(ByVal value As Color)
            _BoardColor = value
            BoardColorButton.BackColor = value
            Board1.BoardColor = value
        End Set
    End Property

    Public Property Player1DarkColor() As Color
        Get
            Return Me._Player1DarkColor
        End Get
        Set(ByVal value As Color)
            Me._Player1DarkColor = value
            P1DarkColorButton.BackColor = value
            Board1.P1DarkColor = value
        End Set
    End Property

    Public Property Player1LightColor() As Color
        Get
            Return Me._Player1LightColor
        End Get
        Set(ByVal value As Color)
            Me._Player1LightColor = value
            P1LightColorButton.BackColor = value
            Board1.P1LightColor = value
        End Set
    End Property

    Public Property Player2DarkColor() As Color
        Get
            Return Me._Player2DarkColor
        End Get
        Set(ByVal value As Color)
            Me._Player2DarkColor = value
            Me.P2DarkColorButton.BackColor = value
            Board1.P2DarkColor = value
        End Set
    End Property

    Public Property Player2LightColor() As Color
        Get
            Return Me._Player2LightColor
        End Get
        Set(ByVal value As Color)
            Me._Player2LightColor = value
            Me.P2LightColorButton.BackColor = value
            Board1.P2LightColor = value
        End Set
    End Property
#End Region

#Region "Event Handlers"
    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub xCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xCancelButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub BgColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BgColorButton.Click
        Dim frm As New Windows.Forms.ColorDialog()

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            BackgroundColor = frm.Color
        End If
    End Sub

    Private Sub BoardColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoardColorButton.Click
        Dim frm As New Windows.Forms.ColorDialog()

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            BoardColor = frm.Color
        End If
    End Sub

    Private Sub ShadowColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShadowColorButton.Click
        Dim frm As New Windows.Forms.ColorDialog()

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ShadowColor = frm.Color
        End If
    End Sub

    Private Sub P1DarkColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P1DarkColorButton.Click
        Dim frm As New Windows.Forms.ColorDialog()

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Player1DarkColor = frm.Color
        End If
    End Sub

    Private Sub P1LightColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P1LightColorButton.Click
        Dim frm As New Windows.Forms.ColorDialog()

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Player1LightColor = frm.Color
        End If
    End Sub


    Private Sub P2DarkColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P2DarkColorButton.Click
        Dim frm As New Windows.Forms.ColorDialog()

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Player2DarkColor = frm.Color
        End If
    End Sub


    Private Sub P2LightColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P2LightColorButton.Click
        Dim frm As New Windows.Forms.ColorDialog()

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Player2LightColor = frm.Color
        End If
    End Sub
#End Region
End Class
