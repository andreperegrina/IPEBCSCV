<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="FiltrarBitacoraReporte.aspx.cs" Inherits="IPEBCSCV.Process.Reportes.FiltrarBitacoraReporte" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>




<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="OptionsContent" runat="server" ContentPlaceHolderID="HeadBarOptions">

    <div class="header-div-right-side">
        <table style="width: 100%;">
            <tr>
                <td>
                    <table class="textbox-with-icon">
                        <tr>

                            <td style="padding-left: 10px;">
                                <dx:ASPxTextBox ID="txtDxBuscar" CssClass="textbox-buscar" NullText="Buscar"
                                    runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxButton ID="ASPxButton1"
                                    CssClass="button-general-only-icon-font orange-button-only-icon  fa"
                                    CssPostfix="none" runat="server" Text="&#xf002;">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton2"
                                    CssClass="button-general-only-icon-font orange-button-only-icon   fa"
                                    CssPostfix="none" runat="server" Text="&#xf014;">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="right">
                    <table>
                        <tr>
                            <td>
                                <table width="100%" style="margin-right: 10px;">
                                    <tr>
                                        <td>
                                            <%--<dx:ASPxButton ID="btnDxNuevo" PostBackUrl="~/Process/Vehiculo/NuevoVehiculo.aspx"
                                                CssClass="button-general-round-font orange-button"
                                                CssPostfix="none" runat="server" Text="Nuevo">
                                            </dx:ASPxButton>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">



    <div class="content-card">
        <table style="width: 100%;">
            <tr>
                <td>
                    <h1 class="content-title-card">Generar reporte de bitácora</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                <span class="caption-text">Nombre del jefe de departamento:</span>

                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtDxNombre" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                                <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                                    <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxDateEdit ID="dtDxAno" DisplayFormatString="yyyy" EditFormatString="yyyy" CssClass="text-box-general-form" Theme="DevEx" EnableTheming="true" Width="100%" runat="server">
                                                <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                                    <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <dx:ASPxComboBox ID="cobxDxMunicipio" ClientInstanceName="cobxDxMunicipio" DropDownStyle="DropDownList" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%"
                                                            ValueType="System.Int32" ValueField="MunicipioId" TextField="Nombre" DataSourceID="ObjectDataSource2">
                                                            <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                                                <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                                            </ValidationSettings>
                                                        </dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.MunicipioManager"></asp:ObjectDataSource>

                                                    </td>
                                                    <td>
                                                        <dx:ASPxButton ID="btnClearCobxMunicipio" CssClass="button-general-round-font blue-button "
                                                            AutoPostBack="false" CssPostfix="none" runat="server" Text="Limpiar">

                                                            <ClientSideEvents Click="function(s, e) {
	                                                               cobxDxMunicipio.SetSelectedIndex(-1);
                                                                }" />
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxListBox ID="liboxDxVehiculo" ClientInstanceName="liboxDxVehiculo" CssClass="text-box-general-form" Height="200px" Theme="Moderno"
                                    EnableTheming="true" SelectionMode="CheckColumn"
                                    ValueType="System.Int32" ValueField="VehiculoId" runat="server" DataSourceID="ObjectDataSource1">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="VehiculoId" Visible="false" />
                                        <dx:ListBoxColumn FieldName="NumeroEconomico" Caption="N. Económico" />
                                        <dx:ListBoxColumn FieldName="Serie" />
                                        <dx:ListBoxColumn FieldName="Placas" />
                                        <dx:ListBoxColumn FieldName="marca_vehiculo.Nombre" Caption="Marca" />
                                        <dx:ListBoxColumn FieldName="NombrePersona" />
                                        <dx:ListBoxColumn FieldName="municipio.Nombre" Caption="Municipio" />
                                    </Columns>
                                </dx:ASPxListBox>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll"
                                    TypeName="IPEBCSCV.BusinessLogic.Manager.VehiculoManager"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnDxSelectAllVehiculos" CssClass="button-general-round-font blue-button "
                                                AutoPostBack="false" CssPostfix="none" runat="server" Text="Seleccionar todos">

                                                <ClientSideEvents Click="function(s, e) {
	                                    liboxDxVehiculo.SelectAll();
                                    }" />
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnDxClearVehiculos" CssClass="button-general-round-font blue-button "
                                                AutoPostBack="false" CssPostfix="none" runat="server" Text="Limpiar">

                                                <ClientSideEvents Click="function(s, e) {
	                                      liboxDxVehiculo.UnselectAll();
                                        }" />
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                    </table>
                </td>

            </tr>
            <tr>
                <td aling="right" style="text-align: right;">
                    <dx:ASPxButton ID="btnDxGenerar"
                        CssClass="button-general-round-font orange-button"
                        CssPostfix="none" runat="server" Text="Generar">
                        <ClientSideEvents Click="function (s, e) {window.open('ReporteViewerBitacora.aspx', '_blank')}" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
