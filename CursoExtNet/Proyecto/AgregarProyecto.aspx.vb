Public Class AgregarProyecto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdID.Value = 0
        End If
    End Sub

    '==========================================================================================================
    'Button Events
    '==========================================================================================================
#Region "Button Events"
    Public Sub btnGuardar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        If Guardar() Then
            Ext.Net.X.Msg.Notify("Guardar", "Proyecto Guardado Satisfactoriamente").Show()
        End If
    End Sub

    Public Sub btnAddAct_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If Guardar() Then
                If ValidaActividad() Then
                    clsActividad.Add(New clsActividad With {.Proyecto = hdID.Value,
                                                            .IDActividad = txtIDAct.Value,
                                                            .Descripcion = txtActividad.Text
                                                          })
                    txtIDAct.Clear()
                    txtActividad.Clear()
                    stActividades.Reload()
                End If
            End If
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnAddUser_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If Not String.IsNullOrEmpty(cboRUsuario.Text) Then
                clsUsuario.AgregarActividad(cboRUsuario.Value, hdIDAct.Value)
                cboRUsuario.Clear()
                stUsuarios.Reload()
                stActividades.Reload()
            Else
                Ext.Net.X.Msg.Alert("Error", "Favor de Seleccionar Un Usuario").Show()
            End If
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnDeleteUser_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            clsUsuario.EliminarActividad(e.ExtraParams("ID"), hdIDAct.Value)
            stUsuarios.Reload()
            stActividades.Reload()
            Ext.Net.X.Msg.Notify("Eliminar", "Usuario Eliminado Satisfactoriamente").Show()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnUsers_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            hdIDAct.Value = e.ExtraParams("ID")
            txtRIDAct.Text = e.ExtraParams("IDActividad")
            txtRAct.Text = e.ExtraParams("Descripcion")
            stUsuarios.Reload()
            wdwUsuarios.Show()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnRecursos_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            hdIDAct.Value = e.ExtraParams("ID")
            txtRecIDAct.Text = e.ExtraParams("IDActividad")
            txtRecAct.Text = e.ExtraParams("Descripcion")
            stRecursos.Reload()
            wdwRecursos.Show()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnAddRecurso_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If ValidaRecurso() Then
                clsRecurso.Agregar(New clsRecurso With {.Actividad = hdIDAct.Value,
                                                       .IDRecurso = txtIDRec.Text,
                                                       .Monto = txtMonto.Value,
                                                       .Tipo = txtTipo.Text,
                                                       .Descripcion = txtDescRecurso.Text
                                                        })
            End If
            stRecursos.Reload()
            txtIDRec.Clear()
            txtMonto.Clear()
            txtTipo.Clear()
            txtDescRecurso.Clear()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnDeleteRecurso_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            clsRecurso.Eliminar(e.ExtraParams("ID"))
            Ext.Net.X.Msg.Alert("Eliminar", "Se Ha Eliminado el Recurso Satisfactoriamente").Show()
            stRecursos.Reload()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnDelete_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            clsActividad.Eliminar(e.ExtraParams("ID"))
            Ext.Net.X.Msg.Notify("Eliminar Actividad", "Se ha Eliminado la Actividad Satisfactoriamente").Show()
            stActividades.Reload()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnAddProducto_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            hdIDRec.Value = e.ExtraParams("ID")
            wdwAddProducto.Show()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnDeleteProducto_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            hdIDRec.Value = e.ExtraParams("ID")
            stDeleteProducto.Reload()
            wdwDeleteProducto.Show()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnAgregarProducto_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If String.IsNullOrEmpty(txtAddProducto.Text) OrElse
                String.IsNullOrEmpty(txtCantidad.Text) _
            Then
                Ext.Net.X.Msg.Alert("Error", "Favor de Llenar Todos Los Campos").Show()
                Return
            End If
            If txtCantidad.Value <= 0 Then
                Ext.Net.X.Msg.Alert("Error", "Cantidad Invalida").Show()
                Return
            End If
            clsProducto.Agregar(New clsProducto With {.Recurso = hdIDRec.Value,
                                                     .Descripcion = txtAddProducto.Text,
                                                     .Cantidad = txtCantidad.Text
                                                    })
            wdwAddProducto.Close()
            txtAddProducto.Clear()
            txtCantidad.Clear()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Sub

    Public Sub btnConcluir_click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If Guardar() Then
                clsSQL.AddParameter("@ID", hdID.Value)
                clsSQL.ExecNonQuery("SPU_AvanzarProyecto", CommandType.StoredProcedure)
                Ext.Net.X.Msg.Notify("Concluir Proyecto", "Se Ha Concluido la Captura del Proyecto Satisfactoriamente").Show()
                HabilitarControles(2)
            End If
        Catch ex As Exception
            ex.ManejoErrores()
        End Try

    End Sub

    Public Sub btnEliminarProducto_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If String.IsNullOrEmpty(cboDeleteProducto.Text) Then
                Ext.Net.X.Msg.Alert("Error", "Favor de Seleccionar un Producto").Show()
                Return
            End If
            clsProducto.Eliminar(cboDeleteProducto.Value)
            cboDeleteProducto.Clear()
            wdwDeleteProducto.Close()
            Ext.Net.X.Msg.Notify("Eliminar", "Producto Eliminado Satisfactoriamente").Show()
        Catch ex As Exception
            ex.ManejoErrores()
        End Try

    End Sub

