using Cidades.Application.Interfaces;
using Cidades.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cidades.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CidadesController : Controller
    {
        private readonly ICidadesService cidadesService;

        public CidadesController(ICidadesService cidadesService)
        {
            this.cidadesService = cidadesService;
        }
        
        [HttpGet]
        public ResultadoPesquisaCidadesViewModel Get(int? ibge = null, string nome = null, string uf = null, string microRegiao = null, string mesorregiao = null)
        {
            return cidadesService.PesquisarCidades(ibge, nome, uf, microRegiao, mesorregiao);
        }

        [HttpDelete]
        public void Delete(int ibge)
        {
            cidadesService.RemoverCidade(ibge);
        }


    }
}
