Namespace UI

    Public Class Board
        Inherits UserControl

#Region "Private class data"
        ' One element per column
        Public allColumns As New Generic.List(Of Column)
        Public SideToMove As Column.State

        Const MaxColumns As Integer = 7
        Const MaxRows As Integer = 6

        Event PlayerMoved(ByVal sender As Object, ByVal e As PlayerMovedEventArgs)

        Private SZ As Integer
        Const OutOfBounds As Integer = 99
        Private MouseColumn As Integer = OutOfBounds

        Public InteractiveP1 As Boolean = True
        Public InteractiveP2 As Boolean = False

        ' The cached board
        Private cache As Image

        ' Colors
        Private P1Color As Color() = {Color.Red, Color.LightPink}
        Private P2Color As Color() = {Color.Blue, Color.LightBlue}
        Private BColor As Color = Color.FromArgb(240, 240, 150)
        Private OColor As Color = Color.LightGray

        ' Brushes
        Private BoardBrush As New SolidBrush(BoardColor)
        Private BackBrush As SolidBrush

        ' Pens
        Private OutlinePen As New Pen(OColor)
#End Region

#Region "Construction Code"
        Public Sub Init()
            Dim I As Integer

            allColumns.Clear()

            For I = 1 To MaxColumns
                allColumns.Add(New Column)
            Next

            SideToMove = UI.Column.State.P1

            SZ = Math.Min(Size.Width, Size.Height) / 7
            SZ = Math.Max(SZ, 40)

            BackBrush = New SolidBrush(BackColor)

            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                        ControlStyles.DoubleBuffer Or _
                        ControlStyles.UserPaint, True)
        End Sub

        Public Sub New()
            Init()
        End Sub
#End Region

#Region "Properties"
        Protected ReadOnly Property Column(ByVal x As Integer) As Column
            Get
                Return allColumns(x)
            End Get
        End Property

        Public Property P1DarkColor() As Color
            Get
                Return P1Color(0)
            End Get
            Set(ByVal Value As Color)
                P1Color(0) = Value
                Me.Invalidate()
            End Set
        End Property

        Public Property P1LightColor() As Color
            Get
                Return P1Color(1)
            End Get
            Set(ByVal Value As Color)
                P1Color(1) = Value
                Me.Invalidate()
            End Set
        End Property

        Public Property P2DarkColor() As Color
            Get
                Return P2Color(0)
            End Get
            Set(ByVal Value As Color)
                P2Color(0) = Value
                Me.Invalidate()
            End Set
        End Property

        Public Property P2LightColor() As Color
            Get
                Return P2Color(1)
            End Get
            Set(ByVal Value As Color)
                P2Color(1) = Value
                Me.Invalidate()
            End Set
        End Property

        Public Property BoardColor() As Color
            Get
                Return BColor
            End Get
            Set(ByVal Value As Color)
                BColor = Value
                BoardBrush.Dispose()
                BoardBrush = New SolidBrush(BColor)
                Me.Invalidate()
            End Set
        End Property

        Public Property OutlineColor() As Color
            Get
                Return OColor
            End Get
            Set(ByVal Value As Color)
                OColor = Value
                OutlinePen.Dispose()
                OutlinePen = New Pen(OColor)
                Me.Invalidate()
            End Set
        End Property

        Public Overrides Property BackColor() As Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal value As Color)
                MyBase.BackColor = value
                Me.BackBrush.Dispose()
                BackBrush = New SolidBrush(value)
            End Set
        End Property
#End Region

#Region "Public functions"

        Public Function MakeMove(ByVal m As String) As Boolean
            Dim column As Integer = Convert.ToInt32(m.ToUpper()(0)) - 65
            Dim outMove As String = ""

            Dim result As Boolean = MakeMove(column, outMove)

            If result = True Then Me.Invalidate()

            Return result
        End Function

        Public Sub Reset()
            ' Reset the display
            Init()
            Me.Invalidate()
        End Sub
#End Region

