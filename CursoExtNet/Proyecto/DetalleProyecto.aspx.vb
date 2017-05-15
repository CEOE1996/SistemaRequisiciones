Public Class DetalleProyecto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            stDetalle.Reload()
        End If
    End Sub

    Private Sub stDetalle_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stDetalle.ReadData
        stDetalle.DataSource = clsProyecto.List()
        stDetalle.DataBind()
    End Sub
End Class