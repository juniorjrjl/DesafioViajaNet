using DesafioViajaNet.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.Entity.Repositorio.Abstract
{
    public abstract class AbstractConfirmacaoPedidoComportamentoRepositorio : RepositorioGenerico<ConfirmacaoPedidoComportamento, long>
    {
        public AbstractConfirmacaoPedidoComportamentoRepositorio(DesafioViajaNetDbContext contexto) : base(contexto) { }
    }
}
