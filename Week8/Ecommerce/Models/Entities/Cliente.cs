using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
	
		[Display(Name = "Nome")]
	
        public string Nome { get; set; }

		
		[Display(Name = "Cognome")]
		public string Cognome { get; set; }

		[Required(ErrorMessage = "Email richiesta")]
		[Display(Name = "Email")]
		

		public string Email { get; set; }


		[Display(Name = "Password")]
		[Required(ErrorMessage = "Password richiesta")]
		public string Password { get; set; }
    }
}
