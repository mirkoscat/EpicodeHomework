using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using SitoSpedizioni.Models;
using SitoSpedizioni.Models.Entities;

namespace SitoSpedizioni.Service
{
	public class SpedizioniService
	{
		private SqlConnection connection = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=SitoSpedizioni;TrustServerCertificate=true; Trusted_Connection=True;Integrated Security=True");/*TrustServerCertificate=true*/
		private const string SELECT_ALL = "SELECT  IDspedizione,DataSpedizione,Peso, CittaDestinataria,Costo, DataPrevistaArrivo,spedizioni.IDanagrafe,Status , nome, cognome, is_privato,indirizzo , codicefiscale, partitaiva FROM Spedizioni join anagrafe on spedizioni.idanagrafe = anagrafe.idanagrafe ";
		// Individuare tutte le spedizioni in consegna nella data odierna

		private const string query1 = "SELECT IDspedizione,DataSpedizione,Peso,CittaDestinataria,Costo,spedizioni.idanagrafe,nome FROM Spedizioni join anagrafe on spedizioni.idanagrafe = anagrafe.idanagrafe";
		// Conoscere il numero delle spedizioni totali in attesa di consegna
		private const string query2 = "SELECT COUNT(IDspedizione)  FROM Spedizioni where Status = '0' ";
		// Conoscere il numero totale delle spedizioni memorizzate raggruppate per città destinataria
		private const string query3 = "SELECT  COUNT(IDspedizione) , CittaDestinataria FROM Spedizioni Group BY CittaDestinataria";


		private const string INSERT_SPEDIZIONE = " INSERT INTO Spedizioni (DataSpedizione,Peso, CittaDestinataria, Costo, DataPrevistaArrivo,IDanagrafe,Status) VALUES ( @dataspedizione, @peso, @cittadestinataria,@costo,  @dataprevistaarrivo,@idanagrafe,@status) ";
		private const string UPDATE_SPEDIZIONE = "UPDATE Spedizioni SET IDspedizione=@idspedizione, DataSpedizione = @dataspedizione, peso = @peso, cittadestinataria = @cittadestinataria, costo = @costo, dataprevistaarrivo = @dataprevistaarrivo , status=@status WHERE IDanagrafe = @id";
		private const string DELETE_SPEDIZIONE = "DELETE  FROM Spedizioni WHERE IDspedizione = @id";
		private static List<Spedizioni> spedizioni;
		public IEnumerable<Spedizioni> GetAll()
		{
			var result = new List<Spedizioni>();
			var select = connection.CreateCommand();
			select.CommandText = SELECT_ALL;
			connection.Open();
			using (var reader = select.ExecuteReader())
			{
				while (reader.Read())
				{
					var item = new Spedizioni
					{
						IDspedizione = reader.GetInt32(0),
						DataSpedizione = reader.GetDateTime(1),
						Peso = reader.GetInt32(2),
						CittaDestinataria = reader.GetString(3),
						Costo = reader.GetInt32(4),
						DataPrevistaArrivo = reader.GetDateTime(5),
						IDanagrafe = reader.GetInt32(6),
						Status = reader.GetInt32(7),

					};
					result.Add(item);
				}
			}
			connection.Close();
			return result;
		}


