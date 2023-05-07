using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzeriaWebApp.DataLayer;

namespace PizzeriaWebApp.Models
{
	public class CartViewModel
	{
		//elenco di articoli scelti dall'utente
	
		
		
		public List<ProductInCart> ListProdottiInCarrello { get; set; } = new List<ProductInCart>();
		
		public Cart Cart { get; set; }
		
		
		
		

	}
}