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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    int idUsuario = Convert.ToInt32(Session["UserID"]);
                    FavoritosNegocio negocioFav = new FavoritosNegocio();
                    Session["Favoritos"] = negocioFav.obtenerFav(idUsuario);
                }
                else
                {
                    Session["Favoritos"] = new List<int>();
                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.listarConSP();
                repArticulos.DataSource = ListaArticulos;
                repArticulos.DataBind();
            }
        }

        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if(e.CommandName == "agregarAFavoritos")
                {
                    if (Session["UserID"] != null)
                    {
                        Favorito favorito = new Favorito();
                        
                        favorito.idUser= Convert.ToInt32(Session["UserID"]);
                        favorito.idArticulo= Convert.ToInt32( e.CommandArgument);

                        FavoritosNegocio negocio = new FavoritosNegocio();

                        List<int> favoritos = negocio.obtenerFav(favorito.idUser);
                        if (favoritos.Contains(favorito.idArticulo))
                        {
                            negocio.eliminarFavoritos(favorito.idUser, favorito.idArticulo);
                            favoritos.Remove(favorito.idArticulo);
                        }
                        else
                        {
                            negocio.agregarFavoritos(favorito);
                            favoritos.Add(favorito.idArticulo);
                        }
                        Session["Favoritos"] = favoritos;

                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        repArticulos.DataSource = articuloNegocio.listarCatalogo();
                        repArticulos.DataBind();


                        Button btn = (Button)e.Item.FindControl("btnFav");
                        btn.Text = "★";


                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                    }

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