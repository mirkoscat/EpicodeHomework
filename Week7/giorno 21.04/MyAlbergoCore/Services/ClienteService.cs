using GestioneAlbergo.Models.Entities;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyAlbergoCore.Services
{
	public class ClienteService : IClienteService
	{

		private SqlConnection connection = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=GestioneAlbergo;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");
		public void AggiungiCliente(Cliente c)
		{

			var insert = connection.CreateCommand();
			insert.CommandText = "Insert into Cliente (Nome, Cognome, Email, CodiceFiscale, Telefono, Cellulare, Citta, Provincia) values (@Nome, @Cognome, @Email, @CodiceFiscale, @Telefono, @Cellulare, @Citta, @Provincia)";
			insert.Parameters.AddWithValue("@Nome", c.Nome);
			insert.Parameters.AddWithValue("@Cognome", c.Cognome);
			insert.Parameters.AddWithValue("@Email", c.Email);
			insert.Parameters.AddWithValue("@CodiceFiscale", c.CodiceFiscale);
			insert.Parameters.AddWithValue("@Telefono", c.Telefono);
			insert.Parameters.AddWithValue("@Cellulare", c.Cellulare);
			insert.Parameters.AddWithValue("@Citta", c.Citta);
			insert.Parameters.AddWithValue("@Provincia", c.Provincia);
			connection.Open();
			insert.ExecuteNonQuery();
			connection.Close();

		}

		public List<Cliente> GetClienti()
		{
			var result = new List<Cliente>();

			var select = connection.CreateCommand();
			select.CommandText = "SELECT IdCliente, Nome, Cognome, Email, CodiceFiscale, Telefono, Cellulare, Citta, Provincia FROM Cliente";
			try
			{
				connection.Open();
				using (var reader = select.ExecuteReader())
				{
					while (reader.Read())
					{
						var item = new Cliente
						{
							IdCliente = reader.GetInt32(0),
							Nome = reader.GetString(1),
							Cognome = reader.GetString(2),
							Email = reader.GetString(3),
							CodiceFiscale = reader.GetString(4),
							Telefono = reader.IsDBNull(5) ? "000" : reader.GetString(5),
							Cellulare = reader.GetString(6),
							Citta = reader.GetString(6),
							Provincia = reader.GetString(6),

						};
						result.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally { connection.Close(); }

			return result;
		}

		public void ModificaCliente(Cliente c)
		{
			//query per modificare un cliente
			var update = connection.CreateCommand();
			update.CommandText = "Update Cliente set Nome=@Nome, Cognome=@Cognome, Email=@Email, CodiceFiscale=@CodiceFiscale, Telefono=@Telefono, Cellulare=@Cellulare, Citta=@Citta, Provincia=@Provincia where IdCliente=@IdCliente";
			update.Parameters.AddWithValue("@IdCliente", c.IdCliente);
			update.Parameters.AddWithValue("@Nome", c.Nome);
			update.Parameters.AddWithValue("@Cognome", c.Cognome);
			update.Parameters.AddWithValue("@Email", c.Email);
			update.Parameters.AddWithValue("@CodiceFiscale", c.CodiceFiscale);
			update.Parameters.AddWithValue("@Telefono", c.Telefono);
			update.Parameters.AddWithValue("@Cellulare", c.Cellulare);
			update.Parameters.AddWithValue("@Citta", c.Citta);
			update.Parameters.AddWithValue("@Provincia", c.Provincia);
			connection.Open();
			update.ExecuteNonQuery();
			connection.Close();

		}
	}


}
