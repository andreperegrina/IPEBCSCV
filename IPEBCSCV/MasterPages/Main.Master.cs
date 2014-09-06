using IPEBCSCV.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {

        protected PerfilUsuario PerfilUsuario
        {
            get
            {
                return ((PerfilUsuario)HttpContext.Current.Session["PerfilUsuario"]);
            }
            set
            {
                HttpContext.Current.Session["PerfilUsuario"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (PerfilUsuario != null)
                {
                    lbUsuario.Text = PerfilUsuario.GetNombre();
                    lbRol.Text = PerfilUsuario.GetRol();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

        }

        protected void btnDxLogOff_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}