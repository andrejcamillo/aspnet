using Domain;
using HotelCachorro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ServicoDAO
    {

        private readonly Context _context;
        public ServicoDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Servico s)
        {
            if (BuscarServicoPorNome(s) == null)
            {
                _context.Servicos.Add(s);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public Servico BuscarServicoPorNome(Servico s)
        {
            return _context.Servicos.FirstOrDefault
                (x => x.NomeServico.Equals(s.NomeServico));
        }

        
        public List<Servico> ListarTodos()
        {
            return _context.Servicos.ToList();
        }

        public Servico BuscarPorId(int id)
        {
            return _context.Servicos.Find(id);
        }

        public void Remover(int id)
        {
            _context.Servicos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Servico s)
        {
            _context.Servicos.Update(s);
            _context.SaveChanges();
        }

        public List<Servico> ListarPorCategoria(int? id)
        {
            return _context.
                Servicos.
                Include(x => x.Categoria).
                Where(x => x.Categoria.CategoriaId == id).
                ToList();
        }


        /*
        public List<ItemVenda> ProdutosPorCliente(Reserva r)
        {
            return _context.ItensVenda.Where(x => x.Reserva.IdReserva == r.IdReserva).ToList();
        }*/

    }
}
