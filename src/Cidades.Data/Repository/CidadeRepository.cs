using Cidades.Data.Context;
using Cidades.Domain.Entidades;
using Cidades.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cidades.Data.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly ApiContext apiContext;

        public CidadeRepository(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        public void Excluir(int idIbge)
        {
            var cidade = apiContext.Cidades.FirstOrDefault<Cidade>(c => c.ibge_id == idIbge);

            if (cidade != null)
            {
                apiContext.Cidades.Remove(cidade);
                apiContext.SaveChanges();
            }
        }

        public IEnumerable<Cidade> ListarCapitais()
        {
            return apiContext.Cidades.Where<Cidade>(c => c.capital);
        }

        public IEnumerable<Cidade> PesquisarCidades(int idIbge, string uf, string nomeCidade, string microRegiao, string mesorregiao)
        {
            var result = apiContext.Cidades.AsEnumerable<Cidade>();

            if (idIbge > 0)
                result = result.Where<Cidade>(c => c.ibge_id == idIbge);

            if (!string.IsNullOrEmpty(uf))
                result = result.Where<Cidade>(c => c.uf == uf);

            if (!string.IsNullOrEmpty(nomeCidade))
                result = result.Where<Cidade>(c =>
                    c.name.Contains(nomeCidade)
                    || c.alternative_names.Contains(nomeCidade)
                    || c.no_accents.Contains(nomeCidade));

            if (!string.IsNullOrEmpty(microRegiao))
                result = result.Where<Cidade>(c => c.microregion.Contains(microRegiao));

            if (!string.IsNullOrEmpty(mesorregiao))
                result = result.Where<Cidade>(c => c.mesoregion.Contains(mesorregiao));

            return result;
        }
        
        public IEnumerable<Estado> ListarEstados()
        {
            return apiContext.Cidades.GroupBy(c => c.uf)
                .Select(group => new Estado() { Uf = group.Key, QtdeCidades = group.Count() });
        }
    }
}
