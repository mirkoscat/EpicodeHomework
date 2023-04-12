
class Program
{

    // Classe per rappresentare un comune italiano
    class Comune
    {
        public string Nome { get; set; }
        public string Provincia { get; set; }
        public string Regione { get; set; }
    }
    static void Main(string[] args)
    {  //per semplificare, ho eliminato le colonne non utilizzate dal DB.csv
        // Leggi le righe dal file dei comuni italiani
        string[] linee = File.ReadAllLines("C:\\Users\\icesa\\Desktop\\ListaComuni\\elencocomuni.csv");

        // Crea una lista di Comune utilizzando LINQ
        List<Comune> comuni = (
            from linea in linee
            let campi = linea.Split(';')
            select new Comune
            {
                Nome = campi[0],
                Regione = campi[1],
                Provincia = campi[2]
            }
        ).ToList();
      

        // Esempio di query LINQ sulla lista dei comuni italiani
        var comuniSicilia = (
                from comune in comuni
                where comune.Regione == "Sicilia"
                select comune
            ).ToList();

            // Stampa i comuni della Sicilia
            Console.WriteLine("Comuni in Sicilia:");
            foreach (var comune in comuniSicilia)
            {
                Console.WriteLine($"{comune.Nome} ({comune.Provincia})");
            }
        //stampare tutta la lista dei comuni
        foreach (var comune in comuni)
        {
            Console.WriteLine($"Comune:{comune.Nome} ({comune.Provincia}). Regione: {comune.Regione}");
        }
    }
    }



