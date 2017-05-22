<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportePeriodos.aspx.vb" Inherits="CursoExtNet.ReportePeriodos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout">
        <Content>
            <ext:FormPanel ID="frmAddProject" runat="server" Title="Agregar Proyecto" TitleAlign="Center" BodyPadding="5" OverflowY="Auto" >
                <Items>                    
                    <ext:Hidden ID="hdID" runat="server" />
                    <ext:Hidden ID="hdIDAct" runat="server" />
                    <ext:FieldSet ID="fsCA" runat="server" Title="Programas" Margin="5">
                        <Items>
                            <ext:ComboBox  ID="cboProgramas"          runat="server"       FieldLabel="Programas"   AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Store>
                                    <ext:Store ID="stProg" runat="server">
                                        <Model>
                                            <ext:Model ID="mdProg" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="Programa"   Type="String" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>     
                            </ext:ComboBox>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="FieldSet1" runat="server" Title="Montos" Margin="5">
                        <Items>
                            <ext:FieldContainer ID="FieldContainer1" runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:NumberField ID="NumberField1" FieldLabel="Monto Maximo" runat="server" Flex="1">
                                    </ext:NumberField>
                                    <ext:NumberField ID="NumberField2" FieldLabel="Monto Minimo" runat="server" Margin="5" Flex="1">
                                    </ext:NumberField>
                                </Items>
                            </ext:FieldContainer>
                        </items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="FieldSet2" runat="server" Title="Periodos" Margin="5">
                        <Items>
                            <ext:FieldContainer ID="FieldContainer2" runat="server" Layout="HBoxLayout" Anchor="100%" AnchorHorizontal="100%" DefaultAnchor="100%" >
                                <Items>
                                    <ext:DateField ID="DateField1" runat="server" FieldLabel="Fecha Inicial" Flex="1">
                                    </ext:DateField>
                                    <ext:DateField ID="DateField2" runat="server" FieldLabel="Fecha Final"  Margin="5" Flex="1">
                                    </ext:DateField>
                                </Items>
                            </ext:FieldContainer>
                        </items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="Generar" Icon="PageAdd" Margins="0 0 0 10" >
                        </ext:Button>

                </Buttons>
            </ext:FormPanel>
        </Content>
    </ext:Viewport>
</asp:Content>
