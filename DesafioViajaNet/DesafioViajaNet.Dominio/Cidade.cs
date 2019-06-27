using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class Cidade
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public long CodigoEstado { get; set; }
        public Estado Estado { get; set; }
        public LandingComportamento LandingComportamentoDestino { get; set; }
        public LandingComportamento LandingComportamentoOrigem { get; set; }
        public IList<Viagem> Origens { get; set; }
        public IList<Viagem> Destinos { get; set; }
    }
}
