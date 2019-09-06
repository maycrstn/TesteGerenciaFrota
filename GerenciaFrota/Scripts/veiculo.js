$(document).ready(function () {
    $("#IdTipoVeiculo").on("change", function () {
        alterarNumeroPassageiros();        
    });
    bloquearCampos();
});

function alterarNumeroPassageiros() {
    var tipoVeiculo = $("#IdTipoVeiculo").val();
    if (tipoVeiculo === "1") {
        $("#NumeroPassageiros").val(2);
    } else {
        $("#NumeroPassageiros").val(42);
    }
}

function bloquearCampos() {
    var veiculoId = $("#VeiculoId").val();
    if (veiculoId > 0) {
        $(".editavel").prop("disabled", "disabled");
    }
}

function buscaChassi() {
    var chassi = $("#buscaChassi").val();
    var url = $("#urlFiltrar").val();
    $.ajax({
        url: url,
        method: "POST",
        data: { chassi: chassi },
        success: function (retorno) {
            $("#tableListVeiculo").html(retorno);
            console.log(retorno);
        },
        error: function (retorno) {
            console.log(retorno);
        }
    });

}