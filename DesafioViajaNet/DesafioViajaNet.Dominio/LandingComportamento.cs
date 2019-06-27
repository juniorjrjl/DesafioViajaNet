using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class LandingComportamento : AbstractComportamento
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataViagem { get; set; }
        public int DiasVagem { get; set; }
        public long CodigoOrigem { get; set; }
        public Cidade Origem { get; set; }
        public long CodigoDestino { get; set; }
        public Cidade Destino { get; set; }
    }
}