#End Region

    '==========================================================================================================
    'Validaciones
    '==========================================================================================================
#Region "Validaciones"
    Private Function ValidaProyecto() As Boolean
        If String.IsNullOrEmpty(txtCA.Text) OrElse
            String.IsNullOrEmpty(txtNombre.Text) OrElse
            String.IsNullOrEmpty(txtDescripcion.Text) OrElse
            String.IsNullOrEmpty(txtClave.Text) OrElse
            String.IsNullOrEmpty(dtfVigenciaFin.Text) OrElse
            String.IsNullOrEmpty(dtfVigenciaInicio.Text) OrElse
            String.IsNullOrEmpty(txtIDCA.Text) _
        Then
            Ext.Net.X.Msg.Alert("Error", "Favor de Llenar Todos los Campos").Show()
            Return False
        End If

        If txtIDCA.Value <= 0 Then
            Ext.Net.X.Msg.Alert("Error", "El ID CA es Invalido").Show()
            Return False
        End If

        If dtfVigenciaFin.Text = "01/01/0001 12:00:00 a.m." OrElse
            dtfVigenciaInicio.Text = "01/01/0001 12:00:00 a.m." _
        Then
            Ext.Net.X.Msg.Alert("Error", "Fechas Invalidas").Show()
            Return False
        End If

        If dtfVigenciaInicio.Value >= dtfVigenciaFin.Value Then
            Ext.Net.X.Msg.Alert("Error", "Vigencia Inicial no Puede Ser Mayour a Vigencia Final").Show()
            Return False
        End If

        Return True
    End Function

    Private Function ValidaActividad() As Boolean
        If String.IsNullOrEmpty(txtActividad.Text) OrElse
            String.IsNullOrEmpty(txtIDAct.Text) _
        Then
            Ext.Net.X.Msg.Alert("Error", "Favor de Llenar Todos los Campos de Actividad").Show()
            Return False
        End If

        If txtIDAct.Value <= 0 Then
            Ext.Net.X.Msg.Alert("Error", "El ID Actividad es Invalido").Show()
            Return False
        End If

        If hdID.Value = 0 Then
            Return False
        End If

        Return True
    End Function

    Private Function ValidaRecurso()
        If String.IsNullOrEmpty(txtDescRecurso.Text) OrElse
            String.IsNullOrEmpty(txtIDRec.Text) OrElse
            String.IsNullOrEmpty(txtMonto.Text) OrElse
            String.IsNullOrEmpty(txtTipo.Text) _
        Then
            Ext.Net.X.Msg.Alert("Error", "Favor de LLenar Todos los Campos").Show()
            Return False
        End If

        If txtMonto.Value <= 0 OrElse txtIDRec.Value <= 0 Then
            Ext.Net.X.Msg.Alert("Error", "Cantidades Invalidas").Show()
            Return False
        End If

        Return True
    End Function
#End Region

    '==========================================================================================================
    'Funciones
    '==========================================================================================================
