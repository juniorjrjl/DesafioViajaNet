using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class CheckoutPedidoComportamentoRepositorio : AbstractCheckoutPedidoComportamentoRepositorio
    {
        public CheckoutPedidoComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}
