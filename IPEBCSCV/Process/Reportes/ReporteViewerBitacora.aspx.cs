using IPEBCSCV.BusinessEntity;
using IPEBCSCV.BusinessLogic.Manager;
using IPEBCSCV.BusinessLogic.ServiceLocator;
using IPEBCSCV.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.Process.Reportes
{
    public partial class ReporteViewerBitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Bitacora> listaReporteBitacora = new List<Bitacora>();
            List<Vehiculo> listaVehiculos = ServiceLocator.Instance.GetService<VehiculoManager>().GetAll();
            foreach (var item in listaVehiculos)
            {
                listaReporteBitacora.Add(new Bitacora(item));
            }
            BitacoraReporte reporte = new BitacoraReporte();
            reporte.DataSource = listaReporteBitacora;
            dvDxReporteDespliegue.Report = reporte;

        }
    }
}