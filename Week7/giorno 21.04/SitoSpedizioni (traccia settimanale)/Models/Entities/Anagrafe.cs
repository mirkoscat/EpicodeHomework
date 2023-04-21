using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace SitoSpedizioni.Models
{
    public class Anagrafe
    {

        //[Bind(Exclude ="IDanagrafe")]
        public int IDanagrafe { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage ="inserire nome")]
        [RegexStringValidator(@"^[A-Za-z]+$")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Il nome deve essere compreso tra 3 e 20 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "inserire cognome")]
        [Display(Name = "Cognome")]
        [RegexStringValidator(@"^[A-Za-z]+$")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Il cognome deve essere compreso tra 3 e 20 caratteri")]
        public string Cognome { get; set; }


        [Display(Name = "Utente Privato?")]
        public bool Is_privato { get; set; }


        [Required(ErrorMessage = "inserire indirizzo")]
        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; }


        [Display(Name = "Codice Fiscale")]
        [RegularExpression(@"^[A-Z]{6}\d{2}[A-Z]\d{2}[A-Z]\d{3}[A-Z]$", ErrorMessage = "Codice fiscale non valido")]
        public string CodiceFiscale { get; set; }


        [Display(Name = "Partita IVA")]
        public string PartitaIva { get; set; }

       

        public override bool Equals(object obj) => obj is Anagrafe && obj.GetHashCode() == GetHashCode();
        public override int GetHashCode() => IDanagrafe;
       
    }
}