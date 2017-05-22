<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleRequisiciones.aspx.vb" Inherits="CursoExtNet.DetalleRequisiciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ext:Viewport runat="server" Layout="FitLayout">
        <Content>
            <ext:GridPanel ID="gpDetalle" runat="server" Title="Detalle Requisiciones" TitleAlign="Center" Layout="FitLayout">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill runat="server" />
                            <ext:Button ID="btnAutorizar" runat="server" Text="Autorizar" Icon="Accept" Margin="5">
                                <DirectEvents>
                                    <Click OnEvent="btnAutorizar_Click">
                                        <EventMask ShowMask="true" />
                                        <ExtraParams>
                                            <ext:Parameter Name="ID" Value="#{gpDetalle}.selModel.selected.items[0].data.ID" Mode="Raw" />
                                            <ext:Parameter Name="Estatus" Value="#{gpDetalle}.selModel.selected.items[0].data.IDEstatus" Mode="Raw" />
                                        </ExtraParams>
                                    </Click>
                                </DirectEvents>
                                <Listeners>
                                    <Click Handler="return #{gpDetalle}.hasSelection();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnModificar" runat="server" Text="Modificar" Icon="ApplicationEdit" Margin="5" Visible="false">
                            
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Store>
                    <ext:Store ID="stDetalle" runat="server" PageSize="20">
                        <Model>
                            <ext:Model ID="mdDetalle" runat="server">
                                <Fields>
                                    <ext:ModelField Name="ID"             Type="Int" />
	                                <ext:ModelField Name="Fecha"          Type="Date" />
	                                <ext:ModelField Name="Area"           Type="String" />
	                                <ext:ModelField Name="Observaciones"  Type="String" />
	                                <ext:ModelField Name="Proyecto"       Type="String" />
	                                <ext:ModelField Name="Actividad"      Type="String" />
	                                <ext:ModelField Name="Recurso"        Type="String" />
	                                <ext:ModelField Name="IDEstatus"      Type="Int" />
	                                <ext:ModelField Name="Estatus"        Type="String" />
	                                <ext:ModelField Name="Usuario"        Type="String" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column     runat="server" DataIndex="ID"             Text="ID"             Visible="false"/>
	                    <ext:DateColumn runat="server" DataIndex="Fecha"          Text="Fecha"          Format="dd/MM/yyyy"/>
	                    <ext:Column     runat="server" DataIndex="Area"           Text="Area"/>
	                    <ext:Column     runat="server" DataIndex="Observaciones"  Text="Observaciones"  Width="250px"/>
	                    <ext:Column     runat="server" DataIndex="Proyecto"       Text="Proyecto"       Width="150px"/>
	                    <ext:Column     runat="server" DataIndex="Actividad"      Text="Actividad"      Width="150px"/>
	                    <ext:Column     runat="server" DataIndex="Recurso"        Text="Recurso"        Width="150px"/>
	                    <ext:Column     runat="server" DataIndex="IDEstatus"      Text="IDEstatus"      Visible="false"/>
	                    <ext:Column     runat="server" DataIndex="Estatus"        Text="Estatus"/>
	                    <ext:Column     runat="server" DataIndex="Usuario"        Text="Usuario"/>
                    </Columns>
                </ColumnModel>
                <Plugins>
                    <ext:FilterHeader runat="server" />
                </Plugins>
                <BottomBar>
                    <ext:PagingToolbar runat="server" />
                </BottomBar>
            </ext:GridPanel>
        </Content>
    </ext:Viewport>
    <ext:Window ID="wdwAutorizar" runat="server" Title="Autorizar Requisición" TitleAlign="Center" Modal="true" Hidden="true" Width="300px" Height="150px">
        <Items>
            <ext:Hidden ID="hdID" runat="server" />
            <ext:ComboBox ID="cboEstado" runat="server" FieldLabel="Estatus" Margin="5" AnchorHorizontal="100%" DefaultAnchor="100%" DisplayField="Estatus" ValueField="ID" Flex="1">
                <Store>
                    <ext:Store ID="stEstado" runat="server">
                        <Model>
                            <ext:Model ID="mdEstado" runat="server">
                                <Fields>
                                    <ext:ModelField Name="ID" />
                                    <ext:ModelField Name="Estatus" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
            </ext:ComboBox>
        </Items>
        <Buttons>
            <ext:Button ID="btnChangeEstatus" runat="server" Text="Autorizar" Margin="5">
                <DirectEvents>
                    <Click OnEvent="btnChangeEstatus_Click">
                        <EventMask ShowMask="true" />
                        <Confirmation Message="¿Deseas Cambiar a Este Estatus?" Title="Autorizar" ConfirmRequest="true" />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
</asp:Content>
