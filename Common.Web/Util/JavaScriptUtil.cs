using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Common.Web.Util
{
    public class JavaScriptUtil
    {
        public static void RunScript(Page page, String content)
        {
            string script = "<SCRIPT LANGUAGE='JavaScript'> ";
            script += content;
            script += "</SCRIPT>";
            if (page.ClientScript.IsStartupScriptRegistered("Run_Script") == false)
                page.ClientScript.RegisterStartupScript(page.GetType(), "Run_Script", script);
        }

        public static void RunScript(Page page, String content, UpdatePanel updatePanel)
        {
            string script = "<SCRIPT LANGUAGE='JavaScript'> ";
            script += content;
            script += "</SCRIPT>";
            if (page.ClientScript.IsStartupScriptRegistered("Run_Script") == false)
                ScriptManager.RegisterClientScriptBlock(updatePanel, page.GetType(), "Run_Script", script, true);
        }

        public static void ShowAlert(Page page, String message)
        {
            string script = "<SCRIPT LANGUAGE='JavaScript'> ";
            script += String.Format("alert('{0}')", message);
            script += "</SCRIPT>";
            if (page.ClientScript.IsStartupScriptRegistered("Show_Alert_Script") == false)
                page.ClientScript.RegisterStartupScript(page.GetType(), "ShowAlert_Script", script);
        }

        public static void ShowAlert(Page page, String message, UpdatePanel updatePanel)
        {
            String script = String.Format("alert('{0}')", message);
            ScriptManager.RegisterClientScriptBlock(updatePanel, page.GetType(), "ShowAlert_Script", script, true);
        }

        public static void ShowAlertAndRedirect(Page page,String message,String redirectPagePath)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "redirect",
                        "alert('Error, no se ha podido eliminar todos los sectores seleccionados'); window.location='" + redirectPagePath + "';", true);
        }

        public static void ShowPopupWindow(Page parent_page, String url_child_page)
        {
            string script = "<SCRIPT LANGUAGE='JavaScript'> ";
            script += String.Format("window.open('{0}',", url_child_page);
            script += "'child_window', 'scrollbars=no' );";
            script += "</SCRIPT>";
            parent_page.RegisterStartupScript("ClientScript", script);
        }

        public static void ShowPopupWindow(Page parent_page, String url_child_page, UpdatePanel updatePanel)
        {
            String script = String.Format("window.open('{0}',", url_child_page);
            script += "'child_window', 'scrollbars=no' );";
            ScriptManager.RegisterClientScriptBlock(updatePanel, parent_page.GetType(), "ShowPopupWindow_Script", script, true);
        }

        public static void ShowPopupWindow(Page parent_page, String url_child_page, UpdatePanel updatePanel, int width, int height)
        {
            String script = String.Format("window.open('{0}',", url_child_page);
            script += String.Format("'child_window', 'scrollbars=no, height={0} , width={1}');", height, width);
            ScriptManager.RegisterClientScriptBlock(updatePanel, parent_page.GetType(), "ShowPopupWindow_Script", script, true);
        }

        public static void Redirect(Page page, string destination_url, string confirm_message)
        {
            string content = String.Format("var answer = confirm('{0}');", confirm_message);
            content += String.Format("if (answer){{ window.location='{0}';}}", destination_url);
            RunScript(page, content);
        }
    }
}
