<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Catalogo_web_productos.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contenedor {
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        .hr-abajo {
            margin-top: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rptFavoritos" runat="server" OnItemCommand="rptFavoritos_ItemCommand">
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
                            <asp:Button Text="X" ID="btnFav" CssClass="btn btn-outline-dark" CommandName="quitarDeFavoritos" CommandArgument='<%# Eval("Id") %>' runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="contenedor">
        <hr class="hr-abajo" />
    </div>

</asp:Content>
