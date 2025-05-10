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
function validateDniLength(dniInput) {
    var dni = dniInput.value.trim();
    var dniErrorSpan = document.getElementById('<%= lblMensajeDni.ClientID %>');

    if (dni.length < 7) {
        dniErrorSpan.textContent = 'El DNI debe tener al menos 7 números.';
        dniInput.classList.add('is-invalid');
        return false;
    } else {
        dniErrorSpan.textContent = '';
        dniInput.classList.remove('is-invalid');
        return true;
    }
}
