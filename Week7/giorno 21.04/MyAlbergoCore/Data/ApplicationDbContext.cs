using GestioneAlbergo.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyAlbergoCore.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{//come mai  sono sono stati generati automaticamente?
		public DbSet<Cliente> Clienti { get; set; }
		public DbSet<Camera> Camere { get; set; }
		//aggiungo dbset prenotazione
		public DbSet<Prenotazione> Prenotazioni { get; set; }
		
		
		
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		
		}
	}
}