using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cidades.Domain.Entidades
{
    public class Cidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ibge_id { get; set; }

        public string uf { get; set; }
        public string name { get; set; }
        public bool capital { get; set; }
        public decimal lon { get; set; }
        public decimal lat { get; set; }
        public string no_accents { get; set; }
        public string alternative_names { get; set; }
        public string microregion { get; set; }
        public string mesoregion { get; set; }
    }
}
