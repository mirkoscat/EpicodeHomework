using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzeriaWebApp.DataLayer;

namespace PizzeriaWebApp.Models
{
	public class AddProductModel
	{
		public Product Product { get; set; }
		public List<Ingredient> Ingredients { get; set; }=new List<Ingredient>();

	}
}