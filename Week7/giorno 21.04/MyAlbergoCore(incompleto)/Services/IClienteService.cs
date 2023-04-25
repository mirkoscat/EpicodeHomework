using GestioneAlbergo.Models.Entities;

namespace MyAlbergoCore.Services
{
	public interface IClienteService
	{
		void AggiungiCliente(Cliente c);
		void ModificaCliente(Cliente c);
		List<Cliente> GetClienti();
		
		

	}
}
