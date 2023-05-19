using System.ComponentModel.DataAnnotations;

namespace GalleriaWeb.Models
{
	public class UploadImageViewModel
	{
		[Display(Name = "Titolo")]
		[Required]
		[StringLength(80)]
		public string Title { get; set; } = string.Empty;
		[Display(Name = "File")]
		[Required]
		public IFormFile? File { get; set; }
	}
}
