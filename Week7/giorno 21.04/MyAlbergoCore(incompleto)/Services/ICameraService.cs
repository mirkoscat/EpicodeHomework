using GestioneAlbergo.Models.Entities;

namespace MyAlbergoCore.Services
{
	public interface ICameraService
	{
		void AggiungiCamera(Camera c);
		void ModificaCamera(Camera c);
		IEnumerable<Camera> GetCamere();

	}
}
