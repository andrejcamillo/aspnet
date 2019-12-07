using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ClienteDAO : IRepository<Cliente>
    {
        private readonly Context _context;
        public ClienteDAO(Context context)
        {
            _context = context;
        }
        public bool Cadastrar(Cliente c)
        {
            if (BuscarClientePorNome(c) == null)
            {
                _context.Clientes.Add(c);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public Cliente BuscarClientePorNome(Cliente c)
        {
            return _context.Clientes.FirstOrDefault
                (x => x.Nome.Equals(c.Nome));
        }
        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.Find(id);
        }
        public void Remover(int id)
        {
            _context.Clientes.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Cliente c)
        {
            _context.Clientes.Update(c);
            _context.SaveChanges();
        }

        public List<Cliente> ListarPorCategoria(int? id)
        {
            return _context.Clientes.Include(x => x.Genero).
                Where(x => x.Genero.GeneroId == id).
                ToList();
        }


        public Cliente BuscarClientePorCpf(string cpf)
        {
            return _context.Clientes.FirstOrDefault(x => x.Cpf.Equals(cpf));
        }

    }
}
