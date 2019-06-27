using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class Voo
    {
        public long Codigo { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataHoraEmbarque { get; set; }
        public DateTime DataHoraDesembarque { get; set; }
        public long CodigoViagem { get; set; }
        public Viagem Viagem { get; set; }
        public IList<UsuarioVoo> UsuariosVoos { get; set; }
        public IList<CheckoutPedidoComportamento> CheckoutPedidoComportamentos { get; set; }
        public IList<ConfirmacaoPedidoComportamento> ConfirmacaoPedidoComportamentos { get; set; }
    }
}
