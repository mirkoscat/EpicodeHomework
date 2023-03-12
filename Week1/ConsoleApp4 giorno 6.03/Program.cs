using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    internal class Program
    {
        //CLASSE ATLETA
        public class Atleta
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public int Eta { get; set; }
            public string Sport { get; set; }

            public void StampaDescrizione()
            {
                Console.WriteLine("Nome: {0}, Cognome: {1}, Età: {2}, Sport: {3}", Nome, Cognome, Eta, Sport);
            }
        }
        //CLASSE Dipendente
        public class Dipendente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public int Eta { get; set; }
            public string Matricola { get; set; }
            public int Anzianita { get; set; }

            public void StampaDescrizione()
            {
                Console.WriteLine("Nome: {0}, Cognome: {1}, Età: {2}, Matricola: {3}, Anni di anzianità: {4}", Nome, Cognome, Eta, Matricola, Anzianita);
            }
        }

        //CLASSE Animale
        public class Animale
        {
            public string Nome { get; set; }
            public string Razza { get; set; }
            public string Ambiente { get; set; }
            public string Nutrizione { get; set; }


            public void StampaDescrizione()
            {
                Console.WriteLine("Nome: {0}, Razza: {1}, Ambiente preferito: {2}, Tipo di Nutrizione: {3}", Nome, Razza, Ambiente, Nutrizione);
            }
        }
        //CLASSE Veicolo
        public class Veicolo
        {
            public string Marca { get; set; }
            public string Modello { get; set; }
            public int Anno { get; set; }
            public string Colore { get; set; }


            public void StampaDescrizione()
            {
                Console.WriteLine("Marca: {0}, Modello: {1}, Anno: {2}, Colore: {3}", Marca, Modello, Anno, Colore);
            }
        }
        static void Main(string[] args)
        {//inizializzo gli oggetti. formattazione automatica dell'IDE
            Atleta atleta1 = new()
            {
                Nome = "Mario",
                Cognome = "Rossi",
                Eta = 25,
                Sport = "Calcio"
            };
            
            Dipendente dipendente1 = new()
            {
                Nome = "Enzo",
                Cognome = "Verdi",
                Eta = 40,
                Matricola = "A0003321AB",
                Anzianita = 5
             };

            Animale animale1 = new()
            {
                Nome = "Orso bruno",
                Razza = "Orsi",
                Ambiente = "Foresta",
                Nutrizione = "Onnivoro"

            };
            Veicolo veicolo1 = new()
            {
                Marca = "Mercedes",
                Modello= "A1",
                Anno = 2010,
                Colore = "Blu"

            };
            //richiamo metodi
            atleta1.StampaDescrizione();
            dipendente1.StampaDescrizione();
            animale1.StampaDescrizione();
            veicolo1.StampaDescrizione();
        }
    }
}