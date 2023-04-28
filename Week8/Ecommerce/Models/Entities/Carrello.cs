using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.Entities
{
    public class Carrello
    {
        [Key]
        public int IdCarrello { get; set; }

        [ForeignKey("IdCliente")]
        public int IdCliente { get; set; }
        public bool IsOpen { get; set; } = false;
        public DateTime DataApertura { get; set; }
        public decimal ImportoTotale { get; set; }


    }
}
