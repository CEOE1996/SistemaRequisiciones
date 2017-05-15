<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleProyecto.aspx.vb" Inherits="CursoExtNet.DetalleProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ext:Viewport runat="server" Layout="FitLayout">
    <Content>
        <ext:GridPanel ID="gpDetalle" runat="server" Title="Detalle de Proyectos" TitleAlign="Center" Layout="FitLayout">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarFill runat="server" />
                        <ext:Button ID="btnDetalle"     runat="server" Text="Mostrar Detalles"      Icon="Information"      Margin="5">
                            <DirectEvents>
                            
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnModificar"   runat="server" Text="Modificar Vigencia"    Icon="ApplicationEdit"  Margin="5">
                            <DirectEvents>
                            
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnMontos"      runat="server" Text="Actualizar Montos"     Icon="MoneyAdd"         Margin="5">
                            <DirectEvents>
                                
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Store>
                <ext:Store ID="stDetalle" runat="server" PageSize="20">
                    <Model>
                        <ext:Model ID="mdDetalle" runat="server">
                            <Fields>
                                <ext:ModelField Name="ID" Type="Int" />
	                            <ext:ModelField Name="IDCA" Type="Int" />
	                            <ext:ModelField Name="CuerpoAcademico" Type="String" />
	                            <ext:ModelField Name="Clave" Type="String" />
	                            <ext:ModelField Name="Nombre" Type="String" />
	                            <ext:ModelField Name="Descripcion" Type="String" />
	                            <ext:ModelField Name="MontoDisponible" Type="Float" />
	                            <ext:ModelField Name="VigenciaInicio" Type="Date" />
	                            <ext:ModelField Name="VigenciaFin" Type="Date" />
	                            <ext:ModelField Name="Estatus" Type="Int" />
	                            <ext:ModelField Name="DescEstatus" Type="String" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel>
                <Columns>
		            <ext:Column     runat="server" Text="ID"                DataIndex="ID"              Visible="false"/>
	                <ext:Column     runat="server" Text="ID CA"             DataIndex="IDCA"            Width="75px"/>
	                <ext:Column     runat="server" Text="Cuerpo Academico"  DataIndex="CuerpoAcademico" Width="150px"/>
	                <ext:Column     runat="server" Text="Clave"             DataIndex="Clave"           Width="100px"/>
	                <ext:Column     runat="server" Text="Nombre"            DataIndex="Nombre"          Width="200px"/>
	                <ext:Column     runat="server" Text="Descripcion"       DataIndex="Descripcion"     Width="250"/>
	                <ext:Column     runat="server" Text="Monto Disponible"  DataIndex="MontoDisponible" Width="100px"/>
	                <ext:DateColumn runat="server" Text="Vigencia Inicio"   DataIndex="VigenciaInicio"  Width="100px"    Format="dd/MM/yyyy"/>
	                <ext:DateColumn runat="server" Text="Vigencia Fin"      DataIndex="VigenciaFin"     Width="100px"    Format="dd/MM/yyyy"/>
	                <ext:Column     runat="server" Text="Estatus"           DataIndex="Estatus"         Visible="false"/>
	                <ext:Column     runat="server" Text="Estatus"           DataIndex="DescEstatus"/>
                </Columns>
            </ColumnModel>
            <BottomBar>
                <ext:PagingToolbar runat="server" />
            </BottomBar>
            <Plugins>
                <ext:FilterHeader runat="server" />
            </Plugins>
        </ext:GridPanel>
    </Content>
</ext:Viewport>
</asp:Content>
