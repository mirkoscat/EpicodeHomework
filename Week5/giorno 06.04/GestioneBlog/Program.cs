/*
 un blog è costituito da articoli, creati da un utente,
 si possono leggere articoli degli altri utenti e modificare i propri

 Un articolo è costituito da un titolo, un contenuto, una data di creazione e autore
possono essere associati commenti che riportano autore e testo
BLOG
 - articoli
      -id  -titolo stringa(80), contenuto stringa(1024), data creazione DateTime, autore ->Utente fk_autore ->utente.id
 - commento
     -id -articolo->Articolo  fk_articoloid -> articolo.id -autore stringa(15) -> UTENTE, testo stringa(1024), data
- utente
  -id -username stringa(15),password stringa(15)
 Analisi operazioni      competenza         input                 output
- creazione articolo       utente           datiarticolo
- leggi articoli           utente                                 visualizzare tutti i titoli
- lettura articolo         utente           id                    visualizzare articolo
- modifica articolo        utente           id e dati articolo
-eliminazione articolo     utente           id 
- creazione commento       utente           dati commento
 */

namespace GestioneBlog
{
    internal class Program
    {
        static void Menu()
        {
            ServizioGestioneArticoli s = new ServizioGestioneArticoli();
            
            string[] opzioni = { "Leggi articoli", "Leggi articolo 10", "Modifica articoli", "Elimina articolo", "Crea articolo impostato", "crea commento", "Esci" };
            while (true)
            {
                Console.WriteLine("Scegli un'opzione");
                for (int i = 0; i < opzioni.Length; i++)
                {
                    Console.WriteLine($"{i + 1}\t{opzioni[i]}");
                }
                Console.Write($"Scegli (1..{opzioni.Length}): ");
                string risposta = Console.ReadLine();
                switch (risposta[0])
                {
                    case '1':
                        Console.WriteLine("Articoli");
                        s.LeggiArticoli();
                        Console.WriteLine("---------------------");
                        break;
                    case '2':
                        s.LeggiArticolo(10);
                        Console.WriteLine("---------------------");
                        break;

                    case '3':
                        s.ModificaArticolo(9, "titolomod", "contenutomod", DateTime.Now, 3);
                        break;
                    case '4':
                        //l'articolo viene eliminato in locale ma non sul db :(
                        s.EliminaArticolo(12);
                        //s.EliminaArticolo();
                        break;
                    case '5':
                        s.CreaArticolo("titolo", "contenuto", DateTime.Now, 4);
                        break;
                    case '6':
                        s.CommentaArticolo(10,3,"commento_art10", DateTime.Now);
                        break;
                    default:
                        return;
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}