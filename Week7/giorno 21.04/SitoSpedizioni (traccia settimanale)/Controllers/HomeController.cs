using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using SitoSpedizioni.Models;
using SitoSpedizioni.Service;

namespace SitoSpedizioni.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AnagrafeService service;

        public HomeController()
        {
            service = new AnagrafeService();

        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult EditAnagrafica(int id)
        {//ci deve essere un id per poter modificare una certa anagrafe
            // mandare i dati dal database alla vista
            var anagrafe = service.GetById(id);
         
            return View(anagrafe);

        }
        [HttpPost]
        public ActionResult EditAnagrafica(Anagrafe model)
        {

            if (ModelState.IsValid)
            {
                var result = service.CambiaAnagrafe(model);
                if (result)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("model", "Impossibile eseguire il comando di inserimento sul database");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult ListAnagrafica()
        {
            // recupera tutte le anagrafe
            var anagrafe = service.GetAll();
            // e passarle alla vista
            return View(anagrafe);
        }
        //prova asincrona
		public JsonResult ListAnagraficaAsync()
		{
			// recupera tutte le anagrafe
			var anagrafe = service.GetAll();
			// e passarle alla vista
			return Json(anagrafe, JsonRequestBehavior.AllowGet);
		}
		public ActionResult CreaAnagrafica()
        {
            // consente all'utente di creare un'attività
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreaAnagrafica(Anagrafe model)
        {
            if (ModelState.IsValid)
            {
                var result = service.CreaAnagrafe(model);
                if (result)
                {
                    return RedirectToAction("ListAnagrafica", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Impossibile eseguire il comando di inserimento sul database.");
                }
            }
            else
            {
                ModelState.AddModelError("", "I dati inseriti non sono validi.");
            }
            return View(model);
        }
      

        public ActionResult CancellaAnagrafica(int id)
        {
            // recupero l'anagrafica tramite l'id
            var anagrafica = service.GetById(id);
                
            return View(anagrafica);
        }
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CancellaAnagrafica(Anagrafe a)
        {
            bool result = service.CancellaAnagrafe(a.IDanagrafe);
            //bool result= service.DeleteAnagrafeById(a.IDanagrafe);
           
            if (result )
            {
                return RedirectToAction("ListAnagrafica");
            }
            else
            {
                return RedirectToAction("ListAnagrafica");
            }   
         
        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}