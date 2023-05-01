using Ecommerce.Models;
using Ecommerce.Models.Entities;
using Microsoft.Data.SqlClient;

namespace Ecommerce.Services
{
    public class ServizioProdotto : IServizioProdotto
    {
        private readonly SqlConnection connection;
        private const string SELECT_ALL = "SELECT  IdProdotto,Nome,Immagine,Prezzo,Descrizione,DescrAggiuntiva,InStock FROM Prodotto";
     
        private const string INSERT_PRODOTTO = "INSERT INTO PRODOTTO (Nome,Immagine,Prezzo,Descrizione,DescrAggiuntiva,InStock)VALUES(@nome,@immagine,@prezzo,@descrizione,@descragg,@instock)";
        private const string UPDATE_PRODOTTO = "UPDATE Prodotto SET Nome = @nome, Immagine = @immagine, Prezzo = @prezzo, Descrizione = @descrizione, DescrAggiuntiva = @descragg, InStock = @instock WHERE IdProdotto = @id";

        public ServizioProdotto(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DbConnection"));
        }


        public bool CreaProdotto(Prodotto p)
        {

            try
            {
                connection.Open();
                var insert = connection.CreateCommand();
                insert.CommandText = INSERT_PRODOTTO;

                insert.Parameters.AddWithValue("@nome", p.Nome);
                insert.Parameters.AddWithValue("@immagine", p.Immagine);
                insert.Parameters.AddWithValue("@prezzo", p.Prezzo);
                insert.Parameters.AddWithValue("@descrizione", p.Descrizione);
                insert.Parameters.AddWithValue("@descragg", p.DescrAggiuntiva);
                insert.Parameters.AddWithValue("@instock", p.InStock);

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

        public bool EliminaProdotto(int id)
        {

                connection.Open();
                var delete = connection.CreateCommand();
                delete.CommandText = "DELETE  FROM Prodotto WHERE IdProdotto = @id ";

                delete.Parameters.AddWithValue("@id", id);
                var i= delete.ExecuteNonQuery();
                connection.Close();
				if (i >= 1)
				{
					return true;
				}
				else
				{

					return false;
				}
				
        }

        public IEnumerable<Prodotto> GetAll()
        {
            var result = new List<Prodotto>();
            var cmd = connection.CreateCommand();
            cmd.CommandText = SELECT_ALL;
            connection.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new Prodotto
                    {
                        IdProdotto = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Immagine = reader.GetString(2),
                        Prezzo = reader.GetDecimal(3),
                        Descrizione = reader.GetString(4),
                        DescrAggiuntiva = reader.IsDBNull(5) ? "vuoto" : reader.GetString(5),
                        InStock = (Stock)(reader.IsDBNull(6) ? 0 : reader.GetInt32(6))


                    };
                    result.Add(item);
                }
            }
            connection.Close();
            return result;

        }

        public Prodotto GetProdottoById(int id)
        {
            var result = new Prodotto();
            try
            {
                var select = connection.CreateCommand();
                select.CommandText = SELECT_ALL + " WHERE IdProdotto = @id";
                select.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.IdProdotto = reader.GetInt32(0);
                        result.Nome = reader.GetString(1);
                        result.Immagine = reader.GetString(2);
                        result.Prezzo = reader.GetDecimal(3);
                        result.Descrizione = reader.GetString(4);
                        result.DescrAggiuntiva = reader.IsDBNull(5) ? "X" : reader.GetString(5);
                        result.InStock = reader.GetBoolean(6) ? Stock.OutOfStock : Stock.InStock;
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


        public bool ModificaProdotto(Prodotto p)
        {
            connection.Open();
            var update = connection.CreateCommand();
            update.CommandText = UPDATE_PRODOTTO;
            update.Parameters.AddWithValue("@nome", p.Nome);
            update.Parameters.AddWithValue("@immagine", p.Immagine);
            update.Parameters.AddWithValue("@prezzo", p.Prezzo);
            update.Parameters.AddWithValue("@descrizione", p.Descrizione);
            update.Parameters.AddWithValue("@descragg", p.DescrAggiuntiva);
            update.Parameters.AddWithValue("@instock", p.InStock);
            update.Parameters.AddWithValue("@id", p.IdProdotto);
            var result = update.ExecuteNonQuery();
            connection.Close() ;
            return result == 1;

        }

  //      public int GetIdProdotto(string nome) { 
        
        
  //          int idProdotto = 0;
		//	connection.Open();
		//	var prodCmd = connection.CreateCommand();
		//	prodCmd.CommandText = "SELECT IdProdotto FROM Prodotto  where Nome= @prodotto";
  //          prodCmd.Parameters.AddWithValue("@prodotto", nome);
		//	idProdotto = (int)prodCmd.ExecuteScalar();
		//	connection.Close();
		//	return idProdotto;
		
		//}

    }
}
