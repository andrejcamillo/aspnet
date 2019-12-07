using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Clientes")]
    public class Cliente : Pessoa
    {
        [Key]
        public int IdCliente { get; set; }

        public string Sobrenome { get; set; }

        public Endend Endend { get; set;}

    }

}

