using DevExpress.Web.ASPxEditors;
using IPEBCSCV.BusinessLogic.Manager;
using IPEBCSCV.BusinessLogic.ServiceLocator;
using IPEBCSCV.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.Process.Servicio
{
    public partial class NuevoServicio : GenericPage
    {



        protected int? EditServicioCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditServicioCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditServicioCatalogoID", value);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditServicioCatalogoID != null)
                {
                    IPEBCSCV.BusinessEntity.Servicio servicioEdit = ServiceLocator.Instance.GetService<ServicioManager>().GetByID(EditServicioCatalogoID.Value);
                    ShowDataFromServicio(servicioEdit);
                    lbTitle.Text = "Editar servicio";
                }

                txtDxKilometraje.Text = ServiceLocator.Instance.GetService<RevisionVehiculoManager>().GetKilometrajeSugerido(DateTime.Today).ToString();
                dtDxFechaServicio.Date = DateTime.Today;
            }


        }

        private void ShowDataFromServicio(IPEBCSCV.BusinessEntity.Servicio servicioEdit)
        {
            txtDxNombre.Text = servicioEdit.Nombre;
            txtDxFactura.Text = servicioEdit.Factura;
            txtDxImporte.Text = servicioEdit.Importe.ToString();
            txtDxProveedor.Text = servicioEdit.Proveedor;
            cobxVehiculo.DataBind();
            cobxVehiculo.Items.FindByValue(servicioEdit.VehiculoId).Selected=true;
            cobxDxTipoServicio.DataBind();
            cobxDxTipoServicio.Items.FindByValue(servicioEdit.TipoServicioId).Selected = true;
            dtDxFechaServicio.Date = servicioEdit.FechaServicio;
            txtDxKilometraje.Text = servicioEdit.Kilometraje.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditServicioCatalogoID != null)
            {
                IPEBCSCV.BusinessEntity.Servicio nuevoServicio = ServiceLocator.Instance.GetService<ServicioManager>().GetByID(EditServicioCatalogoID.Value);
                nuevoServicio.Nombre = txtDxNombre.Text;
                nuevoServicio.Factura = txtDxFactura.Text;
                nuevoServicio.Importe = Convert.ToDouble(txtDxImporte.Text);
                nuevoServicio.Proveedor = txtDxProveedor.Text;
                nuevoServicio.TipoServicioId = Convert.ToInt32(cobxDxTipoServicio.SelectedItem.Value);
                nuevoServicio.VehiculoId = Convert.ToInt32(cobxVehiculo.SelectedItem.Value);
                nuevoServicio.FechaServicio = dtDxFechaServicio.Date;
                nuevoServicio.UsuarioId = PerfilUsuario.UsuarioId;
                nuevoServicio.Kilometraje = Convert.ToInt32(txtDxKilometraje.Text.Replace(",",""));
                if (nuevoServicio.TipoServicioId == nuevoServicio.vehiculo.regla.TipoServicioId)
                {
                    nuevoServicio.vehiculo.Kilometraje = 0;
                }
                ServiceLocator.Instance.GetService<ServicioManager>().Update(nuevoServicio);
                Response.Redirect("/Process/Servicio/AdministrarServicio.aspx");
            }
            else
            {
                IPEBCSCV.BusinessEntity.Servicio nuevoServicio = new IPEBCSCV.BusinessEntity.Servicio();
                nuevoServicio.Nombre = txtDxNombre.Text;
                nuevoServicio.Factura = txtDxFactura.Text;
                nuevoServicio.Importe = Convert.ToDouble(txtDxImporte.Text);
                nuevoServicio.Proveedor = txtDxProveedor.Text;
                nuevoServicio.TipoServicioId = Convert.ToInt32(cobxDxTipoServicio.SelectedItem.Value);
                nuevoServicio.VehiculoId = Convert.ToInt32(cobxVehiculo.SelectedItem.Value);
                nuevoServicio.FechaServicio = dtDxFechaServicio.Date;
                nuevoServicio.FechaCreacion = DateTime.Today;
                nuevoServicio.UsuarioId = PerfilUsuario.UsuarioId;
                nuevoServicio.Kilometraje = Convert.ToInt32(txtDxKilometraje.Text.Replace(",",""));
                ServiceLocator.Instance.GetService<ServicioManager>().Save(nuevoServicio);
                if (nuevoServicio.TipoServicioId==nuevoServicio.vehiculo.regla.TipoServicioId)
                {
                    nuevoServicio.vehiculo.Kilometraje = 0;
                    ServiceLocator.Instance.GetService<VehiculoManager>().Update(nuevoServicio.vehiculo);
                }
                Response.Redirect("/Process/Servicio/AdministrarServicio.aspx");
            }
        }

        protected void dtDxFechaServicio_DateChanged(object sender, EventArgs e)
        {
            DateTime date = ((ASPxDateEdit)sender).Date;
            txtDxKilometraje.Text = ServiceLocator.Instance.GetService<RevisionVehiculoManager>()
                .GetKilometrajeSugerido(date).ToString();

        }
    
    }
}