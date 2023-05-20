
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{
	public class Vote
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public Image? Image { get; set; }
		[Range(0, 100)]
		public int Value { get; set; }
		public string? Username { get; set; }
		public List<Image> Images { get; set; }=new List<Image>();
	}
}
