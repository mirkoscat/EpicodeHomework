using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzeriaWebApp.DataLayer
{
    [Table("Products")]
	public class Product
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        [Range(1,100)]
		[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
		
		public decimal Price{ get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0} min", ApplyFormatInEditMode = false)]
		public int DeliveryTime { get; set; }
		[StringLength(50)]
        ///<summary>Descrizione Prodotto</summary>
		public string Description { get; set; }
		///<summary>Lista di ingredienti in un prodotto</summary>
		public ICollection<Ingredient> Ingredienti { get; set; } = new List<Ingredient>();

		

	}
}