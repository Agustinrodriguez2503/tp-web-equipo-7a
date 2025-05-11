function soloNumeros(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

function soloLetras(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 8 || charCode === 9 || charCode === 0) {
        return true;
    }
    return false;
}
function validarEmail(emailInput) {
    var email = emailInput.value.trim();
    var emailErrorSpan = document.getElementById('emailError');
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailRegex.test(email)) {
        emailErrorSpan.textContent = 'Por favor, ingrese un correo electrónico válido.';
        emailInput.classList.add('is-invalid');
        return false;
    } else {
        emailErrorSpan.textContent = '';
        emailInput.classList.remove('is-invalid');
        return true;
    }
}
function isAlphanumeric(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || (charCode >= 48 && charCode <= 57) || charCode === 32 || charCode === 8 || charCode === 9 || charCode === 0) {
        return true;
    }
    return false;
}
function validateForm() {
    var txtDniEl = document.getElementById(formClientIDs.txtDni);
    var txtNombreEl = document.getElementById(formClientIDs.txtNombre);
    var txtApellidoEl = document.getElementById(formClientIDs.txtApellido);
    var txtEmailEl = document.getElementById(formClientIDs.txtEmail);
    var txtDireccionEl = document.getElementById(formClientIDs.txtDireccion);
    var txtCiudadEl = document.getElementById(formClientIDs.txtCiudad);
    var txtCpEl = document.getElementById(formClientIDs.txtCp);
    var cbxTerminosEl = document.getElementById(formClientIDs.cbxTerminos);

    var dni = txtDniEl.value.trim();
    var nombre = txtNombreEl.value.trim();
    var apellido = txtApellidoEl.value.trim();
    var email = txtEmailEl.value.trim();
    var direccion = txtDireccionEl.value.trim();
    var ciudad = txtCiudadEl.value.trim();
    var cp = txtCpEl.value.trim();
    var terminos = cbxTerminosEl.checked;
    var isValid = true;

    var fieldsToReset = [
        { el: txtDniEl, errorId: 'dniError' }, { el: txtNombreEl, errorId: 'nombreError' },
        { el: txtApellidoEl, errorId: 'apellidoError' }, { el: txtEmailEl, errorId: 'emailError' },
        { el: txtDireccionEl, errorId: 'direccionError' }, { el: txtCiudadEl, errorId: 'ciudadError' },
        { el: txtCpEl, errorId: 'cpError' }
    ];

    fieldsToReset.forEach(function (field) {
        var errorSpan = document.getElementById(field.errorId);
        if (errorSpan) errorSpan.textContent = '';
        else console.warn("Span de error '" + field.errorId + "' no encontrado para limpieza.");
        field.el.classList.remove('is-invalid', 'is-valid');
    });
    var terminosErrorSpan = document.getElementById('terminosError');
    if (terminosErrorSpan) terminosErrorSpan.textContent = '';
    else console.warn("Span de error 'terminosError' no encontrado para limpieza.");

    // Validar DNI
    var dniErrorSpan = document.getElementById('dniError');
    if (dni === '') {
        if (dniErrorSpan) dniErrorSpan.textContent = 'Por favor, ingrese su DNI.';
        txtDniEl.classList.add('is-invalid');
        isValid = false;
    } else if (dni.length < 7) {
        if (dniErrorSpan) dniErrorSpan.textContent = 'El DNI no puede contener menos de 7 números.';
        txtDniEl.classList.add('is-invalid');
        isValid = false;
    } else {
        txtDniEl.classList.add('is-valid');
    }

    // Validar Nombre
    var nombreErrorSpan = document.getElementById('nombreError');
    if (nombre === '') {
        if (nombreErrorSpan) nombreErrorSpan.textContent = 'Por favor, ingrese su nombre.';
        txtNombreEl.classList.add('is-invalid');
        isValid = false;
    } else {
        txtNombreEl.classList.add('is-valid');
    }

    // Validar Apellido
    var apellidoErrorSpan = document.getElementById('apellidoError');
    if (apellido === '') {
        if (apellidoErrorSpan) apellidoErrorSpan.textContent = 'Por favor, ingrese su apellido.';
        txtApellidoEl.classList.add('is-invalid');
        isValid = false;
    } else {
        txtApellidoEl.classList.add('is-valid');
    }

    // Validar Email
    var emailErrorSpan = document.getElementById('emailError');
    if (email === '') {
        if (emailErrorSpan) emailErrorSpan.textContent = 'Por favor, ingrese su email.';
        txtEmailEl.classList.add('is-invalid');
        isValid = false;
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
        if (emailErrorSpan) emailErrorSpan.textContent = 'Por favor, ingrese un email válido.';
        txtEmailEl.classList.add('is-invalid');
        isValid = false;
    } else {
        txtEmailEl.classList.add('is-valid');
    }

    // Validar Dirección
    var direccionErrorSpan = document.getElementById('direccionError');
    if (direccion === '') {
        if (direccionErrorSpan) direccionErrorSpan.textContent = 'Por favor, ingrese su dirección.';
        txtDireccionEl.classList.add('is-invalid');
        isValid = false;
    } else {
        txtDireccionEl.classList.add('is-valid');
    }

    // Validar Ciudad
    var ciudadErrorSpan = document.getElementById('ciudadError');
    if (ciudad === '') {
        if (ciudadErrorSpan) ciudadErrorSpan.textContent = 'Por favor, ingrese su ciudad.';
        txtCiudadEl.classList.add('is-invalid');
        isValid = false;
    } else {
        txtCiudadEl.classList.add('is-valid');
    }

    // Validar CP
    var cpErrorSpan = document.getElementById('cpError');
    if (cp === '') {
        if (cpErrorSpan) cpErrorSpan.textContent = 'Por favor, ingrese su código postal.';
        txtCpEl.classList.add('is-invalid');
        isValid = false;
    } else if (!/^((\d{4})|([A-Za-z]\d{4}[A-Za-z]{3}))$/.test(cp)) {
        if (cpErrorSpan) cpErrorSpan.textContent = 'Ingrese un código postal válido (ej: 1234).';
        txtCpEl.classList.add('is-invalid');
        isValid = false;
    } else {
        txtCpEl.classList.add('is-valid');
    }

    if (!terminos) {
        if (terminosErrorSpan) terminosErrorSpan.textContent = 'Debe aceptar los términos y condiciones.';
        isValid = false;
    }

    return isValid;
}

function limpiarError(inputElement) {

    var inputIdBase = '';
    if (inputElement.id.endsWith('txtDni')) inputIdBase = 'dni';
    else if (inputElement.id.endsWith('txtNombre')) inputIdBase = 'nombre';
    else if (inputElement.id.endsWith('txtApellido')) inputIdBase = 'apellido';
    else if (inputElement.id.endsWith('txtEmail')) inputIdBase = 'email';
    else if (inputElement.id.endsWith('txtDireccion')) inputIdBase = 'direccion';
    else if (inputElement.id.endsWith('txtCiudad')) inputIdBase = 'ciudad';
    else if (inputElement.id.endsWith('txtCp')) inputIdBase = 'cp';

    if (inputIdBase) {
        var errorSpanId = inputIdBase + 'Error';
        var errorSpan = document.getElementById(errorSpanId);

        if (errorSpan) {
            errorSpan.textContent = '';
        }
    } else if (inputElement.id.endsWith('cbxTerminos')) {
        var terminosErrorSpan = document.getElementById('terminosError');
        if (terminosErrorSpan) {
            terminosErrorSpan.textContent = '';
        }
    }

    inputElement.classList.remove('is-invalid');
    inputElement.classList.remove('is-valid');

}

