using System;
using System.Data.Entity;
using System.Linq;
using System.Xml;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PizzeriaWebApp.DataLayer
{
	public class PizzeriaDbContext :DbContext
	{
		
		public PizzeriaDbContext(): base("name=PizzeriaDbContext")
		{
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<ProductInCart> ProductsInCart { get; set; }
	
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Order> Orders { get; set; }

	}

	
}