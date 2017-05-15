Public Class clsProyecto
    Public Property ID As Integer
    Public Property IDCA As Integer
    Public Property CuerpoAcademico As String
    Public Property Nombre As String
    Public Property Clave As String
    Public Property Descripcion As String
    Public Property MontoDisponible As Decimal
    Public Property VigenciaInicio As Date
    Public Property VigenciaFin As Date
    Public Property Estatus As Integer
    Public Property DescEstatus As String

    Public Shared Function Add(data As clsProyecto) As Integer
        clsSQL.AddParameter("@CuerpoAcademico", data.CuerpoAcademico)
        clsSQL.AddParameter("@Clave", data.Clave)
        clsSQL.AddParameter("@Nombre", data.Nombre)
        clsSQL.AddParameter("@Descripcion", data.Descripcion)
        clsSQL.AddParameter("@IDCA", data.IDCA)
        clsSQL.AddParameter("@VigenciaInicio", data.VigenciaInicio)
        clsSQL.AddParameter("@VigenciaFin", data.VigenciaFin)
        clsSQL.AddParameter("@Usuario", VariablesSesion.ID)
        Return clsSQL.ExecScalar("SPI_Proyecto", CommandType.StoredProcedure)
    End Function

    Public Shared Sub Update(data As clsProyecto)
        clsSQL.AddParameter("@ID", data.ID)
        clsSQL.AddParameter("@CuerpoAcademico", data.CuerpoAcademico)
        clsSQL.AddParameter("@Clave", data.Clave)
        clsSQL.AddParameter("@Nombre", data.Nombre)
        clsSQL.AddParameter("@Descripcion", data.Descripcion)
        clsSQL.AddParameter("@IDCA", data.IDCA)
        clsSQL.AddParameter("@VigenciaInicio", data.VigenciaInicio)
        clsSQL.AddParameter("@VigenciaFin", data.VigenciaFin)
        clsSQL.ExecNonQuery("SPU_Proyecto", CommandType.StoredProcedure)
    End Sub

    Public Shared Function List(Optional ID As Integer = 0) As List(Of clsProyecto)
        If ID <> 0 Then
            clsSQL.AddParameter("@ID", ID)
        End If
        Return clsSQL.List("SPQ_Proyecto", CommandType.StoredProcedure).toList(Of clsProyecto)()
    End Function

End Class
