

using DataLayer;


namespace ServiceLayer
{
	public interface IGalleriaService
	{
		Image GetImageById(int id);
		void Upload(Image image);
		IEnumerable<Image> GetImages();
		void DeleteImage(int imageId);
		IEnumerable<Tag> GetTags();
		IEnumerable<Vote> GetVotes();
		void CreateTag(string nome);
		void DeleteTag(int id);
		void AssegnaTag(int id, List<int> tags);

		//void LinkTag(string tag, int imageId);
		void PlaceVote(int id,int voto);
		//IEnumerable<Image> GetImagesByTags(string[] tags);
		//IEnumerable<Image> GetImagesByVotes(int min, int max);
	}
}