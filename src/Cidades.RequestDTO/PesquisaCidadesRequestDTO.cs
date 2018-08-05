using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.RequestDTO
{
    public class PesquisaCidadesRequestDTO
    {
        public int IdIbge { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }
        public string MicroRegiao { get; set; }
        public string Mesorregiao { get; set; }
    }
}
