using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
	public class Image
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[StringLength(80)]
		public string Title { get; set; } = string.Empty;
		[Required]
		[StringLength(80)]
		public string Format { get; set; } = string.Empty;
		[Required]
		[MaxLength(1024 * 1024 * 1024)]
		public byte[]? Content { get; set; }
		[Required]
		[StringLength(80)]
		public string? Username { get; set; }
		public List<Tag> Tags { get; set;}=new List<Tag>();
	}
}