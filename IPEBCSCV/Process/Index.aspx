<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="Index.aspx.cs" Inherits="IPEBCSCV.Process.Index" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>




<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="OptionsContent" runat="server" ContentPlaceHolderID="HeadBarOptions">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-card">
        <table style="width: 100%;">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="padding-top:50px; text-align: center; width: 100%;">
                        <tr>
                            <td align="right" style="width: 5%;">
                                <svg width="100pt" height="100pt" viewBox="0 0 85 82" version="1.1" xmlns="http://www.w3.org/2000/svg">
                                    <path fill="#bad305" d=" M 0.00 0.00 L 25.53 0.00 C 19.83 2.84 14.06 5.95 9.68 10.68 C 5.73 14.65 2.94 19.55 0.00 24.27 L 0.00 0.00 Z" />
                                    <path fill="#013981" d=" M 38.62 0.00 L 46.21 0.00 C 49.63 2.67 51.92 7.90 48.66 11.60 C 45.06 16.70 36.41 14.86 34.87 8.93 C 33.88 5.37 36.38 2.40 38.62 0.00 Z" />
                                    <path fill="#bad305" d=" M 59.51 0.00 L 84.17 0.00 C 85.05 7.64 84.67 15.38 84.33 23.05 C 81.76 19.76 79.88 15.99 77.20 12.79 C 72.30 7.32 66.12 3.14 59.51 0.00 Z" />
                                    <path fill="#bad305" d=" M 17.83 33.73 C 21.35 25.32 28.90 17.86 38.33 16.95 C 39.09 26.94 38.46 36.98 38.66 46.99 C 38.54 53.35 38.98 59.72 38.37 66.05 C 30.19 65.94 23.85 59.76 19.64 53.34 C 16.38 47.44 16.24 40.16 17.83 33.73 Z" />
                                    <path fill="#013981" d=" M 44.52 16.48 C 50.62 17.34 56.68 19.75 60.93 24.34 C 66.56 30.22 69.51 38.94 67.40 46.95 C 65.24 57.62 55.31 65.76 44.57 66.60 C 44.47 49.90 44.60 33.19 44.52 16.48 Z" />
                                    <path fill="#bad305" d=" M 74.31 73.34 C 78.93 69.22 82.03 63.80 85.00 58.45 L 85.00 81.97 C 84.93 81.98 84.78 81.99 84.71 82.00 L 62.39 82.00 C 66.42 79.20 70.87 76.91 74.31 73.34 Z" />
                                    <path fill="#bad305" d=" M 0.00 59.68 C 2.65 62.57 4.30 66.18 6.76 69.21 C 11.11 74.56 16.70 78.78 22.76 82.00 L 0.03 82.00 C 0.02 81.93 0.01 81.79 0.00 81.71 L 0.00 59.68 Z" />
                                </svg>
                            </td>
                            <td align="left" style="width: 5%;">
                                <svg width="300pt" height="100pt" viewBox="0 0 108 34" version="1.1" xmlns="http://www.w3.org/2000/svg">
                                    <path fill="#05377e" d=" M 5.25 6.21 C 7.42 6.22 9.58 6.23 11.75 6.22 C 11.34 15.08 10.61 23.93 10.64 32.81 C 8.48 32.80 6.31 32.80 4.15 32.81 C 4.54 23.94 5.17 15.08 5.25 6.21 Z" />
                                    <path fill="#05377e" d=" M 13.45 6.28 C 18.62 6.32 23.84 5.92 28.99 6.50 C 34.70 8.35 34.59 17.03 30.00 20.11 C 27.31 22.23 23.70 21.83 20.50 21.66 C 20.22 20.36 19.92 19.07 19.60 17.78 C 21.48 17.70 23.47 18.01 25.27 17.32 C 27.66 16.33 28.09 13.06 26.95 11.00 C 24.46 9.70 21.50 10.39 18.82 10.47 C 18.64 17.91 18.35 25.35 18.50 32.79 C 16.44 32.80 14.38 32.80 12.32 32.81 C 12.87 23.97 13.55 15.14 13.45 6.28 Z" />
                                    <path fill="#05377e" d=" M 33.61 6.47 C 40.31 5.91 47.05 6.41 53.77 6.19 C 53.81 7.59 53.85 9.00 53.90 10.40 C 49.35 10.69 44.80 10.46 40.24 10.43 C 39.83 12.72 39.67 15.04 39.67 17.36 C 43.71 17.40 47.75 17.39 51.79 17.26 C 51.64 18.65 51.55 20.05 51.44 21.44 C 47.44 21.34 43.45 21.36 39.45 21.37 C 39.39 23.79 39.31 26.20 39.27 28.62 C 43.86 28.67 48.45 28.54 53.04 28.54 C 52.90 29.97 52.77 31.40 52.64 32.84 C 45.98 32.80 39.31 32.71 32.64 32.90 C 33.42 24.12 33.86 15.29 33.61 6.47 Z" />
                                    <path fill="#05377e" d=" M 54.62 6.51 C 60.55 6.06 66.56 6.01 72.48 6.49 C 78.30 8.06 77.36 17.23 72.02 18.96 C 78.25 20.64 78.26 30.17 72.23 32.08 C 66.27 33.56 60.02 32.43 53.95 32.84 C 54.67 24.10 55.21 15.28 54.62 6.51 Z" />
                                    <path fill="#05377e" d=" M 82.99 7.93 C 88.00 4.94 94.12 5.37 99.62 6.47 C 99.68 7.57 99.79 9.78 99.85 10.88 C 95.57 10.32 90.61 9.17 86.78 11.84 C 81.74 15.03 80.86 23.42 85.81 27.09 C 89.78 30.27 95.06 28.68 99.60 28.13 C 99.26 29.63 98.93 31.13 98.60 32.63 C 93.59 33.78 88.08 33.63 83.26 31.78 C 73.83 27.71 74.09 12.42 82.99 7.93 Z" />
                                    <path fill="#fefefd" d=" M 60.84 10.35 C 64.17 10.47 70.87 8.74 70.50 14.06 C 69.23 18.25 64.01 17.20 60.67 17.27 C 60.74 14.97 60.81 12.66 60.84 10.35 Z" />
                                    <path fill="#fefefd" d=" M 60.51 21.30 C 63.89 21.30 67.52 20.77 70.57 22.60 C 70.45 24.28 71.28 26.55 69.52 27.61 C 66.94 29.66 63.31 28.55 60.27 28.82 C 60.38 26.31 60.46 23.81 60.51 21.30 Z" />
                                </svg>

                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding-top:50px;">
                    <h1 class="content-title-card">Bienvenido al sistema de administración de vehículo</h1>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
