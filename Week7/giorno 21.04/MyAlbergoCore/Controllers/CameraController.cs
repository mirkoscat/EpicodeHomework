using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAlbergoCore.Services;

namespace MyAlbergoCore.Controllers
{
	public class CameraController : Controller
	{

		private readonly ICameraService _cameraService;
        public CameraController(ICameraService cameraService)
        {
			_cameraService = cameraService;
        }



        // GET: CameraController
        public ActionResult Index()
		{
			var model=_cameraService.GetCamere();
			return View(model);
		}

		// GET: CameraController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: CameraController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CameraController/Create
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

		// GET: CameraController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: CameraController/Edit/5
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

		// GET: CameraController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CameraController/Delete/5
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
