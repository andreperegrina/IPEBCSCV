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
    public partial class NuevoRol : System.Web.UI.Page
    {



        protected int? EditRolCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditRolCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditRolCatalogoID", value);

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditRolCatalogoID != null)
                {
                    Rol vehiculoEdit = ServiceLocator.Instance.GetService<RolManager>().GetByID(EditRolCatalogoID.Value);
                    ShowDataFromRol(vehiculoEdit);

                    lbTitle.Text = "Editar rol";
                }
            }

        }

        private void ShowDataFromRol(Rol rolEdit)
        {
            txtDxNombre.Text = rolEdit.Nombre;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditRolCatalogoID != null)
            {

                Rol nuevoRol = ServiceLocator.Instance.GetService<RolManager>().GetByID(EditRolCatalogoID.Value);
                nuevoRol.Nombre = txtDxNombre.Text;
                ServiceLocator.Instance.GetService<RolManager>().Update(nuevoRol);
                Response.Redirect("/Process/Catalogos/AdministrarRol.aspx");
            }
            else
            {
                Rol nuevoRol = new Rol();
                nuevoRol.Nombre = txtDxNombre.Text;
                ServiceLocator.Instance.GetService<RolManager>().Save(nuevoRol);
                Response.Redirect("/Process/Catalogos/AdministrarRol.aspx");
            }
        }
    }
}