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
    public class EstadosController : Controller
    {
        private readonly ICidadesService cidadesService;

        public EstadosController(ICidadesService cidadesService)
        {
            this.cidadesService = cidadesService;
        }

        [HttpGet]
        public ResultadoPesquisaEstadoComMaiorEMenorQuantidadeDeCidadesViewModel Get()
        {
            return cidadesService.ListarEstadosComMaiorEMenorQtdeDeCidades();
        }
    }
}
