using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class GeneroDAO: IRepository<Genero>
    {
        private readonly Context _context;
        public GeneroDAO(Context context)
        {
            _context = context;
        }
        public Genero BuscarPorId(int id)
        {
            return _context.Generos.Find(id);
        }
        public bool Cadastrar(Genero objeto)
        {
            if (BuscarPorNome(objeto) == null)
            {
                _context.Generos.Add(objeto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public Genero BuscarPorNome(Genero g)
        {
            return _context.Generos.FirstOrDefault
                (x => x.Nome.Equals(g.Nome));
        }
        public List<Genero> ListarTodos()
        {
            return _context.Generos.ToList();
        }

       
    }
}

