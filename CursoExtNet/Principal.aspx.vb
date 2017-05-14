Public Class Principal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not VariablesSesion.ExistenVariables Then
                IniciarSesion()
            End If

            If VariablesSesion.ExistenVariables Then
                Dim lp_root As New Ext.Net.Node

                lp_root.Children.AddRange(ConsultaMenu())
                TreePanel1.Root.Add(lp_root)
                If lp_root.Children.Count > 0 Then
                    TreePanel1.Root(0).Expanded = True
                    TreePanel1.RootVisible = False
                End If

                lblNombre.Text = VariablesSesion.Nombre
                lblGpoUsuario.Text = VariablesSesion.TipoUsuario
            End If
        End If
    End Sub

    Public Sub IniciarSesion()
        wdwLogIn.Show()
    End Sub

    Public Function ValidaUsuario() As Boolean

        Try
            clsSQL.AddParameter("@Codigo", txtUser.Text)
            clsSQL.AddParameter("@Contraseña", txtPass.Text)

            Dim lp_dt As DataTable = clsSQL.List("SPQ_ValidaUsuario")
            If lp_dt.Rows.Count > 0 Then
                If lp_dt(0)("IDEstatus") <> 1 Then
                    Ext.Net.X.Msg.Alert("Error", "Lo Sentimos, Tu Estatus es " & lp_dt(0)("Estatus")).Show()
                    Return False
                End If
                VariablesSesion.Nombre = lp_dt(0)("Nombre")
                VariablesSesion.ID = lp_dt(0)("ID")
                VariablesSesion.TipoUsuario = lp_dt(0)("TipoUsuario")
                VariablesSesion.IDTipoUsuario = lp_dt(0)("IDTipoUsuario")
                VariablesSesion.Codigo = lp_dt(0)("Codigo")
                VariablesSesion.Correo = lp_dt(0)("Correo")
                wdwLogIn.Close()
                lblNombre.Text = lp_dt(0)("Nombre")
                lblGpoUsuario.Text = lp_dt(0)("TipoUsuario")
                Return True
            Else
                Ext.Net.X.Msg.Alert("Error", "No se ha encontrado el usuario, o está inactivo.").Show()
                Return False
            End If
        Catch ex As Exception
            Ext.Net.X.Msg.Alert("Error", ex.Message).Show()
            Return False
        End Try
    End Function

    Public Sub btnIngresar_Click(sender As Object, e As Ext.Net.DirectEventArgs)
        If Not String.IsNullOrEmpty(txtPass.Text) And Not String.IsNullOrEmpty(txtUser.Text) Then
            If ValidaUsuario() Then
                Dim lp_root As New Ext.Net.Node

                lp_root.Children.AddRange(ConsultaMenu())
                TreePanel1.Root.Add(lp_root)
                If lp_root.Children.Count > 0 Then
                    TreePanel1.Root(0).Expanded = True
                    TreePanel1.RootVisible = False
                End If

                lblNombre.Text = VariablesSesion.Nombre
                lblGpoUsuario.Text = VariablesSesion.TipoUsuario
            End If
        Else
            Ext.Net.X.Msg.Alert("Error", "Favor de Llenar todos los Campos").Show()
        End If
    End Sub

    Private Function ConsultaMenu() As Ext.Net.NodeCollection
        Dim lp_nodos As New Ext.Net.NodeCollection(False)
        Dim lp_nodo As Ext.Net.Node = Nothing

        clsSQL.AddParameter("@ID", VariablesSesion.ID)
        Dim lp_list As List(Of Menu) = clsSQL.List("SPQ_CargaMenu").toList(Of Menu)()

        For Each item As Menu In lp_list.FindAll(Function(i) i.padre.HasValue = False)
            lp_nodo = New Ext.Net.Node

            CargaNodos(item, lp_list, lp_nodo)

            lp_nodos.Add(lp_nodo)
        Next

        Return lp_nodos
    End Function

    Private Sub CargaNodos(item As Menu, list As List(Of Menu), nodo As Ext.Net.Node)
        Dim lp_nodoHijo As Ext.Net.Node = Nothing

        nodo.NodeID = item.menu
        nodo.Text = item.desc_menu
        nodo.Leaf = True
        nodo.CustomAttributes.Add(New Ext.Net.ConfigItem With {.Name = "url", .Value = item.direccion, .Mode = Ext.Net.ParameterMode.Value})

        For Each hijo In list.FindAll(Function(i) IIf(i.padre.HasValue, i.padre, -1) = item.menu)
            lp_nodoHijo = New Ext.Net.Node
            nodo.Leaf = False

            CargaNodos(hijo, list, lp_nodoHijo)

            nodo.Children.Add(lp_nodoHijo)
        Next
    End Sub

End Class

Public Class Menu
    Public Property menu As Integer
    Public Property desc_menu As String
    Public Property direccion As String
    Public Property padre As Nullable(Of Integer)
End Class