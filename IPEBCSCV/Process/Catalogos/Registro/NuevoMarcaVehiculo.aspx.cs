using IPEBCSCV.BusinessEntity;
using IPEBCSCV.BusinessLogic.Manager;
using IPEBCSCV.BusinessLogic.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.Process.Catalogos.Registro
{
    public partial class NuevoMarcaVehiculo : System.Web.UI.Page
    {


        protected int? EditMarcaVehiculoCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditMarcaVehiculoCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditMarcaVehiculoCatalogoID", value);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditMarcaVehiculoCatalogoID != null)
                {
                    MarcaVehiculo vehiculoEdit = ServiceLocator.Instance.GetService<MarcaVehiculoManager>().GetByID(EditMarcaVehiculoCatalogoID.Value);
                    ShowDataFromMarcaVehiculo(vehiculoEdit);
                    lbTitle.Text = "Editar marca de vehículo";
                }
            }

        }

        private void ShowDataFromMarcaVehiculo(MarcaVehiculo vehiculoEdit)
        {
            txtDxNombre.Text = vehiculoEdit.Nombre;
        }
        
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditMarcaVehiculoCatalogoID != null)
            {
                MarcaVehiculo nuevoMarcaVehiculo = ServiceLocator.Instance.GetService<MarcaVehiculoManager>().GetByID(EditMarcaVehiculoCatalogoID.Value);
                nuevoMarcaVehiculo.Nombre = txtDxNombre.Text;
                ServiceLocator.Instance.GetService<MarcaVehiculoManager>().Update(nuevoMarcaVehiculo);
                Response.Redirect("/Process/Catalogos/AdministrarMarcaVehiculo.aspx");
            }
            else
            {
                MarcaVehiculo nuevoMarcaVehiculo = new MarcaVehiculo();
                nuevoMarcaVehiculo.Nombre = txtDxNombre.Text;
                ServiceLocator.Instance.GetService<MarcaVehiculoManager>().Save(nuevoMarcaVehiculo);
                Response.Redirect("/Process/Catalogos/AdministrarMarcaVehiculo.aspx");
            }
        }
    
    }
}