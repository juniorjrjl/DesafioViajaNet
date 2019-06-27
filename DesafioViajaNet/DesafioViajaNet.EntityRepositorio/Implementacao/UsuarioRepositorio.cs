using DesafioViajaNet.Dominio;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class UsuarioRepositorio : AbstractUsuarioRepositorio
    {
        public UsuarioRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }

        public override long BuscarCodigoPeloEmail(string email) => _contexto.Set<Usuario>().Where(u => u.Email.Equals(email)).Select(u => u.Codigo).First();
    }
}
