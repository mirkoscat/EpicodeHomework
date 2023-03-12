namespace ConsoleApp5
{
    internal class Program
    {
        public class Persona
        {
            public string Nome { get;set; }
            public string Cognome { get; set; }
            public int Eta { get; set; }


            public string getDettagli()
            {
                return $"Nome: {Nome}, Cognome: {Cognome}, Età: {Eta}";
            }

            
            

            public string getCognome()
            {
                return Cognome;
            }

            public string getEta()
            {
                return Eta.ToString();
            }

          
        }
        static void Main(string[] args)
        {
            //inizializzo gli oggetti. formattazione automatica dell'IDE
            Persona persona1 = new()
            {
                Nome = "Mario",
                Cognome = "Rossi",
                Eta = 25                
            };
            //richiamo metodi
            string allinfo = persona1.getDettagli();
            Console.WriteLine(allinfo);
            string nome1 = persona1.getNome();
            Console.WriteLine(nome1);
            string eta1 = persona1.getEta();    
            Console.WriteLine(eta1);
            //setter
            persona1.Nome = "pippo";
            Console.WriteLine(persona1.Nome);

        }
    }
}