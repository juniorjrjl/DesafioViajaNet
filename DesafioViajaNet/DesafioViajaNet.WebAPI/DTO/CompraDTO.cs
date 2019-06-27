using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioViajaNet.WebAPI.DTO
{
    public class CompraDTO
    {
        public long CodigoCliente { get; set; }
        public IList<long> CodigosViagem { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
