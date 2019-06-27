using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class EstadoRepositorio : AbstractEstadoRepositorio
    {
        public EstadoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }

        public override IList<EstadoComboDTO> BuscarTodos() => _contexto.Set<Estado>()
            .Select(e => new EstadoComboDTO { Codigo = e.Codigo, Descricao = e.Descricao })
            .OrderBy(e => e.Descricao).ToList();
    }
}
