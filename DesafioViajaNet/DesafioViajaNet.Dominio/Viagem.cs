using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class Viagem
    {
        public long Codigo { get; set; }
        public long CodigoOrigem { get; set; }
        public Cidade Origem { get; set; }
        public long CodigoDestino { get; set; }
        public Cidade Destino { get; set; }
        public IList<Voo> Voos { get; set; }
    }
}
