
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Image = DataLayer.Image;

namespace ServiceLayer
{
    public class GalleriaService : IGalleriaService
    {
        private readonly ILogger<GalleriaService> _logger;

        private readonly DataContext _dataContext;
        public GalleriaService(ILogger<GalleriaService> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;

            logger.LogDebug("Sto costruendo la classe {}", nameof(GalleriaService));
        }

        public void AssegnaTag(int id, List<int> tags)
        {
            var image = _dataContext.Images.Include(x=>x.Tags).Single(i => i.Id == id);
            var taglist = new List<Tag>();
            foreach (var t in tags)
            {   
                    var tag = _dataContext.Tags.Single(x => x.Id == t);
                    taglist.Add(tag);
                
            }
            image.Tags.Clear();
            _dataContext.SaveChanges();
            image.Tags = taglist;
            
            _dataContext.SaveChanges();

        }

        public void CreateTag(string nome)
        {
            var tag = new Tag() { Name = nome };
            _dataContext.Tags.Add(tag);
            _dataContext.SaveChanges();
        }

        public void DeleteImage(int id)
        {
            var image = _dataContext.Images.Single(i => i.Id == id);
            _dataContext.Images.Remove(image);
            _dataContext.SaveChanges();

        }

        public void DeleteTag(int id)
        {
            var tag = _dataContext.Tags.Single(i => i.Id == id);
            _dataContext.Tags.Remove(tag);
            _dataContext.SaveChanges();

        }

        public Image GetImageById(int id)
        {
            var image = _dataContext.Images.Include(x => x.Tags).FirstOrDefault(i => i.Id == id);
            return new Image { Content = image.Content, Format = image.Format, Id = image.Id, Title = image.Title, Username = image.Username, Tags= image.Tags };
        }
        public IEnumerable<Image> GetImages() => _dataContext.Images.Include(x=>x.Tags).Select(i => new Image { Content = i.Content, Format = i.Format, Id = i.Id, Title = i.Title, Username = i.Username,Tags=i.Tags});

        public IEnumerable<Tag> GetTags() => _dataContext.Tags.Select(t=> new Tag {Id= t.Id,Name=t.Name,Username=t.Username});
  
        public void Upload(Image image)
        {
            var img = new Image { Content = image.Content, Format = image.Format, Title = image.Title, Username = image.Username };
            _dataContext.Images.Add(img);
            _dataContext.SaveChanges();
        }
        //public IEnumerable<Image> GetImagesByTags(string[] tags)
        //{

        //    var images = _dataContext.Images.Include(i => i.Tags).Where(i => i.Tags.Any(t => tags.Contains(t.Name)))
        //        .Select(i => new Image
        //        {
        //            Content = i.Content,
        //            Format = i.Format,
        //            Id = i.Id,
        //            Title = i.Title,
        //            Username = i.Username
        //        });
        //    return images;
        //}

        //public IEnumerable<Image> GetImagesByVotes(int min, int max)
        //{
        //    throw new NotImplementedException();
        //}
        //public void LinkTag(string tag, int imageId)
        //{
        //    throw new NotImplementedException();
        //}

        public void PlaceVote(int id,int voto)
        {
            var image = GetImageById(id);
           

			if (image != null)
			{
			
			
			}
			else
			{
				throw new Exception("Immagine non trovata.");
			}
		}

        public IEnumerable<Vote> GetVotes() => _dataContext.Votes.Select(v=> new Vote { Id=v.Id,Value=v.Value,Username=v.Username });
	}

    }


//var image = _dataContext.Images.Include(x => x.Tags).Single(i => i.Id == id);
//var taglist = new List<Tag>();
//foreach (var t in tags)
//{
//	var tag = _dataContext.Tags.Single(x => x.Id == t);
//	taglist.Add(tag);

//}
//image.Tags.Clear();
//_dataContext.SaveChanges();
//image.Tags = taglist;

//_dataContext.SaveChanges();