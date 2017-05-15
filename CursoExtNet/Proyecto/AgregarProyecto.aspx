<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgregarProyecto.aspx.vb" Inherits="CursoExtNet.AgregarProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <ext:Viewport runat="server" Layout="FitLayout">
        <Content>
            <ext:FormPanel ID="frmAddProject" runat="server" Title="Agregar Proyecto" TitleAlign="Center" BodyPadding="5" OverflowY="Auto" >
                <Items>                    
                    <ext:Hidden ID="hdID" runat="server" />
                    <ext:Hidden ID="hdIDAct" runat="server" />
                    <ext:FieldSet ID="fsCA" runat="server" Title="Información Cuerpo Académico" Margin="5">
                        <Items>
                            <ext:FieldContainer runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:TextField      ID="txtCA"      runat="server" FieldLabel="Cuerpo Académico"    Margin="5" Flex="2" LabelWidth="125"/>
                                    <ext:NumberField    ID="txtIDCA"    runat="server" FieldLabel="ID CA"               Margin="5" Flex="1" AllowDecimals="false"/>
                                </items>
                            </ext:FieldContainer>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="fsProyecto" runat="server" Title="Información del Proyecto" Margin="5">
                        <Items>
                            <ext:FieldContainer runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:TextField      ID="txtNombre"  runat="server" FieldLabel="Nombre del Proyecto" Margin="5" Flex="2" LabelWidth="125"/>
                                    <ext:TextField      ID="txtClave"   runat="server" FieldLabel="Clave"               Margin="5" Flex="1"/>
                                </Items>
                            </ext:FieldContainer>
                            <ext:FieldContainer runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:TextArea       ID="txtDescripcion" runat="server"  FieldLabel="Descripción del Proyecto"   Margin="5" Flex="1" LabelWidth="125" ReadOnlyCls="readonly-class"/>
                                </Items>
                            </ext:FieldContainer>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="fsFechas" runat="server" Title="Fechas" Margin="5">
                        <Items>
                            <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:DateField ID="dtfVigenciaInicio" runat="server" FieldLabel="Fecha Inicio" Margin="5" Flex="1" LabelWidth="125" Editable="false" />
                                    <ext:DateField ID="dtfVigenciaFin" runat="server" FieldLabel="Vigencia" Margin="5" Flex="1" Editable="false" />
                                    <ext:Component runat="server" Margin="5" Flex="1" />
                                </Items>
                            </ext:FieldContainer>
                        </Items>
                    </ext:FieldSet>
                    <ext:GridPanel ID="gpActividades" runat="server" Title="Actividades" TitleAlign="Center" Margin="5" Layout="AnchorLayout" Scroll="Both">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:NumberField ID="txtIDAct" runat="server" FieldLabel="ID Actividad" Width="200px" Margin="5" AllowDecimals="false" />
                                    <ext:TextField ID="txtActividad" runat="server" FieldLabel="Descripción" Width="350px" Margin="5" />
                                    <ext:ToolbarFill runat="server"/>
                                    <ext:Button ID="btnAddAct" runat="server" Text="Agregar" Icon="Add">
                                        <DirectEvents>
                                            <Click OnEvent="btnAddAct_Click">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnDelete" runat="server" Text="Eliminar" Icon="Delete">
                                        <DirectEvents>
                                            <Click OnEvent="btnDelete_Click">
                                                <EventMask ShowMask="true" />
                                                <Confirmation Title="Eliminar Actividad" Message="¿Desea Eliminar la Actividad" ConfirmRequest="true" />
                                                 <ExtraParams>
                                                    <ext:Parameter Name="ID" Value="#{gpActividades}.selModel.selected.items[0].data.ID" Mode="Raw" />
                                                </ExtraParams>                                                
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="return #{gpActividades}.hasSelection();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="stActividades" runat="server">
                                <Model>
                                    <ext:Model ID="mdActividades" runat="server">
                                        <Fields>
                                            <ext:ModelField Name="ID"           Type="Int" />                                            
                                            <ext:ModelField Name="Proyecto"     Type="Int" />                                            
                                            <ext:ModelField Name="IDActividad"  Type="Int" />
                                            <ext:ModelField Name="Descripcion"  Type="String" />
                                            <ext:ModelField Name="Usuarios"     Type="String" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column runat="server" DataIndex="ID"           Text="ID"           Visible="false" />
                                <ext:Column runat="server" DataIndex="Proyecto"     Text="IDProv"       Visible="false" />
                                <ext:Column runat="server" DataIndex="IDActividad"  Text="ID Actividad" Width="75px" />
                                <ext:Column runat="server" DataIndex="Descripcion"  Text="Descripcion"  Width="200px" />                                
                                <ext:Column runat="server" DataIndex="Usuarios"     Text="Usuarios"     Flex="1" />                                
                                <ext:CommandColumn runat="server">
                                    <Commands>
                                        <ext:GridCommand Icon="GroupAdd" Text="Agregar Usuario" CommandName="Add" />
                                    </Commands>
                                    <DirectEvents>
                                        <Command OnEvent="btnUsers_Click">
                                            <EventMask ShowMask="true" />
                                            <ExtraParams>
                                                <ext:Parameter Name="ID"            Value="record.data.ID"          Mode="Raw" />
                                                <ext:Parameter Name="IDActividad"   Value="record.data.IDActividad" Mode="Raw" />
                                                <ext:Parameter Name="Descripcion"   Value="record.data.Descripcion" Mode="Raw" />
                                            </ExtraParams>
                                        </Command>
                                    </DirectEvents>
                                </ext:CommandColumn>
                                <ext:CommandColumn runat="server">
                                    <Commands>
                                        <ext:GridCommand Icon="Overlays" Text="Ver Recursos" CommandName="AddResource" />                                    
                                    </Commands>
                                    <DirectEvents>
                                        <Command OnEvent="btnRecursos_Click">
                                            <EventMask ShowMask="true" />
                                            <ExtraParams>
                                                <ext:Parameter Name="ID"            Value="record.data.ID"          Mode="Raw" />
                                                <ext:Parameter Name="IDActividad"   Value="record.data.IDActividad" Mode="Raw" />
                                                <ext:Parameter Name="Descripcion"   Value="record.data.Descripcion" Mode="Raw" />
                                            </ExtraParams>
                                        </Command>
                                    </DirectEvents>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <Plugins>
                            <ext:RowExpander runat="server">
                                <Loader runat="server" DirectMethod="#{DirectMethods}.GetRecursos" Mode="Component">
                                    <Params>
                                        <ext:Parameter Name="ID"   Value="this.record.data.ID" Mode="Raw" />
                                    </Params>
                                </Loader>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                   <%-- <ext:GridPanel ID="gpArchivos" runat="server" Title="Archivos" TitleAlign="Center" Margin="5" Layout="AnchorLayout">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:TextField ID="txtComentarioArchivo" runat="server" FieldLabel="Comentario" Margin="5" />
                                    <ext:FileUploadField ID="fufArchivos" runat="server" EmptyText="Seleccione un archivo" FieldLabel="Archivo" ButtonText="" Icon="ImageAdd" Margin="5"/>
                                    <ext:Button ID="btnGuardarImg" runat="server" Text="Agregar Archivo" Disabled="true">
                                        <DirectEvents>
                                            <%--<Click OnEvent="btnGuardarImg_Click" Before="if (!#{fpCargaArchivo}.getForm().isValid()) { return false; } Ext.Msg.wait('Cargando archivo...', 'Cargando');"
                                                Failure="Ext.Msg.show({ title: 'Error', msg: 'Error durante la carga', minWidth: 200, modal: true, icon: Ext.Msg.ERROR, buttons: Ext.Msg.OK });">
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store runat="server" ID="stArchivos">
                                <Fields>
                                    <ext:ModelField Name="Fecha" />
                                    <ext:ModelField Name="Usuario" />
                                    <ext:ModelField Name="Archivo" />
                                    <ext:ModelField Name="Comentario" />
                                </Fields>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column runat="server" DataIndex="Fecha"        Text="Fecha"        Width="70" />
                                <ext:Column runat="server" DataIndex="Usuario"      Text="Usuario"      Visible="false" />
                                <ext:Column runat="server" DataIndex="Archivo"      Text="Archivo"      Width="200" />
                                <ext:Column runat="server" DataIndex="Comentario"   Text="Comentario"   Width="213" />
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>--%>
                </Items>
                <Buttons>
                    <ext:Button ID="btnGuardar" runat="server" Text="Guardar" Icon="Disk" Margin="5">
                        <DirectEvents>
                            <Click OnEvent="btnGuardar_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnConcluir" runat="server" Text="Concluir" Icon="PlayGreen" Margin="5">
                        <DirectEvents>
                            <Click OnEvent="btnConcluir_Click">
                                <EventMask ShowMask="true" />
                                <Confirmation Message="¿Deseas Concluir la Captura del Proyecto?" Title="Concluir" ConfirmRequest="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Content>
    </ext:Viewport>
    <ext:Window ID="wdwUsuarios" runat="server" Title="Usuarios" TitleAlign="Center" Modal="true" Hidden="true" Layout="AnchorLayout" Width="800px" Height="500px" >
        <Items>
            <ext:FormPanel runat="server" Layout="AnchorLayout" DefaultAnchor="100" AnchorHorizontal="100%" AnchorVertical="100%" BodyPadding="5" Margin="5">
                <Items>
                    <ext:FieldSet runat="server" Title="Detalle Actividad" Margin="5" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%">
                        <Items>
                            <ext:TextField ID="txtRIDAct"   runat="server" FieldLabel="ID Actividad" Margin="5" Flex="1" ReadOnly="true" AnchorHorizontal="100%" DefaultAnchor="100%"/>
                            <ext:TextField ID="txtRAct"     runat="server" FieldLabel="Actividad"    Margin="5" Flex="1" ReadOnly="true" AnchorHorizontal="100%" DefaultAnchor="100%" />                        
                        </Items>
                    </ext:FieldSet>
                    <ext:GridPanel ID="gpUsuarios" runat="server" Title="Listado de Usuarios" TitleAlign="Center" Layout="AnchorLayout" DefaultAnchor="100%" AnchorHorizontal="100%" AnchorVertical="80%" Scroll="Both">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ComboBox ID="cboRUsuario" runat="server" FieldLabel="Usuario" ValueField="ID" DisplayField="Nombre" Margin="5" ForceSelection="true" TriggerAction="Query" TypeAhead="true" MinChars="1">
                                        <Store>
                                            <ext:Store ID="stRUsuario" runat="server" AutoLoad="false">
                                                <Proxy>
                                                    <ext:AjaxProxy Url="../Controles/BuscaUsuarioGH.ashx">
                                                        <ActionMethods Read="POST">
                                                        </ActionMethods>
                                                        <Reader>
                                                            <ext:JsonReader Root="Articulo">
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:AjaxProxy>
                                                </Proxy>
                                                <Model>
                                                    <ext:Model ID="mdRUsuario" runat="server">
                                                        <Fields>
                                                            <ext:ModelField Name="ID" />
                                                            <ext:ModelField Name="Nombre" />
                                                        </Fields>
                                                    </ext:Model>
                                                </Model>
                                            </ext:Store>
                                        </Store>
                                    </ext:ComboBox>
                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button ID="btnAddUser" runat="server" Text="Agregar" Icon="UserAdd" Margin="5">
                                        <DirectEvents>
                                            <Click OnEvent="btnAddUser_Click">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnDeleteUser" runat="server" Text="Eliminar" Icon="UserDelete" Margin="5">
                                        <DirectEvents>
                                            <Click OnEvent="btnDeleteUser_Click">
                                                <EventMask ShowMask="true"/>
                                                <ExtraParams>
                                                    <ext:Parameter Name="ID" Value="#{gpUsuarios}.selModel.selected.items[0].data.ID" Mode="Raw" />
                                                </ExtraParams>
                                                <Confirmation Message="¿Deseas Eliminar Este Usuario de la Actividad?" Title="Eliminar" ConfirmRequest="true" />
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="return #{gpUsuarios}.hasSelection();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="stUsuarios" runat="server">
                                <Model>
                                    <ext:Model ID="mdUsuarios" runat="server">
                                        <Fields>
                                            <ext:ModelField Name="ID" />
                                            <ext:ModelField Name="Nombre" />
                                            <ext:ModelField Name="TipoUsuario" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column runat="server" Text="ID"            DataIndex="ID"          Visible="false" />
                                <ext:Column runat="server" Text="Nombre"        DataIndex="Nombre"      Flex="1" />
                                <ext:Column runat="server" Text="Tipo Usuario"  DataIndex="TipoUsuario" Width="200px" />
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="Cerrar" Icon="DoorOut">
                        <Listeners>
                            <Click Handler="#{wdwUsuarios}.close();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Window>

    <ext:Window ID="wdwRecursos" runat="server" Title="Recursos" TitleAlign="Center" Modal="true" Hidden="true" Layout="AnchorLayout" Width="800px" Height="500px" >
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:TextField ID="txtRecIDAct"   runat="server" FieldLabel="ID Actividad" Margin="5" ReadOnly="true" />
                    <ext:TextField ID="txtRecAct"     runat="server" FieldLabel="Actividad"    Margin="5" Flex="1" ReadOnly="true" AnchorHorizontal="100%" DefaultAnchor="100%" />                        
                </Items>
            </ext:Toolbar>
        </TopBar>
        <Items>
            <ext:FormPanel runat="server" Layout="AnchorLayout" DefaultAnchor="100" AnchorHorizontal="100%" AnchorVertical="100%" BodyPadding="5" Margins="0 5">
                <Items>                                                        
                    <ext:FieldSet runat="server" Title="Agregar Recurso" Margins="5 0" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%">
                        <Items>
                            <ext:TextField ID="txtTipo"         runat="server" FieldLabel="Tipo Recurso" Margin="5" Flex="1" AnchorHorizontal="100%" DefaultAnchor="100%"/>
                            <ext:FieldContainer runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:NumberField ID="txtIDRec" runat="server" FieldLabel="ID Recurso" Margin="5" Flex="1" AllowDecimals="false"/>
                                    <ext:NumberField ID="txtMonto" runat="server" FieldLabel="Monto"      Margin="5" Flex="1" AllowDecimals="true" DecimalPrecision="2"/>                                    
                                </Items>
                            </ext:FieldContainer>
                            <ext:TextArea ID="txtDescRecurso"     runat="server" FieldLabel="Descripción"    Margin="5" Flex="1" AnchorHorizontal="100%" DefaultAnchor="100%" ReadOnlyCls="readonly-class" />                        
                        </Items>
                    </ext:FieldSet>
                    <ext:GridPanel ID="gpRecursos" runat="server" Layout="AnchorLayout" DefaultAnchor="100%" AnchorHorizontal="100%" AnchorVertical="58%" Scroll="Both">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button ID="btnAddRecurso" runat="server" Text="Agregar" Icon="PageAdd" Margin="5">
                                        <DirectEvents>
                                            <Click OnEvent="btnAddRecurso_Click">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="btnDeleteRecurso" runat="server" Text="Eliminar" Icon="PageDelete" Margin="5">
                                        <DirectEvents>
                                            <Click OnEvent="btnDeleteRecurso_Click">
                                                <EventMask ShowMask="true"/>
                                                <ExtraParams>
                                                    <ext:Parameter Name="ID" Value="#{gpRecursos}.selModel.selected.items[0].data.ID" Mode="Raw" />
                                                </ExtraParams>
                                                <Confirmation Message="¿Deseas Eliminar Este Recurso?" Title="Eliminar" ConfirmRequest="true" />
                                            </Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="return #{gpRecursos}.hasSelection();" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="stRecursos" runat="server">
                                <Model>
                                    <ext:Model ID="mdRecursos" runat="server">
                                        <Fields>
                                            <ext:ModelField Name="ID" />
                                            <ext:ModelField Name="IDRecurso" />
                                            <ext:ModelField Name="Tipo" />
                                            <ext:ModelField Name="Descripcion" />
                                            <ext:ModelField Name="Monto" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column runat="server" Text="ID"            DataIndex="ID"          Visible="false" />
                                <ext:Column runat="server" Text="ID Recurso"    DataIndex="IDRecurso"   Width="50px" />
                                <ext:Column runat="server" Text="Tipo"          DataIndex="Tipo"        Width="125px" />
                                <ext:Column runat="server" Text="Descripcion"   DataIndex="Descripcion" Flex="1" />
                                <ext:Column runat="server" Text="Monto"         DataIndex="Monto"       Width="50px" />
                                <ext:CommandColumn runat="server">
                                    <Commands>
                                        <ext:GridCommand Icon="CarAdd" Text="Agregar Producto" CommandName="Add" />
                                    </Commands>
                                        <DirectEvents>
                                            <Command OnEvent="btnAddProducto_Click">
                                                <EventMask ShowMask="true" />
                                                <ExtraParams>
                                                    <ext:Parameter Name="ID"            Value="record.data.ID"          Mode="Raw" />
                                                </ExtraParams>
                                            </Command>
                                        </DirectEvents>
                                    </ext:CommandColumn>
                                    <ext:CommandColumn runat="server">
                                        <Commands>
                                            <ext:GridCommand Icon="CarDelete" Text="Eliminar Producto" CommandName="AddResource" />                                    
                                        </Commands>
                                        <DirectEvents>
                                            <Command OnEvent="btnDeleteProducto_Click">
                                                <EventMask ShowMask="true" />
                                                <ExtraParams>
                                                    <ext:Parameter Name="ID"            Value="record.data.ID"          Mode="Raw" />
                                                </ExtraParams>
                                            </Command>
                                        </DirectEvents>
                                    </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <Plugins>
                            <ext:RowExpander runat="server">
                                <Loader runat="server" DirectMethod="#{DirectMethods}.GetProductos" Mode="Component">
                                    <Params>
                                        <ext:Parameter Name="ID"   Value="this.record.data.ID" Mode="Raw" />
                                    </Params>
                                </Loader>
                            </ext:RowExpander>
                        </Plugins>
                    </ext:GridPanel>
                </Items>                
                <Buttons>
                    <ext:Button runat="server" Text="Cerrar" Icon="DoorOut">
                        <Listeners>
                            <Click Handler="#{wdwRecursos}.close();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Window>
    <ext:Window ID="wdwAddProducto" runat="server" Title="Agregar Producto" TitleAlign="Center" Width="500px" Height="200px" Modal="true" Hidden="true">
        <Items>
            <ext:FormPanel runat="server" Layout="AnchorLayout" AnchorHorizontal="100%" AnchorVertical="100%" DefaultAnchor="100%" BodyPadding="5" Margin="5">
                <Items>
                    <ext:Hidden ID="hdIDRec" runat="server" />
                    <ext:TextArea ID="txtAddProducto" runat="server" FieldLabel="Descripción" Flex="1" AnchorVertical="100%" DefaultAnchor="100%" Margin="5" ReadOnlyCls="readonly-class" />
                    <ext:NumberField ID="txtCantidad" runat="server" FieldLabel="Cantidad" AnchorVertical="100%" DefaultAnchor="100%"  Margin="5"  AllowDecimals="false"/>
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button ID="btnAgregarProducto" runat="server" Text="Agregar" Icon="Add" Margin="5">
                <DirectEvents>
                    <Click OnEvent="btnAgregarProducto_Click">
                        <EventMask ShowMask="true" />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window ID="wdwDeleteProducto" runat="server" Title="Eliminar Producto" TitleAlign="Center" Width="500px" Height="125px" Modal="true" Hidden="true">
        <Items>
            <ext:FormPanel runat="server" Layout="AnchorLayout" AnchorHorizontal="100%" AnchorVertical="100%" DefaultAnchor="100%" BodyPadding="5" Margin="5">
                <Items>
                    <ext:ComboBox ID="cboDeleteProducto" runat="server" FieldLabel="Producto" Margin="5" ValueField="ID" DisplayField="Descripcion">
                        <Store>
                            <ext:Store ID="stDeleteProducto" runat="server">
                                <Model>
                                    <ext:Model ID="mdDeleteProducto" runat="server">
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
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button ID="btnEliminarProducto" runat="server" Icon="Delete" Text="Eliminar" Margin="5">
                <DirectEvents>
                    <Click OnEvent="btnEliminarProducto_Click">
                        <EventMask ShowMask="true" />
                        <Confirmation Message="¿Deseas Eliminar Este Artículo?" Title="Eliminar" ConfirmRequest="true" />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
</asp:Content>
