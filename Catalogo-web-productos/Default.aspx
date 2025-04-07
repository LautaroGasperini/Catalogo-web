<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo_web_productos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h1>Hola!</h1>
    <p>Encuentra tus productos favoritos y consiguelos al mejor precio!</p>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater runat="server" ID="repArticulos" OnItemCommand="repArticulos_ItemCommand">
                    <ItemTemplate>
                        <div class="col">
                            <br />
                            <div class="card">
                                <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="..." />
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <p class="card-text">AR$ <%# ((decimal)Eval("Precio")).ToString("N2", new System.Globalization.CultureInfo("es-AR")) %></p>
                                    <a href="VerDetalles.aspx?id=<%# Eval("Id") %>">Ver detalles</a>
                                    <asp:Button Text='<%# ((List<int>)Session["Favoritos"]).Contains((int)Eval("Id")) ? "★" : "☆" %>' ID="btnFav"
                                        CssClass='<%# ((List<int>)Session["Favoritos"]).Contains((int)Eval("Id")) ? "btn btn-dark" : "btn btn-outline-dark" %>'
                                        CommandName="agregarAFavoritos" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
