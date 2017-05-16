Public Class AgregarRequisicion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdID.Value = 0
            dtfFecha.Value = Date.Today
            stProyecto.Reload()
        End If
    End Sub

    Public Sub btnGuardar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If Guardar() Then
                Ext.Net.X.Msg.Notify("Guardar", "Requisición Guardada Satisfactoriamente").Show()
            End If
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnAgregar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If Guardar() And ValidaProducto() Then
                Dim Cantidad As Decimal
                clsSQL.AddParameter("@Requisicion", hdID.Value)
                clsSQL.AddParameter("@Producto", cboProducto.Value)
                clsSQL.AddParameter("@Cantidad", txtCantidad.Text)
                Cantidad = clsSQL.ExecScalar("SPI_RequisicionDetalle", CommandType.StoredProcedure)
                If Cantidad = 0 Then
                    Ext.Net.X.Msg.Alert("Error", "Este Producto ya se Solicito en su Totalidad").Show()                    
                ElseIf Cantidad > 0 Then
                    Ext.Net.X.Msg.Alert("Error", "Cantidad Disponible: " & Cantidad).Show()
                End If
                CargarDetalle()
            End If
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnEliminar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            clsSQL.AddParameter("@ID", e.ExtraParams("ID"))
            clsSQL.ExecNonQuery("SPD_RequisicionDetalle", CommandType.StoredProcedure)
            CargarDetalle()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnSolicitar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If Guardar() Then
                clsSQL.AddParameter("@ID", hdID.Value)
                clsSQL.AddParameter("@Estatus", 2)
                clsSQL.ExecNonQuery("SPU_RequisicionEstatus", CommandType.StoredProcedure)
                Ext.Net.X.Msg.Notify("Requisición", "Se Ha Solicitado Autorización").Show()
                Response.Redirect(Me.ResolveUrl("DetalleRequisiciones.aspx"))
            End If
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Private Function Guardar() As Boolean
        Try
            If Not ValidaRequisicion() Then
                Return False
            End If

            If hdID.Value = 0 Then
                hdID.Value = clsRequisicion.Agregar(New clsRequisicion With {.Area = txtArea.Text,
                                                                             .Fecha = dtfFecha.Value,
                                                                             .Observaciones = txtObservaciones.Text,
                                                                             .IDRecurso = cboRecurso.Value
                                                                             })
            Else
                clsRequisicion.Update(New clsRequisicion With {.ID = hdID.Value,
                                                               .Area = txtArea.Text,
                                                               .Fecha = dtfFecha.Value,
                                                               .Observaciones = txtObservaciones.Text,
                                                               .IDRecurso = cboRecurso.Value
                                                               })
            End If
            Return True
        Catch ex As Exception
            ex.ManejoErrores()
            Return False
        End Try
    End Function

    Private Function ValidaRequisicion() As Boolean
        If String.IsNullOrEmpty(txtArea.Text) OrElse
            String.IsNullOrEmpty(txtObservaciones.Text) OrElse
            String.IsNullOrEmpty(cboRecurso.Text) _
        Then
            Ext.Net.X.Msg.Alert("Error", "Favor de Llenar Todos Los Campos").Show()
            Return False
        End If

        If dtfFecha.Text = "01/01/0001 12:00:00 a.m." Then
            Ext.Net.X.Msg.Alert("Error", "Fecha Invalida").Show()
            Return False
        End If

        Return True
    End Function

    Private Function ValidaProducto() As Boolean
        If String.IsNullOrEmpty(txtCantidad.Text) OrElse
            String.IsNullOrEmpty(cboProducto.Text) _
        Then
            Ext.Net.X.Msg.Alert("Error", "Favor de Llenar Todos Los Campos").Show()
            Return False
        End If

        If txtCantidad.Value <= 0 Then
            Ext.Net.X.Msg.Alert("Error", "Cantidad Invalida").Show()
            Return False
        End If

        Return True
    End Function

    <Ext.Net.DirectMethod(ShowMask:=True)>
    Public Sub SelectProyecto()
        Try
            stActividad.Reload()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    <Ext.Net.DirectMethod(ShowMask:=True)>
    Public Sub SelectActividad()
        Try
            stRecurso.Reload()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    <Ext.Net.DirectMethod(ShowMask:=True)>
    Public Sub SelectRecurso()
        Try
            stProducto.Reload()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Private Sub stProyecto_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stProyecto.ReadData
        stProyecto.DataSource = clsProyecto.ListRequisicion()
        stProyecto.DataBind()
    End Sub

    Private Sub stActividad_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stActividad.ReadData
        stActividad.DataSource = clsActividad.ListRequisicion(cboProyecto.Value)
        stActividad.DataBind()
    End Sub

    Private Sub stRecurso_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stRecurso.ReadData
        stRecurso.DataSource = clsRecurso.List(cboActividad.Value)
        stRecurso.DataBind()
    End Sub

    Private Sub stProducto_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stProducto.ReadData
        stProducto.DataSource = clsProducto.Listar(cboRecurso.Value)
        stProducto.DataBind()
    End Sub

    Private Sub CargarDetalle()
        clsSQL.AddParameter("@Requisicion", hdID.Value)
        Dim dt As DataTable = clsSQL.List("SPQ_RequisicionDetalle", CommandType.StoredProcedure)
        stDetalle.DataSource = dt
        stDetalle.DataBind()
        If dt.Rows.Count > 0 Then
            cboProyecto.ReadOnly = True
            cboActividad.ReadOnly = True
            cboRecurso.ReadOnly = True
        Else
            cboProyecto.ReadOnly = False
            cboActividad.ReadOnly = False
            cboRecurso.ReadOnly = False
        End If
    End Sub
End Class