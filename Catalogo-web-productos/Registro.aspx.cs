using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_web_productos
{
    public partial class Registro : System.Web.UI.Page
    {
        private MailMessage email;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                usuario.email = txtEmail.Text;
                usuario.pass = txtPassword.Text;
                usuario.Id = negocio.insertarNuevo(usuario);
                Session.Add("user", usuario);
                emailService.armarCorreo(usuario.email, "Bienvenido", "Hola, gracias por registrarte en la web," +
                    " no pierdas tiempo y empeza a implementar esta web a tu negocio para manejar tus productos de la mejor forma posible ");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}