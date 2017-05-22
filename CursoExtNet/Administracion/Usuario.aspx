<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuario.aspx.vb" Inherits="CursoExtNet.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ext:Viewport runat="server" Layout="FitLayout">
        <Content>
            <ext:GridPanel ID="gpUsuario" runat="server" Title="Usuarios" TitleAlign="Center" >
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:ToolbarFill runat="server"/>
                            <ext:Button ID="btnAgregar" runat="server" Text="Agregar Usuario" Icon="UserAdd" Margin="5">
                            
                            </ext:Button>
                            <ext:Button ID="btnModificar" runat="server" Text="Modificar Usuario" Icon="UserEdit" Margin="5">
                                <Listeners>
                                    <Click Handler="#{wdwTipoUsuario}.show();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Store>
                    <ext:Store ID="stUsuario" runat="server" PageSize="20">
                        <Model>
                            <ext:Model ID="mdUsuario" runat="server">
                                <Fields>
                                    <ext:ModelField Name="ID"               Type="Int" />
	                                <ext:ModelField Name="Codigo"           Type="String" />
	                                <ext:ModelField Name="Nombre"           Type="String" />
	                                <ext:ModelField Name="Telefono"         Type="String" />
	                                <ext:ModelField Name="Correo"           Type="String" />
	                                <ext:ModelField Name="IDTipoUsuario"    Type="Int" />
	                                <ext:ModelField Name="TipoUsuario"      Type="String" />
	                                <ext:ModelField Name="IDEstatus"        Type="Int" />
	                                <ext:ModelField Name="Estatus"          Type="String" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column runat="server" Text="ID"            DataIndex="ID"              Visible="false"/>
	                    <ext:Column runat="server" Text="Codigo"        DataIndex="Codigo"/>
	                    <ext:Column runat="server" Text="Nombre"        DataIndex="Nombre"          Width="250px"/>
	                    <ext:Column runat="server" Text="Telefono"      DataIndex="Telefono"/>
	                    <ext:Column runat="server" Text="Correo"        DataIndex="Correo"          Width="150px"/>
	                    <ext:Column runat="server" Text="IDTipoUsuario" DataIndex="IDTipoUsuario"   Visible="false"/>
	                    <ext:Column runat="server" Text="Tipo Usuario"  DataIndex="TipoUsuario"     Width="200px"/>
	                    <ext:Column runat="server" Text="IDEstatus"     DataIndex="IDEstatus"       Visible="false"/>
	                    <ext:Column runat="server" Text="Estatus"       DataIndex="Estatus"/>
                    </Columns>
                </ColumnModel>
                <Plugins>
                    <ext:FilterHeader runat="server" />
                </Plugins>
                <BottomBar>
                    <ext:PagingToolbar runat="server" />
                </BottomBar>
            </ext:GridPanel>            
            <ext:Window ID="wdwTipoUsuario" runat="server" Title="Registrar Usuario" Hidden="true" Modal="true" Layout="AnchorLayout" Width="400px">
            <Items>
                <ext:FormPanel runat="server" BodyPadding="5" Margin="5" AnchorHorizontal="100%" AnchorVertical="100%" DefaultAnchor="100%">
                    <Items>
                        <ext:TextField  ID="txtCodigo"      runat="server" FieldLabel="Código"       Flex="1" />
                        <ext:TextField  ID="Nombre"         runat="server" FieldLabel="Nombre"       Flex="1" />
                        <ext:TextField  ID="Telefono"       runat="server" FieldLabel="Telefono"     Flex="1" />
                        <ext:TextField  ID="Correo"         runat="server" FieldLabel="Correo"       Flex="1" />
                        <ext:ComboBox   ID="cboTipoUsuario" runat="server" FieldLabel="Tipo Usuario" Flex="1" />
                        <ext:ComboBox   ID="cboEstatus"     runat="server" FieldLabel="Estatus"      Flex="1" />                        
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnAceptar" runat="server" Icon="UserAdd" Text="Aceptar">
                
                </ext:Button>                
                <ext:Button ID="btnCancelar" runat="server" Icon="UserCross" Text="Cancelar">
                   
                </ext:Button>
            </Buttons>
        </ext:Window>
        </Content>
    </ext:Viewport>    
</asp:Content>
