using IPEBCSCV.BusinessLogic.Manager;
using IPEBCSCV.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPEBCSCV.BusinessLogic.ServiceLocator;

namespace IPEBCSCV.Process.Servicio
{
    public partial class AdministrarServicio : GenericPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void gvDxCatalogo_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {

            if (e.CommandArgs.CommandName.Equals("Remove"))
            {


                try
                {
                    IPEBCSCV.BusinessEntity.Servicio removeServicio = (IPEBCSCV.BusinessEntity.Servicio)gvDxCatalogo.GetRow(e.VisibleIndex);
                    ServiceLocator.Instance.GetService<ServicioManager>().Remove(removeServicio);
                    gvDxCatalogo.DataBind();
                }
                catch (Exception ex)
                {
                    IBM.Data.DB2.DB2Exception excepcionIBM = null;
                    if (ex.InnerException != null)
                    {
                        if (ex.InnerException.InnerException != null)
                        {
                            excepcionIBM = ex.InnerException.InnerException as IBM.Data.DB2.DB2Exception;
                            if (excepcionIBM.Errors[0].SQLState.Equals("23000") || excepcionIBM.Errors[0].SQLState.Equals("23001"))
                            {
                                base.ShowPopupErrorWithMessage("ShowPopupMessageError", "Error",
                                    "No se ha podido eliminar debido a que tiene historial.", 0);
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script type=\"text/javascript\"> refreshServicio(); </script>", false);

                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                    if (excepcionIBM == null)
                    {
                        //throw;
                    }
                }

            }
            else
            {
                if (e.CommandArgs.CommandName.Equals("Edit"))
                {
                    IPEBCSCV.BusinessEntity.Servicio editServicio = (IPEBCSCV.BusinessEntity.Servicio)gvDxCatalogo.GetRow(e.VisibleIndex);
                    Page.Session.Add("EditServicioCatalogoID", editServicio.ServicioId);

                    Response.Redirect("/Process/Servicio/NuevoServicio.aspx");

                }
            }
        }

    }
}