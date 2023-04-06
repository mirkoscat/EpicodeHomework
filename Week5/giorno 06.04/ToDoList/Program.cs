namespace ToDoList
{/*to do list
  per ogni todo -> data, ora, titolo, descrizione
    controllare se ò'operazione è stata fatta o meno
    ToDo
    ID int
  DataOra data+ora (DateTime)
    Titolo string (string 30 caratteri) 
    Descrizione string (string 255 caratteri) 
    Effettuato bool
  */
    internal class Program
    {

        static void MostraToDo(ToDoDataSet ds) 
        {
            Console.WriteLine("Elenco dei ToDo");
            //li mostra a video
            //basta un ciclo foreach per scorrere le righe della tabella tramite un oggetto di tipo DataRow row che fa riferimento a todo.rows(righe tabella)
            foreach (ToDoDataSet.ToDoRow row in ds.ToDo.Rows)
            {
                Console.WriteLine($"{row.Id}\t{row.Data}\t{row.Titolo}\t");
            }
        }
        static void AggiungiToDo(ToDoDataSet ds) {
            //chiede dati a utente
            Console.Write("Data: ");
            string data= Console.ReadLine();
            Console.Write("Titolo: ");
            string titolo = Console.ReadLine();
            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine();
            //la tabella crea una nuova riga
            ToDoDataSet.ToDoRow riga = ds.ToDo.NewToDoRow();
            //valorizzare
            riga.Data=DateTime.Parse(data);
            riga.Titolo= titolo;
            riga.Descrizione= descrizione;
            //aggiungere riga alla tabella 
            ds.ToDo.Rows.Add(riga);
        }
        static void AggiornaDb(ToDoDataSet ds) { 
        ToDoDataSetTableAdapters.ToDoTableAdapter adapter = new ToDoDataSetTableAdapters.ToDoTableAdapter();
            adapter.Update(ds.ToDo);
        
        }
        static void CancellaRiga(ToDoDataSet ds) { 
        
        //far scegliere quale riga cancellare
        Console.WriteLine("Quale riga vuoi cancellare? fornisci id");
            string id = Console.ReadLine();
            //cerca riga con id
            ToDoDataSet.ToDoRow riga = ds.ToDo.FindById(int.Parse(id));
            //cancella riga
            ds.ToDo.Rows.Remove(riga);

        }
        static void Menu()
        {   //istanzio dataset
            ToDoDataSet ds = new ToDoDataSet();
            //mi serve un adapter che faccia questo
            ToDoDataSetTableAdapters.ToDoTableAdapter adapter = new ToDoDataSetTableAdapters.ToDoTableAdapter();
            // tramite adapter riempio la tabella todo nel dataset
            adapter.Fill(ds.ToDo);
            //menu
            string[] opzioni = { "Mostra ToDo", "Aggiungi ToDo" ,"Aggiorna DB", "Rimuovi riga"};
            while (true) { 
            Console.WriteLine("Scegli opzione");
            for(int i = 0; i < opzioni.Length; i++)
            {

                Console.WriteLine($"{i + 1}\t{opzioni[i]}");
            }
            Console.WriteLine($"Scegli da 1 a  {opzioni.Length}:");
            string risposta = Console.ReadLine();
                switch(risposta[0])
            {
                case '1':
                    MostraToDo(ds);
                    break;
                    case '2':
                    AggiungiToDo(ds);
                    break;
                    case '3':AggiornaDb(ds);break;
                    case '4': CancellaRiga(ds); break;
                    default:return;

            }
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
      
    }
