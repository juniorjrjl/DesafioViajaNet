using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Dominio
{
    public class Usuario
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IList<UsuarioVoo> UsuariosVoos { get; set; }
    }
}
