namespace Contribuente_giorno_10._3
{/******************************************************************************
Scrivere una classe ‘Contribuente’ che abbia le seguenti proprietà: [Nome, Cognome, DataNascita, CodiceFiscale, Sesso, ComuneResidenza, RedditoAnnuale]; 
    costruire uno o più costruttori (a scelta del candidato) ed un metodo che applichi al reddito le seguenti aliquote per scaglioni e ne determini l’imposta da pagare:
SCAGLIONI DI REDDITO
Reddito da 0 a 15.000
Reddito da 15.001 a 28.000
Reddito da 28.001 a 55.000
Reddito da 55.001 a 75.000
Redduti oltre i 75.001

ALIQUOTA E IMPOSTA DOVUTA
aliquota 23%
3.450 + aliquota 27% sulla parte eccedente i 15.000
6.960 + 38% sulla parte eccedente i 28.000
17.220 + 41% sulla parte eccedente i 55.000
25.420 + 43% sulla parte eccedente i 75.000

Esecuzione del programma:
Il programma (console application) deve richiedere, uno per volta, tutte le proprietà del contribuente, che da tastiera verranno immesse e memorizzate nell’oggetto; 
infine proponga un risultato riepilogativo simile al seguente:

==================================================
CALCOLO DELL’IMPOSTA DA VERSARE:

Contribuente: Mario Rossi,
nato il 15/07/1961 (M),
residente in Palermo,
codice fiscale: MRORSI61LIKSNNNS

Reddito dichiarato: 17.850,00

IMPOSTA DA VERSARE: € 4.219,50
*******************************************************************************/

    using System;
 
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }
        public DateTime DataDiNascita { get; set; }

        // costruttore utile nel caso di simulazione senza input da tastiera
     public Contribuente(string nome, string cognome, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale, DateTime dataDiNascita)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = dataDiNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public Contribuente()
        {
        }

        public double CalcolaImposta()
        {
            double imposta = 0;

            if (RedditoAnnuale <= 15000)
            {
                imposta = RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale > 15000 && RedditoAnnuale <= 28000)
            {
                imposta = 3450 + (RedditoAnnuale - 15000) * 0.27;
            }
            else if (RedditoAnnuale > 28000 && RedditoAnnuale <= 55000)
            {
                imposta = 6960 + (RedditoAnnuale - 28000) * 0.38;
            }
            else if (RedditoAnnuale > 55000 && RedditoAnnuale <= 75000)
            {
                imposta = 17220 + (RedditoAnnuale - 55000) * 0.41;
            }
            else if (RedditoAnnuale > 75000)
            {
                imposta = 25420 + (RedditoAnnuale - 75000) * 0.43;
            }

            return imposta;
        }

        public void Stampa(Contribuente c, DateTime dn)
        {
            //calcolo l'imposta e riprendo il valore
            double imp = c.CalcolaImposta();
            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {c.Nome} {c.Cognome},");
            Console.WriteLine($"nato il {dn} ({c.Sesso}),");
            Console.WriteLine($"residente in {c.ComuneResidenza},");
            Console.WriteLine($"codice fiscale: {c.CodiceFiscale}");
            Console.WriteLine();
            Console.WriteLine($"Reddito dichiarato: € {c.RedditoAnnuale}");
            Console.WriteLine();
            Console.WriteLine($"IMPOSTA DA VERSARE: € {imp}");
            Console.WriteLine("==================================================");
        }
        //case 2 stampa
        public void Stampa(Contribuente c)
        {
            //calcolo l'imposta e riprendo il valore
            double imp = c.CalcolaImposta();
            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {c.Nome} {c.Cognome},");
            Console.WriteLine($"nato il {c.DataDiNascita} ({c.Sesso}),");
            Console.WriteLine($"residente in {c.ComuneResidenza},");
            Console.WriteLine($"codice fiscale: {c.CodiceFiscale}");
            Console.WriteLine();
            Console.WriteLine($"Reddito dichiarato: € {c.RedditoAnnuale}");
            Console.WriteLine();
            Console.WriteLine($"IMPOSTA DA VERSARE: € {imp}");
            Console.WriteLine("==================================================");
        }
        public DateTime chiediData() 
        {
            int g, m, a;
            // inserire data separatamente
            Console.WriteLine("Inserisci giorno di nascita:");
            g = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci mese di nascita");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci anno di nascita");
            a = int.Parse(Console.ReadLine());
            DateTime case1Data = new DateTime(a, m, g);
            return case1Data;
        }
        public void chiediDatiEStampa(Contribuente c)
        {
                Console.WriteLine("Inserisci  nome:");
                c.Nome = Console.ReadLine();

                Console.WriteLine("Inserisci cognome:");
                c.Cognome = Console.ReadLine();

                DateTime case1Data = c.chiediData();

                Console.WriteLine("Inserisci codice fiscale:");

                c.CodiceFiscale = (Console.ReadLine().ToUpper());

                Console.WriteLine("Inserisci sesso:");
                c.Sesso = char.Parse(Console.ReadLine().ToUpper());
       
                Console.WriteLine("Inserisci comune di residenza:");           
                c.ComuneResidenza = Console.ReadLine();                        
                                                                        
                Console.WriteLine("Inserisci reddito annuale:");               
                c.RedditoAnnuale = double.Parse(Console.ReadLine());           
                
                c.Stampa(c, case1Data);
        }

    }


    class Program
    {

        // Ho creato un menu 1-inserisci dati e stampa, 2-stampa dati di un certo dipendente con i dati inseriti in fase di test, 0-esci.
        static void Main(string[] args)
        {
            //permette visualizzazione simbolo €
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // creating date objects 
            DateTime tempDate = new DateTime(2023, 3, 10);
            DateTime case2Data = new DateTime(1992, 5, 15);
        

            Console.Write("Esercizio del \t");
            Console.WriteLine(tempDate.ToString("d")); 
                                                       
            // creare oggetto per case 1
            Contribuente c1 = new Contribuente();
            
            // creazione oggetto senza input utente per case 2
            Contribuente c2 = new Contribuente("Mirko", "Scata","sctmrk92e15", 'M', "Catania", 60000,case2Data);
          

            //do un valore per il do while del menù, diverso da una selezione del menù stesso
            int p = 6; 
            do
            {
                Console.WriteLine("premi 1 per input dati e stampa, 2 per stampa valori da testare,  0 Esci");
                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        c1.chiediDatiEStampa(c1);
                        break;
                    case 2:
                        c2.Stampa(c2);
                        break;
                 
                    case 0:
                        p = 0;
                        break;
                    default:
                        Console.WriteLine("Errore");
                        break;
                }
            } while (p != 0);
            
        }
    }
}