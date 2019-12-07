using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;

namespace EcommerceAngelo.Controllers
{
    public class QuartoController : Controller
    {

        private readonly QuartoDAO _quartoDAO;


        public QuartoController(QuartoDAO quartoDAO)
        {
            _quartoDAO = quartoDAO;

        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Quarto q)
        {

            if (ModelState.IsValid)
            {




                if (_quartoDAO.Cadastrar(q))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError
                    ("", "Esse quarto já existe!");
                }

            }
            return View(q);
        }

       



        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_quartoDAO.ListarQuartos());
        }


        public IActionResult Remover(int id)
        {
            _quartoDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id)
        {
            return View
                (_quartoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Quarto q)
        {
            _quartoDAO.Alterar(q);
            return RedirectToAction("Index");
        }




    }
}
