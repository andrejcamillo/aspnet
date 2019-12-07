using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using EcommerceAngelo.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace EcommerceAngelo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly ItemVendaDAO _itemVendaDAO;
        private readonly UtilsSession _utilsSession;

        public HomeController(ProdutoDAO produtoDAO, 
            CategoriaDAO categoriaDAO, 
            ItemVendaDAO itemVendaDAO,
            UtilsSession utilsSession)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _itemVendaDAO = itemVendaDAO;
            _utilsSession = utilsSession;
        }
        public IActionResult Index(int? id)
        {
            ViewBag.Categorias = _categoriaDAO.ListarTodos();
            if (id == null)
            {
                return View(_produtoDAO.ListarTodos());
            }
            return View(_produtoDAO.ListarPorCategoria(id));
        }
        public IActionResult Detalhes(int id)
        {
            return View(_produtoDAO.BuscarPorId(id));
        }
        public IActionResult RemoverDoCarrinho(int id)
        {
            _itemVendaDAO.Remover(id);
            return RedirectToAction("CarrinhoCompras");
        }

        /*
        public IActionResult CarrinhoCompras()
        {
            ViewBag.TotalCarrinho = _itemVendaDAO.
                RetornarTotalCarrinho(_utilsSession.RetornarCarrinhoId());

            return View(_itemVendaDAO.
                ListarItensPorCarrinhoId
                (_utilsSession.RetornarCarrinhoId()));
        }
        */
        public IActionResult AumentarQuantidade(int id)
        {
            _itemVendaDAO.AumentarQuantidade(id);
            return RedirectToAction("CarrinhoCompras");
        }
        public IActionResult DiminuirQuantidade(int id)
        {
            _itemVendaDAO.DiminuirQuantidade(id);
            return RedirectToAction("CarrinhoCompras");
        }
    
    }
}