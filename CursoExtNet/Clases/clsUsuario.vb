Public Class clsUsuario
    Public Property ID As Integer
    Public Property Codigo As String
    Public Property Nombre As String
    Public Property Telefono As String
    Public Property Correo As String
    Public Property IDTipoUsuario As Integer
    Public Property TipoUsuario As String
    Public Property IDEstatus As Integer
    Public Property Estatus As String

    Public Shared Function List(Optional ID As Integer = -1) As List(Of clsUsuario)
        If ID > 0 Then
            clsSQL.AddParameter("@ID", ID)
        End If
        Return clsSQL.List("SPQ_Usuarios", CommandType.StoredProcedure).toList(Of clsUsuario)()
    End Function

    Public Shared Function BuscarParaActividad(Usuario As String) As List(Of clsUsuario)
        clsSQL.AddParameter("@Usuario", Usuario)
        Return clsSQL.List("SPQ_UsuarioActividad", CommandType.StoredProcedure).toList(Of clsUsuario)()
    End Function

    Public Shared Sub AgregarActividad(ID As Integer, Actividad As Integer)
        clsSQL.AddParameter("@ID", ID)
        clsSQL.AddParameter("@Actividad", Actividad)
        If clsSQL.ExecScalar("SPI_ActividadUsuario", CommandType.StoredProcedure) = 0 Then
            Ext.Net.X.Msg.Alert("Error", "El Usuario ya Existe en esa Actividad").Show()
        End If
    End Sub

    Public Shared Sub EliminarActividad(ID As Integer, Actividad As Integer)
        clsSQL.AddParameter("@ID", ID)
        clsSQL.AddParameter("@Actividad", Actividad)
        clsSQL.ExecNonQuery("SPD_ActividadUsuario", CommandType.StoredProcedure)
    End Sub

    Public Shared Function ConsultaActividad(Actividad As Integer) As List(Of clsUsuario)
        clsSQL.AddParameter("@Actividad", Actividad)
        Return clsSQL.List("SPQ_ActividadUsuario", CommandType.StoredProcedure).toList(Of clsUsuario)()
    End Function

End Class
