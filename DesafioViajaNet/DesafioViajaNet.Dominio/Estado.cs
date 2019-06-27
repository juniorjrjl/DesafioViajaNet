using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class Estado
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public IList<Cidade> Cidades { get; set; }
    }
}
