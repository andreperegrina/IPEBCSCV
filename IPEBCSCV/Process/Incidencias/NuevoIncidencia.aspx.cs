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

namespace IPEBCSCV.Process.Incidencias
{
    public partial class NuevoIncidencia : GenericPage
    {


        protected int? EditIncidenciaCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditIncidenciaCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditIncidenciaCatalogoID", value);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditIncidenciaCatalogoID != null)
                {
                    Incidencia incidenciaEdit = ServiceLocator.Instance.GetService<IncidenciaManager>().GetByID(EditIncidenciaCatalogoID.Value);
                    ShowDataFromIncidencia(incidenciaEdit);
                    lbTitle.Text = "Editar marca de vehículo";
                }
            }

        }

        private void ShowDataFromIncidencia(Incidencia incidenciaEdit)
        {
            memDxDescripcion.Text = incidenciaEdit.Descripcion;
            cobxVehiculo.Items.FindByValue(incidenciaEdit.VehiculoId);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditIncidenciaCatalogoID != null)
            {
                Incidencia nuevoIncidencia = ServiceLocator.Instance.GetService<IncidenciaManager>().GetByID(EditIncidenciaCatalogoID.Value);
                nuevoIncidencia.Descripcion = memDxDescripcion.Text;
                nuevoIncidencia.UsuarioId = PerfilUsuario.UsuarioId;
                nuevoIncidencia.VehiculoId = Convert.ToInt32(cobxVehiculo.SelectedItem.Value);
                ServiceLocator.Instance.GetService<IncidenciaManager>().Update(nuevoIncidencia);
                Response.Redirect("/Process/Catalogos/AdministrarIncidencia.aspx");
            }
            else
            {
                Incidencia nuevoIncidencia = new Incidencia();
                nuevoIncidencia.Descripcion = memDxDescripcion.Text;
                nuevoIncidencia.UsuarioId = PerfilUsuario.UsuarioId;
                nuevoIncidencia.VehiculoId = Convert.ToInt32(cobxVehiculo.SelectedItem.Value);
                ServiceLocator.Instance.GetService<IncidenciaManager>().Save(nuevoIncidencia);
                Response.Redirect("/Process/Catalogos/AdministrarIncidencia.aspx");
            }
        }
    }
}