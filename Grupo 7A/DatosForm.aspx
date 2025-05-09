﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DatosForm.aspx.cs" Inherits="Grupo_7A.Datos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Content/Scripts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 d-flex justify-content-center align-items-center" style="min-height: 60vh;">
        <div class="col-md-8">
            <h1 class="mb-4 text-center">Ingresá tus datos</h1>
            <div class="col-auto">
                <label for="txtDni" class="form-label">DNI</label>
            </div>
            <div class="col-md-3 mb-3">
                <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDni_TextChanged" 
                    placeholder="99999999" onkeypress="return soloNumeros(event);" MaxLength="8" />
            </div>
            <div class="row g-3 mb-3">
                <div class="col-md-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Juan" onkeypress="return soloLetras(event);" MaxLength="15" />
                </div>
                <div class="col-md-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Pérez" onkeypress="return soloLetras(event);" MaxLength="15" />
                </div>
                <div class="col-md-6">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="email@email.com" onblur="validarEmail(this);" />
                    <span id="emailError" class="form-text text-danger"></span>
                </div>
            </div>

            <div class="row g-3 mb-3">
                <div class="col-md-5">
                    <label for="txtDireccion" class="form-label">Dirección</label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Calle 123" onkeypress="return isAlphanumeric(event);" MaxLength="15" />
                </div>
                <div class="col-md-5">
                    <label for="txtCiudad" class="form-label">Ciudad</label>
                    <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" placeholder="Tu ciudad" onkeypress="return isAlphanumeric(event);" MaxLength="15" />
                </div>
                <div class="col-md-2">
                    <label for="txtCp" class="form-label">CP</label>
                    <asp:TextBox runat="server" ID="txtCp" CssClass="form-control" placeholder="xxxx" onkeypress="return soloNumeros(event);" MaxLength="4" />
                </div>
            </div>
            <div class="form-check mb-3">
                <asp:CheckBox runat="server" ID="cbxTerminos" CssClass="form-check-input" />
                <label class="form-check-label" for="cbxTerminos">Acepto los términos y condiciones.</label>
            </div>
            <div class="d-grid">
                <button type="submit" class="btn btn-dark">Participar!</button>
            </div>
        </div>
    </div>
</asp:Content>
