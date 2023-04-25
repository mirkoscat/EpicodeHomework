using GestioneAlbergo.Models.Entities;
using Microsoft.Data.SqlClient;

namespace MyAlbergoCore.Services
{
	public class PrenotazioneService : IPrenotazioneService
	{
		private SqlConnection connection = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=GestioneAlbergo;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");

		public void AggiungiPrenotazione(Prenotazione p)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Prenotazione> GetPrenotazioni()
		{

			var result = new List<Prenotazione>();

			var select = connection.CreateCommand();
			select.CommandText = "Select IdPrenotazione,DataPrenotazione,InizioSoggiorno,FineSoggiorno,CaparraIniziale,Tariffa,IdCamera,AltriDettagli from Prenotazione";
			try
			{
				connection.Open();
				using (var reader = select.ExecuteReader())
				{
					while (reader.Read())
					{
						var item = new Prenotazione
						{
							IdPrenotazione = reader.GetInt32(0),
							DataPrenotazione = reader.GetDateTime(1),
							InizioSoggiorno = reader.GetDateTime(2),
							FineSoggiorno = reader.GetDateTime(3),
							CaparraIniziale = reader.GetDecimal(4),
							Tariffa = reader.GetDecimal(5),
							IdCamera = reader.GetString(6),
							AltriDettagli = (AltriDettagli)reader.GetInt32(7)
						};
						result.Add(item);
					}
				}
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); }
			finally { connection.Close(); }


			return result;
		}

		public void ModificaPrenotazione(Prenotazione p)
		{
			throw new NotImplementedException();
		}
	}
}
