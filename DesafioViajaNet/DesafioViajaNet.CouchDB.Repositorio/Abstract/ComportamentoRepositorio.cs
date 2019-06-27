using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;
using DesafioViajaNet.Dominio;
using DesafioViajaNet.RepositorioGenerico;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.CouchDB.Repositorio.Interface
{
    public abstract class AbstractComportamentoRepositorio<TEntidade> where TEntidade : AbstractComportamento
    {
        private readonly IBucket _bucket;

        public AbstractComportamentoRepositorio(IBucket bucket) => _bucket = bucket;

        public IDocumentResult Inserir(TEntidade entidade) =>  
            _bucket.Upsert(new Document<TEntidade>()
            {
                Content = entidade
            });

        /*public TEntidade BuscarPorIp(string ip)
        {
            QueryRequest queryRequest = new QueryRequest()
                .Statement("SELECT * FROM ")
        }

        public TEntidade BuscarPorIp(string nomePagina)
        {
            QueryRequest queryRequest = new QueryRequest()
                .Statement("SELECT * FROM ")
        }*/

    }
}
