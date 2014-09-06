<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AdministrarReportes.aspx.cs" Inherits="IPEBCSCV.Process.Reportes.AdministrarReportes" %>

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
                                            <dx:ASPxButton ID="btnDxReporteBitacora" PostBackUrl="~/Process/Reportes/FiltrarBitacoraReporte.aspx"
                                                CssClass="button-general-round-font orange-button"
                                                CssPostfix="none" runat="server" Text="Bitacora">
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnDxReporteKilometraje" PostBackUrl="~/Process/Revision/NuevoRevision.aspx"
                                                CssClass="button-general-round-font orange-button"
                                                CssPostfix="none" runat="server" Text="Kilometraje">
                                            </dx:ASPxButton>
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

    

    <div class="content-card" >
        <table style="width: 100%;">
            <tr>
                <td>
                    <h1 class="content-title-card">Administrar servicios</h1>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

