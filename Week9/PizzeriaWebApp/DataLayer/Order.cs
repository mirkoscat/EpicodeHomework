using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzeriaWebApp.DataLayer
{
	[Table("Orders")]
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }


		[StringLength(50)]
		public string Address { get; set; }
		[StringLength(200)]
		public string AdditionalNote { get; set; }
		[Required]

		public bool Evaso { get; set; } = false;
		[Required]
		public DateTime OrderDate { get; set; }
		///<summary>lista prodottinelcarrello in ordini</summary>
		public List<ProductInCart> ProdottiInCarrello { get; set; } = new List<ProductInCart>();
		public Cart Cart { get; set; }






	}
}