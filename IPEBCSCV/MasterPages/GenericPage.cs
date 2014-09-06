using IPEBCSCV.BusinessEntity;
using IPEBCSCV.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace IPEBCSCV.MasterPages
{
    public class GenericPage : Page
    {
        protected bool SeMostroMensajeError = false;


        protected void ShowPopupErrorWithMessage(string nombreMetodo,string title, string popupErrorMessage,int type)
        {
            string script = String.Format("<script type=\"text/javascript\"> {0}('{1}','{2}',{3}); </script>", nombreMetodo,title, popupErrorMessage,type);
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), nombreMetodo, script);
        }


        

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

    }
}