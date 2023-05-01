using Ecommerce.Models.Entities;

namespace Ecommerce.Services
{
	public interface IServizioProdotto
	{
		bool CreaProdotto(Prodotto p);
		bool EliminaProdotto(int id);
        bool ModificaProdotto(Prodotto p);
        IEnumerable<Prodotto> GetAll();
		Prodotto GetProdottoById(int id);

		//int GetIdProdotto(string nome);
		
		
	}
}