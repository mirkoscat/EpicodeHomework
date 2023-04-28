using Ecommerce.Models.Entities;
using Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdottoController : Controller
    {
        private readonly ILogger<ProdottoController> _logger;
        private readonly IServizioProdotto _sp;
        public ProdottoController(ILogger<ProdottoController> logger, IServizioProdotto servizio)
        {
            _logger = logger;
            _sp = servizio;
        }
        // GET: ProdottoController
        public ActionResult Index()
        {
            var prodotti = _sp.GetAll().ToList();
            return View(prodotti);
        }

        // GET: ProdottoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //autorize admin
        public IActionResult Create(Prodotto p)
        {
            if (ModelState.IsValid)
            {
                var result = _sp.CreaProdotto(p);
                if (result)
                    return RedirectToAction("Index");

            }
            return View(p);
        }
        //autorize admin
        public IActionResult Edit(int id)
        {
            var prodotto = _sp.GetProdottoById(id);
            return View(prodotto);
        }
        [HttpPost]
        //autorize admin
        public ActionResult Edit(Prodotto model)
        {

            if (ModelState.IsValid)
            {
                var result = _sp.ModificaProdotto(model);
                if (result)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("model", "Impossibile eseguire il comando di inserimento sul database");
                }
            }
            return RedirectToAction("Index");
        }


        // GET: ProdottoController/Delete/5
        //autorize admin
        public IActionResult Delete(int id)
        {
          var prodotto = _sp.GetProdottoById(id);
            return View(prodotto);
        }
        [HttpPost]
        public IActionResult Delete(Prodotto p, int id)
        {
            bool result = _sp.EliminaProdotto(id);
		
			if (result)
			{
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return View(p);
			}
		}


    }
}
