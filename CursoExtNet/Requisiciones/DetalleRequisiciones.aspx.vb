Public Class DetalleRequisiciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            stDetalle.Reload()
        End If
    End Sub

    Public Sub btnAutorizar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            Dim dt As DataTable
            clsSQL.AddParameter("@Estatus", e.ExtraParams("Estatus"))
            clsSQL.AddParameter("@Usuario", VariablesSesion.IDTipoUsuario)
            dt = clsSQL.List("SPQ_RequisicionAutorizar", CommandType.StoredProcedure)
            If dt.Rows.Count = 0 Then
                Ext.Net.X.Msg.Alert("Error", "No Tienes Permiso de Autorizar en Este Estatus").Show()
                Return
            End If
            stEstado.DataSource = dt
            stEstado.DataBind()
            wdwAutorizar.Show()
            hdID.Value = e.ExtraParams("ID")
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnChangeEstatus_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If String.IsNullOrEmpty(cboEstado.Text) Then
                Ext.Net.X.Msg.Alert("Error", "Favor de Seleccionar un Estatus").Show()
                Return
            End If
            clsSQL.AddParameter("@ID", hdID.Value)
            clsSQL.AddParameter("@Estatus", cboEstado.Value)
            clsSQL.ExecNonQuery("SPU_RequisicionEstatus", CommandType.StoredProcedure)
            Ext.Net.X.Msg.Alert("Autorizar", "Se Ha Autorizado la Requisición Satisfactoriamente").Show()
            wdwAutorizar.Close()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Private Sub stDetalle_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stDetalle.ReadData
        stDetalle.DataSource = clsSQL.List("SPQ_Requisicion", CommandType.StoredProcedure)
        stDetalle.DataBind()
    End Sub
End Class