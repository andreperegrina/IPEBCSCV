<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="NuevoRegla.aspx.cs" Inherits="IPEBCSCV.Process.Catalogos.Registro.NuevoRegla" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>




<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-card">
        <table  width="100%">
            <tr>
                <td>
                    <asp:Label ID="lbTitle" CssClass="content-title-card" Text="Crear nueva regla" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="table-equal-size-columns table-general-form">
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Nombre</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxNombre" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
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

                                <dx:ASPxTextBox ID="txtDxKilometraje"  DisplayFormatString="{0} km" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <MaskSettings Mask="&lt;0..999999g&gt;" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Meses</span>
                            </td>
                            <td width="95%">

                                <dx:ASPxTextBox ID="txtDxMeses" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <MaskSettings Mask="&lt;0..100&gt;" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Tipo de servicios</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxComboBox ID="cobxTipoSevicio" runat="server" CssClass="text-box-general-form" Width="100%" Theme="DevEx"
                                    ValueType="System.Int32" ValueField="TipoServicioId" TextField="Nombre" DataSourceID="ObjectDataSource1">
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.TipoServicioManager"></asp:ObjectDataSource>

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
