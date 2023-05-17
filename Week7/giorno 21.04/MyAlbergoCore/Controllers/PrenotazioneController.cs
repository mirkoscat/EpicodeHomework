using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAlbergoCore.Data;
using MyAlbergoCore.Services;

namespace MyAlbergoCore.Controllers
{
	public class PrenotazioneController : Controller
	{
		private readonly IPrenotazioneService prenotazioniService;
	
        public PrenotazioneController(IPrenotazioneService pren)
        {
			prenotazioniService = pren;
			
        }
        // GET: PrenotazioniController
        public ActionResult Index()
		{
			var model = prenotazioniService.GetPrenotazioni().ToList();
			
			return View(model);
		}

		// GET: PrenotazioniController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PrenotazioniController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PrenotazioniController/Create
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

		// GET: PrenotazioniController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PrenotazioniController/Edit/5
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

		// GET: PrenotazioniController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PrenotazioniController/Delete/5
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
