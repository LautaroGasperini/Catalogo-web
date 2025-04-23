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
    <div class="container mt-4">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="rptFavoritos" runat="server" OnItemCommand="rptFavoritos_ItemCommand">
                <ItemTemplate>
                    <div class="col d-flex justify-content-center">
                        <br />
                        <div class="card">
                            <div class="card-img-wrapper">
                            <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="..." />
                            </div>
                            <div class="card-body">
                                <h5 class="card-title fw-bold"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p class=" card-text text-primary fs-5">AR$ <%# ((decimal)Eval("Precio")).ToString("N2", new System.Globalization.CultureInfo("es-AR")) %></p>
                                <div class="d-flex justify-content-between align-items-center" style="margin-top:35px;">
                                    <a href="VerDetalles.aspx?id=<%# Eval("Id") %>" class="btn btn-outline-primary" style="width: 70%; margin-right: 20px;">Ver detalles</a>
                                    <asp:Button Text="Quitar de Favoritos" ID="btnFav" CssClass="btn btn-outline-light form-control-plaintext" style="margin-top:auto;" CommandName="quitarDeFavoritos" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="contenedor">
        <hr class="hr-abajo" />
    </div>

</asp:Content>
