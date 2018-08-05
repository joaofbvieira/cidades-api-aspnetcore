using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.ViewModel
{
    public class CidadeViewModel
    {
        public int Ibge { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string MicroRegiao { get; set; }
        public string Mesorregiao { get; set; }
        public bool Capital { get; set; }
        public string NomeAlternativo { get; set; }
        public string NomeSemAcentuacao { get; set; }
    }
}
