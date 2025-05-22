using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo_web_productos
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listarCatalogo());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();

            if (Session["user"] == null || !Seguridad.esAdmin((Usuario)Session["user"]))
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                if (ddlCampo.SelectedItem.ToString() == "Nombre")
                {
                    ddlCriterio.Items.Add("Empieza con");
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Termina con");
                }
            }

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormArticulos.aspx?id=" + id);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = ((List<Articulo>)Session["listaArticulos"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource= lista;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Enabled = !chkAvanzado.Checked;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCriterio.SelectedItem == null)
                {
                    lblValidacion.Text = "*Debes cargar un criterio";
                    lblValidacion.ForeColor = Color.Red;
                    return;
                }
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void cvCriterio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlCriterio.SelectedValue != "0";
        }
    }
}