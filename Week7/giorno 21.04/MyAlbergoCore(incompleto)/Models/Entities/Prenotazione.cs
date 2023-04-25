using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyAlbergoCore.Models;

namespace GestioneAlbergo.Models.Entities
{
	public class Prenotazione
	{
		[Key]
		public int IdPrenotazione { get; set; }
		public DateTime DataPrenotazione { get; set; }
		public DateTime InizioSoggiorno { get; set; }
		public DateTime FineSoggiorno { get; set; }
		public decimal CaparraIniziale { get; set; }
		public decimal Tariffa { get; set; }
		public string IdCamera { get; set; }
		//public Camera Camera { get; set; }
		public AltriDettagli AltriDettagli { get; set; }
		


	}
	public enum AltriDettagli : int
	{
		Prima_Colazione = 1,
		Mezza_Pensione,
		Pensione_Completa
	}
}