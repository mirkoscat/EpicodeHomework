/*
 * ESERCIZIO 8/3/23
 * 1. Scrivere una classe ContoCorrente che permetta di archiviare diverse proprietà del conto, più il relativo saldo. In più permetta di effettuare le seguenti azioni:

Aprire il conto
Fare un versamento
Fare un prelevamento
N.B.: L’apertura del conto può essere effettuata solo una volta e contestualmente deve necessariamente consentire un versamento almeno 1000 euro.

2. Scrivere un algoritmo che prenda in input un valore di x nomi (decida il candidato la dimensione dell’array). Dopo aver caricato l’array, specificare un nome da ricercare e stampare se il nome è presente o meno nell’array caricato precedentemente.

3. Scrivere un algoritmo che prenda in input:
a) La dimensione di un array
b) In base alla dimensione dell’array, x numeri interi
e restituisca:

La somma di tutti i numeri inseriti all’interno dell’array
La media aritmetica di tutti i numeri inseriti all’interno dell’array*/


using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ContoCorrente
{
    internal class Program
    {
        class ContoCorrente {
            private int saldo;
            private bool isOpen;
            public void ApriConto()
            {
                // se è aperto->err, altrimenti true e imposta il saldo
                
                int valore;
                if (isOpen == true)
                {
                    Console.WriteLine("Errore, il conto  è già aperto");
                }
                else
                {
                    isOpen = true;
                    Console.WriteLine("il conto è aperto, per la prima volta versa almeno 1k.");
                    // saldoIniziale deve essere >1000 
                    do
                    {
                        Console.WriteLine("Inserisci un valore: ");
                        valore = int.Parse(Console.ReadLine());
                    }
                    while (valore < 1000);
                    saldo = valore;
                }
                Console.WriteLine($"saldo dopo apertura:{saldo}");
            }
            public void Versamento() 
            {
                Console.WriteLine("Quanto vuoi versare?");
                int quantoVersare = int.Parse(Console.ReadLine());

                Console.WriteLine($"Stai versando {quantoVersare}");

                saldo += quantoVersare;

                Console.WriteLine($"saldo dopo versamento:{saldo}");
            }
            public void Prelievo()
            {
                Console.WriteLine("Quanto vuoi prelevare?");
                int quantoPrelevare = int.Parse(Console.ReadLine());
                //se saldo > prelievo ok(tolgo soldi dal saldo), altrimenti errore 
                if (!isOpen || saldo < quantoPrelevare || quantoPrelevare < 0)
                {
                    Console.WriteLine("Non puoi prelevare così tanto");
                }
                else {
                    Console.WriteLine($"Stai prelevando {quantoPrelevare}");
                    saldo -= quantoPrelevare;
                    Console.WriteLine($"saldo dopo prelievo:{saldo}");
                }
             
            }
            public void Cerca(string n1, string n2, string n3, string n4)
            {
                
                    if (n4 != n1 && n4 != n2 && n4 != n3)
                    {
                    Console.WriteLine("Output da Cerca CON params");
                    Console.WriteLine("Il nome non è presente nell'array. Nome: "+ n4);
                }
                    else
                    {
                    Console.WriteLine("Output da Cerca CON params");
                    Console.WriteLine("Il nome è presente nell'array.Nome: " + n4);

                }
            }
            public void Cerca()
            
            {
                string[] nomi;
                string nomeDaCercare;
                bool trovato = false;

                // Inizializzazione delle variabili
                nomi = new string[3];

                // Input dei nomi
                Console.WriteLine("Inserisci il primo nome:");
                nomi[0] = Console.ReadLine();
                Console.WriteLine("Inserisci il secondo nome:");
                nomi[1] = Console.ReadLine();
                Console.WriteLine("Inserisci il terzo nome:");
                nomi[2] = Console.ReadLine();

                // Input del nome da cercare
                Console.WriteLine("Inserisci il nome da cercare:");
                nomeDaCercare = Console.ReadLine();

                // Ciclo di ricerca
                for (int i = 0; i < nomi.Length; i++)
                {
                    if (nomi[i] != nomeDaCercare)
                    {
                        continue;
                    }
                    else
                    {
                        trovato = true;

                    }
                }

                // Stampa del risultato
                if (trovato)
                {
                    Console.WriteLine("Output da Cerca() senza params");
                    Console.WriteLine("Il nome è presente nell'array." );
                }
                else
                {
                    Console.WriteLine("Output da Cerca() senza params");
                    Console.WriteLine("Il nome non è presente nell'array.");
                }

            }
           
        }
     
        static void Main(string[] args)
        {//1
            Console.WriteLine("esercizio 1");
            ContoCorrente c1 = new ContoCorrente();
            int p = 6; //do un valore per il do while
            do
            {
                Console.WriteLine("premi 1 per APRI CONTO, 2 per VERSAMENTO, 3 per PRELIEVO, 0 skip esercizio");
                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        c1.ApriConto();
                        break;
                    case 2:
                        c1.Versamento();
                        break;
                    case 3:
                        c1.Prelievo();
                        break;
                    case 0:
                        p = 0;
                        break;
                    default:
                        Console.WriteLine("Errore");
                        break;
                }
            } while (p != 0);

            //2
            Console.WriteLine("esercizio 2");
            c1.Cerca();
           
            //dopo la spiegazione di giorno 9 ho modificato l'esercizio creando un costruttore con parametri
            string[] names;
            string nameToFind;
            // Inizializzazione delle variabili
            names = new string[3];
            //nomi scelti
            names[0] = "Pippo";
            names[1] = "Pluto";
            names[2] = "Paperino";
            //nome da cercare
            nameToFind = "Ciccio";
            c1.Cerca(names[0], names[1], names[2], nameToFind);


            // 3
            Console.WriteLine("esercizio 3");
           
            //Inizializzazione delle variabili
            int dimensioneArray;
            int[] array;
            int somma = 0;
            double media;

            // Prendere in input la dimensione dell'array
            Console.WriteLine("Inserisci la dimensione dell'array: ");
            dimensioneArray = int.Parse(Console.ReadLine());

            //Creazione dell'array
            array = new int[dimensioneArray];

            //Prendere in input i numeri interi
            for (int i = 0; i < dimensioneArray; i++)
            {
                Console.WriteLine("Inserisci un numero intero: ");
                array[i] = int.Parse(Console.ReadLine());
                somma += array[i];
            }

            //Calcolo della media
            media = (double)somma / dimensioneArray;

            //Stampa dei risultati
            Console.WriteLine("La somma di tutti i numeri è: " + somma );
            Console.WriteLine("La media aritmetica di tutti i numeri è: "+ media );



            
        }

       
    }
}