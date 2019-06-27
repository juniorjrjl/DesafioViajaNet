$(document).ready(function(){

    buscarVooSelecionado()
    $("#btnConfirmar").on("click", enviarComportamentoConfirmacao);
    $("#btnCancelar").on("click", enviarComportamentoConfirmacao);
});

let buscarVooSelecionado = (() => {
    let codigoVoo = localStorage.getItem("viajanet.codigo_viagem_selecionada");
    $.get({
        headers: { 
            'Accept': 'application/json',
            'Content-Type': 'application/json' 
        },
        url: `http://localhost:50857/viagens/confirmar/${codigoVoo}`,
        error: erro,
        success : exibirDetalhes
    });
});

let erro = ((xhr, status, error) => console.log("Erro ao enviar informações: " + error));

let exibirDetalhes = ((viagem) => {
    $("#txtRota").text(viagem.Origem.Estado + " / " + viagem.Origem.Cidade + " - " + viagem.Destino.Estado + " / " + viagem.Destino.Cidade);
    $("#txtEmbarque").text("Embarque: " + moment(viagem.DataHoraEmbarque).format('DD/MM/YYYY HH:mm:ss'));
    $("#txtDesembarque").text("Desembarque: " + moment(viagem.DataHoraDesembarque).format('DD/MM/YYYY HH:mm:ss'));
    $("#txtPreco").text("Preço: R$" + (viagem.Preco).toLocaleString('pt-BR'));
});

let enviarComportamentoConfirmacao = (() => console.log("bora terminar esssa zica preguiçoso"))