using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Servico.Interface
{
    public interface ICheckoutPedidoComportamentoServico
    {
        CheckoutPedidoComportamento Inserir(CheckoutPedidoComportamento CheckoutPedidoComportamento);
    }
}
