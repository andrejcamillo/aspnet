$(document).ready(function () {

    $("#btnbuscarcep").click(function () {
        cep = $("#Endend_Codigo").val();
        $.getJSON("http://apps.widenet.com.br/busca-cep/api/cep/" + cep+".json", function (dados) {
            $("#Telefone").val(cep.adress);
        });
    })



})