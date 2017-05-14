Public Class VariablesSesion

    Public Shared ReadOnly Property ExistenVariables As Boolean
        Get
            If HttpContext.Current.Session.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Shared Property Nombre As String
        Get
            Return CType(HttpContext.Current.Session("Nombre"), String)
        End Get
        Set(value As String)
            HttpContext.Current.Session("Nombre") = value
        End Set
    End Property

    Public Shared Property ID As Nullable(Of Integer)
        Get
            Return CType(HttpContext.Current.Session("ID"), Nullable(Of Integer))
        End Get
        Set(value As Nullable(Of Integer))
            HttpContext.Current.Session("ID") = value
        End Set
    End Property

    Public Shared Property Codigo As String
        Get
            Return CType(HttpContext.Current.Session("Codigo"), String)
        End Get
        Set(value As String)
            HttpContext.Current.Session("Codigo") = value
        End Set
    End Property

    Public Shared Property IDTipoUsuario As Integer
        Get
            Return CType(HttpContext.Current.Session("IDTipoUsuario"), Integer)
        End Get
        Set(value As Integer)
            HttpContext.Current.Session("IDTipoUsuario") = value
        End Set
    End Property


    Public Shared Property TipoUsuario As String
        Get
            Return CType(HttpContext.Current.Session("TipoUsuario"), String)
        End Get
        Set(value As String)
            HttpContext.Current.Session("TipoUsuario") = value
        End Set
    End Property

    Public Shared Property Correo As String
        Get
            Return CType(HttpContext.Current.Session("Correo"), String)
        End Get
        Set(value As String)
            HttpContext.Current.Session("Correo") = value
        End Set
    End Property

End Class
