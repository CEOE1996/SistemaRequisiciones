<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgregarRequisicion.aspx.vb" Inherits="CursoExtNet.AgregarRequisicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ext:Viewport runat="server" Layout="FitLayout">
        <Content>
            <ext:FormPanel ID="frmRequisiciones" runat="server" Title="Nueva Requisición" TitleAlign="Center" BodyPadding="5" OverflowY="Auto">
                <Items>
                    <ext:Hidden ID="hdID" runat="server" />
                    <ext:FieldSet ID="fsInfo" runat="server" Title="Información De Requisición" Margin="5">
                        <Items>
                            <ext:FieldContainer runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:TextField  ID="txtArea"    runat="server" FieldLabel="Área"    Margin="5" Flex="2" />
                                    <ext:DateField  ID="dtfFecha"   runat="server" FieldLabel="Fecha"   Margin="5" Flex="1" ReadOnly="true" />
                                </items>
                            </ext:FieldContainer>
                            <ext:TextArea ID="txtObservaciones" runat="server" FieldLabel="Observacionens" Margin="5" AnchorHorizontal="100%" DefaultAnchor="100%" />
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="fsProyecto" runat="server" Title="Información Del Proyecto" Margin="5">
                        <Items>
                            <ext:FieldContainer runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:ComboBox   ID="cboProyecto"    runat="server" FieldLabel="Proyecto"    Margin="5" Flex="1" Editable="false" ForceSelection="true" ValueField="ID" DisplayField="Descripcion" >
                                        <Store>
                                            <ext:Store ID="stProyecto" runat="server">
                                                <Model>
                                                    <ext:Model ID="mdProyecto" runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="ID" />
                                                            <ext:ModelField Name="Descripcion" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                    </ext:ComboBox>
                                    <ext:ComboBox   ID="cboActividad"   runat="server" FieldLabel="Actividad"   Margin="5" Flex="1" Editable="false" ForceSelection="true" ValueField="ID" DisplayField="Descripcion" >
                                        <Store>
                                            <ext:Store ID="stActividad" runat="server">
                                                <Model>
                                                    <ext:Model ID="mdActividad" runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="ID" />
                                                            <ext:ModelField Name="Descripcion" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                    </ext:ComboBox>
                                    <ext:ComboBox   ID="cboRecurso"     runat="server" FieldLabel="Recurso"     Margin="5" Flex="1" Editable="false" ForceSelection="true" ValueField="ID" DisplayField="Descripcion" >
                                        <Store>
                                            <ext:Store ID="stRecurso" runat="server">
                                                <Model>
                                                    <ext:Model ID="mdRecurso" runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="ID" />
                                                            <ext:ModelField Name="Descripcion" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                    </ext:ComboBox>
                                </Items>
                            </ext:FieldContainer>
                        </Items>
                    </ext:FieldSet>
                    <ext:GridPanel ID="gpDetalle" runat="server" Title="Productos" TitleAlign="Center" AnchorHorizontal="100%" AnchorVertical="59%" DefaultAnchor="100%" Scroll="Both" Margin="5">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ComboBox ID="cboProducto" runat="server" FieldLabel="Producto" Margin="5" ValueField="ID" DisplayField="Descripcion" Width="500px" Editable="false" ForceSelection="true">
                                        <Store>
                                            <ext:Store ID="stProducto" runat="server" >
                                                <Model>
                                                    <ext:Model ID="mdProcucto" runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="ID" />
                                                            <ext:ModelField Name="Descripcion" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                    </ext:ComboBox>
                                    <ext:NumberField ID="txtCantidad" runat="server" FieldLabel="Cantidad" Margin="5" AllowDecimals="true" />
                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button ID="btnAgregar" runat="server" Text="Agregar" Icon="Add" Margin="5">
                                    
                                    </ext:Button>
                                    <ext:Button ID="btnEliminar" runat="server" Text="Eliminar" Icon="Delete" Margin="5">
                                    
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="stDetalle" runat="server">
                                <Model>
                                    <ext:Model ID="mdDetalle" runat="server">
                                        <Fields>
                                            <ext:ModelField Name="ID" />
                                            <ext:ModelField Name="Producto" />
                                            <ext:ModelField Name="Cantidad" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column runat="server" DataIndex="ID"       Text="ID"       Visible="false" />
                                <ext:Column runat="server" DataIndex="Producto" Text="Producto" Flex="1" />
                                <ext:Column runat="server" DataIndex="Cantidad" Text="Cantidad" Width="100px" />
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnGuardar" runat="server" Text="Guardar" Icon="Disk" Margin="5">
                    
                    </ext:Button>
                    <ext:Button ID="btnSolicitar" runat="server" Text="Solicitar" Icon="PlayGreen" Margin="5">
                    
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Content>
    </ext:Viewport>
</asp:Content>
