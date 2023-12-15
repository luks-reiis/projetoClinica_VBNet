Public Class Cliente

    Dim sql As String
    Dim ds As New DataSet
    Dim con As New Conexao_sql

    Private idCliente_ As Integer
    Public Property idCliente() As Integer
        Get
            Return idCliente_
        End Get
        Set(ByVal value As Integer)
            idCliente_ = value
        End Set
    End Property

    Private nomeCliente_ As String
    Public Property nomeCliente() As String
        Get
            Return nomeCliente_
        End Get
        Set(ByVal value As String)
            nomeCliente_ = value
        End Set
    End Property

    Private rgCliente_ As String
    Public Property rgCliente() As String
        Get
            Return rgCliente_
        End Get
        Set(ByVal value As String)
            rgCliente_ = value
        End Set
    End Property

    Private nascCliente_ As String
    Public Property nascCliente() As String
        Get
            Return nascCliente_
        End Get
        Set(ByVal value As String)
            nascCliente_ = value
        End Set
    End Property

    Private telefoneCliente_ As String
    Public Property telefoneCliente() As String
        Get
            Return telefoneCliente_
        End Get
        Set(ByVal value As String)
            telefoneCliente_ = value
        End Set
    End Property

    Private idadeCliente_ As Integer
    Public Property idadeCliente() As Integer
        Get
            Return idadeCliente_
        End Get
        Set(ByVal value As Integer)
            idadeCliente_ = value
        End Set
    End Property

    Private usuario_ As String
    Public Property usuario() As String
        Get
            Return usuario_
        End Get
        Set(ByVal value As String)
            usuario_ = value
        End Set
    End Property

    Private dataCadastro_ As String
    Public Property dataCadastro() As String
        Get
            Return dataCadastro_
        End Get
        Set(ByVal value As String)
            dataCadastro_ = value
        End Set
    End Property

    Public Sub cadastrarCliente()

        sql = "INSERT INTO clientes(nome_cliente, rg_cliente, nasc_cliente, telefone_cliente, idade_cliente, usuario, data_cadastro) VALUES ('" & nomeCliente & "', '" & rgCliente & "', '" & nascCliente & "', '" & telefoneCliente & "', " & idadeCliente & ", '" & usuario & "', '" & dataCadastro & "')"

        con.Operar(sql)

    End Sub

    Public Function consultaMaxCodigo()

        sql = "SELECT MAX(id_cliente) FROM clientes"
        ds = con.Listar(sql)
        Return ds

    End Function

End Class
