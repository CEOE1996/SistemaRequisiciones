Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not VariablesSesion.ExistenVariables Then
            Dim lp_Principal As New Principal
            lp_Principal.IniciarSesion()
        End If
    End Sub

End Class