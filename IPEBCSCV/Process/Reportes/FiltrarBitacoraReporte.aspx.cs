using IPEBCSCV.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.Process.Reportes
{
    public partial class FiltrarBitacoraReporte : GenericPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDxNombre.Text = PerfilUsuario.GetNombre();
            }
        }
    }
}