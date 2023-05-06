using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzeriaWebApp.DataLayer;

namespace PizzeriaWebApp
{
	public class GestioneViewModel
	{
		//pagina di gestione
		public List<Ingredient> Ingredient { get; set; }
		public List<Product> Product { get; set; }
		public List<Cart> Cart { get; set; }
		
		
	}
}