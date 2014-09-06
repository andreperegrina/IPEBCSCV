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
    public partial class AdministrarIncidencias : GenericPage
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
                    Incidencia removeIncidencia = (Incidencia)gvDxCatalogo.GetRow(e.VisibleIndex);
                    ServiceLocator.Instance.GetService<IncidenciaManager>().Remove(removeIncidencia);
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
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script type=\"text/javascript\"> refreshIncidencia(); </script>", false);

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
                    Incidencia editIncidencia = (Incidencia)gvDxCatalogo.GetRow(e.VisibleIndex);
                    Page.Session.Add("EditIncidenciaCatalogoID", editIncidencia.IncidenciaId);
                    Response.Redirect("/Process/Catalogos/Registro/NuevoIncidencia.aspx");


                }
            }
        }

    }
}