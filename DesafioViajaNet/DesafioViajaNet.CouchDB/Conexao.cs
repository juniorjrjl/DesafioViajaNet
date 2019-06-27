using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.CouchDB
{
    public class Conexao
    {
        private Conexao() { }

        public static Cluster GetConexao(string servidor, string usuario, string senha)
        {
            Cluster cluster = new Cluster(new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri(servidor) }
            });
            PasswordAuthenticator authenticator = new PasswordAuthenticator(usuario, senha);
            cluster.Authenticate(authenticator);
            return cluster;
        }

    }
}
