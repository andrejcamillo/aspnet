using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Quartos")]
    public class Quarto
    {
        [Key]
        public int IdQuarto { get; set; }
        public string NomeQuarto { get; set; }
        public double PrecoQuarto { get; set; }
        public Boolean Checado { get; set; }
        public string EnderecoEntrega { get; set; }
    }
}
