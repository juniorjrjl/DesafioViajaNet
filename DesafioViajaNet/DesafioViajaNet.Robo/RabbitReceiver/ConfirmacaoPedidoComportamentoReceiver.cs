using DesafioViajaNet.DTO;
using DesafioViajaNet.RabbitManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Robo.RabbitReceiver
{
    public class ConfirmacaoPedidoComportamentoReceiver : Receiver<ConfirmacaoPedidoComportamentoDTO>
    {
        public ConfirmacaoPedidoComportamentoReceiver(string hostName) : base(hostName) { }
    }
}
