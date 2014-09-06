using DevExpress.Web.ASPxGridView;
using IPEBCSCV.BusinessEntity;
using IPEBCSCV.MasterPages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.Process.MonitoreoVehiculos
{
    public partial class MonitoreoVehiculos : GenericPage
    {


        private bool SeMostroMensajeAdvertencia = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void gvDxCatalogo_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

            if (e.RowType != GridViewRowType.Data)
                return;
            Vehiculo vehiculoRowPaint = (Vehiculo)gvDxCatalogo.GetRow(e.VisibleIndex);
            double vehiculoRowPaintreglaKilometraje = vehiculoRowPaint.regla.Kilometraje;
            if (vehiculoRowPaint.Kilometraje >= vehiculoRowPaintreglaKilometraje)
            {
                e.Row.BackColor = Color.FromArgb(0xDB, 0x6B, 0x6B);
                e.Row.ForeColor = Color.White;

                if (!(base.SeMostroMensajeError))
                {
                    base.ShowPopupErrorWithMessage("ShowPopupMessageError",
                        "Advertencia critica", "Tiene uno o más vehículos que necesitan mantenimiento", 0);
                }
                base.SeMostroMensajeError = true;
            }
            else
            {

                if (vehiculoRowPaint.Kilometraje >= vehiculoRowPaintreglaKilometraje - vehiculoRowPaintreglaKilometraje / 3)
                {
                    e.Row.BackColor = Color.FromArgb(0xff, 0xb2, 0x30);
                    e.Row.ForeColor = Color.White;

                    if (!(SeMostroMensajeAdvertencia))
                    {
                        base.ShowPopupErrorWithMessage("ShowPopupMessage",
                            "Advertencia", "Tiene uno o más vehículos estan por llegar a su kilometraje de mantenimiento", 1);
                    }
                    SeMostroMensajeAdvertencia = true;
                }


            }

        }
    }
}