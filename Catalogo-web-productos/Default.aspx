<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo_web_productos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="bienvenida-container">
        <h1 class="titulo-bienvenida">¡Bienvenido al Catálogo de Productos!</h1>
        <p class="descripcion-bienvenida">
            Descubrí una gran variedad de artículos y encontrá tus favoritos fácilmente. 
        ¡Explorá lo que tenemos para ofrecerte!
        </p>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container mt-4">
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater runat="server" ID="repArticulos" OnItemCommand="repArticulos_ItemCommand">
                        <ItemTemplate>
                            <div class="col d-flex justify-content-center">
                                <div class="card custom-card h-100 shadow rounded">
                                    <div class="card-img-wrapper">
                                        <img src="<%# Eval("UrlImagen") %>" alt="Producto" />
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title fw-bold"><%# Eval("Nombre") %></h5>
                                        <p class="card-text"><%# Eval("Descripcion") %></p>
                                        <p class="card-text text-primary fs-5">AR$ <%# ((decimal)Eval("Precio")).ToString("N2", new System.Globalization.CultureInfo("es-AR")) %></p>

                                        <div class="d-flex justify-content-between align-items-center">
                                            <a href='VerDetalles.aspx?id=<%# Eval("Id") %>' class="btn btn-outline-primary btn-sm">Ver detalles</a>

                                            <asp:Button Text='<%# ((List<int>)Session["Favoritos"]).Contains((int)Eval("Id")) ? "★" : "☆" %>'
                                                ID="btnFav"
                                                CssClass='<%# ((List<int>)Session["Favoritos"]).Contains((int)Eval("Id")) ? "btn btn-warning btn-fav" : "btn btn-outline-warning btn-sm btn-fav" %>'
                                                CommandName="agregarAFavoritos"
                                                CommandArgument='<%# Eval("Id") %>'
                                                runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
