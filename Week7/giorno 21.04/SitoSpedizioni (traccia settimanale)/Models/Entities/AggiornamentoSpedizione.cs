using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitoSpedizioni.Models.Entities
{
	public class AggiornamentoSpedizione
	{
		public int IDAggiornamento { get; set; }
		public int IDSpedizione { get; set; }
		public StatoSpedizione Stato { get; set; }
		public string LuogoDiTransito { get; set; }
		public string DescrizioneDiTransito { get; set; }
		public DateTime OraDiTransito { get; set; }

		public string IDAnagrafe { get; set; }
		public Anagrafe Anagrafe { get; internal set; }
	}

	public enum StatoSpedizione : int
	{
		InTransito,
		InConsegna,
		Consegnato,
		NonConsegnato
	}
}