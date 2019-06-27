
var erro = ((xhr, status, error) => console.log("Erro ao enviar informações: " + error));

$(window).on('load', function(e){
    $.getJSON("https://api.ipify.org/?format=json", function(e) {
        let ip = e.ip;
        let pagina = document.location.href.match(/[^\/]+$/)[0];
        let browserInfo = navigator.userAgent.split(" ");
        let browser = browserInfo[browserInfo.length - 1];
        let json = JSON.stringify(
            {
                "IP": ip, 
                "NomePagina": pagina, 
                "Browser": browser
            }
            );
        $.post({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: 'http://localhost:50857/acessos',
            data: json,
            error: erro
        });

    });
});
