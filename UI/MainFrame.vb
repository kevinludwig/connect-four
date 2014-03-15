Public Class MainFrame
    Inherits System.Windows.Forms.Form

#Region "Private Class Data"
    Friend WithEvents MoveView1 As C4.UI.MoveView

    Friend WithEvents OptionsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EngineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents AppStatusLabel As System.Windows.Forms.ToolStripStatusLabel

    Private gs As New C4.Engine.GameState()
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Delegate Sub MakeComputerMoveEndDelegate(ByVal m As Generic.List(Of String), ByVal eval As Double)
    Private makeMoveDelegate As New MakeComputerMoveEndDelegate(AddressOf MakeComputerMoveEnd)
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Load color settings from configuration file
        UIBoard.BackColor = My.Settings.BackgroundColor
        UIBoard.BoardColor = My.Settings.BoardColor
        UIBoard.OutlineColor = My.Settings.ShadowColor
        UIBoard.P1DarkColor = My.Settings.Player1DarkColor
        UIBoard.P1LightColor = My.Settings.Player1LightColor
        UIBoard.P2DarkColor = My.Settings.Player2DarkColor
        UIBoard.P2LightColor = My.Settings.Player2LightColor

        gs.Algorithm = CType(Engine.GameState.AlgorithmType.Parse(gs.Algorithm.GetType(), My.Settings.Algorithm), Engine.GameState.AlgorithmType)
        gs.Random = My.Settings.RandomPlay

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
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Player1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Player2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents UIBoard As UI.Board
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Player1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Player2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EngineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.MoveView1 = New C4.UI.MoveView
        Me.UIBoard = New C4.UI.Board
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.AppStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.OptionsToolStripMenuItem1, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(628, 26)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(40, 22)
        Me.FileToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuFile
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.NewGameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Player1ToolStripMenuItem, Me.Player2ToolStripMenuItem})
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.NewGameToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuFileNewGame
        '
        'Player1ToolStripMenuItem
        '
        Me.Player1ToolStripMenuItem.Name = "Player1ToolStripMenuItem"
        Me.Player1ToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.Player1ToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuFileNgPlayer1
        '
        'Player2ToolStripMenuItem
        '
        Me.Player2ToolStripMenuItem.Name = "Player2ToolStripMenuItem"
        Me.Player2ToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.Player2ToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuFileNgPlayer2
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ExitToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuFileExit
        '
        'OptionsToolStripMenuItem1
        '
        Me.OptionsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColorsToolStripMenuItem, Me.EngineToolStripMenuItem})
        Me.OptionsToolStripMenuItem1.Name = "OptionsToolStripMenuItem1"
        Me.OptionsToolStripMenuItem1.Size = New System.Drawing.Size(69, 22)
        Me.OptionsToolStripMenuItem1.Text = Global.C4.My.Resources.Resources.menuOptions
        '
        'ColorsToolStripMenuItem
        '
        Me.ColorsToolStripMenuItem.Name = "ColorsToolStripMenuItem"
        Me.ColorsToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ColorsToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuOptionsColors
        '
        'EngineToolStripMenuItem
        '
        Me.EngineToolStripMenuItem.Name = "EngineToolStripMenuItem"
        Me.EngineToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EngineToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuOptionsEngine
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(48, 22)
        Me.HelpToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuHelp
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ContentsToolStripMenuItem.Text = "Contents"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AboutToolStripMenuItem.Text = Global.C4.My.Resources.Resources.menuHelpAbout
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.MoveView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.UIBoard)
        Me.SplitContainer1.Size = New System.Drawing.Size(628, 395)
        Me.SplitContainer1.SplitterDistance = 165
        Me.SplitContainer1.TabIndex = 2
        '
        'MoveView1
        '
        Me.MoveView1.BackColor = System.Drawing.Color.Beige
        Me.MoveView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MoveView1.Location = New System.Drawing.Point(0, 0)
        Me.MoveView1.Name = "MoveView1"
        Me.MoveView1.Size = New System.Drawing.Size(165, 395)
        Me.MoveView1.TabIndex = 0
        '
        'UIBoard
        '
        Me.UIBoard.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.UIBoard.BoardColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.UIBoard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UIBoard.Location = New System.Drawing.Point(0, 0)
        Me.UIBoard.Name = "UIBoard"
        Me.UIBoard.OutlineColor = System.Drawing.Color.LightGray
        Me.UIBoard.P1DarkColor = System.Drawing.Color.Red
        Me.UIBoard.P1LightColor = System.Drawing.Color.LightPink
        Me.UIBoard.P2DarkColor = System.Drawing.Color.Blue
        Me.UIBoard.P2LightColor = System.Drawing.Color.LightBlue
        Me.UIBoard.Size = New System.Drawing.Size(459, 395)
        Me.UIBoard.TabIndex = 1
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(628, 395)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(628, 443)
        Me.ToolStripContainer1.TabIndex = 3
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(628, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "Ready."
        '
        'AppStatusLabel
        '
        Me.AppStatusLabel.Name = "AppStatusLabel"
        Me.AppStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'MainFrame
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(628, 443)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainFrame"
        Me.Text = "Connect Four"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Event Handlers"
    Private Sub Player1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Player1ToolStripMenuItem.Click
        gs.Reset()
        UIBoard.Reset()
        UIBoard.InteractiveP1 = True
        UIBoard.InteractiveP2 = False
        MoveView1.Reset()
    End Sub

    Private Sub Player2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Player2ToolStripMenuItem.Click
        gs.Reset()
        UIBoard.Reset()
        UIBoard.InteractiveP1 = False
        UIBoard.InteractiveP2 = True
        MoveView1.Reset()

        MakeComputerMove()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim dlg As New AboutDialog

        If My.Settings.AboutDlgPosition.X = 0 And My.Settings.AboutDlgPosition.Y = 0 Then
            dlg.StartPosition = FormStartPosition.CenterParent
        Else
            dlg.StartPosition = FormStartPosition.Manual
            dlg.Location = My.Settings.AboutDlgPosition
        End If


        dlg.ShowDialog()

        My.Settings.AboutDlgPosition = dlg.Location
        My.Settings.Save()
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        Dim path As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Help\Help.chm")
        Help.ShowHelp(Me, path, "overview.htm")
    End Sub

    Private Sub ColorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorsToolStripMenuItem.Click
        Dim frm As New ColorsForm

        frm.BackgroundColor = UIBoard.BackColor
        frm.BoardColor = UIBoard.BoardColor
        frm.ShadowColor = UIBoard.OutlineColor
        frm.Player1DarkColor = UIBoard.P1DarkColor
        frm.Player1LightColor = UIBoard.P1LightColor
        frm.Player2DarkColor = UIBoard.P2DarkColor
        frm.Player2LightColor = UIBoard.P2LightColor

        If My.Settings.ColorDlgPosition.X = 0 And My.Settings.ColorDlgPosition.Y = 0 Then
            frm.StartPosition = FormStartPosition.CenterParent
        Else
            frm.StartPosition = FormStartPosition.Manual
            frm.Location = My.Settings.ColorDlgPosition
        End If


        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            UIBoard.BackColor = frm.BackgroundColor
            My.Settings.BackgroundColor = frm.BackgroundColor

            UIBoard.BoardColor = frm.BoardColor
            My.Settings.BoardColor = frm.BoardColor

            UIBoard.OutlineColor = frm.ShadowColor
            My.Settings.ShadowColor = frm.ShadowColor

            UIBoard.P1DarkColor = frm.Player1DarkColor
            My.Settings.Player1DarkColor = frm.Player1DarkColor

            UIBoard.P1LightColor = frm.Player1LightColor
            My.Settings.Player1LightColor = frm.Player1LightColor

            UIBoard.P2DarkColor = frm.Player2DarkColor
            My.Settings.Player2DarkColor = frm.Player2DarkColor

            UIBoard.P2LightColor = frm.Player2LightColor
            My.Settings.Player2LightColor = frm.Player2LightColor

            ' save form position
            My.Settings.ColorDlgPosition = frm.Location
            My.Settings.Save()

        End If

    End Sub

    Private Sub EngineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EngineToolStripMenuItem.Click
        Dim frm As New EngineForm

        frm.Algorithm = My.Settings.Algorithm
        frm.SearchDepth = My.Settings.SearchDepth
        frm.Random = My.Settings.RandomPlay

        If My.Settings.LevelsDlgPosition.X = 0 And My.Settings.LevelsDlgPosition.Y = 0 Then
            frm.StartPosition = FormStartPosition.CenterParent
        Else
            frm.StartPosition = FormStartPosition.Manual
            frm.Location = My.Settings.LevelsDlgPosition
        End If


        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            My.Settings.SearchDepth = frm.SearchDepth

            Me.gs.Algorithm = CType(Engine.GameState.AlgorithmType.Parse(gs.Algorithm.GetType(), frm.Algorithm), Engine.GameState.AlgorithmType)
            My.Settings.Algorithm = frm.Algorithm

            My.Settings.RandomPlay = frm.Random
            gs.Random = frm.Random

            My.Settings.LevelsDlgPosition = frm.Location
            My.Settings.Save()
        End If
    End Sub

    ''' <summary>
    ''' This event fires when the player makes a move. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HandleMoveMade(ByVal sender As System.Object, ByVal e As UI.PlayerMovedEventArgs) Handles UIBoard.PlayerMoved
        Dim m As String = ""

        ' Update the move view
        MoveView1.MakeMove(e.Location)

        ' update the engine game state
        gs.MakeMove(e.Location)

        ' check for end of game condition
        If gs.EndState() = True Then
            If gs.MaxWins() Or gs.MinWins() Then
                ' player wins: we can get away with checking if either max or min wins, 
                ' because we don't know if the user is player1 or player2. Further, since
                ' the user *just* moved, he can be the only winner.
                MoveView1.MakeMove("#")
            End If
        Else
            MakeComputerMove()
        End If

    End Sub
#End Region

#Region "Helper functions"
    ''' <summary>
    ''' Do the alphabeta search in a worker thread
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoMoveSearch(ByVal obj As Object)
        Dim line As New Generic.List(Of String)

        Dim evaluation As Double

        Threading.Thread.BeginCriticalRegion()
        evaluation = gs.Search(line, My.Settings.SearchDepth)
        Threading.Thread.EndCriticalRegion()

        ' Post results back to the UI in the main thread
        Me.Invoke(makeMoveDelegate, New Object() {line, evaluation})
    End Sub

    Private Function FormatStatusBarText(ByVal line As Generic.List(Of String), ByVal eval As Double) As String
        Dim currentMove As Integer = MoveView1.CurrentMove
        Dim firstMove As Boolean = True
        Dim p2OnMove As Boolean = False
        Dim symbol As String

        If eval = Engine.GameState.MIN_WINS Then
            symbol = "--"
        ElseIf eval < -3 Then
            symbol = "-/+"
        ElseIf eval < -0.05 Then
            symbol = "-/="
        ElseIf eval < 0.05 Then
            symbol = "="
        ElseIf eval < 3 Then
            symbol = "+/="
        ElseIf eval < Engine.GameState.MAX_WINS Then
            symbol = "+/-"
        Else
            symbol = "++"
        End If

        Dim text As String = String.Format("{0} ({1}): ", symbol, eval.ToString("F"))

        For Each m As String In line
            If firstMove = True Then
                firstMove = False

                If UIBoard.InteractiveP1 Then
                    text += String.Format("{0}. ...{1}", currentMove, m)
                    currentMove += 1
                Else
                    text += String.Format("{0}. {1}", currentMove, m)
                    p2OnMove = True
                End If
            Else
                If p2OnMove Then
                    text += String.Format(" {0}", m)
                    currentMove += 1
                Else
                    text += String.Format(" {0}. {1}", currentMove, m)
                End If

                p2OnMove = Not p2OnMove
            End If
        Next

        Return text
    End Function

    ''' <summary>
    ''' Posts results back to UI when computer move has been chosen
    ''' </summary>
    ''' <param name="line">the PV</param>
    ''' <param name="evaluation">the evaluation of the position</param>
    ''' <remarks></remarks>
    Private Sub MakeComputerMoveEnd(ByVal line As Generic.List(Of String), ByVal evaluation As Double)
        Dim m As String = line(0)

        AppStatusLabel.Text = FormatStatusBarText(line, evaluation)

        ' Update the engine game state with computer's move
        gs.MakeMove(m)

        ' Update the UI board with computer's move
        UIBoard.MakeMove(m)

        ' Update the move view with computer's move
        MoveView1.MakeMove(m)

        ' check if computer wins
        If gs.EndState() Then
            UIBoard.InteractiveP1 = False
            UIBoard.InteractiveP2 = False

            If gs.MaxWins() Or gs.MinWins() Then
                MoveView1.MakeMove("#")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Start the process of making a computer's move
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeComputerMove()
        Dim m As String = ""

        Me.AppStatusLabel.Text = My.Resources.statusBarThinking

        ' determine computer's next move
        Threading.ThreadPool.QueueUserWorkItem(AddressOf DoMoveSearch)
    End Sub
#End Region

End Class
