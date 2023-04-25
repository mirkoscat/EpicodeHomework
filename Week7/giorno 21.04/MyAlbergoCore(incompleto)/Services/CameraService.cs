using GestioneAlbergo.Models.Entities;
using Microsoft.Data.SqlClient;

namespace MyAlbergoCore.Services
{
	public class CameraService : ICameraService
	{
		private SqlConnection connection = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=GestioneAlbergo;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");

		public void AggiungiCamera(Camera c)
		{

			var insert = connection.CreateCommand();
			insert.CommandText = "Insert into Camera (Descrizione,Tipologia,IdCliente) values (@Descrizione, @Tipologia, @Email, @CodiceFiscale, @Telefono, @Cellulare, @Citta, @Provincia)";
			insert.Parameters.AddWithValue("@Descrizione", c.Descrizione);
			insert.Parameters.AddWithValue("@Descrizione", c.Descrizione);
			insert.Parameters.AddWithValue("@Tipologia", c.Tipologia);
			insert.Parameters.AddWithValue("@IdCliente", c.IdCliente);
			
			connection.Open();
			insert.ExecuteNonQuery();
			connection.Close();
		}

		public IEnumerable<Camera> GetCamere()
		{
			var result = new List<Camera>();
		//faccio la query
		var select = connection.CreateCommand();
			select.CommandText = "SELECT IdCamera, Descrizione, Tipologia, IdCliente FROM Camera";
			try
			{
				/*
				 Microsoft.Data.SqlClient.SqlException: 'A connection was successfully established with the server, 
				but then an error occurred during the login process. (provider: SSL Provider, error: 0 - 
				Catena di certificati emessa da una Autorità di certificazione non disponibile nell'elenco locale.)'
				 */
				connection.Open();//errore
				using (var reader = select.ExecuteReader())
				{
					while (reader.Read())
					{
						var item = new Camera
						{
							IdCamera = reader.GetInt32(0),
							Descrizione = reader.GetString(1),
							Tipologia = (TipologiaCamera)reader.GetInt32(2),
							IdCliente = reader.GetInt32(3),
						};
						result.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Errore nel recupero dei dati", ex);
			}
			finally
			{
				connection.Close();
			}
			return result;
		}

		public void ModificaCamera(Camera c)
		{
			//query per modificare una camera
			var update = connection.CreateCommand();
			update.CommandText = "UPDATE Camera SET Descrizione = @Descrizione, Tipologia = @Tipologia, IdCliente = @IdCliente WHERE IdCamera = @IdCamera";
			update.Parameters.AddWithValue("@IdCamera", c.IdCamera);
			update.Parameters.AddWithValue("@Descrizione", c.Descrizione);
			update.Parameters.AddWithValue("@Tipologia", c.Tipologia);
			update.Parameters.AddWithValue("@IdCliente", c.IdCliente);
			connection.Open();
			update.ExecuteNonQuery();
			connection.Close();

		}
	}
}
