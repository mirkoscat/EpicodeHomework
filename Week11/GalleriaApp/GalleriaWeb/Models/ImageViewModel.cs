using System.ComponentModel.DataAnnotations;
using DataLayer;

namespace GalleriaWeb.Models
{
	public class ImageViewModel
	{
		public int Id { get; set; }
		[Display(Name = "Titolo")]
		public string Title { get; set; } = string.Empty;
		[Display(Name = "Formato")]
		public string Format { get; set; } = string.Empty;
		[Display(Name = "Autore")]
		public string? Username { get; set; }
		[Display(Name = "Dimensione")]
		public long Size { get; set; }
		public virtual List<Tag> Tags { get; set; }= new List<Tag>();
	}
}
