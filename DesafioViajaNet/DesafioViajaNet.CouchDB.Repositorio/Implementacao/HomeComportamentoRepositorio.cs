using Couchbase.Core;
using DesafioViajaNet.CouchDB.Repositorio.Interface;
using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.CouchDB.Repositorio.Implementacao
{
    public class HomeComportamentoRepositorio : AbstractComportamentoRepositorio<HomeComportamento>
    {
        public HomeComportamentoRepositorio(IBucket bucket) : base(bucket) { }
    }
}
