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
    public class CapitaisController : Controller
    {
        private readonly ICidadesService cidadesService;

        public CapitaisController(ICidadesService cidadesService)
        {
            this.cidadesService = cidadesService;
        }

        [HttpGet]
        public IEnumerable<CidadeViewModel> Get()
        {
            return cidadesService.ListarCapitais();
        }

    }
}
