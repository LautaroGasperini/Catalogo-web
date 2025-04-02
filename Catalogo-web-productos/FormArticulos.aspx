<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormArticulos.aspx.cs" Inherits="Catalogo_web_productos.FormArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="ID" ID="lblID" runat="server" />
                <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Codigo" runat="server" />
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" runat="server" />
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Descripcion" runat="server" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Marca:" runat="server" />
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Categoria:" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Precio" runat="server" />
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" runat="server" CssClass="btn btn-primary" ID="btnAceptar" OnClick="btnAceptar_Click" />
                <%if (Request.QueryString["id"] != null)
                    {%>
                <asp:Button Text="Eliminar" CssClass="btn btn-primary btn-danger" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" />
                    <%if (ConfirmarEliminacion)
                    {%>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                        <asp:Button Text="Eliminacion" ID="btnConfirmarEliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminar_Click" runat="server" />
                    </div>
                    <%} %>
                <%} %>
            </div>
        </div>
        <div class="col-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Label Text="Url Imagen" runat="server" />
                        <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://www.recambiosoriginal.com/server/Portal_0011062/img/products/no_image_xxl.jpg" ID="imgArticulo" Width="60%" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
