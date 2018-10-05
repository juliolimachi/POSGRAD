var controler = siteRoot + "Account/";
$(document).ready(function () {
    /* POPUP CERRAR;*/
    $('#btnOkCerrarSesion').click(function () {
        $.ajax({
            type: "POST",
            url: siteRoot + "home/CerrarSesion",
            cache: false,
            dataType: 'json',
            success: function (evt) {
                location.href = siteRoot;
            },
            error: function (req, status, error) {
                alert("Ha ocurrido un error.");
            }
        });
    });

    $("div#logout").click(function (evt) {
        loadURL("/home/Close/", $("#RenderManModal"));
        var titulo = "Cerrar Sesión";
        $("#ManModal-title").html("<i class=\"fa fa-pencil-square-o fa-fw\"></i> " + titulo);
    });
    /* END POPUP CERRAR ;*/
    //$('#login-form').submit(function () {
    //    return false;
    //});
    $('#login-form #user_email,#login-form #user_password').keydown(function (e) {
        if (e.keyCode == 13) {
            if ($("#login-form").valid()) {
                Autenticar();
            } else {
                return false;
            }

        }
    });
    $('#login-form #user_email,#login-form #user_password').keydown(function (e) {
        if (e.keyCode == 13) {
            if ($("#login-form").valid()) {
                Autenticar();
            } else {
                return false;
            }

        }
    });
    $("#btnEntrarSession").click(function (evt) {
        Autenticar();
    });

});


function Autenticar() {
    if ($("#login-form").valid()) {
        $('#load').modal('show');
        $.ajax({
            type: "POST",
            url: controler + "Login",
            dataType: 'json',
            data: {
                usuario: $('#user_email').val(), password: $('#user_password').val()
            },
            success: function (resultado) {
                $('#accionResultado').removeClass("action-alert");
                $("#accionResultado").html("");
                if (resultado == 1) {
                    location.href = siteRoot;
                }
                if (resultado == 2) {
                    $('#accionResultado').addClass("action-alert");
                    $('#accionResultado').html("El usuario ingresado no existe.");
                    $('#load').modal('hide');
                }
                if (resultado == 3) {
                    $('#accionResultado').addClass("action-alert");
                    $('#accionResultado').html("El usuario o clave son incorrectos.");
                    $('#load').modal('hide');
                }
                if (resultado == -1) {
                    $('#accionResultado').addClass("action-error");
                    $('#accionResultado').html("Ha ocurrido un error.");
                    $('#load').modal('hide');
                }
                if (resultado == 5) {
                    $('#accionResultado').addClass("action-alert");
                    $('#accionResultado').html("No !! tiene permiso para acceder a este Modulo,solicite su usuario.");
                    $('#load').modal('hide');
                }
                if (resultado == 0) {
                    $('#accionResultado').addClass("action-alert");
                    $('#accionResultado').html("Ingrese su Usuario y Clave");
                    $('#load').modal('hide');
                }
            },
            error: function (req, status, error) {
                $('#accionResultado').addClass("action-error");
                $('#accionResultado').html("Ha ocurrido un error.");
            }
        });
    } else {
        return false;
    }
}