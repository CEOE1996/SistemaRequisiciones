Public Class Usuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            stUsuario.Reload()
        End If
    End Sub

    Private Sub stUsuario_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stUsuario.ReadData
        stUsuario.DataSource = clsUsuario.List()
        stUsuario.DataBind()
    End Sub
End Class