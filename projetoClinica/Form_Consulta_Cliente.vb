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
End Class