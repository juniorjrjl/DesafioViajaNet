$(document).ready(function(){

    buscarVoos();

});

let buscarVoos = (() => {
    let dataEmbarque = localStorage.getItem("viajanet.email_data_embarque");
    let dataDesembarque = localStorage.getItem("viajanet.email_data_desembarque");
    let codigoDestino = localStorage.getItem("viajanet.email_codigo_destino");
    $.get({
        headers: { 
            'Accept': 'application/json',
            'Content-Type': 'application/json' 
        },
        url: `http://localhost:50857/viagens/consultar?data-embarque=${dataEmbarque}&data-desembarque=${dataDesembarque}&codigo-destino=${codigoDestino}`,
        error: erro,
        success : montarLinha
    });
});

let montarLinha = ((viagens) => {
    let linha = $("<div></div>");
    linha.addClass("row");
    linha.css({'padding-bottom': '2%'});
    for (let i = 0; i < viagens.length; i++){
        linha.append(montarCard(viagens[i]));
        if (((i + 1) % 3 === 0) || (i + 1 === viagens.length)){
            $("#container").append(linha);
            linha = $("<div></div>");
            linha.addClass("row");
            linha.css({'padding-bottom': '2%'});
        }
    }
});

let montarCard = ((viagem) => {

    let colunaCard = $("<div></div>");
    colunaCard.addClass("col-3");

    let card = $("<div></div>");
    card.addClass("card");
    card.css(["width : 18rem"]);

    let corpoCard = $("<div></div>");
    corpoCard.addClass("card-body");

    let titulo = $("<h5></h5>").addClass("card-title").append(viagem.CidadeOrigem + " / " + viagem.CidadeDestino);
    corpoCard.append(titulo);

    let subTitulo = $("<h6></h6>").addClass("card-subtitle").addClass("mb-2").addClass("text-muted").append("R$" + (viagem.Preco).toLocaleString('pt-BR'));
    corpoCard.append(subTitulo);

    let texto = $("<p></p>").addClass("card-text").append("Embarque: " + moment(viagem.DataHoraEmbarque).format('DD/MM/YYYY HH:mm:ss') + " <br> Desembarque: " + moment(viagem.DataHoraDesembarque).format('DD/MM/YYYY HH:mm:ss'));
    corpoCard.append(texto);

    let idBotao = `#btnViagem${viagem.CodigoVoo}`;
    let botao = $("<button>Selecionar</button>");
    botao.attr("id",idBotao);
    botao.addClass("btn").addClass("btn-primary");
    botao.on("click", guardarViagem)
    corpoCard.append(botao);

    card.append(corpoCard);
    colunaCard.append(card);
    return colunaCard;
});

let guardarViagem = ((e) => {
    let codigoVoo = e.currentTarget.id.replace("#btnViagem", "");
    enviarComportamento(codigoVoo);
    localStorage.setItem("viajanet.codigo_viagem_selecionada", parseInt(codigoVoo));
});

let enviarComportamento = ((codigoVoo) =>{
    $.getJSON("https://api.ipify.org/?format=json", function(e) {
        let ip = e.ip;
        let pagina = document.location.href.match(/[^\/]+$/)[0];
        let browserInfo = navigator.userAgent.split(" ");
        let browser = browserInfo[browserInfo.length - 1];
        let json = JSON.stringify(
            {
                "IP": ip, 
                "NomePagina": pagina, 
                "Browser": browser,
                "Email": localStorage.getItem("viajanet.email_usuario_atual"),
                "CodigoVoo": parseInt(codigoVoo)
            });
        $.post({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: 'http://localhost:50857/viagens/consultar',
            data: json,
            error: erro,
            success: sucesso
        });

    });
});

let erro = ((xhr, status, error) => console.log("Erro ao enviar informações: " + error));
let sucesso = (() => window.location.href = "confirmacao.html");