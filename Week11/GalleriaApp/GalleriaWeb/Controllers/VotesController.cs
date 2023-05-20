using GalleriaWeb.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace GalleriaWeb.Controllers
{
	public class VotesController : Controller
	{
		private readonly IGalleriaService gs;
        public VotesController(IGalleriaService gs)
        {
			this.gs = gs;
            
        }
        // GET: VotesController
        public ActionResult Index()
		{ 
			return View();
		}
		//public ActionResult AssegnaVoto(int qty)
		//{
		//	//var model = new VoteModel { 
		//	//Value = qty,
		//	//Username=User.Identity.Name
		//	//};
			
		//	//return View(model);
		//}
		[HttpPost]
		public ActionResult AssegnaVoto(int id,VoteModel m)
		{
			gs.PlaceVote(id,m.Value);
			return View();
		}
		// GET: VotesController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: VotesController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: VotesController/Create
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

		// GET: VotesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: VotesController/Edit/5
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

		// GET: VotesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: VotesController/Delete/5
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
