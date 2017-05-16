Public Class clsActividad
    Public Property ID As Integer
    Public Property Proyecto As Integer
    Public Property IDActividad As Integer
    Public Property Descripcion As String
    Public Property Usuarios As String

    Public Shared Sub Add(data As clsActividad)
        clsSQL.AddParameter("@Proyecto", data.Proyecto)
        clsSQL.AddParameter("@Descripcion", data.Descripcion)
        clsSQL.AddParameter("@IDActividad", data.IDActividad)
        clsSQL.ExecNonQuery("SPI_Actividad", CommandType.StoredProcedure)
    End Sub

    Public Shared Function List(ID As Integer) As List(Of clsActividad)
        clsSQL.AddParameter("@ID", ID)
        Return clsSQL.List("SPQ_ProyectoActividad", CommandType.StoredProcedure).toList(Of clsActividad)()
    End Function

    Public Shared Sub Eliminar(ID As Integer)
        clsSQL.AddParameter("@ID", ID)
        clsSQL.ExecNonQuery("SPD_Actividad", CommandType.StoredProcedure)
    End Sub

    Public Shared Function ListRequisicion(Proyecto As Integer) As List(Of clsActividad)
        clsSQL.AddParameter("@Usuario", VariablesSesion.ID)
        clsSQL.AddParameter("@Proyecto", Proyecto)
        Return clsSQL.List("SPQ_RequisicionActividad", CommandType.StoredProcedure).toList(Of clsActividad)()
    End Function

End Class
