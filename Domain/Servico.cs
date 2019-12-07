using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{

    [Table("Servicos")]
    public  class Servico
    {
        [Key]
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public double PrecoServico { get; set; }
        public Categoria Categoria { get; set; }

    }
}
