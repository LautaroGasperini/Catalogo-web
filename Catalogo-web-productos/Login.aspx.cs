using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_web_productos
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.email = txtEmail.Text;
                usuario.pass = txtPassword.Text;
                if (negocio.Login(usuario))
                {
                    Session.Add("user", usuario);
                    Session.Add("UserID", usuario.Id);
                    Response.Redirect("Default.aspx", false);
                    return;
                }
                lblError.Text = "Email o contraseña incorrectos.";
                lblError.Visible = true;
                //Response.Redirect("Error.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
                
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}