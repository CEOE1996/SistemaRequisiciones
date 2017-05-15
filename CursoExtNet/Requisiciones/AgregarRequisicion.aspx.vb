Public Class AgregarRequisicion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdID.Value = 0
            dtfFecha.Value = Date.Today
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

End Class