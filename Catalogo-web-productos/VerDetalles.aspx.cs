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
    public partial class VerDetalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(id))
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        List<Articulo> lista = negocio.listarCatalogo(id);
                        Articulo seleccionado = lista.FirstOrDefault();
                        decimal precio = seleccionado.Precio;

                        if (seleccionado != null)
                        {
                            lblNombre.Text = seleccionado.Nombre;
                            lblCategoria.Text = seleccionado.Categoria.Categoria;
                            lblDescripcion.Text = seleccionado.Descripcion;
                            lblPrecio.Text = "AR$ " + precio.ToString("N2", new System.Globalization.CultureInfo("es-AR"));
                            imgProducto.ImageUrl = seleccionado.UrlImagen;
                            lblMarca.Text = seleccionado.Marca.Marca;
                        }
                        else
                        {
                            lblNombre.Text = "Articulo no encontrado";
                        }
                    }
                }
            }
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
			}
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

       
    }
}