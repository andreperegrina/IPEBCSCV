using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using Common.Web.Util;

namespace Common.Web.Mail
{
    public class NotificacionesUtil : Page
    {

        public string EnviarNotificacion(string correo_destino, string asunto, string mensaje, string nombre, string correo_configuracion, string pass_configuracion)
        {
            String SMTP = Server.HtmlDecode("smtp.gmail.com");
            String CredentialsUserName = Server.HtmlDecode(correo_configuracion);
            String CredentialsPassword = Server.HtmlDecode(pass_configuracion);
            String from = Server.HtmlDecode(correo_configuracion);
            String to = correo_destino;
            String subject = asunto;            
            try
            {
                MailMessage mailMessage = new MailMessage() { From = new MailAddress(from, nombre, Encoding.UTF8) };
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = String.Format("{0} ha enviado el siguiente mensaje: <br \\><br \\>{1}", from, mensaje);
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient(SMTP) { Port = 587, Credentials = new NetworkCredential(CredentialsUserName, CredentialsPassword), EnableSsl = true };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                smtpClient.Send(mailMessage);                
                return "Correo enviado exitosamente!";
            }
            catch (Exception ex)
            {                
                JavaScriptUtil.ShowAlert(Page, "");
                Console.Write(ex);
                return "Se ha producido un error inesperado. Por favor, inténtalo de nuevo.";
            }
        }
    }
}
