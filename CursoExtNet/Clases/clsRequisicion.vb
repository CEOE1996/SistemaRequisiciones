Public Class clsRequisicion
    Public Property ID As Integer
    Public Property Area As String
    Public Property Fecha As Date
    Public Property Observaciones As String
    Public Property IDTipoPago As Integer
    Public Property TipoPago As String
    Public Property IDEstatus As Integer
    Public Property Estatus As String
    Public Property Usuario As Integer
    Public Property IDProyecto As Integer
    Public Property IDActividad As Integer
    Public Property IDRecurso As Integer

    Public Shared Function Agregar(dato As clsRequisicion) As Integer
        clsSQL.AddParameter("@Area", dato.Area)
        clsSQL.AddParameter("@Fecha", dato.Fecha)
        clsSQL.AddParameter("@Observaciones", dato.Observaciones)
        clsSQL.AddParameter("@Usuario", VariablesSesion.ID)
        clsSQL.AddParameter("@Recurso", dato.IDRecurso)
        Return clsSQL.ExecScalar("SPI_Requisicion", CommandType.StoredProcedure)
    End Function

    Public Shared Sub Update(dato As clsRequisicion)
        clsSQL.AddParameter("@ID", dato.ID)
        clsSQL.AddParameter("@Area", dato.Area)
        clsSQL.AddParameter("@Fecha", dato.Fecha)
        clsSQL.AddParameter("@Observaciones", dato.Observaciones)
        clsSQL.AddParameter("@Recurso", dato.IDRecurso)
        clsSQL.ExecNonQuery("SPU_Requisicion", CommandType.StoredProcedure)
    End Sub

End Class
