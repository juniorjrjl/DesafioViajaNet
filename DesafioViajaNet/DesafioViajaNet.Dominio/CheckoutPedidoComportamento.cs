using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class CheckoutPedidoComportamento : AbstractComportamento
    {
        public string Email { get; set; }
        public long CodigoVoo { get; set; }
        public Voo Voo { get; set; }
    }
}
