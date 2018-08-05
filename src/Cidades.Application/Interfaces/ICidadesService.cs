using Cidades.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.Application.Interfaces
{
    public interface ICidadesService
    {
        IEnumerable<CidadeViewModel> ListarCapitais();
        ResultadoPesquisaCidadesViewModel PesquisarCidades(int? ibge, string nome, string uf, string microRegiao, string mesorregiao);
        ResultadoPesquisaEstadoComMaiorEMenorQuantidadeDeCidadesViewModel ListarEstadosComMaiorEMenorQtdeDeCidades();
        void RemoverCidade(int idIBGE);
    }
}
