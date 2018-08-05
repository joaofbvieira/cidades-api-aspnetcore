using Cidades.Application.Interfaces;
using Cidades.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cidades.Application.Mappers;

namespace Cidades.Application
{
    public class CidadesService : ICidadesService
    {
        private readonly Domain.IRepository.ICidadeRepository cidadeRepository;

        public CidadesService(Domain.IRepository.ICidadeRepository cidadeRepository)
        {
            this.cidadeRepository = cidadeRepository;
        }
        
        public IEnumerable<CidadeViewModel> ListarCapitais()
        {
            return cidadeRepository.ListarCapitais()
                .Select(c => DomainToViewModelMapper.CidadeToCidadeViewModel(c));
        }

        public ResultadoPesquisaCidadesViewModel PesquisarCidades(
            int? ibge, string nome, string uf, string microRegiao, string mesorregiao)
        {
            var resultadoPesquisa = cidadeRepository.PesquisarCidades(ibge??0, uf, nome, microRegiao, mesorregiao);

            var result = new ResultadoPesquisaCidadesViewModel();
            result.Cidades = resultadoPesquisa.Select(c => DomainToViewModelMapper.CidadeToCidadeViewModel(c));
            result.QuantidadeCidades = result.Cidades.Count();

            return result;
        }

        public ResultadoPesquisaEstadoComMaiorEMenorQuantidadeDeCidadesViewModel ListarEstadosComMaiorEMenorQtdeDeCidades()
        {
            var estados = cidadeRepository.ListarEstados();

            var ufComMaisCidades = estados.OrderByDescending(e => e.QtdeCidades).FirstOrDefault();
            var ufComMenosCidades = estados.OrderByDescending(e => e.QtdeCidades).LastOrDefault();

            var result = new ResultadoPesquisaEstadoComMaiorEMenorQuantidadeDeCidadesViewModel();
            result.UfComMaiorNumeroDeCidades = DomainToViewModelMapper.EstadoToEstadoViewModel(ufComMaisCidades);
            result.UfComMenorNumeroDeCidades = DomainToViewModelMapper.EstadoToEstadoViewModel(ufComMenosCidades);

            return result;
        }
        
        public void RemoverCidade(int idIBGE)
        {
            cidadeRepository.Excluir(idIBGE);
        }
    }
}
