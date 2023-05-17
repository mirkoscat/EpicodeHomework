using GestioneAlbergo.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAlbergoCore.Services;

namespace MyAlbergoCore.Controllers
{
	public class ClienteController : Controller
	{
		private readonly IClienteService _clienteService;
		public ClienteController(IClienteService cliente)
		{
			_clienteService = cliente;

		}
		// GET: ClienteController
		public ActionResult Index()
		{
			var model = _clienteService.GetClienti().ToList();
			return View(model);
		}

		// GET: ClienteController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ClienteController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ClienteController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Cliente c)
		{

			if (ModelState.IsValid)
			{
				return RedirectToAction(nameof(Index));
			}
			else
			{
				return View();
			}

		}

		// GET: ClienteController/Edit/5
		public ActionResult Edit(int id)
		{
			var model = _clienteService.GetClienti().FirstOrDefault(x => x.IdCliente == id); ;
			return View(model);
		}

		// POST: ClienteController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Cliente c)
		{
			var model = _clienteService.GetClienti().FirstOrDefault(x => x.IdCliente.Equals(id));
			if (model == null)
			{
				return NotFound();
			}
			else
			{
				model.Nome = c.Nome;
				model.Cognome = c.Cognome;
				model.Email = c.Email;
				model.CodiceFiscale = c.CodiceFiscale;
				model.Telefono = c.Telefono;
				model.Cellulare = c.Cellulare;
				model.Citta = c.Citta;
				model.Provincia = c.Provincia;

			}
			return View(model);
		}

		// GET: ClienteController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ClienteController/Delete/5
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
