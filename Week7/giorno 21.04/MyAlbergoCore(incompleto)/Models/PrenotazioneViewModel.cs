using GestioneAlbergo.Models.Entities;
using MyAlbergoCore.Models.Entities;

namespace MyAlbergoCore.Models
{
	public class PrenotazioneViewModel
	{
		public Prenotazione prenotazione { get; set; }

		public List<Cliente> listaClienti { get; set; }

		public List<Camera> listCamere { get; set; }

		public List<PrenotazioneServizio> prenotazioneServizi { get; set; }


	}
	public enum AltriDettagli: int
	{
		Prima_Colazione =1,
		Mezza_Pensione,
		Pensione_Completa
	}
}
