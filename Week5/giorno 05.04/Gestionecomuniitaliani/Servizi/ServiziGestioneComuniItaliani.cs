using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Gestionecomuniitaliani.Dati;

namespace Gestionecomuniitaliani.Servizi
{
    internal class ServiziGestioneComuniItaliani
    { 
        public IDbConnection Connection { get; set; }

        const string SELECT = "select c.ID, c.Denominazione AS Citta, c.SiglaProvincia AS Sigla, c.Capoluogo, c.Catastale, p.Denominazione AS Provincia,r.ID as ID_Regione, r.Denominazione_regione As Regione, ri.Denominazione AS Ripartizione,ri.ID AS ID_Ripartizione from Comuni as c join Province as p on c.SiglaProvincia = p.Sigla join Regioni as r on p.ID_Regione = r.ID join Ripartizioni as ri on r.ID_Ripartizione = ri.ID WHERE c.Denominazione LIKE '%oma'";
        public void VisualizzaComuni(string partedelnome) {
            //se connessione=null uscire
            if (Connection == null) return;

            //1-collegarsi,
            Connection.Open();
            // crea comando
            IDbCommand select =Connection.CreateCommand();
            select.CommandText = SELECT;
            //crea parametro
            IDbDataParameter param = select.CreateParameter();
            param.ParameterName = "@nome";
            select.Parameters.Add(param);
            param.Value = partedelnome;
            IDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Comuni comune = new Comuni
                {
                    Id = reader.GetInt32(0),
                    Denominazione = reader.GetString(1),
                    SiglaProvincia = reader.GetString(2),
                    Capoluogo = reader.GetString(3)[0] == '1',
                    Catastale = reader.GetString(4),

                    Provincia = new Province
                    {
                        Sigla = reader.GetString(2),
                        Denominazione = reader.GetString(5), // ok
                        
                        Regione = new Regioni
                        {
                            Id = reader.GetInt32(6),
                            Denominazione = reader.GetString(7),
                            Ripartizione = new Ripartizioni
                            {
                                Id = reader.GetInt32(9),
                                Denominazione = reader.GetString(8),
                                
                            }
                        }
                    }
                };
                    Console.WriteLine(comune);
            };
            Connection.Close();

        }


            //2-inviare comando select,3-leggere i dati di un comune dai risultati
        //4- creare un oggetto di classe comune. 5-***visualizzare i dati, 6-chiudi DB
        }
    }

