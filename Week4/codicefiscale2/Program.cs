using static codicefiscale.Program.CodiceFiscale;

namespace codicefiscale
{
    internal class Program
    {
      //programma che chiede in input dei dati e ne calcola il codice fiscale. da migliorare il carattere di controllo
        public class Persona
        {
            public string Nome { get; internal set; }
            public string Cognome {get; internal set; }
            public DateTime DataDiNascita{get; internal set; }
            public bool Sesso {get; internal set; } // true = maschio, false = femmina
            public string Comune { get; internal set; }
            public string CodiceFiscale { get; internal set; }

            private CodiceFiscale codiceFiscale;
        }

        public class CodiceFiscale
        {
            public static readonly bool Sesso;
            public string Comune { get; private set; }
            public DateTime DataDiNascita { get; private set; }


            private static string CalcolaCognome(object cognome)
            {
                //cognome 1a 2a 3a consonante

                string cognomestringa = cognome.ToString();

                var consonanti = "";
                var vocali = "";
                
                //popolo vocali e consonanti
                for (int i = 0; i < cognomestringa.Length; i++)
                {
                    if (cognomestringa[i] != 'A' && cognomestringa[i] != 'E' && cognomestringa[i] != 'I' && cognomestringa[i] != 'O' && cognomestringa[i] != 'U' && cognomestringa[i] != ' ')
                    {
                        consonanti += cognomestringa[i];
                    }
                    else { vocali += cognomestringa[i]; }
                }
                
                //se ci sono fino a 2 consonanti, aggiungo le vocali
                if (consonanti.Length < 3)
                {
                    //se non ci sono vocali aggiungo X
                    if (vocali.Length == 0)
                    {
                        consonanti += "XX";
                        consonanti = consonanti.Substring(0, 2);
                    }
                    else
                    {
                        consonanti += vocali;
                        consonanti = consonanti.Substring(0, 2);
                    }
                }
                else if (consonanti.Length >= 3)
                {
                    consonanti = consonanti.Substring(0, 3);
                }

                return consonanti;
            }
           
            private static string CalcolaNome(object nome)
            {
                
                //nome 1a 2a 4a consonante.
                string nomestringa = nome.ToString();

                var consonanti = "";
                var vocali = "";

                for (int i = 0; i < nomestringa.Length; i++)
                {
                    if (nomestringa[i] != 'A' && nomestringa[i] != 'E' && nomestringa[i] != 'I' && nomestringa[i] != 'O' && nomestringa[i] != 'U' && nomestringa[i] != ' ')
                    {
                        consonanti += nomestringa[i];
                    }
                    else
                    {
                        vocali += nomestringa[i];
                    }
                }

                //se ci sono fino a 2 consonanti, aggiungo le vocali
                if (consonanti.Length < 3)
                {
                    //se non ci sono vocali aggiungo X
                    if (vocali.Length == 0)
                    {
                        consonanti += "XX";
                        consonanti = consonanti.Substring(0, 2);
                    }
                    else
                    {
                        consonanti += vocali;
                        consonanti = consonanti.Substring(0, 2);
                    }
                }
                else if (consonanti.Length == 3)
                {
                    //prende i primi due caratteri che sono dentro consonanti
                    string parte1 = consonanti.Substring(0, 2);
                    //prende il terzo carattere dentro consonanti
                    string parte2 = consonanti.Substring(2,1);
                    consonanti = parte1 + parte2;
                }
                else if (consonanti.Length > 3)
                {
                    //prende i primi due caratteri che sono dentro consonanti
                    string parte1 = consonanti.Substring(0, 2);
                    //prende il terzo carattere dentro consonanti
                    string parte2 = consonanti.Substring(3, 1);
                    consonanti = parte1 + parte2;
                }
                return consonanti;
            }

            public class ValoriNascita
            {
                public string Giorno { get; set; }
                public char MeseNascita { get; set; }
                public string Anno { get; set; }
            }

            public static ValoriNascita CalcolaValoriNascita(DateTime DataDiNascita)
            {
                string anno = DataDiNascita.ToString("yy");

                string giorno = DataDiNascita.ToString("dd");
                if (Sesso == false)
                {
                    int giornointero = int.Parse(giorno);
                    giorno = giorno + 40;
                }

                int mese = DataDiNascita.Month;
                char mesenascita;

                switch (mese)
                {
                    case 01:
                        mesenascita = 'A';
                        break;
                    case 02:
                        mesenascita = 'B';
                        break;
                    case 03:
                        mesenascita = 'C';
                        break;
                    case 04:
                        mesenascita = 'D';
                        break;
                    case 05:
                        mesenascita = 'E';
                        break;
                    case 06:
                        mesenascita = 'H';
                        break;
                    case 07:
                        mesenascita = 'L';
                        break;
                    case 08:
                        mesenascita = 'M';
                        break;
                    case 09:
                        mesenascita = 'P';
                        break;
                    case 10:
                        mesenascita = 'R';
                        break;
                    case 11:
                        mesenascita = 'S';
                        break;
                    case 12:
                        mesenascita = 'T';
                        break;
                    default:
                        mesenascita = 'X';
                        break;
                }  
                return new ValoriNascita { Giorno = giorno, MeseNascita = mesenascita, Anno = anno };
            }

