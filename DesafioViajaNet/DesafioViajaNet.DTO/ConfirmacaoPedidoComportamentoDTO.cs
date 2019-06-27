using DesafioViajaNet.RabbitManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.DTO
{
    public class ConfirmacaoPedidoComportamentoDTO : AbstractComportamento
    {
        public string Email { get; set; }
        public long CodigoVoo { get; set; }
        public bool Confirmou { get; set; }
    }
}
