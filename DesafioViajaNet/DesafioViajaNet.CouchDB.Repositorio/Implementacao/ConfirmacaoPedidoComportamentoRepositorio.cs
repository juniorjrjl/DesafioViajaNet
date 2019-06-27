using Couchbase.Core;
using DesafioViajaNet.CouchDB.Repositorio.Interface;
using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.CouchDB.Repositorio.Implementacao
{
    public class ConfirmacaoPedidoComportamentoRepositorio : AbstractComportamentoRepositorio<ConfirmacaoPedidoComportamento>
    {
        public ConfirmacaoPedidoComportamentoRepositorio(IBucket bucket) : base(bucket) { }
    }
}
