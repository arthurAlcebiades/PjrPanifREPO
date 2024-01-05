function SalvarPedido() {

    var data = $("#Data").val();

    var cliente = $("#IdCliente").val();

    var rota = $("#IdRota").val();

    var dataInicioRecorrencia = $("#DataInicioRecorrencia").val();

    var dataFinalRecorrencia = $("#DataFinalRecorrencia").val();

    var token = $('input[name="_RequestVerificationToken"]').val();
    var tokenadr = $('form[action="Pedido/Create"] input[name="_RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};

    headers['_RequestVerificationToken'] = token;
    headersadr['_RequestVerificationToken'] = tokenadr;

    var url = "/Pedido/Create";

    $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        headers: headersadr,
        data: { Data: data, IdCliente: cliente, IdRota: rota, DataInicioRecorrencia: dataInicioRecorrencia, DataFinalRecorrencia: dataFinalRecorrencia, _RequestVerificationToken: token },
        success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(data.Resultado);
            }
        }
    })
}

function ListarPedidos() {
    var url = "/ItemPedido/ListarItens";

    $.ajax({
        url: url,
        type: "GET",
        data: { id: IdPedido },
        datatype: "html",
        success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    })
}

function SalvarItens() {
    var idPedido = $("#IdPedido").val();
    var idProduto = $("#IdProduto").val();
    var quantidade = $("#Quantidade").val();
    var valorUnitario = $("#ValorUnitario").val();
    var valorTotal = $("#ValorTotal").val();
    var valorDesconto = $("#ValorDesconto").val();

    var url = "/ItemPedido/SalvarItens";

    $.ajax({
        url: url,
        data: { idPedido: idPedido, idProduto: idProduto, quantidade: quantidade, valorUnitario: valorUnitario, valorTotal: valorTotal, valorDesconto: valorDesconto },
        type: "GET",
        datatype: "html",
        success: function (data) {
            if (data > 0) {
                ListarPedidos(idPedido);
            }
        }
    })
}