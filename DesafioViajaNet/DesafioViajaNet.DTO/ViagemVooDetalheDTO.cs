using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.DTO
{
    public class ViagemVooDetalheDTO
    {
        public long CodigoVoo { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataHoraEmbarque { get; set; }
        public DateTime DataHoraDesembarque { get; set; }
        public LocalViagemDTO Origem { get; set; }
        public LocalViagemDTO Destino { get; set; }
    }
}
