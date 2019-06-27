using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioViajaNet.RabbitManager
{
    public abstract class AbstractComportamento
    {
        public string IP { get; set; }
        public string NomePagina { get; set; }
        public string Browser { get; set; }
    }
}
