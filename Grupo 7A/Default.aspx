<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grupo_7A.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--banner--%>
    <div class="banner">
        <h1>HOLAAAAAAA</h1>
    </div>

    <div class="row mt-5">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Ingrese el codigo:</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary" Text="Enviar" />
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
