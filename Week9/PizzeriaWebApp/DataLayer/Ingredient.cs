using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzeriaWebApp.DataLayer
{
    [Table("Ingredients")]
	public class Ingredient
	{//un ingrediente di un prodotto
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
       
		// Relazione many-to-many con Prodotto
		public ICollection<Product> Prodotti { get; set; } =new List<Product>();





	}
}