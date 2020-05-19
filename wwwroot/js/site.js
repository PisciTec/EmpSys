// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code


$(document).ready(function () {
    var dados = []
    $("#table_chart> tbody tr").each(function (i, e) {
        var info = []
        if (i != 0) {
            console.log(i);
            console.log($(e).attr('data-area'));
            console.log($(e).attr('data-count'));
            info.push($(e).attr('data-area'), parseInt($(e).attr('data-count')));
            dados.push(info);
        }
        
    });
    console.log(dados);

    var chart = c3.generate({
        bindto: '#chart',
        data: {
            columns: dados,
            type: "donut",
            onclick: function (d, i) { console.log("onclick", d, i); },
            onmouseover: function (d, i) { console.log("onmouseover", d, i); },
            onmouseout: function (d, i) { console.log("onmouseout", d, i); }
        },
        donut: {
            title: "Funcionário x Área"
        }
    });
});

