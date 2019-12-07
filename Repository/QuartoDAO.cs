using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class QuartoDAO
    {
        private readonly Context _context;

        public QuartoDAO(Context context)
        {
            _context = context;
        }


        public List<Quarto> ListarQuartos()
        {
            return _context.Quartos.ToList();
        }

        public Quarto BuscarQuartoPorNome(Quarto q)
        {
            return _context.Quartos.FirstOrDefault(x => x.NomeQuarto.Equals(q.NomeQuarto));
        }


        public Quarto BuscarQuartoPorId(int quarto)
        {
            return _context.Quartos.FirstOrDefault(x => x.IdQuarto == quarto);
        }

        public List<Quarto> BuscarQuarto(Quarto q)
        {
            return _context.Quartos.Where(x => x.IdQuarto == q.IdQuarto).ToList();
        }

        public Quarto ValorQuarto(Quarto q)
        {
            return _context.Quartos.FirstOrDefault(x => x.PrecoQuarto == q.PrecoQuarto);
        }


        public bool Cadastrar(Quarto q)
        {

            if(!string.IsNullOrEmpty(q.NomeQuarto) && q.PrecoQuarto > 0 && q.Checado != false && q.EnderecoEntrega != null)
                    
            {
                if (BuscarQuartoPorNome(q) == null)
                {
                    _context.Quartos.Add(q);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }


        }


        public bool Remover(int id)
        {

            _context.Quartos.Remove(BuscarPorId(id));
            _context.SaveChanges();
            return true;

        }

        public bool Alterar(Quarto q)
        {

            if (!string.IsNullOrEmpty(q.NomeQuarto) && q.PrecoQuarto > 0)
            {

                _context.Entry(q).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Quarto BuscarPorId(int id)
        {
            return _context.Quartos.Find(id);
        }


        public List<Quarto> ListarTodos()
        {
            return _context.Quartos.ToList();
        }

    }
}
