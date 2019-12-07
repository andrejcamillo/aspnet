using Domain;
using HotelCachorro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Endend> Endends { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
