using System;
using System.Collections.Generic;
using System.Data.Entity;
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
          	var listProdotti = _dbcontext.ProductsInCart.Include(nameof(Product)).Include(nameof(Cart)).Where(p => p.Cart.Id == cart.Id).ToList();
            var model = new CartViewModel
            {
                ListProdottiInCarrello = listProdotti,
                Cart = cart

            };
            return View(model);
        }


        public ActionResult AddToCart(long id, int qty)
        {

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddToCart(FormCollection form)

        {
            if (ModelState.IsValid)
            {
                var cart = _dbcontext.Carts.Include(x=>x.ListaProdotti.Select(c=>c.Product)).FirstOrDefault(x => x.Username == User.Identity.Name);
                
                if (cart == null)
                {
                    cart = new Cart();
                    cart.Username = User.Identity.Name;
                    _dbcontext.Carts.Add(cart);
                    _dbcontext.SaveChanges();
                }

                var quantity = int.Parse(form["qty"]);
                var id = long.Parse(form["id"]);
                //include ingredient?
                var product = _dbcontext.Products.FirstOrDefault(x => x.Id == id);
                var productInCart = cart.ListaProdotti.FirstOrDefault(x => x.Product.Id == id);
                var check = cart.ListaProdotti.Any(x=>x.Product.Id==id);
                if (!check  )
                {
                    var newItem = new ProductInCart
                    {
                        Cart = cart,
                        Product = product,
                        Quantity = quantity
                    };
                    _dbcontext.ProductsInCart.Add(newItem);
                }
                else
                { 
                    productInCart.Quantity += quantity;
                }
                _dbcontext.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateQuantity(long id, int qty)
        {

            return Json(true, JsonRequestBehavior.AllowGet);
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



        [HttpPost]
        public ActionResult CheckOut(FormCollection form)
        {
            var cart = _dbcontext.Carts.Include("ListaProdotti").FirstOrDefault(x => x.Username == User.Identity.Name);
            var order = new Order();
            var note = form["note"];
            var indirizzo = form["indirizzo"];
            order.AdditionalNote = note;
            order.Address = indirizzo;
            order.OrderDate = System.DateTime.Now;
            order.Evaso = false;
            order.Cart = cart;

            foreach (var p in cart.ListaProdotti)
            {
                order.ProdottiInCarrello.Add(p);
            }
            cart.ListaProdotti.Clear();
            _dbcontext.Orders.Add(order);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(HomeController.Index));

        }



    }
}