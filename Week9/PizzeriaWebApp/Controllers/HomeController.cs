using System;
using System.Web.Mvc;

using System.Linq;

using Microsoft.Owin;
using PizzeriaWebApp.DataLayer;
using PizzeriaWebApp.Models;
using FormCollection = System.Web.Mvc.FormCollection;
using System.Security.Cryptography.X509Certificates;
using System.Data.Entity;
using System.Collections.Generic;

namespace PizzeriaWebApp.Controllers
{
	public class HomeController : Controller
	{
		private PizzeriaDbContext _dbcontext;
		
		public HomeController()
		{
			_dbcontext = new PizzeriaDbContext();
		
		}

		[Authorize]
		public ActionResult Index()
		{
			var products = _dbcontext.Products.Include(x=>x.Ingredienti).ToList();
		
		
			return View(products);
		}
		[Authorize(Roles = "admin")]
		public ActionResult Gestione()
		{
			var ingredients = _dbcontext.Ingredients.ToList();
			var products = _dbcontext.Products.ToList();


			var model = new GestioneViewModel
			{
				Ingredient = ingredients,
				Product = products
			};
			return View(model);
		}
	
		[Authorize(Roles = "admin")]
		public ActionResult AddProduct()
		{
			var model = new AddProductModel
			{
				Ingredients = _dbcontext.Ingredients.ToList(),
				Product = new Product()
			};


			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public ActionResult AddProduct(AddProductModel p, FormCollection form)
		{ 
			var ingredientlist = new List<Ingredient>();


			foreach (var i in p.Ingredients)
			{   //prendo i valori dal form
				var id = int.Parse(form["ingredientId"]);
				var ingrediente = _dbcontext.Ingredients.FirstOrDefault(x => x.Id == id);
				ingredientlist.Add(ingrediente);
			}
			p.Product.Ingredienti = ingredientlist;
			_dbcontext.Products.Add(p.Product);
			_dbcontext.SaveChanges();
			return RedirectToAction(nameof(Gestione));
			}

		[Authorize (Roles = "admin")]
		public ActionResult EditProduct(int id)
		{
			var product = _dbcontext.Products.Single(x => x.Id == id);

			return View(product);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public ActionResult EditProduct(Product p)
		{
			var product = _dbcontext.Products.Single(x => x.Id == p.Id);
			product.Name = p.Name;
			product.Price = p.Price;
			product.Url = p.Url;
			product.DeliveryTime = p.DeliveryTime;
			product.Description = p.Description;
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}


		[Authorize(Roles = "admin")]

		public ActionResult DeleteProduct(int id)
		{
			var product = _dbcontext.Products.Single(x => x.Id == id);
			_dbcontext.Products.Remove(product);
			_dbcontext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		//details product
		[Authorize(Roles = "admin")]
		public ActionResult DetailsProduct(int id)
		{
			var product = _dbcontext.Products.Single(x => x.Id == id);
			return View(product);
		}
		//details product post
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public ActionResult DetailsProduct(Product p)
		{
			var product = _dbcontext.Products.Single(x => x.Id == p.Id);
			product.Name = p.Name;
			product.Price = p.Price;
			product.Url = p.Url;
			product.DeliveryTime = p.DeliveryTime;
			product.Description= p.Description;
			_dbcontext.SaveChanges();
			return RedirectToAction("Index");
		}
		[Authorize(Roles = "admin")]
		public ActionResult Ordini()
		{
			var ordini = _dbcontext.Orders.ToList();
			return View(ordini);
		}
		[Authorize(Roles = "admin")]
		[HttpPost]
		public ActionResult UpdateStatus(FormCollection form)
		{
			int id= int.Parse(form["id"]);
			var status = form["status"].ToLower();
			var ordine = _dbcontext.Orders.FirstOrDefault(x => x.Id == id);
			if (status== "evaso")
			{
				ordine.Evaso = true;
			}
			else 
			{
				ordine.Evaso = false;
			}		
			
			_dbcontext.SaveChanges();
		
			return RedirectToAction(nameof(Ordini));

		}


		//INGREDIENTI CRUD
		[Authorize(Roles = "admin")]
		public ActionResult AddIngredient()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public ActionResult AddIngredient(Ingredient i)
		{
			
				_dbcontext.Ingredients.Add(i);
				_dbcontext.SaveChanges();
				return RedirectToAction(nameof(Gestione));
			
		}
		[Authorize(Roles = "admin")]
		public ActionResult EditIngredient(int id)
		{
			var ingredient = _dbcontext.Ingredients.Single(x => x.Id == id);
			return View(ingredient);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public ActionResult EditIngredient(Ingredient i)
		{
			var ingredient = _dbcontext.Ingredients.Single(x => x.Id == i.Id);
			ingredient.Name = i.Name;
			_dbcontext.SaveChanges();
			return RedirectToAction(nameof(Gestione));
		}
		[Authorize(Roles = "admin")]
		public ActionResult DeleteIngredient(int id)
		{
			var ingredient = _dbcontext.Ingredients.Single(x => x.Id == id);
			_dbcontext.Ingredients.Remove(ingredient);
			_dbcontext.SaveChanges();
			return RedirectToAction(nameof(Gestione));
		}

	}



}
