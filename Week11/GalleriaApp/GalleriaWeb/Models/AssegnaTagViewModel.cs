

using DataLayer;

namespace GalleriaWeb.Models
{
    public class AssegnaTagViewModel
    {
        public int Id { get; set; }
        //public string  Name { get; set; }
        public Image? Image { get; set; }

        public virtual List<Tag> Tags { get; set; }=new List<Tag>();
    }
}
