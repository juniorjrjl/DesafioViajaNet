
$(document).ready(function(){
    esconderMensagemErro();
    buscarEstados();
    validarForm();
    $('#txtDataViagem').val(moment(new Date()).format('YYYY-MM-DD'));
    definirEventoValidacao("#txtNome", "#txtEmail", "#txtDataViagem", "#txtDias", "#cbmEstadoOrigem", "#cbmCidadeOrigem", "#cbmEstadoDestino", "#cbmCidadeDestino");
    exibirErroCampo("#txtNome", "#txtEmail", "#txtDataViagem", "#txtDias", "#cbmEstadoOrigem", "#cbmCidadeOrigem", "#cbmEstadoDestino", "#cbmCidadeDestino");
    $("#btnEnviar").on("click", solicitarViagem);
    $("#cbmEstadoOrigem").change(buscarCidadesOrigem);
    $("#cbmEstadoDestino").change(buscarCidadesDestino);
});

let esconderMensagemErro = () => ["#dvNomeValidacao", "#dvEmailValidacao", "#dvDataViagemValidacao", "#dvDiasValidacao", "#dvCidadeOrigemValidacao", "#dvEstadoOrigemValidacao", "#dvCidadeDestinoValidacao", "#dvEstadoDestinoValidacao"].forEach((id) => $(id).hide());
let exibirErroCampo = (...seletores) => seletores.forEach(s => $(s).focusout(exibirMensagemErro));
let definirEventoValidacao = (...seletores) => seletores.forEach(s => $(s).change(validarForm));

let validarForm = (() => $("#btnEnviar").prop("disabled", nomeInvalido() || emailInvalido() || dataViagemInvalida() || diasViagemInvalido() || cidadeOrigemInvalida() || cidadeDestinoInvalida() || estadoOrigemInvalido() || estadoDestinoInvalido()));

let nomeInvalido = (() => $("#txtNome").val().trim() === "");

let emailInvalido = (() => !(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($("#txtEmail").val())));

let dataViagemInvalida = (() => (!moment($("#txtDataViagem").val()).isValid()) || moment($("#txtDataViagem").val()).isBefore(new Date(), 'day'));

let diasViagemInvalido = (() => parseInt($("#txtDias").val()) <= 0);

let cidadeOrigemInvalida = (() => parseInt($("#cbmCidadeOrigem").val()) === -1);

let cidadeDestinoInvalida = (() => parseInt($("#cbmCidadeDestino").val()) === -1);

let estadoOrigemInvalido = (() => parseInt($("#cbmEstadoOrigem").val()) === -1);

let estadoDestinoInvalido = (() => parseInt($("#cbmEstadoDestino").val()) === -1);

let exibirMensagemErro = (e) => {
    switch(e.currentTarget.id){
        case "txtNome":
                nomeInvalido() ? $("#dvNomeValidacao").show() : $("#dvNomeValidacao").hide();
            break;
        case "txtEmail":
                emailInvalido() ? $("#dvEmailValidacao").show() : $("#dvEmailValidacao").hide();
            break;
        case "txtDataViagem":
                dataViagemInvalida() ? $("#dvDataViagemValidacao").show() : $("#dvDataViagemValidacao").hide();
            break;
        case "txtDias":
                diasViagemInvalido() ? $("#dvDiasValidacao").show() : $("#dvDiasValidacao").hide();
            break;
        case "cbmCidadeOrigem":
                cidadeOrigemInvalida() ? $("#dvCidadeOrigemValidacao").show() : $("#dvCidadeOrigemValidacao").hide();
            break;
        case "cbmCidadeDestino":
                cidadeDestinoInvalida() ? $("#dvCidadeDestinoValidacao").show() : $("#dvCidadeDestinoValidacao").hide();
            break;
        case "cbmEstadoOrigem":
                estadoOrigemInvalido() ? $("#dvEstadoOrigemValidacao").show() : $("#dvEstadoOrigemValidacao").hide();
            break;
        case "cbmEstadoDestino":
            estadoDestinoInvalido() ? $("#dvEstadoDestinoValidacao").show() : $("#dvEstadoDestinoValidacao").hide();
        break;
    }
}

