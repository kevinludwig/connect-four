<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EngineForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.xCancelButton = New System.Windows.Forms.Button
        Me.xAcceptButton = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xCancelButton
        '
        Me.xCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xCancelButton.Location = New System.Drawing.Point(158, 159)
        Me.xCancelButton.Margin = New System.Windows.Forms.Padding(4)
        Me.xCancelButton.Name = "xCancelButton"
        Me.xCancelButton.Size = New System.Drawing.Size(133, 28)
        Me.xCancelButton.TabIndex = 0
        Me.xCancelButton.Text = Global.C4.My.Resources.Resources.DialogCancel
        Me.xCancelButton.UseVisualStyleBackColor = True
        '
        'xAcceptButton
        '
        Me.xAcceptButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xAcceptButton.Location = New System.Drawing.Point(17, 159)
        Me.xAcceptButton.Margin = New System.Windows.Forms.Padding(4)
        Me.xAcceptButton.Name = "xAcceptButton"
        Me.xAcceptButton.Size = New System.Drawing.Size(133, 28)
        Me.xAcceptButton.TabIndex = 1
        Me.xAcceptButton.Text = Global.C4.My.Resources.Resources.DialogOK
        Me.xAcceptButton.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {Global.C4.My.Resources.Resources.EngineFormAlphaBeta, Global.C4.My.Resources.Resources.EngineFormNegaMax, Global.C4.My.Resources.Resources.EngineFormNegaScout})
        Me.ComboBox1.Location = New System.Drawing.Point(152, 31)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(139, 24)
        Me.ComboBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Algorithm"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(152, 71)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(59, 22)
        Me.NumericUpDown1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Search Depth"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(54, 110)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(151, 21)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Play random moves"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'EngineForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 202)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.xAcceptButton)
        Me.Controls.Add(Me.xCancelButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "EngineForm"
        Me.Text = "Choose Program Difficulty"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents xCancelButton As System.Windows.Forms.Button
    Friend WithEvents xAcceptButton As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
