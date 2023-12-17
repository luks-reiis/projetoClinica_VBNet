Public Class Form_Consulta_Cliente

    Dim sql As String
    Dim ds As New DataSet
    Dim con As New Conexao_sql

    Dim cliente As New Cliente

    Public Sub contaLinhas()

        Try
            Dim numLinhas As Integer = dgvClientes.RowCount - 1
            Dim contador As Integer = 0

            While (numLinhas >= 0)

                contador += 1
                numLinhas -= 1

            End While

            lblCliente.Text = contador
        Catch ex As Exception
            MsgBox("Erro ao contar o número de itens na tabela de resultados! Detalhes do erro: " & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Public Sub formataGrid()

        With dgvClientes

            .Columns(0).HeaderText = "Código"
            .Columns(1).HeaderText = "Nome"
            .Columns(2).HeaderText = "RG"
            .Columns(3).HeaderText = "Nascimento"
            .Columns(4).HeaderText = "Telefone"
            .Columns(5).HeaderText = "Idade"
            .Columns(6).HeaderText = "Cadastrado por"
            .Columns(7).HeaderText = "Data de cadastro"
            .Columns(0).HeaderText = "Código"

        End With

    End Sub


    Private Sub Form_Consulta_Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            ds = cliente.consultaClientes()
            dgvClientes.DataSource = ds.Tables(0)
            contaLinhas()
            formataGrid()

        Catch ex As Exception
            MsgBox("Erro ao consultar clientes no banco de dados! Detalhes do erro: " & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick

    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick

        Try

            Form_Cliente.txtCodigo.Text = dgvClientes.CurrentRow.Cells(0).Value
            Form_Cliente.txtNome.Text = dgvClientes.CurrentRow.Cells(1).Value
            Form_Cliente.txtRg.Text = dgvClientes.CurrentRow.Cells(2).Value
            Form_Cliente.txtNascimento.Text = dgvClientes.CurrentRow.Cells(3).Value
            Form_Cliente.txtCelular.Text = dgvClientes.CurrentRow.Cells(4).Value
            Form_Cliente.txtIdade.Text = dgvClientes.CurrentRow.Cells(5).Value


            con.salvar = 2

            Form_Cliente.Habilitar()

            Me.Close()

        Catch ex As Exception
            MsgBox("Não foi possível selecionar o cliente! Detalhes do erro: " & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Form_Cliente.txtCodigo.Text = dgvClientes.CurrentRow.Cells(0).Value
        Form_Cliente.txtNome.Text = dgvClientes.CurrentRow.Cells(1).Value
        Form_Cliente.txtRg.Text = dgvClientes.CurrentRow.Cells(2).Value
        Form_Cliente.txtNascimento.Text = dgvClientes.CurrentRow.Cells(3).Value
        Form_Cliente.txtCelular.Text = dgvClientes.CurrentRow.Cells(4).Value
        Form_Cliente.txtIdade.Text = dgvClientes.CurrentRow.Cells(5).Value


        con.salvar = 2

        Form_Cliente.Habilitar()

        Me.Close()
    End Sub

    Private Sub txtNome_TextChanged(sender As Object, e As EventArgs) Handles txtNome.TextChanged

        Try

            cliente.nomeCliente = txtNome.Text
            ds = cliente.consultasClientesNome()
            dgvClientes.DataSource = ds.Tables(0)

        Catch ex As Exception
            MsgBox("Não foi possível consultar o cliente! Detalhes do erro: " & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub
End Class