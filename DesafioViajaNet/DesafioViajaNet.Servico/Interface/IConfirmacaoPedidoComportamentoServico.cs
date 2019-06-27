using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Interface
{
    public interface IConfirmacaoPedidoComportamentoServico
    {
        ConfirmacaoPedidoComportamento Inserir(ConfirmacaoPedidoComportamento confirmacaoPedidoComportamento);
    }
}
