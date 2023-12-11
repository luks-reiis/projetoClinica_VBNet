Public Class Usuario
    Dim sql As String
    Dim ds As New DataSet
    Dim con As New Conexao_sql

    Private id_usuario_ As Integer
    Public Property id_usuario() As Integer
        Get
            Return id_usuario_
        End Get
        Set(ByVal value As Integer)
            id_usuario_ = value
        End Set
    End Property

    Private nome_usuario_ As String
    Public Property nome_usuario() As String
        Get
            Return nome_usuario_
        End Get
        Set(ByVal value As String)
            nome_usuario_ = value
        End Set
    End Property

    Private senha_usuario_ As String
    Public Property senha_usuario() As String
        Get
            Return senha_usuario_
        End Get
        Set(ByVal value As String)
            senha_usuario_ = value
        End Set
    End Property

    Private nivel_acesso_ As String
    Public Property nivel_acesso() As String
        Get
            Return nivel_acesso_
        End Get
        Set(ByVal value As String)
            nivel_acesso_ = value
        End Set
    End Property

    Public Function consultaUsuarios()
        sql = "SELECT * FROM usuarios WHERE nome_usuario='" & nome_usuario & "'AND senha_usuario='" & senha_usuario & "'"
        ds = con.Listar(sql)
        Return ds


    End Function

End Class
