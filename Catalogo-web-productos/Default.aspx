<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo_web_productos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hola!</h1>
    <p>Encuentra tus productos favoritos y consiguelos al mejor precio!</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repArticulos">
            <ItemTemplate>
                <div class="col">
                    <br />
                    <div class="card">
                        <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="..." />
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <p class="card-text"><%# Eval("Precio") %></p>
                            <a href="Detalles.aspx?id=<%# Eval("Id") %>">Ver detalles</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
