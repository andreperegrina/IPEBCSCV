using Common.Security.Encrypt;
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
    public partial class NuevoUsuario : System.Web.UI.Page
    {



        protected int? EditUsuarioCatalogoID
        {
            get
            {
                return ((int?)HttpContext.Current.Session["EditUsuarioCatalogoID"]);
            }
            set
            {
                Page.Session.Add("EditUsuarioCatalogoID", value);

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (EditUsuarioCatalogoID != null)
                {
                    Usuario vehiculoEdit = ServiceLocator.Instance.GetService<UsuarioManager>().GetByID(EditUsuarioCatalogoID.Value);
                    ShowDataFromUsuario(vehiculoEdit);
                    lbTitle.Text = "Editar usuario";
                }
            }

        }

        private void ShowDataFromUsuario(Usuario usuarioEdit)
        {

            txtDxNombre.Text = usuarioEdit.NombreCompleto;
            txtDxNombreUsuario.Text = usuarioEdit.NombreUsuario;
            cobxDxRol.DataBind();
            cobxDxRol.Items.FindByValue(usuarioEdit.RolId).Selected=true;
            cobxDxMunicipio.DataBind();
            cobxDxMunicipio.Items.FindByValue(usuarioEdit.MunicipioId).Selected = true ;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (EditUsuarioCatalogoID != null)
            {
                Usuario nuevoUsuario = ServiceLocator.Instance.GetService<UsuarioManager>().GetByID(EditUsuarioCatalogoID.Value);
                nuevoUsuario.NombreCompleto = txtDxNombre.Text;
                nuevoUsuario.NombreUsuario = txtDxNombreUsuario.Text;
                nuevoUsuario.Password = EncryptionUtil.Encrypt(txtDxNombreUsuario.Text);
                nuevoUsuario.RolId = Convert.ToInt32(cobxDxRol.SelectedItem.Value);
                nuevoUsuario.MunicipioId = Convert.ToInt32(cobxDxMunicipio.SelectedItem.Value);
                nuevoUsuario.FechaCreacion = DateTime.Today;
                ServiceLocator.Instance.GetService<UsuarioManager>().Update(nuevoUsuario);
                Response.Redirect("/Process/Catalogos/AdministrarRol.aspx");
            }
            else
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.NombreCompleto = txtDxNombre.Text;
                nuevoUsuario.NombreUsuario = txtDxNombreUsuario.Text;
                nuevoUsuario.Password = EncryptionUtil.Encrypt(txtDxNombreUsuario.Text);
                nuevoUsuario.RolId = Convert.ToInt32(cobxDxRol.SelectedItem.Value);
                nuevoUsuario.MunicipioId = Convert.ToInt32(cobxDxMunicipio.SelectedItem.Value);
                nuevoUsuario.FechaCreacion = DateTime.Today;
                ServiceLocator.Instance.GetService<UsuarioManager>().Save(nuevoUsuario);
                Response.Redirect("/Process/Catalogos/AdministrarRol.aspx");
            }
        }
    }
}