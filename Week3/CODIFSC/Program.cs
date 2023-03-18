namespace CODIFSC
{
    internal class Program
    {
        public class Persona
        { 
            public string consonanti = "";
            public static string Nome { get; set; }
            public static string Cognome { get; set; }
            public static string CharControllo { get; set; }
            public static string Comune { get; set; }


            public Persona() { }

            public string calcolaNomeCognome(string n)
            {
                consonanti = "";
                foreach (char c in n)
                {
                    if (c != 'A' && c != 'E' && c != 'I' && c != 'O' && c != 'U' && c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
                        consonanti += c;
                }
                return consonanti;
            }
            public string calcolaMeseNascita(string m)
            {
                string mesenascita = "";
                switch (m)
                {
                    case "01":
                        mesenascita = "A";
                        break;
                    case "02":
                        mesenascita = "B";
                        break;
                    case "03":
                        mesenascita = "C";
                        break;
                    case "04":
                        mesenascita = "D";
                        break;
                    case "05":
                        mesenascita = "E";
                        break;
                    case "06":
                        mesenascita = "H";
                        break;
                    case "07":
                        mesenascita = "L";
                        break;
                    case "08":
                        mesenascita = "M";
                        break;
                    case "09":
                        mesenascita = "P";
                        break;
                    case "10":
                        mesenascita = "R";
                        break;
                    case "11":
                        mesenascita = "S";
                        break;
                    case "12":
                        mesenascita = "T";
                        break;
                    default:
                        mesenascita = "ERR";
                        break;
                }
                return mesenascita;
            }

            public string calcolaComune(string c)
            {// Calcolo del codice del comune
                string codiceComune = "";
                switch (c)
                {
                    case "Roma":
                        codiceComune = "H501";
                        break;
                    case "Acireale":
                        codiceComune = "A028";
                        break;
                    case "Napoli":
                        codiceComune = "Z724";
                        break;
                    case "Milano":
                        codiceComune = "F205";
                        break;
                    default:
                        codiceComune = "XXXX";
                        break;
                }
                return codiceComune;
            }




            public string calcolaCarattereDiControllo(string s)
            {
                // Calcolo del carattere di controllo, capire come calcolarlo e implementare
                string carattereControllo = "";
                if (s == "M")
                    carattereControllo = "0";
                else
                    carattereControllo = "1";
                return carattereControllo;
            }
            public void stampaCodFisc(string c, string n, string an, string mn, string gn, string s, string charcontr)
            {
                Console.WriteLine($"Il tuo codice fiscale è {c}{n}{an}{mn}{gn}{s}{charcontr}");

            }
            static void Main(string[] args)
            {
                Persona p1 = new Persona();
                
                string Nome = p1.calcolaNomeCognome("mirko").Substring(0, 3).ToUpper();
                string Cognome = p1.calcolaNomeCognome("scata").Substring(0, 3).ToUpper();

                string giornoNascita = "15"; 
                string meseNascita = "05"; 
                string annoNascita = "1992";

                string anno = annoNascita.Substring(2);
                string meseNascitaLettera = p1.calcolaMeseNascita(meseNascita);

                string Comune = p1.calcolaComune("Acireale");

                string CharControllo = p1.calcolaCarattereDiControllo("M");

                p1.stampaCodFisc(Cognome, Nome, anno, meseNascitaLettera, giornoNascita, Comune, CharControllo);
             }
        }
    }
}