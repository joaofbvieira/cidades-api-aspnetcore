using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.ViewModel
{
    public class ResultadoPesquisaCidadesViewModel
    {
        public int QuantidadeCidades { get; set; }
        public IEnumerable<CidadeViewModel> Cidades { get; set; }

    }
}