#Region "Funciones"
    Private Function Guardar() As Boolean
        If ValidaProyecto() Then
            Try
                Dim Proyecto As clsProyecto = New clsProyecto With {.IDCA = txtIDCA.Text,
                                                                    .CuerpoAcademico = txtCA.Text,
                                                                    .Nombre = txtNombre.Text,
                                                                    .Clave = txtClave.Text,
                                                                    .Descripcion = txtDescripcion.Text,
                                                                    .VigenciaInicio = dtfVigenciaInicio.Value,
                                                                    .VigenciaFin = dtfVigenciaFin.Value,
                                                                    .ID = hdID.Value
                                                                   }
                If hdID.Value = 0 Then
                    hdID.Value = clsProyecto.Add(Proyecto)
                Else
                    clsProyecto.Update(Proyecto)
                End If
                Return True
            Catch ex As Exception
                ex.ManejoErrores()
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Private Sub HabilitarControles(Estatus As Integer)
        If Estatus = 1 Then
            txtCA.ReadOnly = False
            txtIDCA.ReadOnly = False
            txtNombre.ReadOnly = False
            txtClave.ReadOnly = False
            txtDescripcion.ReadOnly = False
            dtfVigenciaFin.ReadOnly = False
            dtfVigenciaInicio.ReadOnly = False
            txtIDAct.ReadOnly = False
            txtActividad.ReadOnly = False
            txtRecIDAct.ReadOnly = False
            txtRecAct.ReadOnly = False
            txtTipo.ReadOnly = False
            txtIDRec.ReadOnly = False
            txtMonto.ReadOnly = False
            txtAddProducto.ReadOnly = False
            txtCantidad.ReadOnly = False
            txtDescRecurso.ReadOnly = False
            cboRUsuario.ReadOnly = False
            cboDeleteProducto.ReadOnly = False

            btnAddRecurso.Hidden = False
            btnDeleteRecurso.Hidden = False
            btnAddAct.Hidden = False
            btnDelete.Hidden = False
            btnConcluir.Hidden = False
            btnGuardar.Hidden = False
            btnAddUser.Hidden = False
            btnDeleteUser.Hidden = False
            btnAgregarProducto.Hidden = False
            btnEliminarProducto.Hidden = False

        Else
            txtCA.ReadOnly = True
            txtIDCA.ReadOnly = True
            txtNombre.ReadOnly = True
            txtClave.ReadOnly = True
            txtDescripcion.ReadOnly = True
            dtfVigenciaFin.ReadOnly = True
            dtfVigenciaInicio.ReadOnly = True
            txtIDAct.ReadOnly = True
            txtActividad.ReadOnly = True
            txtRecIDAct.ReadOnly = True
            txtRecAct.ReadOnly = True
            txtTipo.ReadOnly = True
            txtIDRec.ReadOnly = True
            txtMonto.ReadOnly = True
            txtAddProducto.ReadOnly = True
            txtCantidad.ReadOnly = True
            txtDescRecurso.ReadOnly = True
            cboRUsuario.ReadOnly = True
            cboDeleteProducto.ReadOnly = True

            btnAddRecurso.Hidden = True
            btnDeleteRecurso.Hidden = True
            btnAddAct.Hidden = True
            btnDelete.Hidden = True
            btnConcluir.Hidden = True
            btnGuardar.Hidden = True
            btnAddUser.Hidden = True
            btnDeleteUser.Hidden = True
            btnAgregarProducto.Hidden = True
            btnEliminarProducto.Hidden = True
        End If
    End Sub

    <Ext.Net.DirectMethod(ShowMask:=True)>
    Public Shared Function GetRecursos(Parameters As Dictionary(Of String, String)) As String
        Try
            clsSQL.AddParameter("@ID", Parameters("ID"))
            Dim lp_dt As DataTable = clsSQL.List("SPQ_Recursos", CommandType.StoredProcedure)
            Dim lp_model As New Ext.Net.Model
            lp_model.Fields.Add("Actividad")
            lp_model.Fields.Add("IDRecurso")
            lp_model.Fields.Add("Tipo")
            lp_model.Fields.Add("Descripcion")
            lp_model.Fields.Add("Monto")
            Dim lp_column As New Ext.Net.ColumnCollection
            lp_column.Add(New Ext.Net.Column With {.Text = "Actividad", .DataIndex = "Actividad", .Visible = False})
            lp_column.Add(New Ext.Net.Column With {.Text = "ID Recurso", .DataIndex = "IDRecurso", .Width = New Unit(75, UnitType.Pixel)})
            lp_column.Add(New Ext.Net.Column With {.Text = "Descripción", .DataIndex = "Descripcion", .Flex = "1"})
            lp_column.Add(New Ext.Net.Column With {.Text = "Tipo", .DataIndex = "Tipo", .Width = New Unit(150, UnitType.Pixel)})
            lp_column.Add(New Ext.Net.Column With {.Text = "Monto", .DataIndex = "Monto", .Width = New Unit(50, UnitType.Pixel)})

            Dim lp_Store As New Ext.Net.Store
            lp_Store.Model.Add(lp_model)
            lp_Store.DataSource = lp_dt
            Dim lp_grid As New Ext.Net.GridPanel With {.Height = If(lp_dt.Rows.Count >= 5, 100, 30 + (lp_dt.Rows.Count * 20)), .EnableColumnHide = False, .Scroll = Ext.Net.ScrollMode.Both}
            lp_grid.ColumnModel.Add(lp_column)
            lp_grid.Store.Add(lp_Store)
            Return Ext.Net.ComponentLoader.ToConfig(lp_grid)
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Function

    <Ext.Net.DirectMethod(ShowMask:=True)>
    Public Shared Function GetProductos(Parameters As Dictionary(Of String, String)) As String
        Try
            clsSQL.AddParameter("@ID", Parameters("ID"))
            Dim lp_dt As DataTable = clsSQL.List("SPQ_Producto", CommandType.StoredProcedure)
            Dim lp_model As New Ext.Net.Model
            lp_model.Fields.Add("ID")
            lp_model.Fields.Add("Descripcion")
            lp_model.Fields.Add("Cantidad")
            Dim lp_column As New Ext.Net.ColumnCollection
            lp_column.Add(New Ext.Net.Column With {.Text = "ID", .DataIndex = "ID", .Visible = False})
            lp_column.Add(New Ext.Net.Column With {.Text = "Descripción", .DataIndex = "Descripcion", .Flex = "1"})
            lp_column.Add(New Ext.Net.Column With {.Text = "Cantidad", .DataIndex = "Cantidad", .Width = New Unit(150, UnitType.Pixel)})

            Dim lp_Store As New Ext.Net.Store
            lp_Store.Model.Add(lp_model)
            lp_Store.DataSource = lp_dt
            Dim lp_grid As New Ext.Net.GridPanel With {.Height = If(lp_dt.Rows.Count >= 5, 100, 30 + (lp_dt.Rows.Count * 20)), .EnableColumnHide = False, .Scroll = Ext.Net.ScrollMode.Both}
            lp_grid.ColumnModel.Add(lp_column)
            lp_grid.Store.Add(lp_Store)
            Return Ext.Net.ComponentLoader.ToConfig(lp_grid)
        Catch ex As Exception
            ex.ManejoErrores()
        End Try
    End Function
#End Region

    '==========================================================================================================
    'Store Read Data
    '==========================================================================================================
#Region "Store Read Data"
    Private Sub stActividades_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stActividades.ReadData
        stActividades.DataSource = clsActividad.List(hdID.Value)
        stActividades.DataBind()
    End Sub

    Private Sub stUsuarios_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stUsuarios.ReadData
        stUsuarios.DataSource = clsUsuario.ConsultaActividad(hdIDAct.Value)
        stUsuarios.DataBind()
    End Sub

    Private Sub stRecursos_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stRecursos.ReadData
        stRecursos.DataSource = clsRecurso.List(hdIDAct.Value)
        stRecursos.DataBind()
    End Sub

    Private Sub stDeleteProducto_ReadData(sender As Object, e As Ext.Net.StoreReadDataEventArgs) Handles stDeleteProducto.ReadData
        stDeleteProducto.DataSource = clsProducto.Listar(hdIDRec.Value)
        stDeleteProducto.DataBind()
    End Sub
#End Region

End Class