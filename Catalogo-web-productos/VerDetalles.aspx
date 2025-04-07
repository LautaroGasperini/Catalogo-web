<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerDetalles.aspx.cs" Inherits="Catalogo_web_productos.VerDetalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mb-3" style="max-width: 800px;">
        <div class="row g-0">
            <div class="col-md-4">
                <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid rounded-start" />
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <h5 class="card-title">
                        <asp:Label ID="lblNombre" runat="server" /></h5>
                    <p class="card-text">
                        <asp:Label ID="lblDescripcion" runat="server" /></p>
                    <p class="card-text"><strong>Precio:</strong>
                        <asp:Label ID="lblPrecio" runat="server" /></p>
                    <p class="card-text"><strong>Categoría:</strong>
                        <asp:Label ID="lblCategoria" runat="server" /></p>
                    <p class="card-text"><strong>Marca:</strong>
                        <asp:Label ID="lblMarca" runat="server" /></p>
                    <div class="d-flex justify-content-around">
                        <asp:Button Text="Volver" CssClass="btn btn-outline-dark" ID="btnVolver" OnClick="btnVolver_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
