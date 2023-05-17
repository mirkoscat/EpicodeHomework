using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GestioneAlbergo.Models.Entities
{
	public class Cliente
	{

		[Key]
        public int IdCliente { get; set; }
		[Required(ErrorMessage ="Nome obbligatorio")]
	
		public string Nome { get; set; }
		[Required(ErrorMessage = "Nome obbligatorio")]
	
		public string Cognome { get; set; }
		[Required(ErrorMessage = "Cognome obbligatorio")]
		public string Email { get; set; }
		
		public string CodiceFiscale { get; set; }
		public string Telefono{ get; set; }
		[Required(ErrorMessage = "Codice Fiscale obbligatorio")]
		public string Cellulare { get; set; }
		[Required(ErrorMessage = "Cellulare obbligatorio")]
		public string Citta { get; set; }
		[Required(ErrorMessage = "Citta obbligatoria")]
		public string Provincia { get; set; }

    }
}