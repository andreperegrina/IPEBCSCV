using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using IPEBCSCV.BusinessEntity;
using IPEBCSCV.BusinessLogic.Manager;
using IPEBCSCV.BusinessLogic.ServiceLocator;
using IPEBCSCV.MasterPages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPEBCSCV.Process.Catalogos
{
    public partial class AdministrarVehiculo : GenericPage
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
                    Vehiculo removeVehiculo = (Vehiculo)gvDxCatalogo.GetRow(e.VisibleIndex);
                    ServiceLocator.Instance.GetService<VehiculoManager>().Remove(removeVehiculo);
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
                                base.ShowPopupErrorWithMessage("ShowPopupMessageError", "Error" ,
                                    "No se ha podido eliminar debido a que tiene historial.",0);
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script type=\"text/javascript\"> refreshVehiculo(); </script>", false);

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
                    Vehiculo editVehiculo = (Vehiculo)gvDxCatalogo.GetRow(e.VisibleIndex);
                    Page.Session.Add("EditVehiculoCatalogoID", editVehiculo.VehiculoId);

                    Response.Redirect("/Process/Catalogos/Registro/NuevoVehiculo.aspx");

                }
                else
                {

                    if (e.CommandArgs.CommandName.Equals("Hide") || e.CommandArgs.CommandName.Equals("Show"))
                    {
                        Vehiculo showHideVehiculo = (Vehiculo)gvDxCatalogo.GetRow(e.VisibleIndex);
                        showHideVehiculo.Hide = !showHideVehiculo.Hide;
                        ServiceLocator.Instance.GetService<VehiculoManager>().Update(showHideVehiculo);
                        gvDxCatalogo.DataBind();
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key",
                        //    "<script type=\"text/javascript\"> refreshgvCatalogo(); </script>", false);
                    }
                }
            }
        }

        protected void btnDxShow_Init(object sender, EventArgs e)
        {
            ASPxButton btnInit = (ASPxButton)sender;

            GridViewDataItemTemplateContainer templateContainer =
                (GridViewDataItemTemplateContainer)btnInit.NamingContainer;
            int visibleIndexbtnInit = templateContainer.VisibleIndex;
            Vehiculo vehiculoSelect = (Vehiculo)gvDxCatalogo.GetRow(visibleIndexbtnInit);
            btnInit.Visible = !vehiculoSelect.Hide;
        }

        protected void btnDxHide_Init(object sender, EventArgs e)
        {

            ASPxButton btnInit = (ASPxButton)sender;

            GridViewDataItemTemplateContainer templateContainer =
                (GridViewDataItemTemplateContainer)btnInit.NamingContainer;
            int visibleIndexbtnInit = templateContainer.VisibleIndex;
            Vehiculo vehiculoSelect = (Vehiculo)gvDxCatalogo.GetRow(visibleIndexbtnInit);
            btnInit.Visible = vehiculoSelect.Hide;
        }

    }
}