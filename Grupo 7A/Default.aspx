<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Grupo_7A.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner mt-3"></div>
    <div class="row mt-5">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="p-4 bg-white shadow rounded">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Ingrese el código:</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                    <div id="divAlerta" runat="server" class="alert alert-warning alerta-chica" visible="false">
                         Ingrese un código, por favor.
                    </div>
                </div>
                <div class="d-grid gap-2 col-6 mx-auto">
                    <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary btn-select" OnClick="btnEnviar_Click" Text="¡Canjear!" />
                </div>
            </div>
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
