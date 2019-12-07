using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;
using Microsoft.AspNetCore.Hosting;

namespace EcommerceAngelo.Controllers
{
    public class ServicoController : Controller
    {
        private readonly ServicoDAO _servicoDAO;
        private readonly CategoriaDAO _categoriaDAO;

        public ServicoController(ServicoDAO servicoDAO, CategoriaDAO categoriaDAO)
        {
            _servicoDAO = servicoDAO;
            _categoriaDAO = categoriaDAO;
        }
        
        [HttpPost]
        public IActionResult Cadastrar(Servico s, int drpCategorias)
        {
            ViewBag.Categorias =
                new SelectList(_categoriaDAO.ListarTodos(),
                "CategoriaId", "Nome");

            if (ModelState.IsValid)
            {

                s.Categoria =
                     _categoriaDAO.BuscarPorId(drpCategorias);

                if (_servicoDAO.Cadastrar(s))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError
                    ("", "Esse servico já existe!");
            }
            return View(s);
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_servicoDAO.ListarTodos());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias =
                new SelectList(_categoriaDAO.ListarTodos(),
                "CategoriaId", "Nome");
            return View();
        }


        public IActionResult Remover(int id)
        {
            _servicoDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id)
        {
            return View
                (_servicoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Servico s)
        {
            _servicoDAO.Alterar(s);
            return RedirectToAction("Index");
        }
    }
}