let buscarEstados = (() => {
    $.get({
        headers: { 
            'Accept': 'application/json',
            'Content-Type': 'application/json' 
        },
        url: 'http://localhost:50857/estados',
        error: erro,
        success : popularEstados
    });
});

let popularEstados = ((estados) => estados.forEach((e) => {
    this.combo
    $("#cbmEstadoOrigem").append($("<option />").val(e.codigo).text(e.descricao))
    $("#cbmEstadoDestino").append($("<option />").val(e.codigo).text(e.descricao))
}));

let buscarCidadesOrigem = (() => {
    let codigoEstado = parseInt($("#cbmEstadoOrigem").val());
    $("#cbmCidadeOrigem").empty();
    $("#cbmCidadeOrigem").append($("<option />").val(-1).text("Selecione a cidade"))
    if (codigoEstado > 0){
        $.get({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: `http://localhost:50857/cidades/${codigoEstado}`,
            error: erro,
            success : popularCidadesOrigem
        });
    }
});

let popularCidadesOrigem = ((cidades) => cidades.forEach((c) => $("#cbmCidadeOrigem").append($("<option />").val(c.codigo).text(c.descricao))));

let buscarCidadesDestino = (() => {
    let codigoEstado = parseInt($("#cbmEstadoDestino").val());
    $("#cbmCidadeDestino").empty();
    $("#cbmCidadeDestino").append($("<option />").val(-1).text("Selecione a cidade"))
    if (codigoEstado > 0){
        $.get({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: `http://localhost:50857/cidades/${codigoEstado}`,
            error: erro,
            success : popularCidadesDestino
        });
    }
});

let popularCidadesDestino = ((cidades) => cidades.forEach((c) => $("#cbmCidadeDestino").append($("<option />").val(c.codigo).text(c.descricao))));

let solicitarViagem = (() =>{
    $.getJSON("https://api.ipify.org/?format=json", function(e) {
        let ip = e.ip;
        let pagina = document.location.href.match(/[^\/]+$/)[0];
        let browserInfo = navigator.userAgent.split(" ");
        let browser = browserInfo[browserInfo.length - 1];
        let horaAtual = new Date()
        let json = JSON.stringify(
            {
                "IP": ip, 
                "NomePagina": pagina, 
                "Browser": browser,
                "Nome" : $("#txtNome").val(),
                "Email": $("#txtEmail").val(),
                "DataViagem": moment($("#txtDataViagem").val()).set(
                    {
                        hour: horaAtual.getHours(),
                        minute: horaAtual.getMinutes(),
                        second: horaAtual.getSeconds()
                    }
                    ).format('YYYY-MM-DD HH:mm:ss'),
                "DiasVagem": parseInt($("#txtDias").val()),
                "CodigoCidadeOrigem" : parseInt($("#cbmCidadeOrigem").val()),
                "CodigoCidadeDestino" : parseInt($("#cbmCidadeDestino").val())
            }
            );
        $.post({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: 'http://localhost:50857/viagens/solicitar',
            data: json,
            error: erro,
            success: exibirVoos
        });

    });
});

let erro = ((xhr, status, error) => console.log("Erro ao enviar informações: " + error));

let exibirVoos = (() => {
    localStorage.setItem("viajanet.email_usuario_atual", $("#txtEmail").val());
    localStorage.setItem("viajanet.email_data_embarque", moment($("#txtDataViagem").val()).format('YYYY-MM-DD'));
    localStorage.setItem("viajanet.email_data_desembarque", moment($("#txtDataViagem").val()).add(parseInt($("#txtDias").val()), 'days').format('YYYY-MM-DD'));
    localStorage.setItem("viajanet.email_codigo_destino", parseInt($("#cbmCidadeDestino").val()));
    window.location.href = "checkout.html";
});