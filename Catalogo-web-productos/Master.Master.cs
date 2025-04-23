using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_web_productos
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgFotoPerfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error)) 
            {
                if (!Seguridad.sesionActiva(Session["user"]))
                {
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    Usuario user = (Usuario)Session["user"];
                    if(!string.IsNullOrEmpty(user.urlImagenPerfil))
                        imgFotoPerfil.ImageUrl = "~/Images/" + ((Usuario)Session["user"]).urlImagenPerfil;
                       
                }
            }

            if (Seguridad.sesionActiva(Session["user"]))
            {
                Usuario usuario = (Usuario)Session["user"];
                if (!string.IsNullOrEmpty(usuario.urlImagenPerfil))
                    imgFotoPerfil.ImageUrl = "/Images/" + usuario.urlImagenPerfil; // 🔹 Ruta corregida
                else
                    imgFotoPerfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            }
            else
            {
                imgFotoPerfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            }


        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}