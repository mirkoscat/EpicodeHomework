using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestioneAlbergo.Models.Entities
{
	public class Camera
	{
		[Key]
        public int IdCamera { get; set; }
		public string Descrizione { get; set; }
		public TipologiaCamera Tipologia { get; set; }

		public int IdCliente { get; set; }
		//public Cliente Cliente { get; set; }
		

	}
	public enum TipologiaCamera: int
	{
		Singola=1,
		Doppia,
		Tripla,
		Quadrupla
	}
}