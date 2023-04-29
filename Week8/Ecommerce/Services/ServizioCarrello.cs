using Ecommerce.Models.Entities;
using Microsoft.Data.SqlClient;

namespace Ecommerce.Services
{
    public class ServizioCarrello : IServizioCarrello
    {
        private readonly SqlConnection connection;

        private const string SELECT_ALL = "SELECT  IdCarrello,IdCliente,IsOpen,DataApertura,ImportoTotale FROM Carrello";
        private const string CREA_CARRELLO = "INSERT INTO Carrello (IdCliente,IsOpen,DataApertura)VALUES(@idcliente,@isopen,@dataapertura) ";
        public ServizioCarrello(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DbConnection"));
        }

        public void CreaCarrello()
        {
            var idcarrello = GetIdCarrelloAttuale();

            if (idcarrello == 0)
            {
                Carrello carrello = new Carrello();
                carrello.IdCliente = 1;
                carrello.IsOpen = true;
                carrello.DataApertura = DateTime.Now;
                connection.Open();
                var insert = connection.CreateCommand();
                insert.CommandText = CREA_CARRELLO;

                insert.Parameters.AddWithValue("@idcliente", carrello.IdCliente);
                insert.Parameters.AddWithValue("@isopen", carrello.IsOpen);
                insert.Parameters.AddWithValue("@dataapertura", carrello.DataApertura);
                var result = insert.ExecuteNonQuery();
                connection.Close();
            }

        }

      

        public IEnumerable<CarrelloProdotto> GetProdottiInCarrello(int id)
        {
             var result = new List<CarrelloProdotto>();
            var cmd = connection.CreateCommand();

            cmd.CommandText = "select p.Nome, Quantita, p.Prezzo, Quantita*P.Prezzo as totale  from CarrelloProdotto cp join Prodotto p on cp.IdProdotto = p.IdProdotto join Carrello c on cp.IdCarrello = c.IdCarrello where c.IdCarrello=@id";
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //int idcarrello = Convert.ToInt32(reader["IdCarrello"]);
                    //string nome = Convert.ToString(reader["Nome"]);//nome del campo

                    var item = new CarrelloProdotto
                    {
                        Carrello = new Carrello
                        {
                            ImportoTotale = reader.GetDecimal(3)
                        },
                        Prodotto = new Prodotto
                        {
                            Nome = reader.GetString(0),
                            Prezzo = reader.GetDecimal(2),
                        },
                        Quantita = reader.GetInt32(1)
                    };
                    result.Add(item);
                }
            }
            connection.Close();
            return result;

        }

        public int GetIdCarrelloAttuale()
        {
            int idCarrello = -1;

            connection.Open();

            var carrelloCmd = connection.CreateCommand();
            //carrello solo del primo cliente
            carrelloCmd.CommandText = "SELECT IdCarrello FROM Carrello WHERE IsOpen = 1 and IdCliente = 1";

            using (var reader = carrelloCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    idCarrello = reader.GetInt32(0);

                }
            }

            connection.Close();

            // Se non ho trovato un carrello aperto, ne creo uno nuovo
            if (idCarrello == -1)
            {
                CreaCarrello();
                idCarrello = GetIdCarrelloAttuale();
            }

            return idCarrello;
        }

        public void AggiungiProdottoAlCarrello(int carrello, int prodotto, int quantita)

        {//vedere se esiste già il prodotto nel carrello
            var select = connection.CreateCommand();
            select.CommandText = "SELECT Quantita FROM CarrelloProdotto WHERE IdCarrello = @idcarrello AND IdProdotto = @idprodotto";
            select.Parameters.AddWithValue("@idcarrello", carrello);
            select.Parameters.AddWithValue("@idprodotto", prodotto);
            connection.Open();
            var result = select.ExecuteReader();
           

            if (result.Read())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE CarrelloProdotto SET Quantita = @quantita WHERE IdCarrello = @idcarrello AND IdProdotto = @idprodotto";
                cmd.Parameters.AddWithValue("@idcarrello", carrello);
                cmd.Parameters.AddWithValue("@idprodotto", prodotto);
                cmd.Parameters.AddWithValue("@quantita", quantita);
               
                cmd.ExecuteNonQuery();
               
            }
            else
            {
                
                var insert = connection.CreateCommand();
                insert.CommandText = "INSERT INTO CarrelloProdotto (IdCarrello,IdProdotto,Quantita) VALUES (@idcarrello,@idprodotto,@quantita)";
                insert.Parameters.AddWithValue("@idcarrello", carrello);
                insert.Parameters.AddWithValue("@idprodotto", prodotto);
                insert.Parameters.AddWithValue("@quantita", quantita);
              
                insert.ExecuteNonQuery();
               
            }
            connection.Close();
        }

        public List<Carrello> GetCarrelli()
        {

            var result = new List<Carrello>();
            var cmd = connection.CreateCommand();
            cmd.CommandText = SELECT_ALL;
            connection.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new Carrello
                    {
                        IdCarrello = reader.GetInt32(0),
                        IdCliente = reader.GetInt32(1),
                        IsOpen = reader.IsDBNull(2) ? false : reader.GetBoolean(2),
                        DataApertura = reader.IsDBNull(2) ? DateTime.Today : reader.GetDateTime(3),
                        ImportoTotale = reader.IsDBNull(2) ? 0 : reader.GetDecimal(4)


                    };
                    result.Add(item);
                }
            }
            connection.Close();
            return result;
        }
        public  int IncrementaQuantita(int idcarrello, int idprodotto) {

            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE CarrelloProdotto SET Quantita = Quantita + 1 WHERE IdCarrelloProdotto = @idCarrelloProdotto";
            cmd.Parameters.AddWithValue("@idCarrelloProdotto", idcarrello);
            var nuovaquantita = (int)cmd.ExecuteScalar();
            return nuovaquantita;
        
        }

        public void ModificaQuantita( int idcarrelloprodotto, int idcarrello, int idprodotto, int quantita)
        {
            var cmd = connection.CreateCommand();
            //query ok
            cmd.CommandText = "UPDATE CarrelloProdotto SET Quantita = 0 + @quantita WHERE IdCarrelloProdotto = @idCarrelloProdotto AND IdCarrello=@idcarrello AND IdProdotto=@idprodotto";
            cmd.Parameters.AddWithValue("@idCarrelloProdotto", idcarrelloprodotto);
			cmd.Parameters.AddWithValue("@idcarrello", idcarrello);
			cmd.Parameters.AddWithValue("@idprodotto", idprodotto);
            cmd.Parameters.AddWithValue("@quantita", quantita);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            
        }
    }

}
