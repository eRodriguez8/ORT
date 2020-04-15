$(document).ready(function () {
    getCookieUser();

    $('#btnSalir').click(function () {
        salirPocketBotton();
    });
});

function getCookieUser() {
    $.ajax({
        type: 'get',
        url: ContextPath + 'ConteoSega/GetCookieUser',
        contentType: 'charset=utf-8',
        dataType: 'text',
        async: false,
        success: function (result) {
            getDocumento();
        },
        statusCode: {
            500: function (err) {
                $('#MsgError').html('UPS! Algo fue mal, reinicie aplicacion.');
            }
        }
    });
}

function getDocumento() {
    $.ajax({
        type: 'get',
        url: ContextPath + 'ConteoSega/GetDocumento',
        contentType: 'charset=utf-8',
        dataType: 'text', 
        async: false,
        success: function (result) {
            var conteo = JSON.parse(result);
            if (conteo.RegistroTotal > 0) {
                if (conteo.Leido) {
                    var url = ContextPath + 'ConteoSega/ContinuarCarga';
                    window.location.href = url;
                }
                else {
                    comenzarCarga();
                    var url = ContextPath + 'ConteoSega/Inventario';
                    window.location.href = url;
                }
            }
            else {
                $('#MsgError').html(conteo.MsgError);
            }
        },
        statusCode: {
            500: function (err) {
                $('#MsgError').html('UPS! Algo fue mal, reinicie aplicacion.');
            }
        }
    });
}


function confirmPopUp(option) {
    var r = confirm('¿Desea ' + option + '?');

    return r;
}

function salirPocketBotton() {
    var option = 'Salir'

    if (confirmPopUp(option)) {
        var url = getURL();
        window.location.href = url;
    }
}

function comenzarCarga() {
    $.ajax({
        type: 'get',
        url: ContextPath + 'ConteoSega/ComenzarCarga',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (result) {
        },
        statusCode: {
            500: function (err) {
                alert(err.statusText);
            }
        }
    });
}

function getURL() {
    var url;

    $.ajax({
        type: 'get',
        url: ContextPath + 'ConteoSega/GetURL',
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            url = result;
        },
        statusCode: {
            500: function (err) {
                alert(err.statusText);
            }
        }
    });

    return url;
}