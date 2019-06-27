using Couchbase.Core;
using DesafioViajaNet.CouchDB.Repositorio.Interface;
using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.CouchDB.Repositorio.Implementacao
{
    public class CheckoutPedidoComportamentoRepositorio : AbstractComportamentoRepositorio<CheckoutPedidoComportamento>
    {
        public CheckoutPedidoComportamentoRepositorio(IBucket bucket) : base(bucket) { }
    }
}
