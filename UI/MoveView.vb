Namespace UI

    Public Class MoveView
        Inherits UserControl

#Region "Private Class Data"
        Friend WithEvents ListView1 As System.Windows.Forms.ListView
        Private moveCounter As Integer = 0
#End Region

#Region "Construction Code"
        Public Sub New()

            InitializeComponent()

            BackColor = System.Drawing.Color.Beige
            Me.ListView1.GridLines = True
            Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Init()
            Me.ListView1.MultiSelect = False
            Me.ListView1.Name = "MoveView"
            Me.ListView1.UseCompatibleStateImageBehavior = False
            Me.ListView1.View = System.Windows.Forms.View.Details

        End Sub

        Private Sub Init()

            Me.ListView1.Columns.Add("#", 25)
            Me.ListView1.Columns.Add(My.Resources.MoveViewP1)
            Me.ListView1.Columns.Add(My.Resources.MoveViewP2)

            For i As Integer = 1 To 21
                Dim lvi As New ListViewItem(i.ToString())

                Me.ListView1.Items.Add(lvi)
            Next
        End Sub

        ''' <summary>
        ''' Control initialization code
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitializeComponent()
            Me.ListView1 = New System.Windows.Forms.ListView
            Me.SuspendLayout()
            '
            'ListView1
            '
            Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ListView1.Location = New System.Drawing.Point(0, 0)
            Me.ListView1.Name = "ListView1"
            Me.ListView1.Size = New System.Drawing.Size(150, 150)
            Me.ListView1.TabIndex = 0
            Me.ListView1.UseCompatibleStateImageBehavior = False
            '
            'MoveView
            '
            Me.Controls.Add(Me.ListView1)
            Me.Name = "MoveView"
            Me.ResumeLayout(False)

        End Sub
#End Region

#Region "Public Methods"
        ''' <summary>
        ''' Reset the view to a start of game state
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Reset()
            moveCounter = 0

            Me.ListView1.Clear()

            Init()

        End Sub

        ''' <summary>
        ''' Append a move to the view
        ''' </summary>
        ''' <param name="m">The move specified as square coordinates</param>
        ''' <remarks></remarks>
        Public Sub MakeMove(ByVal m As String)
            Dim n As Integer = Math.Floor(moveCounter / 2)

            ' Add to move view
            ListView1.Items(n).SubItems.Add(m)
            moveCounter += 1
        End Sub
#End Region

#Region "Public Properties"
        Public ReadOnly Property CurrentMove() As Integer
            Get
                Return Math.Floor(moveCounter / 2) + 1
            End Get
        End Property
#End Region
    End Class
End Namespace
