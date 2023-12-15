Public Class Form_Principal

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim data As String

        data = DateAndTime.Now

        lblData.Text = data

    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click

        Form_Cliente.MdiParent = Me
        Form_Cliente.Show()

    End Sub
End Class