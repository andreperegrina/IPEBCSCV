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

namespace IPEBCSCV.Process.Revision
{
    public partial class NuevoRevision : GenericPage
    {



        protected int? EditRevisionVehiculoCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditRevisionVehiculoCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditRevisionVehiculoCatalogoID", value);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditRevisionVehiculoCatalogoID != null)
                {
                    RevisionVehiculo revisionVehiculoEdit = ServiceLocator.Instance.GetService<RevisionVehiculoManager>().GetByID(EditRevisionVehiculoCatalogoID.Value);
                    ShowDataFromRevisionVehiculo(revisionVehiculoEdit);
                    lbTitle.Text = "Editar revisión";
                }
                dtDxFechaRevision.Date = DateTime.Today;
            }

        }

        private void ShowDataFromRevisionVehiculo(RevisionVehiculo revisionVehiculoEdit)
        {
            txtDxAntena.Text=revisionVehiculoEdit.Antena;
            txtDxCarroseria.Text = revisionVehiculoEdit.Carroceria;
            txtDxEspejos.Text = revisionVehiculoEdit.Espejos;
            txtDxFocos.Text = revisionVehiculoEdit.Focos;
            txtDxKilometraje.Text = revisionVehiculoEdit.Kilometraje.ToString();
            txtDxLlantas.Text = revisionVehiculoEdit.Llantas;
            txtDxParabrisas.Text = revisionVehiculoEdit.Parabrisas;
            txtDxPlacas.Text = revisionVehiculoEdit.Placas;
            memDxObservaciones.Text = revisionVehiculoEdit.Observaciones;
            txtDxPuertas.Text = revisionVehiculoEdit.Puertas;
            dtDxFechaRevision.Date = revisionVehiculoEdit.FechaRevision;
            cobxVehiculo.DataBind();
            cobxVehiculo.Items.FindByValue(revisionVehiculoEdit.RevisionVehiculoId);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditRevisionVehiculoCatalogoID != null)
            {
                RevisionVehiculo nuevoRevisionVehiculo = ServiceLocator.Instance.GetService<RevisionVehiculoManager>().GetByID(EditRevisionVehiculoCatalogoID.Value);
                nuevoRevisionVehiculo.Antena= txtDxAntena.Text;
                nuevoRevisionVehiculo.Carroceria=txtDxCarroseria.Text;
                nuevoRevisionVehiculo.Espejos=txtDxEspejos.Text;
                nuevoRevisionVehiculo.Focos=txtDxFocos.Text;
                nuevoRevisionVehiculo.Kilometraje=Convert.ToInt32(txtDxKilometraje.Text.Replace(",",""));
                nuevoRevisionVehiculo.Llantas=txtDxLlantas.Text;
                nuevoRevisionVehiculo.Manijas=txtDxParabrisas.Text;
                nuevoRevisionVehiculo.Placas=txtDxPlacas.Text;
                nuevoRevisionVehiculo.Puertas=txtDxPuertas.Text;
                nuevoRevisionVehiculo.Observaciones = memDxObservaciones.Text;
                nuevoRevisionVehiculo.FechaRevision = dtDxFechaRevision.Date;
                nuevoRevisionVehiculo.UsuarioId = PerfilUsuario.UsuarioId;
                Vehiculo vehiculoRevision = nuevoRevisionVehiculo.vehiculo;
                int tipoServicioRegla = vehiculoRevision.regla.TipoServicioId;
                IEnumerable<IPEBCSCV.BusinessEntity.Servicio> serviciosKilometraje = vehiculoRevision.servicio.Where(serv => serv.TipoServicioId == tipoServicioRegla);
                nuevoRevisionVehiculo.vehiculo.Kilometraje = nuevoRevisionVehiculo.Kilometraje - (serviciosKilometraje.Count() > 0 ? serviciosKilometraje.LastOrDefault().Kilometraje : 0);
                ServiceLocator.Instance.GetService<RevisionVehiculoManager>().Update(nuevoRevisionVehiculo);
                Response.Redirect("/Process/Revision/AdministrarRevision.aspx");
            }
            else
            {
                RevisionVehiculo nuevoRevisionVehiculo = new RevisionVehiculo();
                nuevoRevisionVehiculo.Antena = txtDxAntena.Text;
                nuevoRevisionVehiculo.Carroceria = txtDxCarroseria.Text;
                nuevoRevisionVehiculo.Espejos = txtDxEspejos.Text;
                nuevoRevisionVehiculo.Focos = txtDxFocos.Text;
                nuevoRevisionVehiculo.Kilometraje = Convert.ToInt32(txtDxKilometraje.Text.Replace(",",""));
                nuevoRevisionVehiculo.Llantas = txtDxLlantas.Text;
                nuevoRevisionVehiculo.Manijas = txtDxParabrisas.Text;
                nuevoRevisionVehiculo.Placas = txtDxPlacas.Text;
                nuevoRevisionVehiculo.Puertas = txtDxPuertas.Text;
                nuevoRevisionVehiculo.Observaciones = memDxObservaciones.Text;
                nuevoRevisionVehiculo.FechaRevision = dtDxFechaRevision.Date;
                nuevoRevisionVehiculo.FechaCreacion = DateTime.Today;
                nuevoRevisionVehiculo.VehiculoId = Convert.ToInt32(cobxVehiculo.SelectedItem.Value);
                nuevoRevisionVehiculo.UsuarioId = PerfilUsuario.UsuarioId;
                nuevoRevisionVehiculo.NombreUsuario = PerfilUsuario.GetNombre();
                nuevoRevisionVehiculo.Parabrisas = txtDxParabrisas.Text;
                ServiceLocator.Instance.GetService<RevisionVehiculoManager>().Save(nuevoRevisionVehiculo);
                Vehiculo vehiculoRevision = nuevoRevisionVehiculo.vehiculo;
                int tipoServicioRegla = vehiculoRevision.regla.TipoServicioId;
                
                IEnumerable<IPEBCSCV.BusinessEntity.Servicio> serviciosKilometraje = vehiculoRevision.servicio.Where(serv => serv.TipoServicioId == tipoServicioRegla);
                nuevoRevisionVehiculo.vehiculo.Kilometraje =nuevoRevisionVehiculo.Kilometraje-(serviciosKilometraje.Count() > 0 ? serviciosKilometraje.LastOrDefault().Kilometraje: 0);
                ServiceLocator.Instance.GetService<VehiculoManager>().Update(nuevoRevisionVehiculo.vehiculo);
                Response.Redirect("/Process/Revision/AdministrarRevision.aspx");
            }
        }
    
    }
}