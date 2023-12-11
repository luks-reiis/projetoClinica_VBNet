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
        txtCodigo.Enabled = True
        txtIdade.Enabled = True

    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click

        Habilitar()
        txtNome.Focus()

    End Sub

    Public Sub Limpar()

        txtNome.Clear()
        txtRg.Clear()
        txtNascimento.Clear()
        txtIdade.Clear()
        txtCelular.Clear()
        txtCodigo.Clear()
        txtIdade.Clear()

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
        txtCodigo.Enabled = False
        txtIdade.Enabled = False

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Limpar()
        Desabilitar()

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click



    End Sub

    Private Sub txtIdade_Enter(sender As Object, e As EventArgs) Handles txtIdade.Enter



    End Sub

    Private Sub txtNascimento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNascimento.KeyPress

        'Tecla Enter
        If e.KeyChar = Convert.ToChar(13) Then

            Dim dt As DateTime

            DateTime.TryParseExact(txtNascimento.Text, "dd/MM/yyyy", Nothing, Nothing, dt)

            If dt = DateTime.MinValue Then

                MessageBox.Show("Digite a Data de Nascimento Corretamente!")

            Else

                Dim dataAtual As Date = DateAndTime.Now

                Dim dataNasc As Date = txtNascimento.Text

                Dim anoAtual, anoNasc, mesAtual, mesNasc, diaAtual, diaNasc As Integer

                anoAtual = dataAtual.Year
                mesAtual = dataAtual.Month
                diaAtual = dataAtual.Day

                anoNasc = dataNasc.Year
                mesNasc = dataNasc.Month
                diaNasc = dataNasc.Day

                Dim idade As Integer = 0

                idade = anoAtual - anoNasc

                If mesAtual <= mesNasc And diaAtual < diaNasc Then

                    idade -= 1

                End If

                txtIdade.Text = idade


            End If
            txtCelular.Focus()
        End If
    End Sub
End Class