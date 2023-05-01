using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.Models.Entities
{
	public class CarrelloProdotto
    {
       
        [Key]
        public int IdCarrelloProdotto { get; set; }
        public int IdProdotto { get; set; }
        public int IdCarrello { get; set; }

        [ForeignKey("IdCarrello")]
        public  Carrello Carrello { get; set ; }

        [ForeignKey("IdProdotto")]
        public Prodotto Prodotto {  get; set; }
        public int Quantita { get; set; }
       
        public List<CarrelloProdotto> CarrelloProdotti { get; set; }


    }
}
