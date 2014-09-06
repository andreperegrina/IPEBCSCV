<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IPEBCSCV.Login" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html style="width: 100%; height: 100%;" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/CSS/font-awesome.min.css">

    <link href="/CSS/master_style.css" rel="stylesheet" />
</head>
<body style="width: 100%; height: 100%;">
    <form id="form1" style="width: 100%; height: 100%;" runat="server">
        <div>

            <img class="image-background" src="/Images/Fondo.jpg" />
            <div class="image-cover-background">
                <div style="height: 100%;"></div>
            </div>
        </div>
        <div class="parent-login">
            <div class="login-content">
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td>
                            <div class="login-card">


                                <table cellpadding="0" cellspacing="0" style="height: 100%; width: 100%;">
                                    <tr style="height: 0;">
                                        <td>
                                            <div class="login-header">
                                                <div class="parent-login">
                                                    <div class="login-content">
                                                        <div style="margin-left: 25px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <h1 style="font-size: 36px; margin-right: 15px;" class="icon-span icon-white">&#xf023;</h1>
                                                                    </td>
                                                                    <td>
                                                                        <h1 style="font-weight: normal;">Inicio de sesión</h1>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Login ID="LgnUsuario" runat="server" Width="100%"
                                                OnAuthenticate="LgnUsuario_Authenticate"
                                                DestinationPageUrl="~/Login/Login.aspx"
                                                FailureText="Su intento de conexión no se ha realizado correctamente. Favor, inténtalo de nuevo."
                                                Style="font-size: small; font-weight: 700;" Height="100%">
                                                <LayoutTemplate>

                                                    <div style="height: 100%; margin: 20px;">
                                                        <table cellspacing="0" cellpadding="0" style="width: 100%; padding-top: 20px; height: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <h6 style="font-size: 15px; font-weight: normal;">Usuario:</h6>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxTextBox ID="UserName" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <h6 style="font-size: 15px; font-weight: normal;">Contraseña:</h6>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxTextBox ID="Password" Password="true" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                                                            <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxTextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="color: Red; height: 21px;">
                                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center;">
                                                                    <dx:ASPxButton ID="btnAceptar" CommandName="Login" ValidationGroup="ElementosRequeridos"
                                                                        CssClass="button-general-round-font font-login orange-button"
                                                                        CssPostfix="none" runat="server" Text="Iniciar sesión">
                                                                    </dx:ASPxButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table class="table-equal-size-columns" style="width: 100%;">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <svg width="35pt" height="35pt" viewBox="0 0 85 82" version="1.1" xmlns="http://www.w3.org/2000/svg">
                                                                                    <path fill="#bad305" d=" M 0.00 0.00 L 25.53 0.00 C 19.83 2.84 14.06 5.95 9.68 10.68 C 5.73 14.65 2.94 19.55 0.00 24.27 L 0.00 0.00 Z" />
                                                                                    <path fill="#013981" d=" M 38.62 0.00 L 46.21 0.00 C 49.63 2.67 51.92 7.90 48.66 11.60 C 45.06 16.70 36.41 14.86 34.87 8.93 C 33.88 5.37 36.38 2.40 38.62 0.00 Z" />
                                                                                    <path fill="#bad305" d=" M 59.51 0.00 L 84.17 0.00 C 85.05 7.64 84.67 15.38 84.33 23.05 C 81.76 19.76 79.88 15.99 77.20 12.79 C 72.30 7.32 66.12 3.14 59.51 0.00 Z" />
                                                                                    <path fill="#bad305" d=" M 17.83 33.73 C 21.35 25.32 28.90 17.86 38.33 16.95 C 39.09 26.94 38.46 36.98 38.66 46.99 C 38.54 53.35 38.98 59.72 38.37 66.05 C 30.19 65.94 23.85 59.76 19.64 53.34 C 16.38 47.44 16.24 40.16 17.83 33.73 Z" />
                                                                                    <path fill="#013981" d=" M 44.52 16.48 C 50.62 17.34 56.68 19.75 60.93 24.34 C 66.56 30.22 69.51 38.94 67.40 46.95 C 65.24 57.62 55.31 65.76 44.57 66.60 C 44.47 49.90 44.60 33.19 44.52 16.48 Z" />
                                                                                    <path fill="#bad305" d=" M 74.31 73.34 C 78.93 69.22 82.03 63.80 85.00 58.45 L 85.00 81.97 C 84.93 81.98 84.78 81.99 84.71 82.00 L 62.39 82.00 C 66.42 79.20 70.87 76.91 74.31 73.34 Z" />
                                                                                    <path fill="#bad305" d=" M 0.00 59.68 C 2.65 62.57 4.30 66.18 6.76 69.21 C 11.11 74.56 16.70 78.78 22.76 82.00 L 0.03 82.00 C 0.02 81.93 0.01 81.79 0.00 81.71 L 0.00 59.68 Z" />
                                                                                </svg>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </LayoutTemplate>
                                            </asp:Login>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--                                            <div style="height: 100%; margin: 20px;">
                                                <table cellspacing="0" cellpadding="0" style="width: 100%; padding-top: 20px; height: 100%;">
                                                    <tr>
                                                        <td>
                                                            <h6 style="font-size: 15px; font-weight: normal;">Usuario:</h6>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="UserName" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                                                <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h6 style="font-size: 15px; font-weight: normal;">Contraseña:</h6>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="Password" CssClass="text-box-general-form" Theme="DevEx" runat="server" Width="100%">
                                                                <ValidationSettings SetFocusOnError="True" ValidationGroup="ElementosRequeridos" ErrorDisplayMode="ImageWithTooltip">
                                                                    <RequiredField IsRequired="True" ErrorText="Elemento requerido" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <dx:ASPxButton ID="btnAceptar" ValidationGroup="ElementosRequeridos"
                                                                CssClass="button-general-round-font font-login orange-button"
                                                                CssPostfix="none" runat="server" Text="Iniciar sesión">
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table class="table-equal-size-columns" style="width: 100%;">
                                                                <tr>
                                                                    <td style="text-align: right;">
                                                                        <svg width="35pt" height="35pt" viewBox="0 0 85 82" version="1.1" xmlns="http://www.w3.org/2000/svg">
                                                                            <path fill="#bad305" d=" M 0.00 0.00 L 25.53 0.00 C 19.83 2.84 14.06 5.95 9.68 10.68 C 5.73 14.65 2.94 19.55 0.00 24.27 L 0.00 0.00 Z" />
                                                                            <path fill="#013981" d=" M 38.62 0.00 L 46.21 0.00 C 49.63 2.67 51.92 7.90 48.66 11.60 C 45.06 16.70 36.41 14.86 34.87 8.93 C 33.88 5.37 36.38 2.40 38.62 0.00 Z" />
                                                                            <path fill="#bad305" d=" M 59.51 0.00 L 84.17 0.00 C 85.05 7.64 84.67 15.38 84.33 23.05 C 81.76 19.76 79.88 15.99 77.20 12.79 C 72.30 7.32 66.12 3.14 59.51 0.00 Z" />
                                                                            <path fill="#bad305" d=" M 17.83 33.73 C 21.35 25.32 28.90 17.86 38.33 16.95 C 39.09 26.94 38.46 36.98 38.66 46.99 C 38.54 53.35 38.98 59.72 38.37 66.05 C 30.19 65.94 23.85 59.76 19.64 53.34 C 16.38 47.44 16.24 40.16 17.83 33.73 Z" />
                                                                            <path fill="#013981" d=" M 44.52 16.48 C 50.62 17.34 56.68 19.75 60.93 24.34 C 66.56 30.22 69.51 38.94 67.40 46.95 C 65.24 57.62 55.31 65.76 44.57 66.60 C 44.47 49.90 44.60 33.19 44.52 16.48 Z" />
                                                                            <path fill="#bad305" d=" M 74.31 73.34 C 78.93 69.22 82.03 63.80 85.00 58.45 L 85.00 81.97 C 84.93 81.98 84.78 81.99 84.71 82.00 L 62.39 82.00 C 66.42 79.20 70.87 76.91 74.31 73.34 Z" />
                                                                            <path fill="#bad305" d=" M 0.00 59.68 C 2.65 62.57 4.30 66.18 6.76 69.21 C 11.11 74.56 16.70 78.78 22.76 82.00 L 0.03 82.00 C 0.02 81.93 0.01 81.79 0.00 81.71 L 0.00 59.68 Z" />
                                                                        </svg>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
