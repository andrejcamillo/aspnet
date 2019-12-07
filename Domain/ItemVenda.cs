using HotelCachorro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{

    [Table("ItensVendas")]
    public class ItemVenda
    {
        
        [Key]
        public int IdVendaId { get; set; }

        public Servico Servico { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public Reserva Reserva { get; set; }
    }
}
