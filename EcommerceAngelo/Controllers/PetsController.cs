using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Repository;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;




namespace EcommerceAngelo.Controllers
{
    public class PetsController : Controller
    {
        private readonly PetDAO _petDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly GeneroDAO _generoDAO;
        private readonly IHostingEnvironment _hosting;

        public PetsController(PetDAO petDAO, GeneroDAO generoDAO, ClienteDAO clienteDAO,IHostingEnvironment hosting)
        {
            _petDAO = petDAO;
            _generoDAO = generoDAO;
            _hosting = hosting;
            _clienteDAO = clienteDAO;
        }

        [HttpPost]
        public IActionResult Cadastrar(Pet p,
            int drpGeneros, IFormFile fupImagem)
        {
            ViewBag.Generos =
                new SelectList(_generoDAO.ListarTodos(),
                "GeneroId", "Nome");

            


            if (ModelState.IsValid)
            {

                //Cadastrar a imagem
                if (fupImagem != null)
                {
                    //paste: ecommerceimagens
                    string arquivo = Guid.NewGuid().ToString() +
                        Path.GetExtension(fupImagem.FileName);
                    string caminho = Path.Combine(_hosting.WebRootPath,
                        "ecommerceimagens", arquivo);
                    fupImagem.CopyTo(
                        new FileStream(caminho, FileMode.Create));
                    p.Imagem = arquivo;
                }
                else
                {
                    p.Imagem = "semimagem.jfif";
                }


                p.Genero =
                    _generoDAO.BuscarPorId(drpGeneros);

                p.cliente = _clienteDAO.BuscarClientePorCpf(p.cliente.Cpf);


                if(p.cliente != null)
                {
                    if (_petDAO.Cadastrar(p))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError
                        ("", "Esse pet já existe!");
                    }

                }
                else
                {
                    ModelState.AddModelError
                      ("", "Esse cliente não existe!");
                }

             
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Generos =
                new SelectList(_generoDAO.ListarTodos(),
                "GeneroId", "Nome");
            return View();
        }


        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_petDAO.ListarTodos());
        }






        public IActionResult Remover(int id)
        {
            _petDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id)
        {
            return View
                (_petDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Pet p)
        {
            _petDAO.Alterar(p);
            return RedirectToAction("Index");
        }



        /*
        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .FirstOrDefaultAsync(m => m.IdPet == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }*/

    }
}
