<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Catalogo_web_productos.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2>Mi Perfil</h2>
    <hr />
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Correo Electronico" runat="server" />
                <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre" runat="server" />
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Apellido" runat="server" />
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label Text="Imagen de perfil" runat="server" />
                <input type="file" runat="server" id="txtImagen" class="form-control"/>
            </div>
            <div class="mb-3">
                <asp:Image ID="imgPreCargada" CssClass="img-fluid mb-3"
                    ImageUrl="https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" />
                <a href="Default.aspx" class="btn btn-primary">Salir</a>
            </div>
        </div>
    </div>
</asp:Content>
