using DesafioViajaNet.RabbitManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioViajaNet.DTO
{
    public class LandingComportamentoDTO : AbstractComportamento
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataViagem { get; set; }
        public int DiasVagem { get; set; }
        public long CodigoCidadeOrigem { get; set; }
        public long CodigoCidadeDestino { get; set; }
    }
}
