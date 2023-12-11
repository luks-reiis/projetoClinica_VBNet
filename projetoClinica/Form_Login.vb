Public Class Form_Login
    Dim sql As String
    Dim ds As New DataSet
    Dim con As New Conexao_sql

    Dim usuario As New Usuario

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSenha.CheckedChanged
        If chkSenha.Checked = True Then

            txtSenha.PasswordChar = ""

        Else

            txtSenha.PasswordChar = "*"

        End If
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click

        Try

            If txtUsuario.Text = "" Then
                MsgBox("Por favor preencha o campo Usuário!", MsgBoxStyle.Information, "INFORMAÇÃO")
                txtUsuario.Focus()
                Exit Try
            End If

            If txtSenha.Text = "" Then
                MsgBox("Por favor preencha o campo Senha!", MsgBoxStyle.Information, "INFORMAÇÃO")
                txtSenha.Focus()
                Exit Try
            End If

            usuario.nome_usuario = txtUsuario.Text
            usuario.senha_usuario = txtSenha.Text

            ds = usuario.consultaUsuarios()

            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)

                If row(1).ToString() = txtUsuario.Text AndAlso row(2).ToString() = txtSenha.Text Then
                    ' Usuário e senha corretos
                    Form_Principal.Show()
                    Form_Principal.lblUsuario.Text = row(1).ToString()
                    Form_Principal.lblAcesso.Text = row(3).ToString()
                    Me.Hide()
                End If
            Else
                ' Nenhuma linha retornada pela consulta ou credenciais incorretas
                MsgBox("Credenciais incorretas. Por favor, verifique seu usuário e senha.", MsgBoxStyle.Information, "DADOS INCORRETOS")
            End If

        Catch ex As Exception
            MsgBox("Erro ao tentar fazer o LOGIN!" & ex.Message, MsgBoxStyle.Critical, "ERRO")
        End Try

    End Sub

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.Focus()
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress

        'Tecla Enter
        If e.KeyChar = Convert.ToChar(13) Then

            txtSenha.Focus()

        End If

    End Sub

    Private Sub txtSenha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSenha.KeyPress

        'Tecla Enter
        If e.KeyChar = Convert.ToChar(13) Then

            btnEntrar.Focus()

        End If

    End Sub
End Class