using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
       

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("aguantequilmes1887@gmail.com", "ktke nljn vmfc zeqz");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@discosweb.com");
            email.To.Add(emailDestino);
            email.Subject = "<h3>Bienvenida<h3>";
            email.IsBodyHtml = true;
            email.Body = "<h1>Reporte de materias a las que se ha inscripto</h1> <br>Hola, te inscribite a... bla bla";
            //email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
