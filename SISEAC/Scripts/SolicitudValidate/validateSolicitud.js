function validarSolicitudAfiliacion()
{

    $("#frmSolicitud").validate({
        rules: {
            sNombre: {
                required: true,
                maxlength: 100,
                minlength: 2
            },
            sApellido1: {
                required: true,
                maxlength: 100,
                minlength: 2
            },
            sApellido2: {
                required: false,
                maxlength: 100,
                minlength: 2
            },
            nINSS: {
                required: true,
                maxlength: 100,
                minlength: 2,
                number: true
            },
            sCedula: {
                required: true,
                maxlength: 20,
                minlength: 16
            },
            sDomicilio: {
                required: false,
                maxlength: 199,
                minlength: 1
            },
            sTelefonoDomiciliar: {
                required: false,
                maxlength: 20,
                minlength: 1
            },
            sTelefonoMovil1: {
                required: true,
                maxlength: 20,
                minlength: 1
            },
            sTelefonoMovil2: {
                required: false,
                maxlength: 20,
                minlength: 1
            },
            sTelefonoUNI: {
                required: false,
                maxlength: 11,
                minlength: 1
            },
            sTelefonoExt: {
                required: false,
                maxlength: 5,
                minlength: 3,
                number: true
            },
            sCorreo1: {
                required: true,
                maxlength: 100,
                minlength: 3,
                email: true
            },
            sCorreo2: {
                required: false,
                maxlength: 100,
                minlength: 3,
                email: true
            },
            sSitioWeb: {
                required: false,
                maxlength: 100,
                minlength: 3,
                url: true
            },
            nNoEmpleado: {
                required: true,
                maxlength: 20,
                minlength: 3,
                number: true
            },
            nAnioIngreso: {
                required: true,
                maxlength: 5,
                minlength: 4,
                number: true
            },
            nNoActa: {
                required: true,
                maxlength: 20,
                minlength: 1,
                number: true
            }
        },
        messages: {
            //required: "El nombre es requerido",
            //minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
            //maxlength: "El nombre no debe sobrepasar los 99 caracteres."
            sNombre: {
                required: "El nombre es requerido",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "El nombre no debe sobrepasar los {0} caracteres."
            },
            sApellido1: {
                required: "El primer apellido es requerido",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            sApellido2: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            nINSS: {
                required: "El número INSS es requerido",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                number: "Este campo solo contiene números."
            },
            sCedula: {
                required: "El número de cédula es requerida",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            sDomicilio: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            sTelefonoDomiciliar: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            sTelefonoMovil1: {
                required: "Se requiere al menos un teléfono",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            sTelefonoMovil2: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            sTelefonoUNI: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres."
            },
            sTelefonoExt: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                number: "Este campo solo contiene números."
            },
            sCorreo1: {
                required: "Se requiere al menos un correo electrónico",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                email: "Debe ingresar un correo electrónico válido"
            },
            sCorreo2: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                email: "Debe ingresar un correo electrónico válido"
            },
            sSitioWeb: {
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                url: "Debe ingresar un URL válido"
            },
            nNoEmpleado: {
                required: "El número de empleado es requerido",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                number: "Este campo solo contiene números."
            },
            nAnioIngreso: {
                required: "El año de ingreso es requerido",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                number: "Este campo solo contiene números."
            },
            nNoActa: {
                required: "El número de acta es requerido",
                minlength: jQuery.validator.format("Debe contener al menos {0} caracteres"),
                maxlength: "No debe sobrepasar los {0} caracteres.",
                number: "Este campo solo contiene números."
            }
        }
    });
}