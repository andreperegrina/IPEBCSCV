using Common.Security;
using Common.Security.Encrypt;
using IPEBCSCV.BusinessLogic;
using IPEBCSCV.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV
{
    public partial class Login : GenericPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LgnUsuario_Authenticate(object sender, AuthenticateEventArgs e)
        {
            System.Web.UI.WebControls.Login lgnUsuario = (System.Web.UI.WebControls.Login)sender;
            SecurityManager.Instance.GetUserImplementation = GetUser;
            e.Authenticated = SecurityManager.Instance.AuthenticateUser(lgnUsuario.UserName, lgnUsuario.Password);
        }


        public CustomUser GetUser(String user_name, String password)
        {
            Encrypt encriptar = new Encrypt();

            PerfilUsuario perfilUsuario = null;
            perfilUsuario = UserAutentification.Instance.GetPerfilUsuario(user_name, password);

            if (perfilUsuario == null)
            {
                LgnUsuario.FailureText =  "Usuario o contraseña incorrectos.";
                return null;
            }

            PerfilUsuario = perfilUsuario;


            LgnUsuario.DestinationPageUrl = "~/Process/Index.aspx";

            return perfilUsuario;
        }

    }
}