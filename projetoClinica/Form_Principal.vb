Public Class Form_Principal

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim data As String

        data = DateAndTime.Now

        lblData.Text = data

    End Sub
End Class