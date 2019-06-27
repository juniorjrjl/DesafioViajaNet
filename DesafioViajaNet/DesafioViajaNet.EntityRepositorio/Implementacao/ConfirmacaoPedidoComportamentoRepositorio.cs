using DesafioViajaNet.Entity.Repositorio.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Implementacao
{
    public class ConfirmacaoPedidoComportamentoRepositorio : AbstractConfirmacaoPedidoComportamentoRepositorio
    {
        public ConfirmacaoPedidoComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}
