<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Catalogo_web_productos.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center mt-5">
        <div class="perfil-card shadow rounded p-4">
            <h2 class="text-center mb-4">Mi Perfil</h2>
            <div class="row justify-content-around">
                <div class="col-md-6">
                    <div class="mb-3">
                        <asp:Label Text="Correo Electrónico" runat="server" />
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
                <div class="col-md-6 text-center">
                    <div class="mb-3">
                        <asp:Label Text="Imagen de perfil" runat="server" />
                        <input type="file" runat="server" id="txtImagen" class="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Image ID="imgPreCargada" CssClass="perfil-img rounded-circle mb-3"
                            ImageUrl="https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg" runat="server" />
                    </div>
                </div>
                <div class="text-end">
                    <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-primary me-2" OnClick="btnGuardar_Click" runat="server" />
                    <a href="Default.aspx" class="btn btn-secondary">Salir</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
