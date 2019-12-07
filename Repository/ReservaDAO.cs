using HotelCachorro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ReservaDAO
    {

        private readonly Context _context;
        public ReservaDAO(Context context)
        {
            _context = context;
        }

        public bool Cadastrar(Reserva r)
        {


            if (r.DataEntrada < r.DataSaida && r.DataEntrada >= DateTime.Now)
            {
                if (_context.Reservas.Include(x => x.Quarto).Any(x => x.DataSaida >= r.DataEntrada && x.DataEntrada <= r.DataSaida
                && x.Quarto.IdQuarto == r.Quarto.IdQuarto) == true)
                {
                    return false;
                }
                else
                {


                    _context.Reservas.Add(r);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public List<Reserva> ListarTodos()
        {
            return _context.Reservas.ToList();
        }

        public void Remover(int id)
        {
            _context.Reservas.Remove(BuscarReservaPorId(id));
            _context.SaveChanges();

        }

        public Reserva BuscarPorId(int id)
        {
            return _context.Reservas.Find(id);
        }

        public Reserva BuscarReservaPorId(int reserva)
        {
            return _context.Reservas.Find(reserva);
        }

        public bool Alterar(Reserva r)
        {

            var reservaAtual = _context.Reservas.Include(x => x.Quarto).Where(b => b.Quarto.IdQuarto == r.Quarto.IdQuarto).
            Select(b => r.DataEntrada < b.DataSaida && r.DataEntrada > b.DataEntrada).FirstOrDefault();

            //Console.WriteLine(reservaAtual);

            if (r.DataEntrada < r.DataSaida && r.DataEntrada >= DateTime.Now)
            {


                if (_context.Reservas.Include(x => x.Quarto).Any(x => x.DataSaida >= r.DataEntrada && x.DataEntrada <= r.DataSaida
                && x.Quarto.IdQuarto == r.Quarto.IdQuarto && x.IdReserva != r.IdReserva) == true)
                {
                    Console.WriteLine(r.DataEntrada);
                    return false;
                }
                else
                {
                    _context.Entry(r).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }


        public List<Reserva> ListarReservas() => _context.Reservas.Include(t => t.Pet).Include(x => x.Quarto).ToList();




    }
}
