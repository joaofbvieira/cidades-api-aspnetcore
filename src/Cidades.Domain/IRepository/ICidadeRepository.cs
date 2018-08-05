using Cidades.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.Domain.IRepository
{
    public interface ICidadeRepository
    {
        IEnumerable<Cidade> ListarCapitais();
        IEnumerable<Cidade> PesquisarCidades(int idIbge, string uf, string nomeCidade, string microRegiao, string mesorregiao);
        IEnumerable<Estado> ListarEstados();
        void Excluir(int idIbge);
    }
}
