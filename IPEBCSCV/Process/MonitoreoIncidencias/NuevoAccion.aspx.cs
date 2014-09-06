using IPEBCSCV.BusinessEntity;
using IPEBCSCV.BusinessLogic.Manager;
using IPEBCSCV.BusinessLogic.ServiceLocator;
using IPEBCSCV.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.Process.MonitoreoIncidencias
{
    public partial class NuevoAccion : GenericPage
    {


        protected int? EditAccionCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditAccionCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditAccionCatalogoID", value);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditAccionCatalogoID != null)
                {
                    Accion accionEdit = ServiceLocator.Instance.GetService<AccionManager>().GetByID(EditAccionCatalogoID.Value);
                    ShowDataFromAccion(accionEdit);
                    lbTitle.Text = "Editar acción";
                }
            }

        }

        private void ShowDataFromAccion(Accion accionEdit)
        {
            memDxDescripcion.Text = accionEdit.Descripcion;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditAccionCatalogoID != null)
            {
                Accion nuevoAccion = ServiceLocator.Instance.GetService<AccionManager>().GetByID(EditAccionCatalogoID.Value);
                nuevoAccion.Descripcion = memDxDescripcion.Text;
                ServiceLocator.Instance.GetService<AccionManager>().Update(nuevoAccion);
                Response.Redirect("/Process/Catalogos/AdministrarAccion.aspx");
            }
            else
            {
                Accion nuevoAccion = new Accion();
                nuevoAccion.Descripcion = memDxDescripcion.Text;
                ServiceLocator.Instance.GetService<AccionManager>().Save(nuevoAccion);
                Response.Redirect("/Process/Catalogos/AdministrarAccion.aspx");
            }
        }
    }
}