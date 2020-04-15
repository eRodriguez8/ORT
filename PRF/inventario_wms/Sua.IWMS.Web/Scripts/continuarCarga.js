$(document).ready(function () {
    $('#btnSi').click(function () {
        //Inventario
        logearOpcion("Continua Carga")
        var url = ContextPath + 'ConteoSega/Inventario';
        window.location.href = url;
    });

    $('#btnNo').click(function () {
        //Comenzar Carga
        comenzarCarga();
        logearOpcion("Reinicia Carga");
        var url = ContextPath + 'ConteoSega/Inventario';
        window.location.href = url;
    });
});

function comenzarCarga() {
    $.ajax({
        type: 'get',
        url: ContextPath + 'ConteoSega/ComenzarCarga/',
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
function logearOpcion(opcionText) {
    var datos = "{ 'opcion':'" + opcionText + "'}";
    $.ajax({
        type: 'post',
        url: ContextPath + 'ConteoSega/Loggear',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: datos,
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
