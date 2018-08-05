using Cidades.Domain.Entidades;
using Cidades.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.Application.Mappers
{
    public class DomainToViewModelMapper
    {
        public static CidadeViewModel CidadeToCidadeViewModel(Cidade cidade)
        {
            return new CidadeViewModel()
            {
                Ibge = cidade.ibge_id,
                Capital = cidade.capital,
                Latitude = cidade.lat,
                Longitude = cidade.lon,
                Nome = cidade.name,
                Uf = cidade.uf,
                MicroRegiao = cidade.microregion,
                Mesorregiao = cidade.mesoregion,
                NomeAlternativo = cidade.alternative_names,
                NomeSemAcentuacao = cidade.no_accents
            };
        }

        public static EstadoViewModel EstadoToEstadoViewModel(Estado estado)
        {
            return new EstadoViewModel()
            {
                UF = estado.Uf,
                QuantidadeDeCidades = estado.QtdeCidades
            };
        }
    }
}
