using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzeriaWebApp.DataLayer;
using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Controllers
{
	[Authorize]
	public class CarrelloController : Controller
	{
		private readonly PizzeriaDbContext _dbcontext;
		
		public CarrelloController()
		{
			_dbcontext = new PizzeriaDbContext();
		}
		public ActionResult Index()
		{
			var cart = _dbcontext.Carts.FirstOrDefault(c => c.Username == User.Identity.Name);
			var listProdotti = _dbcontext.ProductsInCart.Include(nameof(Product)).Include(nameof(Cart)).Where(p => p.Cart.Id == cart.Id && p.Product.Id==p.Id).ToList();
			var model = new CartViewModel
			{
				ListProdottiInCarrello = listProdotti,
				Cart = cart

			};
			return View(model);
		}
		
	
		[HttpPost]
		public ActionResult UpdateQuantity(FormCollection form)
		{

			var id = long.Parse(form["id"]);
			var qty = int.Parse(form["qty"]);
			var productInCart = _dbcontext.ProductsInCart.FirstOrDefault(x => x.Id == id);
			productInCart.Quantity = qty;
			_dbcontext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}



	}
}