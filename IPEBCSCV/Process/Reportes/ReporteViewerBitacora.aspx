<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteViewerBitacora.aspx.cs" Inherits="IPEBCSCV.Process.Reportes.ReporteViewerBitacora" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.1.Web, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <dx:ASPxDocumentViewer ID="dvDxReporteDespliegue" runat="server"  >
                <SettingsReportViewer EnableReportMargins="True" />
                <SettingsDocumentMap ShowTreeLines="True" />
                <SettingsSplitter RightPaneVisible="true" SidePaneVisible="true" />
                <StylesViewer>
                    <BookmarkSelectionBorder BorderColor="Gray" BorderStyle="Dashed" BorderWidth="3px"></BookmarkSelectionBorder>
                </StylesViewer>

                <StylesSplitter>
                    <Pane>
                        <Paddings Padding="16px"></Paddings>
                    </Pane>
                </StylesSplitter>
            </dx:ASPxDocumentViewer>
        </div>
    </form>
</body>
</html>