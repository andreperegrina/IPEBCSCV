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
    public partial class NuevoRegla : System.Web.UI.Page
    {


        protected int? EditReglaCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditReglaCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditReglaCatalogoID", value);

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditReglaCatalogoID != null)
                {
                    Regla reglaEdit = ServiceLocator.Instance.GetService<ReglaManager>().GetByID(EditReglaCatalogoID.Value);
                    ShowDataFromRegla(reglaEdit);

                    lbTitle.Text = "Editar regla";
                }
            }

        }

        private void ShowDataFromRegla(Regla reglaEdit)
        {
            txtDxNombre.Text = reglaEdit.Nombre;
            txtDxKilometraje.Text = reglaEdit.Kilometraje.ToString();
            txtDxMeses.Text = reglaEdit.Meses.ToString();
            cobxTipoSevicio.DataBind();
            cobxTipoSevicio.Items.FindByValue(reglaEdit.TipoServicioId).Selected=true;

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditReglaCatalogoID != null)
            {

                Regla nuevoRegla = ServiceLocator.Instance.GetService<ReglaManager>().GetByID(EditReglaCatalogoID.Value);

                nuevoRegla.Nombre = txtDxNombre.Text;
                nuevoRegla.Kilometraje = Convert.ToDouble(txtDxKilometraje.Text);
                nuevoRegla.Meses = Convert.ToInt32(txtDxMeses.Text);
                nuevoRegla.TipoServicioId = Convert.ToInt32(cobxTipoSevicio.SelectedItem.Value);
                nuevoRegla.FechaCreacion = DateTime.Today;
                ServiceLocator.Instance.GetService<ReglaManager>().Update(nuevoRegla);
                Response.Redirect("/Process/Catalogos/AdministrarRegla.aspx");

            }
            else
            {
                Regla nuevoRegla = new Regla();

                nuevoRegla.Nombre = txtDxNombre.Text;
                nuevoRegla.Kilometraje = Convert.ToDouble(txtDxKilometraje.Text);
                nuevoRegla.Meses = Convert.ToInt32(txtDxMeses.Text);
                nuevoRegla.TipoServicioId = Convert.ToInt32(cobxTipoSevicio.SelectedItem.Value);
                nuevoRegla.FechaCreacion = DateTime.Today;
                ServiceLocator.Instance.GetService<ReglaManager>().Save(nuevoRegla);
                Response.Redirect("/Process/Catalogos/AdministrarRegla.aspx");
            }
        }

    }
}