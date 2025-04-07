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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idUsuario = Convert.ToInt32(Session["UserID"]);
                FavoritosNegocio negocio = new FavoritosNegocio();

                rptFavoritos.DataSource = negocio.listarFavoritos(idUsuario);
                rptFavoritos.DataBind();
            }
        }

        protected void rptFavoritos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "quitarDeFavoritos")
                {
                    int idArticulo = Convert.ToInt32(e.CommandArgument);
                    int idUsuario = (int)Session["UserID"];

                    FavoritosNegocio negocio = new FavoritosNegocio();
                    negocio.eliminarFavoritos(idUsuario, idArticulo);


                    List<Articulo> favoritosActualizados = negocio.listarFavoritos(idUsuario);

                    rptFavoritos.DataSource = favoritosActualizados;
                    rptFavoritos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}