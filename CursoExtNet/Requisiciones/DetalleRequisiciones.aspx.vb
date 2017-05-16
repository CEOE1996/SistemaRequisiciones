Public Class DetalleRequisiciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            stDetalle.Reload()
        End If
    End Sub

    Private Sub stDetalle_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stDetalle.ReadData
        stDetalle.DataSource = clsSQL.List("SPQ_Requisicion", CommandType.StoredProcedure)
        stDetalle.DataBind()
    End Sub
End Class