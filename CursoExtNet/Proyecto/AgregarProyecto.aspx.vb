Public Class AgregarProyecto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdID.Value = 0
        End If
    End Sub

    Public Sub btnGuardar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        If Guardar() Then
            Ext.Net.X.Msg.Notify("Guardar", "Proyecto Guardado Satisfactoriamente").Show()
        End If
    End Sub

    Public Sub btnAddAct_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        Try
            If Not Guardar() Then
                Return
            End If
            If ValidaActividad() Then
                clsActividad.Add(New clsActividad With {.Proyecto = hdID.Value,
                                                        .IDActividad = txtIDAct.Value,
                                                        .Descripcion = txtActividad.Text
                                                      })
                txtIDAct.Clear()
                txtActividad.Clear()
                stActividades.Reload()
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
End Class