var articulo = document.getElementById('Articulo');
var digito = document.getElementById('Digito');
var etiqueta = document.getElementById('Etiqueta');
var usuarioInv = document.getElementById('UsuarioInventario');
var documento = document.getElementById('Documento');

$(document).ready()
{
    $('#articuloTr').hide();

    cleanValues();

    if (usuarioInv != null) {
        if (usuarioInv.value != '') {
            digito.focus();
        } else {
            usuarioInv.focus();
        }
    }

    $('#btnGrabar').click(function () {
        if (isFieldValidate()) {
            grabar();
        }
    });

    $('#Observaciones').keydown(function (e) {
        if (e.keyCode == 13) {
            if (isFieldValidate())
                grabar();
        }
    });

    $('#btnSalir').click(function () {
        salirPocketBotton();
    });
}

function nextTextbox(e, x) {
    var INCREMENTO = 1;
    var DIGITOVACIO = ".";
    var DIGITO = 3;
    var CAJASUELTA = 5;
    var CODE = 13;
    var POSICION = 2;

    var digitoInv = 0;
    var etiquetaInv = 0;

    var tipoInventario = $('#tipoInventario').html();
    var articulo = document.getElementById('articuloTr');

    var atriculoShow = false;

    if (e.keyCode == CODE) {
        textboxes = $('input');
        currentBoxNumber = textboxes.index(x);

        if (digito != null && digito.value.length >= 1) {
            digitoInv = digito.value.substring(digito.value.length - POSICION, digito.value.length);
        }

        if (etiqueta != null && etiqueta.value.length >= 1) {
            etiquetaInv = etiqueta.value.substring(etiqueta.value.length - POSICION, etiqueta.value.length);
        }

        if (digito.value != DIGITOVACIO && etiqueta.value == '') {
            atriculoShow = false;
        }
        else if (digitoInv != etiquetaInv) {
            atriculoShow = false;
        }
        else {
            if (digitoInv == etiquetaInv && articulo != null) {
                atriculoShow = false;
            }
            else if (articulo != null) {
                atriculoShow = true;
            }
        }
        
        if (digito.value == DIGITOVACIO && currentBoxNumber == DIGITO) {
            INCREMENTO++;
        }

        if (textboxes[currentBoxNumber + INCREMENTO] != null) {
            if ((currentBoxNumber + INCREMENTO) == 4 && atriculoShow) {
                nextBox = textboxes[currentBoxNumber + 2];
            }
            else {
                if (tipoInventario != 'Camadas' && currentBoxNumber == CAJASUELTA) {
                    INCREMENTO++;
                }

                nextBox = textboxes[currentBoxNumber + INCREMENTO];
            }

            nextBox.focus();
            nextBox.select();
        }
    }
}

function validarDigito(e, x) {
    if (e.keyCode == 13) {
        var POSICION = 2;
        var DIGITOVACIO = '.';
        var digitoInv = 0;
        var etiquetaInv = 0;

        if (digito != null && digito.value.length >= 1) {
            digitoInv = digito.value.substring(digito.value.length - POSICION, digito.value.length);
        }

        if (etiqueta != null && etiqueta.value.length >= 1) {
            etiquetaInv = etiqueta.value.substring(etiqueta.value.length - POSICION, etiqueta.value.length);
        }

        if ((digito.value != DIGITOVACIO && etiqueta.value == '')) {
            $('#articuloTr').show();
        }
        else if (digitoInv != etiquetaInv && digito.value != DIGITOVACIO) {
            $('#articuloTr').show();
            document.getElementById('Articulo').value = '';
        }
        else {
            if (digitoInv == etiquetaInv && $('#articuloTr') != null) {
                $('#articuloTr').show();
                document.getElementById('Articulo').value = articulo.value;
            }
            else if ($('#articuloTr') != null) {
                $('#articuloTr').hide();
            }
        }

        nextTextbox(e, x);
    }

    return true;
}

function grabar() {
    var conteo = {
        Id: $('#Id').val(),
        Documento: $('#Documento').val(),
        UsuarioInventario: $('#UsuarioInventario').val(),
        Ubicacion: $('#Ubicacion').val(),
        Articulo: $('#Articulo').val(),
        Observaciones: $('#Observaciones').val(),
        Etiqueta: $('#Etiqueta').val(),
        Digito: $('#Digito').val(),
        Leido: $('#Leido').val(),
        iCxHActual: $('#iCxHActual').val(),
        Indice: $('#Indice').val(),
        CajasSueltas: $('#CajasSueltas').val(),
        Camadas: $('#Camadas').val(),
        TipoInventario: $('#tipoInventario').html(),
        RegistroCargado: $('#RegistroCargado').val(),
        RegistroTotal: $('#RegistroTotal').val(),
        idDocumento: $('#idDocumento').val()
    };

    $.ajax({
        type: 'post',
        url: ContextPath + 'ConteoSega/Grabar',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        data: conteo,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        success: function (result) {
            cleanValues();

            var url = ContextPath + 'ConteoSega/Inventario';
            window.location.href = url;
        },
        statusCode: {
            500: function (err) {
                alert(err.statusText);
            }
        }
    });
}

function cleanValues() {
    var digitoInv = 0;
    var etiquetaInv = 0;

    var DIGITOVACIO = '.';
    var POSICION = 2;

    $('#articuloTr').hide();
    $('#Msg').html('');

    if (digito != null && digito.value.length >= 1) {
        digitoInv = digito.value.substring(digito.value.length - POSICION, digito.value.length);
    }
    if (etiqueta != null && etiqueta.value.length >= 1) {
        etiquetaInv = etiqueta.value.substring(etiqueta.value.length - POSICION, etiqueta.value.length);
    }
    if (documento == '') {
        dcumento.value = '';
    }
    if (digito != null) {
        digito.value = '';
    }
    if (document.getElementById('Camadas') != null) {
        document.getElementById('Camadas').value = '';
    }
    if (document.getElementById('CajasSueltas') != null) {
        document.getElementById('CajasSueltas').value = '';
    }
    if (document.getElementById('Observaciones') != null) {
        document.getElementById('Observaciones').value = '';
    }
    if (articulo != null && digito.value != DIGITOVACIO && etiqueta.value == '') {
        document.getElementById('Articulo').value = '';
    }
}

function isFieldValidate() {
    var validate = true;

    var digito = $('#Digito').val();
    var tipoInv = $('#tipoInventario').html();
    var cajaBulto = $('#Camadas').val();
    var cajaSueltas = $('#CajasSueltas').val();
    var articulodesc = $('#Articulo').val();

    if (digito == ''){
        validate = false;
        $('#Msg').html('Ingrese Digito');
    }
    else if (digito != '.'){
        if (cajaBulto == '') {
            validate = false;
            $('#Msg').html('Ingrese ' + tipoInv.toString());
        }
        if (articulodesc == '') {
            validate = false;
            $('#Msg').html('Ingrese Articulo');
        }
        if (tipoInv == 'Camadas') {
            if (cajaSueltas == '') {
                validate = false;
                $('#Msg').html('Ingrese Cajas Sueltas');
            }
        }       
    }
    return validate;
}

function salirPocketBotton() {
    var option = 'Salir'

    if (confirmPopUp(option)) {
        var url = getURL();
        window.location.href = url;
    }
}

function confirmPopUp(option) {
    var r = confirm('¿Desea ' + option + '?');

    return r;
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