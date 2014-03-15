Namespace UI
    Public Class Column
#Region "Private class data"
        Public column As New Generic.List(Of State)
        Public Top As Integer
#End Region

        Public Enum State
            P1 = 1
            P2 = 2
            NotSet = 3
        End Enum

#Region "Construction Code"
        Public Sub New()
            Top = 0

            Dim i As Integer
            For i = 0 To 5
                column.Add(State.NotSet)
            Next
        End Sub
#End Region

#Region "Public Methods"
        Public Function Add(ByVal x As State) As Boolean
            If Top > 5 Then Return False

            column(Top) = x
            Top += 1
            Return True
        End Function
#End Region

    End Class
End Namespace
