$(document).ready(function () {
    var url = getURL();

    window.location.href = url;
});

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