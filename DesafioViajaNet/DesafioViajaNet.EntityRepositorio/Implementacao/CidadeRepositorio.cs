using DesafioViajaNet.Dominio;
using DesafioViajaNet.DTO;
using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class CidadeRepositorio : AbstractCidadeRepositorio
    {
        public CidadeRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }

        public override IList<CidadeComboDTO> BuscarPorEstado(long idEstado) => _contexto.Set<Cidade>()
            .Where(c => c.Estado.Codigo == idEstado)
            .Select(c => new CidadeComboDTO { Codigo = c.Codigo, Descricao = c.Descricao })
            .OrderBy(c => c.Descricao).ToList();
    }
}
