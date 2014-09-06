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
    public partial class NuevoTipoServicio : System.Web.UI.Page
    {



        protected int? EditTipoServicioCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditTipoServicioCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditTipoServicioCatalogoID", value);

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditTipoServicioCatalogoID != null)
                {
                    TipoServicio vehiculoEdit = ServiceLocator.Instance.GetService<TipoServicioManager>().GetByID(EditTipoServicioCatalogoID.Value);
                    ShowDataFromTipoServicio(vehiculoEdit);
                    lbTitle.Text = "Editar";
                }
            }

        }

        private void ShowDataFromTipoServicio(TipoServicio tipoServicioEdit)
        {
            txtDxNombre.Text = tipoServicioEdit.Nombre;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditTipoServicioCatalogoID != null)
            {
                TipoServicio nuevoTipoServicio = ServiceLocator.Instance.GetService<TipoServicioManager>().GetByID(EditTipoServicioCatalogoID.Value);
                nuevoTipoServicio.Nombre = txtDxNombre.Text;
                nuevoTipoServicio.FechaCreacion = DateTime.Today;
                ServiceLocator.Instance.GetService<TipoServicioManager>().Update(nuevoTipoServicio);
                Response.Redirect("/Process/Catalogos/AdministrarTipoServicio.aspx");
            }
            else
            {
                TipoServicio nuevoTipoServicio = new TipoServicio();
                nuevoTipoServicio.Nombre = txtDxNombre.Text;
                nuevoTipoServicio.FechaCreacion = DateTime.Today;
                ServiceLocator.Instance.GetService<TipoServicioManager>().Save(nuevoTipoServicio);
                Response.Redirect("/Process/Catalogos/AdministrarTipoServicio.aspx");
            }
        }
    }
}