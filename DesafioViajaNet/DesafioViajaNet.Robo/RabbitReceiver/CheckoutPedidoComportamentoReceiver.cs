using DesafioViajaNet.DTO;
using DesafioViajaNet.RabbitManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Robo.RabbitReceiver
{
    public class CheckoutPedidoComportamentoReceiver : Receiver<CheckoutPedidoComportamentoDTO>
    {
        public CheckoutPedidoComportamentoReceiver(string hostName) : base(hostName) { }
    }
}
