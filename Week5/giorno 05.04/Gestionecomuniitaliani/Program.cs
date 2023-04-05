using System.Data;
using System.Data.SqlClient;
using Gestionecomuniitaliani.Servizi;

namespace Gestionecomuniitaliani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDbConnection dbConnection = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=ComuniItaliani;Integrated Security=True");
            ServiziGestioneComuniItaliani servizio = new ServiziGestioneComuniItaliani { Connection = dbConnection };
            Console.WriteLine("Comuni che terminano con la stringa «oma»");
            servizio.VisualizzaComuni("%oma");
            Console.WriteLine("Comuni della provincia di Catania");
            servizio.VisualizzaComuniCT("CT");
           

        }
    }
}