<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="NuevoRevision.aspx.cs" Inherits="IPEBCSCV.Process.Revision.NuevoRevision" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>




<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-card">
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="lbTitle" CssClass="content-title-card" Text="Crear nueva revisión" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="table-equal-size-columns table-general-form">
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Espejos</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxEspejos" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr><tr>
                            <td width="5%">
                                <span class="caption-text">Focos</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxFocos" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr><tr>
                            <td width="5%">
                                <span class="caption-text">Llantas</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxLlantas" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Puertas</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxPuertas" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr><tr>
                            <td width="5%">
                                <span class="caption-text">Manijas</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxManijas" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Parabrisas</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxParabrisas" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr><tr>
                            <td width="5%">
                                <span class="caption-text">Antena</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxAntena" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr><tr>
                            <td width="5%">
                                <span class="caption-text">Carroseria</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxCarroseria" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
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
                                <span class="caption-text">Kilometraje</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxTextBox ID="txtDxKilometraje" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                    <MaskSettings Mask="&lt;0..999999g&gt;" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Fecha revisión</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxDateEdit ID="dtDxFechaRevision" CssClass="text-box-general-form" Theme="DevEx" EnableTheming="true" Width="100%" runat="server">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Observaciones</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxMemo ID="memDxObservaciones"  CssClass="text-box-general-form" runat="server" Height="71px" Width="100%">
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxMemo>
                            </td>
                        </tr>
                        <tr>
                            <td width="5%">
                                <span class="caption-text">Vehículo</span>
                            </td>
                            <td width="95%">
                                <dx:ASPxComboBox ID="cobxVehiculo" runat="server" CssClass="text-box-general-form" Width="100%" Theme="DevEx"
                                    ValueType="System.Int32" ValueField="VehiculoId" DataSourceID="ObjectDataSource1">
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="NumeroEconomico" Caption="No. Economico" />
                                            <dx:ListBoxColumn FieldName="marca_vehiculo.Nombre" Caption="Marca" />
                                            <dx:ListBoxColumn FieldName="Modelo" Caption="Modelo" />
                                            <dx:ListBoxColumn FieldName="Placas" Caption="Placas" />
                                        </Columns>
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="IPEBCSCV.BusinessLogic.Manager.VehiculoManager"></asp:ObjectDataSource>

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

