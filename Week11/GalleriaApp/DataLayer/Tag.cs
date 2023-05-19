using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class Tag
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Username { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; } = false;
		public List<Image> Images { get; set; }=new List<Image>();
    

	}
	

	
}
