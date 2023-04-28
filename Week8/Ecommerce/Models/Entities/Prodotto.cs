using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Entities
{
    public class Prodotto
    {
        [Key]
        public int IdProdotto { get; set; }

		[Display(Name = "Nome prodotto")]
		[Required(ErrorMessage = "Nome prodotto richiesto")]
		public string Nome { get; set; }


		[Required(ErrorMessage = "Immagine prodotto richiesta")]
		[Display(Name = "Immagine prodotto")]
		public string Immagine { get; set; }

		[Required(ErrorMessage = "Prezzo prodotto richiesto")]
		[Display(Name = "Prezzo prodotto")]
		public decimal Prezzo { get; set; }

		[Required(ErrorMessage = "Descrizione prodotto richiesta")]
		[Display(Name = "Descrizione prodotto")]
		public string Descrizione { get; set; }

		[Display(Name = "Descrizione aggiuntiva prodotto")]
		public string? DescrAggiuntiva { get; set; }

		public Stock InStock { get; set; }
	}
    public enum Stock : int
    {
        OutOfStock,
        InStock

    }
}
