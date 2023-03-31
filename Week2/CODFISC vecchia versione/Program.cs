using System.Security.Cryptography;

namespace CODIFSC
{
    internal class Program
    {
        public class Persona
        { 
            public static string Nome { get; private set; }
            public static string Cognome { get; private set; }
            public static string CharControllo { get; private set; }
            public static string Comune { get; private set; }
            public static string GiornoNascita { get; private set; }
            public static string MeseNascita { get; private set; }
            public static string AnnoNascita { get; private set; }


            public Persona() { }

            public string calcolaNomeCognome(string n)
            {
                string consonanti = "";
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
            {
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

                //Calcolo del carattere di controllo, capire come calcolarlo e implementare
                string carattereControllo = "";
                if (s == "M")
                    carattereControllo = "0";
                else
                    carattereControllo = "1";
                return carattereControllo;

            }
            public void stampaCodFisc(string c, string n, string an, string mn, string gn, string cmn, string cr)
            {
                Console.WriteLine($"Il tuo codice fiscale è {c}{n}{an}{mn}{gn}{cmn}{cr}");

            }
            public string tornaCodFisc(string c, string n, string an, string mn, string gn, string cmn)
            {
                string codice = "";
                codice += c + n + an + mn + gn + cmn;
                
                return codice;

            }
            static void Main(string[] args)
            {
                Persona p1 = new Persona();
              
                Persona.Nome = p1.calcolaNomeCognome("Mirko").Substring(0, 3).ToUpper();
                Cognome = p1.calcolaNomeCognome("Scatà").Substring(0, 3).ToUpper();

                GiornoNascita = "15";
                MeseNascita = "05";
                AnnoNascita = "1992";

                string anno = AnnoNascita.Substring(2);

                string meseNascitaLettera = p1.calcolaMeseNascita(MeseNascita);

                Comune = p1.calcolaComune("Acireale");

                CharControllo = p1.calcolaCarattereDiControllo("M");

                //p1.stampaCodFisc(Cognome, Nome, anno, meseNascitaLettera, GiornoNascita, Comune, CharControllo);

                string codice = p1.tornaCodFisc(Cognome, Nome, anno, meseNascitaLettera, GiornoNascita, Comune);
                Console.WriteLine($"Il tuo codice fiscale senza carattere di controllo è:{codice}");
                CharControllo = p1.calcolaCarattereDiControllo(codice);
                


            }
        }
    }
}