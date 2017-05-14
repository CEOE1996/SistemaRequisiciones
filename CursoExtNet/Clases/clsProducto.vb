Public Class clsProducto
    Public Property ID As Integer
    Public Property Recurso As Integer
    Public Property Descripcion As String
    Public Property Cantidad As Integer
    Public Property CantidadEjercida As Integer

    Public Shared Sub Agregar(data As clsProducto)
        clsSQL.AddParameter("@Recurso", data.Recurso)
        clsSQL.AddParameter("@Descripcion", data.Descripcion)
        clsSQL.AddParameter("@Cantidad", data.Cantidad)
        clsSQL.ExecNonQuery("SPI_Producto", CommandType.StoredProcedure)
    End Sub

    Public Shared Function Listar(Recurso As Integer) As List(Of clsProducto)
        clsSQL.AddParameter("@ID", Recurso)
        Return clsSQL.List("SPQ_Producto", CommandType.StoredProcedure).toList(Of clsProducto)()
    End Function

    Public Shared Sub Eliminar(ID As Integer)
        clsSQL.AddParameter("@ID", ID)
        clsSQL.ExecNonQuery("SPD_Producto", CommandType.StoredProcedure)
    End Sub

End Class