            public static string CalcolaComune(string comune)
            {
                var codiceComune = "";
                switch (comune)
                {
                    case "ACIREALE":
                        codiceComune = "A028";
                        break;

                    case "ROMA":
                        codiceComune = "A032";
                        break;

                    case "MILANO":
                        codiceComune = "A033";
                        break;

                    default:
                        codiceComune = "XXX";
                        break;

                }

                return codiceComune;
            }
            
            public static char CalcolaCarattereControllo(string codiceFiscale)
            {
                // Scompone la stringa in un array di caratteri
                char[] caratteri = codiceFiscale.ToCharArray();

                // Calcola la somma dei valori dei caratteri in posizione pari e dispari
                int sommaPari = 0;
                int sommaDispari = 0;
                for (int i = 0; i < caratteri.Length; i++)
                {
                    // Se la posizione è pari, aggiungo a sommaPari il valore del carattere
                    if (i % 2 == 0)
                    {
                        int valore;
                        switch (caratteri[i])
                        {
                            case '0':
                            case 'A':
                                valore = 0;
                                break;
                            case '1':
                            case 'B':
                                valore = 1;
                                break;
                            case '2':
                            case 'C':
                                valore = 2;
                                break;
                            case '3':
                            case 'D':
                                valore = 3;
                                break;
                            case '4':
                            case 'E':
                                valore = 4;
                                break;
                            case '5':
                            case 'F':
                                valore = 5;
                                break;
                            case '6':
                            case 'G':
                                valore = 6;
                                break;
                            case '7':
                            case 'H':
                                valore = 7;
                                break;
                            case '8':
                            case 'I':
                                valore = 8;
                                break;
                            case '9':
                            case 'J':
                                valore = 9;
                                break;

                            case 'K':
                                valore = 10;
                                break;
                            case 'L':
                                valore = 11;
                                break;
                            case 'M':
                                valore = 12;
                                break;
                            case 'N':
                                valore = 13;
                                break;
                            case 'O':
                                valore = 14;
                                break;
                            case 'P':
                                valore = 15;
                                break;
                            case 'Q':
                                valore = 16;
                                break;
                            case 'R':
                                valore = 17;
                                break;
                            case 'S':
                                valore = 18;
                                break;
                            case 'T':
                                valore = 19;
                                break;
                            case 'U':
                                valore = 20;
                                break;
                            case 'V':
                                valore = 21;
                                break;
                            case 'W':
                                valore = 22;
                                break;
                            case 'X':
                                valore = 23;
                                break;
                            case 'Y':
                                valore = 24;
                                break;
                            case 'Z':
                                valore = 25;
                                break;
                            default:
                                valore=0;
                                break;
                        }
                        sommaPari += valore;
                    }
                    else
                    {
                        int valore;
                        switch (caratteri[i])
                        {
                            case '0':
                            case 'B':
                                valore = 1;
                                break;
                            case '1':
                            case 'A':
                                valore = 0;
                                break;
                            case '2':
                            case 'C':
                                valore = 5;
                                break;
                            case '3':
                            case 'D':
                                valore = 7;
                                break;
                            case '4':
                            case 'E':
                                valore = 9;
                                break;
                            case '5':
                            case 'F':
                                valore = 13;
                                break;
                            case '6':
                            case 'G':
                                valore = 15;
                                break;
                            case '7':
                            case 'H':
                                valore = 17;
                                break;
                            case '8':
                            case 'I':
                                valore = 19;
                                break;
                            case '9':
                            case 'J':
                                valore = 21;
                                break;
                            case 'K':
                                valore = 2;
                                break;
                            case 'L':
                                valore = 4;
                                break;
                            case 'M':
                                valore = 18;
                                break;
                            case 'N':
                                valore = 20;
                                break;
                            case 'O':
                                valore = 11;
                                break;
                            case 'P':
                                valore = 3;
                                break;
                            case 'Q':
                                valore = 6;
                                break;
                            case 'R':
                                valore = 8;
                                break;
                            case 'S':
                                valore = 12;
                                break;
                            case 'T':
                                valore = 14;
                                break;
                            case 'U':
                                valore = 16;
                                break;
                            case 'V':
                                valore = 10;
                                break;
                            case 'W':
                                valore = 22;
                                break;
                            case 'X':
                                valore = 25;
                                break;
                            case 'Y':
                                valore = 24;
                                break;
                            case 'Z':
                                valore = 23;
                                break;
                            default: valore=0;
                                break;
                        }
                        sommaDispari += valore;
                    }
                }
              
                // Calcola il valore del carattere di controllo
                int valoreControllo = sommaPari + sommaDispari;
                int resto = valoreControllo % 26;
                char carattereControllo ;
                switch (resto)
                {
                    case 0:
                        carattereControllo = 'A';
                        break;
                    case 1:
                        carattereControllo = 'B';
                        break;
                    case 2:
                        carattereControllo = 'C';
                        break;
                    case 3:
                        carattereControllo = 'D';
                        break;
                    case 4:
                        carattereControllo = 'E';
                        break;
                    case 5:
                        carattereControllo = 'F';
                        break;
                    case 6:
                        carattereControllo = 'G';
                        break;
                    case 7:
                        carattereControllo = 'H';
                        break;
                    case 8:
                        carattereControllo = 'I';
                        break;
                    case 9:
                        carattereControllo = 'J';
                        break;
                    case 10:
                        carattereControllo = 'K';
                        break;
                    case 11:
                        carattereControllo = 'L';
                        break;
                    case 12:
                        carattereControllo = 'M';
                        break;
                    case 13:
                        carattereControllo = 'N';
                        break;
                    case 14:
                        carattereControllo = 'O';
                        break;
                    case 15:
                        carattereControllo = 'P';
                        break;
                    case 16:
                        carattereControllo = 'Q';
                        break;
                    case 17:
                        carattereControllo = 'R';
                        break;
                    case 18:
                        carattereControllo = 'S';
                        break;
                    case 19:
                        carattereControllo = 'T';
                        break;
                    case 20:
                        carattereControllo = 'U';
                        break;
                    case 21:
                        carattereControllo = 'V';
                        break;
                    case 22:
                        carattereControllo = 'W';
                        break;
                    case 23:
                        carattereControllo = 'X';
                        break;
                    case 24:
                        carattereControllo = 'Y';
                        break;
                    case 25:
                        carattereControllo = 'Z';
                        break;
                    default: carattereControllo = 'O';
                        break;

                }
                return carattereControllo;
            }

