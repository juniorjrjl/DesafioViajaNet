using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.DTO
{
    public class ViagemVooDTO
    {
        public long CodigoVoo { get; set; }
        public string CidadeOrigem { get; set; }
        public string CidadeDestino { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataHoraEmbarque { get; set; }
        public DateTime DataHoraDesembarque { get; set; }
    }
}
