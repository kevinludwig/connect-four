Public Class EngineForm

#Region "Private Class Data"
    Private _SearchDepth As Integer
#End Region

#Region "Construction Code"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Public Properties"
    Public Property SearchDepth() As Integer
        Get
            Return NumericUpDown1.Value
        End Get
        Set(ByVal value As Integer)
            NumericUpDown1.Value = value
        End Set
    End Property

    Public Property Algorithm() As String
        Get
            Return ComboBox1.Items(ComboBox1.SelectedIndex)
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "AlphaBeta"
                    ComboBox1.SelectedIndex = 0
                Case "NegaMax"
                    ComboBox1.SelectedIndex = 1
                Case "NegaScout"
                    ComboBox1.SelectedIndex = 2

            End Select
        End Set
    End Property

    Public Property Random() As Boolean
        Get
            Return CheckBox1.Checked
        End Get
        Set(ByVal value As Boolean)
            CheckBox1.Checked = value
        End Set
    End Property
#End Region

#Region "Event Handlers"
    Private Sub xAcceptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xAcceptButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub xCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xCancelButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
#End Region


End Class