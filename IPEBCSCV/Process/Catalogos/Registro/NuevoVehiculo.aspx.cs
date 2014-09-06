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
    public partial class NuevoVehiculo : System.Web.UI.Page
    {




        protected int? EditVehiculoCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditVehiculoCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditVehiculoCatalogoID", value);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditVehiculoCatalogoID!=null)
                {
                    Vehiculo vehiculoEdit=ServiceLocator.Instance.GetService<VehiculoManager>().GetByID(EditVehiculoCatalogoID.Value);
                    ShowDataFromVehiculo(vehiculoEdit);
                    lbTitle.Text = "Editar vehículo";
                }
            }

        }

        private void ShowDataFromVehiculo(Vehiculo vehiculoEdit){


            txtDxModelo.Text = vehiculoEdit.Modelo;
            cobxDxMarcaVehiculo.DataBind();
            cobxDxMarcaVehiculo.Items.FindByValue(vehiculoEdit.MarcaVehiculoId).Selected=true;
            txtDxColor.Text = vehiculoEdit.Color;
            txtDxPlacas.Text = vehiculoEdit.Placas;
            txtDxSerie.Text = vehiculoEdit.Serie;
            txtDxNumeroEconomico.Text = vehiculoEdit.NumeroEconomico.ToString();
            txtDxKilometraje.Text = vehiculoEdit.Kilometraje.ToString();
            txtDxNombrePersona.Text = vehiculoEdit.NombrePersona;
            cobxDxRegla.DataBind();
            cobxDxRegla.Items.FindByValue(vehiculoEdit.ReglaId).Selected=true;
            cobxDxMunicipio.DataBind();
            cobxDxMunicipio.Items.FindByValue(vehiculoEdit.MunicipioId).Selected=true;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (EditVehiculoCatalogoID != null)
            {

                Vehiculo nuevoVehiculo = ServiceLocator.Instance.GetService<VehiculoManager>().GetByID(EditVehiculoCatalogoID.Value);
                nuevoVehiculo.Modelo = txtDxModelo.Text;
                nuevoVehiculo.MarcaVehiculoId = Convert.ToInt32(cobxDxMarcaVehiculo.SelectedItem.Value);
                nuevoVehiculo.Color = txtDxColor.Text;
                nuevoVehiculo.Placas = txtDxPlacas.Text;
                nuevoVehiculo.Serie = txtDxSerie.Text;
                nuevoVehiculo.NumeroEconomico = Convert.ToInt32(txtDxNumeroEconomico.Text);
                nuevoVehiculo.Kilometraje = Convert.ToInt32(txtDxKilometraje.Text);
                nuevoVehiculo.NombrePersona = txtDxNombrePersona.Text;
                nuevoVehiculo.ReglaId = Convert.ToInt32(cobxDxRegla.SelectedItem.Value);
                nuevoVehiculo.MunicipioId = Convert.ToInt32(cobxDxMunicipio.SelectedItem.Value);
                nuevoVehiculo.FechaCreacion = DateTime.Today;
                nuevoVehiculo.Hide = false;
                ServiceLocator.Instance.GetService<VehiculoManager>().Update(nuevoVehiculo);
            }
            else
            {
                Vehiculo nuevoVehiculo = new Vehiculo();
                nuevoVehiculo.Modelo = txtDxModelo.Text;
                nuevoVehiculo.MarcaVehiculoId = Convert.ToInt32(cobxDxMarcaVehiculo.SelectedItem.Value);
                nuevoVehiculo.Color = txtDxColor.Text;
                nuevoVehiculo.Placas = txtDxPlacas.Text;
                nuevoVehiculo.Serie = txtDxSerie.Text;
                nuevoVehiculo.NumeroEconomico = Convert.ToInt32(txtDxNumeroEconomico.Text);
                nuevoVehiculo.Kilometraje = Convert.ToInt32(txtDxKilometraje.Text);
                nuevoVehiculo.NombrePersona = txtDxNombrePersona.Text;
                nuevoVehiculo.ReglaId = Convert.ToInt32(cobxDxRegla.SelectedItem.Value);
                nuevoVehiculo.MunicipioId = Convert.ToInt32(cobxDxMunicipio.SelectedItem.Value);
                nuevoVehiculo.FechaCreacion = DateTime.Today;
                nuevoVehiculo.Hide = false;
                ServiceLocator.Instance.GetService<VehiculoManager>().Save(nuevoVehiculo);
            }
            Response.Redirect("/Process/Catalogos/AdministrarVehiculo.aspx");

        }
    }
}