#Region "Helper functions"

        Public Function MakeMove(ByVal column As Integer, ByRef strMove As String) As Boolean
            If column > MaxColumns - 1 Then
                Return False
            End If

            If allColumns(column).Top >= MaxRows Then
                Return False
            End If

            Dim x As Char = Microsoft.VisualBasic.ChrW(97 + column)

            strMove = String.Format("{0}{1}", x, allColumns(column).Top + 1)

            If allColumns(column).Add(SideToMove) = False Then
                Return False
            End If

            If SideToMove = UI.Column.State.P1 Then
                SideToMove = UI.Column.State.P2
            Else
                SideToMove = UI.Column.State.P1
            End If

            Return True
        End Function

        Private Sub DrawChecker(ByVal g As Graphics, ByVal r As Rectangle, ByVal c As Color())
            Dim r1 As New Rectangle(r.X + 5, r.Y + 5, r.Width - 10, r.Height - 10)
            Dim offset As Integer = SZ / 8
            Dim r2 As New Rectangle(r1.X + offset, r1.Y + offset, r1.Width - (offset * 2), r1.Height - (offset * 2))
            g.FillEllipse(New Drawing2D.LinearGradientBrush(r1, c(1), c(0), Drawing2D.LinearGradientMode.ForwardDiagonal), r1)
            g.FillEllipse(New Drawing2D.LinearGradientBrush(r2, c(0), c(1), Drawing2D.LinearGradientMode.ForwardDiagonal), r2)
        End Sub

        Private Sub DrawTopRow(ByRef g As Graphics)
            Dim i As Integer

            For i = 0 To 6
                Dim r As New Rectangle(i * SZ, 0, SZ, SZ)
                g.FillRectangle(BackBrush, r)

                If i = MouseColumn Then
                    If SideToMove = UI.Column.State.P1 Then
                        If InteractiveP1 Then
                            DrawChecker(g, r, P1Color)
                        End If
                    Else
                        If InteractiveP2 Then
                            DrawChecker(g, r, P2Color)
                        End If
                    End If
                End If
            Next

        End Sub

        Private Sub DrawEmpty(ByVal g As Graphics, ByVal r As Rectangle)
            Dim r1 As New Rectangle(r.X + 5, r.Y + 5, r.Width - 10, r.Height - 10)
            Dim r2 As New Rectangle(r1.X + 2, r1.Y + 2, r1.Width - 4, r1.Height - 4)

            g.FillRectangle(BoardBrush, r)
            DrawOutline(g, r)
            g.FillEllipse(New Drawing2D.LinearGradientBrush(r1, OColor, BackColor, Drawing2D.LinearGradientMode.ForwardDiagonal), r1)
            g.FillEllipse(BackBrush, r2)
        End Sub

        Private Sub DrawOutline(ByRef g As Graphics, ByVal r As Rectangle)
            g.DrawLine(OutlinePen, r.X + r.Width, r.Y, r.X + r.Width, r.Y + r.Height)
            g.DrawLine(OutlinePen, r.X + 6, r.Y + r.Height, r.X + SZ, r.Y + r.Height)
        End Sub

        Private Sub DrawColumn(ByRef g As Graphics, ByVal X As Integer)
            Dim i As Integer

            ' Get the column
            Dim col As Column = Column(X)

            Dim j As Integer = 6
            For i = 0 To 5
                Dim val As Column.State
                val = col.column.Item(i)

                If val = UI.Column.State.NotSet Then
                    DrawEmpty(g, New Rectangle(X * SZ, j * SZ, SZ, SZ))

                ElseIf val = UI.Column.State.P1 Then
                    Dim r As New Rectangle(X * SZ, j * SZ, SZ, SZ)
                    g.FillRectangle(BoardBrush, r)
                    DrawOutline(g, r)
                    DrawChecker(g, r, P1Color)
                Else
                    Dim r As New Rectangle(X * SZ, j * SZ, SZ, SZ)
                    g.FillRectangle(BoardBrush, r)
                    DrawOutline(g, r)
                    DrawChecker(g, r, P2Color)
                End If

                j -= 1
            Next
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub Board_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint

            If cache Is Nothing Then
                cache = New Bitmap(SZ * 7, SZ * 7)
            End If

            Dim g As Graphics = Graphics.FromImage(cache)

            g.SetClip(e.ClipRectangle)

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            DrawTopRow(g)

            Dim i As Integer
            For i = 0 To 6
                DrawColumn(g, i)
            Next

            g.ResetClip()

            e.Graphics.DrawImage(cache, 0, 0)
        End Sub

        Private Sub Board_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
            MouseColumn = OutOfBounds
            Me.Invalidate(New Rectangle(0, 0, SZ * 7, SZ))
        End Sub

        Private Sub Board_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
            Dim pt As Point = Me.PointToClient(Control.MousePosition)

            Dim i As Integer
            For i = 0 To 6
                If pt.X >= i * SZ And pt.X < (i + 1) * SZ Then
                    If MouseColumn <> i Then
                        Dim x As Integer = System.Math.Min(MouseColumn, i)
                        MouseColumn = i

                        Me.Invalidate(New Rectangle(x * SZ, 0, 2 * SZ, SZ))
                    End If
                End If
            Next
        End Sub


        Private Sub Board_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
            If MouseColumn = OutOfBounds Then Exit Sub

            Dim redraw As Boolean = False

            If SideToMove = UI.Column.State.P1 And _
            InteractiveP1 = True Then
                Dim s As String = Nothing
                If MakeMove(MouseColumn, s) Then
                    RaiseEvent PlayerMoved(Me, New PlayerMovedEventArgs(s))
                    redraw = True
                End If
            ElseIf SideToMove = UI.Column.State.P2 And _
            InteractiveP2 = True Then
                Dim s As String = Nothing
                If MakeMove(MouseColumn, s) Then
                    RaiseEvent PlayerMoved(Me, New PlayerMovedEventArgs(s))
                    redraw = True
                End If
                End If

                If redraw Then
                    Me.Invalidate(New Rectangle(MouseColumn * SZ, 0, SZ, SZ * 7))
                End If
        End Sub

        Private Sub Board_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            SZ = Math.Min(Size.Width, Size.Height) / 7

            SZ = Math.Max(SZ, 40)

            If cache IsNot Nothing Then
                cache.Dispose()
                cache = Nothing
            End If

            Invalidate()
        End Sub
#End Region

    End Class
End Namespace

