<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Catalogo_web_productos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center min-vh-100">
        <div class="card login-card p-5">
            <h3 class="text-center">Iniciar Sesión</h3>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" required="true"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-around">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-secondary" OnClick="btnIngresar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
            </div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="align-self-md-center" Visible="false"></asp:Label>

            <br />
            <a href="Registro.aspx">¿Todavia no tienes una cuenta? Registrate Aqui!</a>
        </div>
    </div>
</asp:Content>
