namespace Logging
{
    internal class Program
    {
        public static class Utente
        {
          
            public static string Nome { get; set; }
            public static string Password { get; set; }
            public static string ControlPassword { get; set; }
            public static bool IsLogged { get; set; }
            public static DateTime LastLogin { get; set; }
            //massimo 10 accessi
            public static DateTime[] allDate = new DateTime[10];
            public static int Contatore { get; set ; }

            public static void LogIn() 
            {
                Console.WriteLine("FACCIO LOGIN");

                Console.WriteLine("Dammi il nome");
                string name = Console.ReadLine();
                Console.WriteLine("Dammi la password");
                string pass = Console.ReadLine();
                Console.WriteLine("Dammi la conferma password");
                string controlPass = Console.ReadLine();

                if (name != null && pass == controlPass && IsLogged == false)
                {
                    //inizializzare dati da testare: passo dai valori alle proprietà
                    IsLogged = true;
                    Console.WriteLine("sono loggato");
                    Nome = name;
                    Password = pass;
                    DateTime date = DateTime.Now;
                    LastLogin = date;

                    allDate[Contatore] = date;
                    Contatore++;
                    Console.WriteLine("sono loggato: {0} {1}", Nome, LastLogin);

                }
                else { Console.WriteLine("login fallito"); }
              

            }
            public  static void LogOut() { Console.WriteLine("FACCIO LOGOUT");
                if (!IsLogged)
                {
                    Console.WriteLine("Errore, Utente già sloggato");
                }
                else {
                    Console.WriteLine("nome: "+ Nome);
                    Nome = "";
                   
                    IsLogged = false;
                    Console.WriteLine("Sono riuscito a sloggare");
                    Console.WriteLine(Nome);
                }
            }
            public static void Lista() { Console.WriteLine("FACCIO LISTA");
                //devo sloggare prima di chiedere la lista
                for(int i = 0; i<Contatore;i++)
                 {  Console.WriteLine(allDate[i]); 
                }
                 
            }
            public static void Verifica() { Console.WriteLine("FACCIO VERIFICA");
                if (IsLogged)
                {
                    Console.WriteLine(LastLogin);
                }
                else { Console.WriteLine("Errore. prova a loggare");
                }
            }

            internal static void LogIn(string nome, string password, string controlPassword)
            {
                Console.WriteLine("FACCIO LOGIN con params");

                if (password == controlPassword && IsLogged == false )
                {
                    //inizializzare dati da testare: passo dai valori alle proprietà
                    IsLogged = true;
                    Console.WriteLine("sono loggato");
                    Nome = nome;
                    Password = password;
                    DateTime date = DateTime.Now;
                    LastLogin = date;

                    allDate[Contatore] = date;
                    Contatore++;
                    Console.WriteLine("sono loggato: {0} {1}", Nome, LastLogin);

                }
                else { Console.WriteLine("login fallito"); }
            }
        }
        static void Main(string[] args)
        {
          
            int n; //do un valore per il do while
            do
            {
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("1.: Login\r\n2.: Logout\r\n3.: Verifica ora e data di login\r\n4.: Lista degli accessi\r\n5.: Esci");
               n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        //Utente.LogIn();
                        Utente.Nome = "Mirko";
                        Utente.Password = "123";
                        Utente.ControlPassword = "123";
                        Utente.LogIn(Utente.Nome, Utente.Password, Utente.ControlPassword);
                        break;
                    case 2:
                        Utente.LogOut();
                        break;
                    case 3:
                        Utente.Verifica();
                        break;
                    case 4:
                        Utente.Lista();
                        break;
                    case 5:
                        
                        break;
                    default:
                        Console.WriteLine("Errore");
                        break;
                }
            } while (n != 5);
        }
    }
}