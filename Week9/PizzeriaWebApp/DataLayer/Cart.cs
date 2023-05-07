using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzeriaWebApp.DataLayer
{
	public class Cart
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		///<summary>Lista di prodottinelcarrello in un carrello</summary>
		public ICollection<ProductInCart> ListaProdotti { get; set; }= new List<ProductInCart>();

		public string Username { get; set; }




	}
}