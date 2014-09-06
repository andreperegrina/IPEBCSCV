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
    public partial class NuevoMunicipio : System.Web.UI.Page
    {


        protected int? EditMunicipioCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditMunicipioCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditMunicipioCatalogoID", value);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditMunicipioCatalogoID != null)
                {
                    Municipio vehiculoEdit = ServiceLocator.Instance.GetService<MunicipioManager>().GetByID(EditMunicipioCatalogoID.Value);
                    ShowDataFromMunicipio(vehiculoEdit);

                    lbTitle.Text = "Editar municipio";
                }
            }

        }

        private void ShowDataFromMunicipio(Municipio vehiculoEdit)
        {
            txtDxNombre.Text = vehiculoEdit.Nombre;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditMunicipioCatalogoID != null)
            {

                Municipio nuevoMunicipio = ServiceLocator.Instance.GetService<MunicipioManager>().GetByID(EditMunicipioCatalogoID.Value);
                nuevoMunicipio.Nombre = txtDxNombre.Text;
                nuevoMunicipio.FechaCreacion = DateTime.Today;

                ServiceLocator.Instance.GetService<MunicipioManager>().Update(nuevoMunicipio);
                Response.Redirect("/Process/Catalogos/AdministrarMunicipio.aspx");
            }
            else
            {
                Municipio nuevoMunicipio = new Municipio();
                nuevoMunicipio.Nombre = txtDxNombre.Text;
                nuevoMunicipio.FechaCreacion = DateTime.Today;

                ServiceLocator.Instance.GetService<MunicipioManager>().Save(nuevoMunicipio);
                Response.Redirect("/Process/Catalogos/AdministrarMunicipio.aspx");
            }
        }
    }
}