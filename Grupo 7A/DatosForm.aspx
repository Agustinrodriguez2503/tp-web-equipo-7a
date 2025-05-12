<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DatosForm.aspx.cs" Inherits="Grupo_7A.Datos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <script type="text/javascript">
        var formClientIDs = {
            txtDni: '<%= txtDni.ClientID %>',
            txtNombre: '<%= txtNombre.ClientID %>',
            txtApellido: '<%= txtApellido.ClientID %>',
            txtEmail: '<%= txtEmail.ClientID %>',
            txtDireccion: '<%= txtDireccion.ClientID %>',
            txtCiudad: '<%= txtCiudad.ClientID %>',
            txtCp: '<%= txtCp.ClientID %>',
            cbxTerminos: '<%= cbxTerminos.ClientID %>'
        };
    </script>

    <script src="Content/Scripts.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 d-flex justify-content-center align-items-center" style="min-height: 60vh;">
        <div class="form-box p-4 shadow-lg bg-white rounded-4" style="width: 100%; max-width: 700px;">
            <h1 class="mb-3 text-center text-dark fw-bold">Ingresá tus datos</h1>
            <p class="text-center text-muted">Completá el formulario para participar</p>
            <div class="col-auto">
                <label for="txtDni" class="form-label">DNI</label>
            </div>
            <div class="input-group">
                <span class="input-group-text"><i class="fa fa-id-card"></i></span>
                <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDni_TextChanged"
                    placeholder="99999999" onkeypress="return soloNumeros(event);" MaxLength="8" />
                <span id="dniError" class="form-text text-danger"></span>
            </div>
            <div class="row g-3 mb-3">
                <div class="col-md-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Juan"
                        onkeypress="return soloLetras(event);" MaxLength="15" oninput="limpiarError(this);" />
                    <span id="nombreError" class="form-text text-danger"></span>
                </div>
                <div class="col-md-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Pérez"
                        onkeypress="return soloLetras(event);" MaxLength="15" oninput="limpiarError(this);" />
                    <span id="apellidoError" class="form-text text-danger"></span>
                </div>
                <div class="col-md-6">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="email@email.com"
                        onblur="validarEmail(this);" oninput="limpiarError(this);" />
                    <span id="emailError" class="form-text text-danger"></span>
                </div>
            </div>

            <div class="row g-3 mb-3">
                <div class="col-md-5">
                    <label for="txtDireccion" class="form-label">Dirección</label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Calle 123"
                        onkeypress="return isAlphanumeric(event);" MaxLength="15" oninput="limpiarError(this);" />
                    <span id="direccionError" class="form-text text-danger"></span>
                </div>
                <div class="col-md-5">
                    <label for="txtCiudad" class="form-label">Ciudad</label>
                    <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" placeholder="Tu ciudad"
                        onkeypress="return isAlphanumeric(event);" MaxLength="15" oninput="limpiarError(this);" />
                    <span id="ciudadError" class="form-text text-danger"></span>
                </div>
                <div class="col-md-2">
                    <label for="txtCp" class="form-label">CP</label>
                    <asp:TextBox runat="server" ID="txtCp" CssClass="form-control" placeholder="xxxx"
                        onkeypress="return soloNumeros(event);" MaxLength="4" oninput="limpiarError(this);" />
                    <span id="cpError" class="form-text text-danger"></span>
                </div>
            </div>
            <div class="form-check mb-3">
                <asp:CheckBox runat="server" ID="cbxTerminos" CssClass="form-check-input" onclick="limpiarError(this);" />
                <label class="form-check-label" for="cbxTerminos">Acepto los términos y condiciones.</label>
                <span id="terminosError" class="form-text text-danger"></span>
            </div>


            <div class="d-grid">
                <asp:Button Text="¡Participar!" runat="server" ID="btnParticipar" type="submit" CssClass="btn btn-primary btn-select"
                    OnClientClick="return validateForm();" OnClick="btnParticipar_Click" />
            </div>
        </div>
    </div>

</asp:Content>
