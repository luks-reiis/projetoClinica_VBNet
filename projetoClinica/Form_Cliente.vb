Public Class Form_Cliente

    Dim sql As String
    Dim ds As New DataSet
    Dim con As New Conexao_sql

    Dim cliente As New Cliente

    'Armazena cadastro=1 ou alteração=2
    Dim salvar As Integer = 0

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
        salvar = 1

        Habilitar()
        txtNome.Focus()



        Try

            ds = cliente.consultaMaxCodigo()

            txtCodigo.Text = ds.Tables(0).Rows(0).Item(0) + 1



        Catch ex As Exception
            txtCodigo.Text = "0"
        End Try


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
        If txtNome.Text.Length < 1 Then

            MsgBox("Por favor, preencha o campo nome!")
            txtNome.Focus()
            Exit Sub

        End If

        If txtRg.Text.Length < 1 Then

            MsgBox("Por favor, preencha o campo RG!")
            txtRg.Focus()
            Exit Sub

        End If

        If txtNascimento.Text.Length < 1 Then

            MsgBox("Por favor, preencha o campo data de nascimento!")
            txtNascimento.Focus()
            Exit Sub

        End If

        If txtCelular.Text.Length < 1 Then

            MsgBox("Por favor, preencha o campo celular!")
            txtCelular.Focus()
            Exit Sub

        End If


        'Salvar novo
        If salvar = 1 Then
            Dim dt As Date = DateAndTime.Now



            cliente.nomeCliente = txtNome.Text
            cliente.rgCliente = txtRg.Text
            cliente.nascCliente = txtNascimento.Text
            cliente.telefoneCliente = txtCelular.Text
            cliente.idadeCliente = txtIdade.Text
            cliente.usuario = Form_Principal.lblUsuario.Text
            cliente.dataCadastro = dt

            cliente.cadastrarCliente()
            MsgBox("Cliente cadastrado com sucesso!", MsgBoxStyle.Information, "Cadastro de clientes")

            Limpar()
            Desabilitar()

            salvar = 0

            'Alterar existente
        ElseIf salvar = 2 Then

        End If



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

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        Form_Consulta_Cliente.Show()


    End Sub
End Class