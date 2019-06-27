using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public class AbstractCheckoutPedidoComportamentoRepositorio : RepositorioGenerico<CheckoutPedidoComportamento, long>
    {
        public AbstractCheckoutPedidoComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}
