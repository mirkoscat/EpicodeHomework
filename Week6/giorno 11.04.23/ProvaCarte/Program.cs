using System.Numerics;

namespace ProvaCarte
{
    internal class Program
    {//devo gestire un mazzo di carte, ogni carta ha un valore e un seme
        //si crea la classe carta con le due proprietà
        //si crea la classe mazzo con un con IEnumerator di tipo carta
        //si crea la classe giocatore con un mazzo di carte
        //per creare il mazzo si crea un metodo che crea un mazzo di carte
        //delego il giocatore per creare un mazzo di carte?
        //si crea un metodo che mischia il mazzo
        //si crea un metodo che distribuisce le carte. si ha in input il mazzo mischiato e la quantità di carte da distribuire. il return sarà una lista di carte
        class Carte
        {
            public int Valore { get; set; }
            public string Seme { get; set; }
        }
        class MazzoDiCarte { 
        //elenco di carte
        public List<Carte> Carte { get; set; }
            //metodo che crea un mazzo di carte
            public void CreaMazzo()
            {
                Carte = new List<Carte>();
                for (int i = 1; i <= 13; i++)
                {
                    Carte.Add(new Carte { Valore = i, Seme = "Mazze" });
                    Carte.Add(new Carte { Valore = i, Seme = "Oro" });
                    Carte.Add(new Carte { Valore = i, Seme = "Coppe" });
                    Carte.Add(new Carte { Valore = i, Seme = "Spade" });
                }
            }
            // metodo che mischia il mazzo
            public void MischiaMazzo()
            {
                Random rnd = new Random();
                for (int i = 0; i < Carte.Count; i++)
                {
                    int j = rnd.Next(0, Carte.Count);
                    Carte temp = Carte[i];
                    Carte[i] = Carte[j];
                    Carte[j] = temp;
                }
            }
 
            public List<Carte> DistribuisciCarte(int numeroCarte)
            {
                List<Carte> carteDistribuite = new List<Carte>();
                for (int i = 0; i < numeroCarte; i++)
                {
                    carteDistribuite.Add(Carte[i]);
                    Carte.RemoveAt(i);
                }
                return carteDistribuite;
            }

        }
        class Giocatore {
            public string Nome { get; set; }
            public MazzoDiCarte Mazzo { get; set; }
            public Giocatore(string nome)
            {
                Nome = nome;
                Mazzo = new MazzoDiCarte();
                Mazzo.CreaMazzo();
            }

        }

        //creo un layer partita, con due giocatori, che si mischiano il mazzo a vicenda e poi si distribuiscono le carte
        class Partita
        {
            public Giocatore Giocatore1 { get; set; }
            public Giocatore Giocatore2 { get; set; }
            public Partita(Giocatore giocatore1, Giocatore giocatore2)
            {
                Giocatore1 = giocatore1;
                Giocatore2 = giocatore2;
            }
            public void Gioca()
            {
                Giocatore1.Mazzo.MischiaMazzo();
                Giocatore2.Mazzo.MischiaMazzo();
                List<Carte> carteDistribuite = Giocatore1.Mazzo.DistribuisciCarte(5);
                foreach (var carta in carteDistribuite)
                {
                    Giocatore2.Mazzo.Carte.Add(carta);
                }
                carteDistribuite = Giocatore2.Mazzo.DistribuisciCarte(5);
                foreach (var carta in carteDistribuite)
                {
                    Giocatore1.Mazzo.Carte.Add(carta);
                }
            
            }
        }
        static void Main(string[] args)
        {
       
            Partita p = new Partita(new Giocatore("Mario"), new Giocatore("Luigi"));
            p.Gioca();
            ////stampo il mazzo di carte del giocatore 1
            //Console.WriteLine("--------------------");
            //Console.WriteLine("Mazzo di carte del giocatore 1");
            //foreach (var carta in p.Giocatore1.Mazzo.Carte)
            //{
            //    Console.WriteLine($"{carta.Valore} di {carta.Seme}");
            //}
            Console.WriteLine($"Carte in mano di {p.Giocatore1.Nome}");

            //stampare le prime 5 carte distribuite al giocatore 1

            foreach (var carta in p.Giocatore1.Mazzo.Carte.Take(5))
            {
                Console.WriteLine($"{carta.Valore} di {carta.Seme}");
            }

            Console.WriteLine($"Carte in mano di {p.Giocatore2.Nome}");

            foreach (var carta in p.Giocatore2.Mazzo.Carte.Take(5))
            {
                Console.WriteLine($"{carta.Valore} di {carta.Seme}");
            }

        }
    }
}