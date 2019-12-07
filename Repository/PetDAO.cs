using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PetDAO
    {
        private readonly Context _context;
        public PetDAO(Context context)
        {
            _context = context;
        }


        public bool Cadastrar(Pet p)
        {
            if (BuscarPetPorCliente(p) == null)
            {
                _context.Pets.Add(p);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public Pet BuscarPetPorCliente(Pet p)
        {
            return _context.Pets.Include(z => z.cliente).FirstOrDefault
                (x => x.Nome.Equals(p.Nome) && x.cliente.IdCliente == p.cliente.IdCliente);
        }

        


        public Pet BuscarPetPorNome(Pet p)
        {
            return _context.Pets.FirstOrDefault
                (x => x.Nome.Equals(p.Nome));
        }
        public List<Pet> ListarTodos()
        {
            return _context.Pets.ToList();
        }
        public Pet BuscarPorId(int id)
        {
            return _context.Pets.Find(id);
        }
        public void Remover(int id)
        {
            _context.Pets.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Pet p)
        {
            _context.Pets.Update(p);
            _context.SaveChanges();
        }

        


    }
}
