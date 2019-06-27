using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class UsuarioVoo
    {
        public long CodigoUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public long CodigoVoo { get; set; }
        public Voo Voo { get; set; }
        public decimal Preco { get; set; }
    }
}
