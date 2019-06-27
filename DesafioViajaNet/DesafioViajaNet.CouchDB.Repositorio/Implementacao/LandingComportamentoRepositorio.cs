using Couchbase.Core;
using DesafioViajaNet.CouchDB.Repositorio.Interface;
using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.CouchDB.Repositorio.Implementacao
{
    public class LandingComportamentoRepositorio : AbstractComportamentoRepositorio<LandingComportamento>
    {
        public LandingComportamentoRepositorio(IBucket bucket) : base(bucket) { }
    }
}
