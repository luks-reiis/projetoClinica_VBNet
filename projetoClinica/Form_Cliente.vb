Public Class Form_Cliente

    Public Sub Habilitar()

        txtNome.Enabled = True
        txtRg.Enabled = True
        txtNascimento.Enabled = True
        txtCelular.Enabled = True
        btnSalvar.Enabled = True
        btnLimpar.Enabled = True
        btnExcluir.Enabled = True
        btnCancelar.Enabled = True

    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click

        Habilitar()

    End Sub

    Public Sub Limpar()

        txtNome.Clear()
        txtRg.Clear()
        txtNascimento.Clear()
        txtIdade.Clear()
        txtCelular.Clear()

    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click

        Limpar()

    End Sub

    Public Sub Desabilitar()

        txtNome.Enabled = False
        txtRg.Enabled = False
        txtNascimento.Enabled = False
        txtCelular.Enabled = False
        btnSalvar.Enabled = False
        btnLimpar.Enabled = False
        btnExcluir.Enabled = False
        btnCancelar.Enabled = False

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Limpar()
        Desabilitar()

    End Sub
End Class