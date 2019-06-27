using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class AbstractComportamento
    {
        public long Codigo { get; set; }
        public string IP { get; set; }
        public string NomePagina { get; set; }
        public string Browser { get; set; }
    }
}
