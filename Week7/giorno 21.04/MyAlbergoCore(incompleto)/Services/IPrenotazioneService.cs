using GestioneAlbergo.Models.Entities;

namespace MyAlbergoCore.Services
{
	public interface IPrenotazioneService
	{
		void AggiungiPrenotazione(Prenotazione p);
		void ModificaPrenotazione(Prenotazione p);
		IEnumerable<Prenotazione> GetPrenotazioni();

	}
}
