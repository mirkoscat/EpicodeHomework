using System.ComponentModel.DataAnnotations;
using GestioneAlbergo.Models.Entities;

namespace MyAlbergoCore.Models.Entities
{
	public class PrenotazioneServizio
	{
		[Key]
		public int IdPrenotazioneServizio { get; set; }
		//public int IdPrenotazione { get; set; }
		public Prenotazione Prenotazione { get; set; }
		public TipologiaServizio TipoServizio { get; set; }
		//public int IdServizio { get; set; }
		public int Quantita { get; set; }
		public ImportoTipologia Importo { get; set; }
		public DateTime DataServizio { get; set; }
	}
	public enum TipologiaServizio : int
	{
		ColazioneInCamera = 1,
		Minibar,
		Internet,
		LettoAggiuntivo,
		Culla
	}
	public enum ImportoTipologia : int
	{
		ColazioneInCamera = 10,
		Minibar = 40,
		Internet = 4,
		LettoAggiuntivo = 80,
		Culla = 50
	}
}
