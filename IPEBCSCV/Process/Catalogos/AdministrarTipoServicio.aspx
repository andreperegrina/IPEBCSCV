<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="AdministrarTipoServicio.aspx.cs" Inherits="IPEBCSCV.Process.Catalogos.AdministrarTipoServicio" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>




<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content><asp:Content ID="OptionsContent" runat="server" ContentPlaceHolderID="HeadBarOptions">
    
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
                                            <dx:ASPxButton ID="btnDxNuevo" PostBackUrl="~/Process/Catalogos/Registro/NuevoTipoServicio.aspx"
                                                CssClass="button-general-round-font orange-button"
                                                CssPostfix="none" runat="server" Text="Nuevo">
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
    <div class="content-card">
        <table style="width: 100%;">
            <tr>
                <td>
                    <h1 class="content-title-card">Administrar tipos de servicio</h1>
                </td>
            </tr>
            <tr>
                <td>
        <dx:ASPxGridView ID="gvDxCatalogo" OnRowCommand="gvDxCatalogo_RowCommand" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno"
            Width="100%" runat="server" DataSourceID="ObjectDataSource1">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="TipoServicioId" Visible="false" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="FechaCreacion" VisibleIndex="2">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataColumn Caption="Acciones" CellStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center" VisibleIndex="4">
                    <DataItemTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <dx:ASPxButton ID="btnDxEdit" CssClass="button-general-only-icon-font orange-button-only-icon  fa"
                                        CommandName="Edit" CssPostfix="none" runat="server" Text="&#xf040;">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnDxRemove" CssClass="button-general-only-icon-font orange-button-only-icon  fa"
                                        CommandName="Remove" CssPostfix="none" runat="server" Text="&#xf014;">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>


                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <SettingsPager Position="Bottom">
                <Summary Visible="false" />
                <PageSizeItemSettings Caption="Resultados por página" Items="10, 20, 50" Visible="true" />
            </SettingsPager>
            <Styles>
                <CommandColumn Spacing="10px" Wrap="False" />
            </Styles>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.TipoServicioManager"></asp:ObjectDataSource>
    </td>
                </tr>
            </table>
                    </div>
</asp:Content>
