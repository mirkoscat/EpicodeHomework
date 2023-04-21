using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using SitoSpedizioni.Models.Entities;

namespace SitoSpedizioni.Models
{
    public class Spedizioni
    {
        public int IDspedizione { get; set; }
        [Required(ErrorMessage = "Il campo Data di Spedizione è obbligatorio.")]
        [Display(Name = "Data di Spedizione")]
        public DateTime DataSpedizione { get; set; }
        public int Peso { get; set; }
        public string CittaDestinataria { get; set; }
        public int Costo { get; set; }
        public DateTime DataPrevistaArrivo { get; set; }

        public int IDanagrafe { get;  set; }

        public int Status { get;set; }
       // public string StatoSpedizione { get; set; }
       
       // public Anagrafe Anagrafe { get; set; }

        public override bool Equals(object obj) => obj is Spedizioni && obj.GetHashCode() == GetHashCode();
        public override int GetHashCode() => IDspedizione;
	
	}
}