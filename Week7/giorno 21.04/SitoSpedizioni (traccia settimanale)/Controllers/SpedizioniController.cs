using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitoSpedizioni.Models;
using SitoSpedizioni.Models.Entities;
using SitoSpedizioni.Service;

namespace SitoSpedizioni.Controllers
{
	public class SpedizioniController : Controller
	{
		private SpedizioniService service;

		public SpedizioniController()
		{
			service = new SpedizioniService();

		}
		// GET: Spedizioni
		public ActionResult Index()
		{//torno una lista con tutte le spedizioni
			var spedizioni = service.GetAll();

			return View(spedizioni);

		}
		public ActionResult PrimaQuery()
		{//spedizioni in consegna odierna
			string oggi = DateTime.Now.ToString("dd/MM/yyyy");
			//(StatoSpedizione)s.Status == StatoSpedizione.InConsegna)
			//in consegna = 1 
		
			var spedizioni = service.GetAll().Where(x=>x.DataPrevistaArrivo.ToString("dd/MM/yyyy").Equals(oggi) && (StatoSpedizione)x.Status == StatoSpedizione.InConsegna);
			return View(spedizioni);

		}
		public ActionResult SecondaQuery()

		{//spedizioni ordinate per città
		 
			DateTime oggi = DateTime.Today;
			//in transito ||attesa  = 0
			var spedizioni = service.GetAll().GroupBy(x => x.CittaDestinataria);
			return View(spedizioni);

		}
		public ActionResult TerzaQuery()
		{
			DateTime oggi = DateTime.Today;
			//spedizioni totali in attesa consegna
			var spedizioni = service.GetAll().Where(x=>x.Status != 2 && x.Status != 3);
			
			return View(spedizioni);

		}

		// GET: Spedizioni/Details/5
		public ActionResult Details(int id)
		{
			var spedizioni = service.GetById(id);
			return View(spedizioni);
		}

		// GET: Spedizioni/Create
		public ActionResult Create()
		{//creo il viewbag con l'enumerazione
			ViewBag.Status = new SelectList(Enum.GetValues(typeof(StatoSpedizione)));

			return View();
		}

		// POST: Spedizioni/Create
		[HttpPost]
		public ActionResult Create(Spedizioni s)
		{
			if (ModelState.IsValid)
			{
				var result = service.CreaSpedizione(s);
				if (result)
				{
					return RedirectToAction("Index", "Spedizioni");
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
			return View(s);
		}

		// GET: Spedizioni/Edit/5
		public ActionResult Edit(int id)
		{
			var spedizione = service.GetById(id);
			
			return View(spedizione);
		}

		// POST: Spedizioni/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Spedizioni s)
		{


			if (ModelState.IsValid)
			{
				var result = service.CambiaSpedizione(s);
				if (result)
					return RedirectToAction("Index", "Home");
				else
				{
					ModelState.AddModelError("model", "Impossibile eseguire il comando di inserimento sul database");
				}
			}

			return RedirectToAction("Index");

		}

		// GET: Spedizioni/Delete/5
		public ActionResult Delete(int id)
		{
			var spedizione = service.GetById(id);
			

			return View(spedizione);
		}

		// POST: Spedizioni/Delete/5
	//[HttpPost]
		public ActionResult DeletePress(int id)
		{
			try
			{
				bool result = service.CancellaSpedizione(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
		[HttpPost]
		public JsonResult VerificaSpedizioneAsync(int id, string cod)
		{
			var aggiornamento = service.VerificaSpedizione(id,cod);
		
			
		
			return Json(aggiornamento, JsonRequestBehavior.AllowGet);
		}


	}
}
