using System.ComponentModel.DataAnnotations;

namespace GalleriaWeb.Models.Entities
{
	public class VoteModel
	{
		public int Id { get; set; }
		public int Value { get; set; }
		public string? Username { get; set; }
	}
}