		public Spedizioni GetById(int id)
		{
			var result = new Spedizioni();
			try
			{
				var select = connection.CreateCommand();
				select.CommandText = SELECT_ALL + " WHERE IDspedizione = @id";
				select.Parameters.AddWithValue("@id", id);
				connection.Open();
				using (var reader = select.ExecuteReader())
				{
					while (reader.Read())
					{
						result.IDspedizione = reader.GetInt32(0);
						result.DataSpedizione = reader.GetDateTime(1);
						result.Peso = reader.GetInt32(2);
						result.CittaDestinataria = reader.GetString(3);
						result.Costo = reader.GetInt32(4);
						result.DataPrevistaArrivo = reader.GetDateTime(5);
						result.IDanagrafe = reader.GetInt32(6);
						result.Status = reader.GetInt32(7);

					}
				}
			}
			catch { }
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
			return result;
		}
		public bool CancellaSpedizione(int id)
		{
			try
			{
				connection.Open();
				var delete = connection.CreateCommand();
				delete.CommandText = DELETE_SPEDIZIONE;
				delete.Parameters.AddWithValue("@id", id);
				var result = delete.ExecuteNonQuery();
				return result == 1;
			}
			catch
			{
				return false;
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
		}
		public bool CambiaSpedizione(Spedizioni viewModel)
		{
			try
			{
				connection.Open();
				var update = connection.CreateCommand();
				update.CommandText = UPDATE_SPEDIZIONE;
				update.Parameters.AddWithValue("@idspedizione", viewModel.IDspedizione);
				update.Parameters.AddWithValue("@dataspedizione", viewModel.DataSpedizione);
				update.Parameters.AddWithValue("@peso", viewModel.Peso);
				update.Parameters.AddWithValue("@cittadestinataria", viewModel.CittaDestinataria);
				update.Parameters.AddWithValue("@costo", viewModel.Costo);
				update.Parameters.AddWithValue("@dataprevistaarrivo", viewModel.DataPrevistaArrivo);
				update.Parameters.AddWithValue("@status", viewModel.Status);
				var result = update.ExecuteNonQuery();
				return result == 1;
			}
			catch
			{
				return false;
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
		}

		public bool CreaSpedizione(Spedizioni viewModel)
		{
			try
			{
				connection.Open();
				var insert = connection.CreateCommand();
				insert.CommandText = INSERT_SPEDIZIONE;

				//insert.Parameters.AddWithValue("@idspedizione", viewModel.IDspedizione);
				insert.Parameters.AddWithValue("@dataspedizione", viewModel.DataSpedizione);
				insert.Parameters.AddWithValue("@peso", viewModel.Peso);
				insert.Parameters.AddWithValue("@cittadestinataria", viewModel.CittaDestinataria);
				insert.Parameters.AddWithValue("@costo", viewModel.Costo);
				insert.Parameters.AddWithValue("@dataprevistaarrivo", viewModel.DataPrevistaArrivo);
				insert.Parameters.AddWithValue("@idanagrafe", viewModel.IDanagrafe);
				insert.Parameters.AddWithValue("@status", viewModel.Status);


				var result = insert.ExecuteNonQuery();
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if (connection.State == System.Data.ConnectionState.Open)
				{
					connection.Close();
				}
			}
		}

		public IEnumerable<Spedizioni> ExecQuery1()
		{
			var result = new List<Spedizioni>();
			var select = connection.CreateCommand();
			select.CommandText = query1;
			connection.Open();
			using (var reader = select.ExecuteReader())
			{
				while (reader.Read())
				{
					var item = new Spedizioni
					{
						IDspedizione = reader.GetInt32(0),
						DataSpedizione = reader.GetDateTime(1),
						Peso = reader.GetInt32(2),
						CittaDestinataria = reader.GetString(3),
						Costo = reader.GetInt32(4),
						IDanagrafe = reader.GetInt32(5)

					};
					result.Add(item);
				}
			}
			connection.Close();
			return result;
		}
		public int ExecQuery2()
		{
			var result = new List<Spedizioni>();
			var select = connection.CreateCommand();
			select.CommandText = query2;
			connection.Open();
			using (var reader = select.ExecuteReader())
			{
				while (reader.Read())
				{
					var item = new Spedizioni
					{
						IDspedizione = reader.GetInt32(0)

					};
					result.Add(item);
				}
			}
			connection.Close();
			return result.Count();

		}


		public IEnumerable<Spedizioni> ExecQuery3()
		{
			var result = new List<Spedizioni>();
			var select = connection.CreateCommand();
			select.CommandText = query3;
			connection.Open();
			using (var reader = select.ExecuteReader())
			{
				while (reader.Read())
				{
					var item = new Spedizioni
					{
						IDspedizione = reader.GetInt32(0),
						CittaDestinataria = reader.GetString(1)

					};
					result.Add(item);
				}
			}
			connection.Close();
			return result;

		}

		public IEnumerable<AggiornamentoSpedizione> VerificaSpedizione(int id, string cod)
		{
			var result = new List<AggiornamentoSpedizione>();

			var select = connection.CreateCommand();
			
			select.CommandText = "SELECT s.LuogoDiTransito, s.OraDiTransito, s.DescrizioneDiTransito, s.IDspedizione, a.CodiceFiscale, a.PartitaIva FROM aggiornamentospedizione AS s JOIN anagrafe AS a ON s.IDanagrafe = a.IDanagrafe";
			select.Parameters.AddWithValue("@id", id);
			select.Parameters.AddWithValue("@cod", cod);
			try
			{
				connection.Open();
				
				using (var reader = select.ExecuteReader())
				{
					while (reader.Read())
					{
						var item = new AggiornamentoSpedizione
						{
							LuogoDiTransito = reader.GetString(0),
							OraDiTransito = reader.GetDateTime(1),
							DescrizioneDiTransito = reader.GetString(2),
							IDSpedizione = reader.GetInt32(3),
							Anagrafe = new Anagrafe
							{
								CodiceFiscale = reader.GetString(4),
								PartitaIva = reader.GetString(5)
							}
						};
						result.Add(item);
					}
				}

				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally { connection.Close(); }
			var result2 = result.Where(x => x.IDSpedizione == id && x.Anagrafe.CodiceFiscale == cod);
			return result2;
		}


	}



}