           public static string CalcolaCodiceFiscale(Persona p) {

                string nome = CalcolaNome(p.Nome);
                string cognome = CalcolaCognome(p.Cognome);
                string giornoNascita = CalcolaValoriNascita(p.DataDiNascita).Giorno.Substring(0, 2);
                string meseNascita = CalcolaValoriNascita(p.DataDiNascita).MeseNascita.ToString();
                string annoNascita = CalcolaValoriNascita(p.DataDiNascita).Anno;
                string comune = CalcolaComune(p.Comune);
                string codiceFisc = cognome + nome + annoNascita + meseNascita + giornoNascita + comune;
                string carattereControllo = CalcolaCarattereControllo(codiceFisc).ToString();
                string codicefiscale = codiceFisc + carattereControllo;
               
                return codicefiscale;
            }

          
        }
        public static void chiediDati(Persona p) {

            Console.WriteLine("Inserisci il nome:");
            string nomeintero = Console.ReadLine();
            p.Nome = nomeintero.ToUpper();

            Console.WriteLine("Inserisci il cognome:");
            string cognomeintero = Console.ReadLine();
            p.Cognome = cognomeintero.ToUpper();

            Console.WriteLine("Inserisci il comune di nascita:");
            string comunestring = Console.ReadLine();
            p.Comune = comunestring.ToUpper();

            Console.WriteLine("Inserisci sesso M/F");
            char sesso = char.Parse(Console.ReadLine());

            p.Sesso = false;
            if (sesso == 'M' || sesso == 'm')
            {
                p.Sesso = true;
            }

            Console.WriteLine("Inserisci il giorno di nascita in formato GG:");
            int giornoint = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il mese di nascita in formato MM:");
            int meseint = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci l'anno di nascita in formato AAAA:");
            int annoint = int.Parse(Console.ReadLine());

            p.DataDiNascita = new DateTime(annoint, meseint, giornoint);

            // inizializzo oggetto valoriNascita per scomporre i valori
            ValoriNascita valoriNascita = CalcolaValoriNascita(p.DataDiNascita);
        }
        
        static void Main(string[] args)
        {
            Persona p = new Persona();
            chiediDati(p);
            string codicefiscale = CalcolaCodiceFiscale(p);
            p.CodiceFiscale = codicefiscale;
           
            Console.WriteLine("il tuo codice fiscale è: " + p.CodiceFiscale);
        }  
    }
}
