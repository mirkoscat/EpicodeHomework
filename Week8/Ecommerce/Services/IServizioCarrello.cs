using Ecommerce.Models.Entities;

namespace Ecommerce.Services
{
    public interface IServizioCarrello
    {   
        void CreaCarrello();
        IEnumerable<CarrelloProdotto> GetProdottiInCarrello(int id);
        int GetIdCarrelloAttuale();
        void AggiungiProdottoAlCarrello(int idcarrello, int idprodotto,int quantita);
        List<Carrello> GetCarrelli();
        void ModificaQuantita(int idcarrelloprodotto, int idcarrello, int idprodotto,int quantita);
        

        

        


    }
}
