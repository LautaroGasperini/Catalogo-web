using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_web_productos
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["user"]) && !IsPostBack)
            {
                Usuario user =(Usuario)Session["user"];
                txtCorreo.Text = user.email;
                txtNombre.Text = user.nombre;
                txtApellido.Text = user.apellido;
                if (!string.IsNullOrEmpty(user.urlImagenPerfil))
                    imgPreCargada.ImageUrl = "~/Images/" + user.urlImagenPerfil;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario user = (Usuario)Session["user"];
                //escribir img
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.urlImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.nombre = txtNombre.Text;
                user.apellido = txtApellido.Text;

                negocio.actualizar(user);
                //leer img
                Image img = (Image)Master.FindControl("imgFotoPerfil");
                img.ImageUrl = "~/Images/" + user.urlImagenPerfil;

                Response.Redirect("Default.aspx", true);


            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}