using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.RepositorioGenerico
{
    public interface IRepositorioComposto<TEntidade>
        where TEntidade : class
    {
        List<TEntidade> Selecionar();
        TEntidade Inserir(TEntidade entidade);
        TEntidade Alterar(TEntidade entidade);
        void Excluir(TEntidade entidade);
        void AplicarAlteracoes();
    }
}
