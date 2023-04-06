
using GestioneBlog.BlogDataSetTableAdapters;

namespace GestioneBlog
{
    internal class ServizioGestioneArticoli
    {
        private BlogDataSet ds;
        private ArticoliTableAdapter articoli;
        private CommentiTableAdapter commenti;
        private UtentiTableAdapter utenti;
        public ServizioGestioneArticoli()
        {
            ds=new BlogDataSet();
            articoli = new ArticoliTableAdapter();
            commenti = new CommentiTableAdapter();
            utenti = new UtentiTableAdapter();
            utenti.Fill(ds.Utenti);
            articoli.Fill(ds.Articoli);
            commenti.Fill(ds.Commenti);
        }
        public void CreaArticolo(string titolo, string contenuto, DateTime data, int autoreId) {
        //prendere una riga del dataset
        BlogDataSet.ArticoliRow riga = ds.Articoli.NewArticoliRow();
            //popolare la riga
            riga.Titolo = titolo;
            riga.Contenuto = contenuto;
            riga.DataCreazione = data;
            riga.AutoreID = autoreId;
            //aggiungere la riga al dataset
            ds.Articoli.AddArticoliRow(riga);
            //aggiornare il database
            articoli.Update(ds.Articoli);
        }
        public void LeggiArticoli() {
        foreach(BlogDataSet.ArticoliRow row in ds.Articoli.Rows)
            {
                Console.WriteLine($"{row.Id}\t{row.Titolo}\t{row.UtentiRow.NomeUtente}");
            }
        }
        public void LeggiArticolo(int articoloId) {
            //leggere articolo da id
            BlogDataSet.ArticoliRow articolo = ds.Articoli.FindById(articoloId);
            //visualizzare articolo
            Console.WriteLine($"{articolo.Titolo}\t{articolo.Contenuto}\t{articolo.DataCreazione}\t{articolo.UtentiRow.NomeUtente}");
            //leggere commenti
            foreach (BlogDataSet.CommentiRow commento in articolo.GetCommentiRows())
            {
                Console.WriteLine($"{commento.Contenuto}\t{commento.Data}\t{commento.UtentiRow.NomeUtente}");
            }
        }
        public void ModificaArticolo(int articoloId, string titolo, string contenuto, DateTime data, int autoreId) {
            // leggere articolo da id
            BlogDataSet.ArticoliRow articolo = ds.Articoli.FindById(articoloId);
            //modificare i campi di quell'articolo
            articolo.Titolo = titolo;
            articolo.Contenuto = contenuto;
            articolo.DataCreazione = data;
            //aggiornare il database
            articoli.Update(ds.Articoli);
        }
        public void EliminaArticolo(int articoloId)
        {
            //cerca riga con id
            BlogDataSet.ArticoliRow riga = ds.Articoli.FindById(articoloId);
            //cancella riga
            ds.Articoli.Rows.Remove(riga);
            articoli.Update(ds.Articoli);

        }
        public void EliminaArticolo()
        {
            //far scegliere quale riga cancellare
            Console.WriteLine("Quale riga vuoi cancellare? fornisci id");
            string id = Console.ReadLine();
            //cerca riga con id
            BlogDataSet.ArticoliRow riga = ds.Articoli.FindById(int.Parse(id));
            //cancella riga
            ds.Articoli.Rows.Remove(riga);
            articoli.Update(ds.Articoli);

        }
        public void CommentaArticolo(int articoloId, int autoreId, string contenuto, DateTime data) {
            //leggere articolo da id
            BlogDataSet.ArticoliRow articolo = ds.Articoli.FindById(articoloId);
            //creare commento
            BlogDataSet.CommentiRow commento = ds.Commenti.NewCommentiRow();
            commento.Contenuto = contenuto;
            commento.Data = data;
            commento.ArticoloID = articoloId;
            commento.UtenteID = autoreId;
            // aggiungere il commento alle righe 
            ds.Commenti.Rows.Add(commento);
            //aggiornare il database
            commenti.Update(ds.Commenti);
           
        }

    }
}
