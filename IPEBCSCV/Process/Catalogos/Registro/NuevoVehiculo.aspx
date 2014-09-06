<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="NuevoVehiculo.aspx.cs" Inherits="IPEBCSCV.Process.Catalogos.Registro.NuevoVehiculo" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>




<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-card">
        <table  width="100%">
            <tr>
                <td>
                    <asp:Label ID="lbTitle" CssClass="content-title-card" Text="Crear nuevo vehículo" runat="server" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <table class="table-equal-size-columns table-general-form">
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Marca</span>
                            </td>
                            <td width="95%">
 <dx:ASPxComboBox ID="cobxDxMarcaVehiculo" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%"
                                    ValueType="System.Int32" ValueField="MarcaVehiculoId" TextField="Nombre" DataSourceID="ObjectDataSource3">
         <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.MarcaVehiculoManager"></asp:ObjectDataSource>

                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Modelo</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxModelo" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Color</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxColor" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Placas</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxPlacas" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Serie</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxSerie" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Número economico</span>
                            </td>
                            <td width="95%">

                                <dx:ASPxTextBox ID="txtDxNumeroEconomico" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <MaskSettings Mask="&lt;0..100&gt;" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Nombre del conductor</span>
                            </td>
                            <td width="95%">

                                <dx:ASPxTextBox ID="txtDxNombrePersona" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Kilometraje</span>
                            </td>
                            <td width="95%">

                                <dx:ASPxTextBox ID="txtDxKilometraje" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <MaskSettings Mask="&lt;0..2147483647&gt;" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Regla</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxComboBox ID="cobxDxRegla" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%"
                                    ValueType="System.Int32" ValueField="ReglaId" TextField="Nombre" DataSourceID="ObjectDataSource1">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.ReglaManager"></asp:ObjectDataSource>

                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Municipio</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxComboBox ID="cobxDxMunicipio" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%"
                                    ValueType="System.Int32" ValueField="MunicipioId" TextField="Nombre" DataSourceID="ObjectDataSource2">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.MunicipioManager"></asp:ObjectDataSource>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr>
                <td align="right" style="padding-right: 20px;">
                    <dx:ASPxButton ID="btnAceptar" ValidationGroup="ElementosRequeridos"
                        CssClass="button-general-round-font orange-button" OnClick="btnAceptar_Click"
                        CssPostfix="none" runat="server" Text="Guardar">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
