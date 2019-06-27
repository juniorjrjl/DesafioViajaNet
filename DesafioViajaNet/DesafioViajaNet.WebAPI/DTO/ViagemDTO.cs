using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioViajaNet.WebAPI.DTO
{
    public class ViagemDTO
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DateEmbarque { get; set; }
        public DateTime DataDesembarque { get; set; }
    }
}
