using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioViajaNet.RepositorioGenerico
{
    public interface IRepositorio<TEntidade, TChave>
        where TEntidade : class
    {
        List<TEntidade> Selecionar();
        TEntidade Selecionar(TChave id);
        TEntidade Inserir(TEntidade entidade);
        TEntidade Alterar(TEntidade entidade);
        void Excluir(TEntidade entidade);
        void Excluir(TChave id);
        void AplicarAlteracoes();
    }
}
