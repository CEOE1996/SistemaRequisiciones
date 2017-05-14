Public Class clsRecurso
    Public Property ID As Integer
    Public Property IDRecurso As Integer
    Public Property Actividad As Integer
    Public Property Tipo As String
    Public Property Descripcion As String
    Public Property Monto As Decimal

    Public Shared Sub Agregar(data As clsRecurso)
        clsSQL.AddParameter("@Actividad", data.Actividad)
        clsSQL.AddParameter("@Tipo", data.Tipo)
        clsSQL.AddParameter("@Monto", data.Monto)
        clsSQL.AddParameter("@Descripcion", data.Descripcion)
        clsSQL.AddParameter("@IDRecurso", data.IDRecurso)
        clsSQL.ExecNonQuery("SPI_Recurso", CommandType.StoredProcedure)
    End Sub

    Public Shared Function List(Actividad As Integer) As List(Of clsRecurso)
        clsSQL.AddParameter("@Actividad", Actividad)
        Return clsSQL.List("SPQ_Recurso", CommandType.StoredProcedure).toList(Of clsRecurso)()
    End Function

    Public Shared Sub Eliminar(ID As Integer)
        clsSQL.AddParameter("@ID", ID)
        clsSQL.ExecNonQuery("SPD_Recurso", CommandType.StoredProcedure)
    End Sub
End Class
