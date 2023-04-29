
using Ecommerce.Models.Entities;
using Ecommerce.Services;

using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Controllers
{
    public class CarrelloController : Controller
    {
        private readonly ILogger<CarrelloController> _logger;

        private readonly IServizioCarrello _scart;
        private readonly IServizioProdotto _sp;


        public CarrelloController(ILogger<CarrelloController> logger, IServizioCarrello serviziocarrello, IServizioProdotto servizioprodotto)
        {
            _logger = logger;
            _scart = serviziocarrello;
            _sp = servizioprodotto;
        }
        // GET: CarrelloController
        public ActionResult Index()
        {

            var idcart = _scart.GetIdCarrelloAttuale();
            var carrello = _scart.GetProdottiInCarrello(idcart);

            return View(carrello);
        }

        // POST: CarrelloController
        [HttpPost]
        public ActionResult Index(CarrelloProdotto p, IFormCollection form)
        {
            var idcarrello = _scart.GetIdCarrelloAttuale();
            var idcarrelloprodotto = p.IdCarrelloProdotto;
            //var idprodotto = p.Prodotto.IdProdotto; errore oggetto non istanziato

            _scart.ModificaQuantita(idcarrelloprodotto, idcarrello, int.Parse(form["id-prodotto"]), int.Parse(form["quantita"]));

            return RedirectToAction(nameof(Index));



        }

        // GET: CarrelloController/Details
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;

            var carrello = _scart.GetProdottiInCarrello(id);
            return View(carrello);
        }

        // GET: CarrelloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarrelloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarrelloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarrelloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarrelloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarrelloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
