<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/Main.Master"  CodeBehind="MonitoreoVehiculos.aspx.cs" Inherits="IPEBCSCV.Process.MonitoreoVehiculos.MonitoreoVehiculos" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>




<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
      <link rel="stylesheet" href="/CSS/progress_bar_style.css" media="screen" type="text/css" />
    <script src="/JS/progress_bar.js"></script>
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
            </tr>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-card">
        <dx:ASPxGridView ID="gvDxCatalogo" OnHtmlRowPrepared="gvDxCatalogo_HtmlRowPrepared" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno"
            Width="100%" runat="server" DataSourceID="ObjectDataSource1">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="VehiculoId" Visible="false" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NumeroEconomico" CellStyle-HorizontalAlign="Center" 
                    HeaderStyle-HorizontalAlign="Center" Caption="N. Económico" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Serie" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Placas" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="marca_vehiculo.Nombre" Caption="Marca" VisibleIndex="4">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NombrePersona" VisibleIndex="7">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="municipio.Nombre" Caption="Municipio" VisibleIndex="9">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="% kilometros recorridos" Width="300px" CellStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center" VisibleIndex="10">
                    <DataItemTemplate>
                        <ul class="style-1">
                            <li>
                                <em>km</em>
                                <span><%# Eval("Kilometraje") %></span>
                            </li>
                            <li style="display: none;">
                                <em>Cars</em>
                                <span><%# Eval("regla.Kilometraje") %> </span>
                            </li>
                        </ul>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.VehiculoManager"></asp:ObjectDataSource>
    </div>
</asp:Content>
