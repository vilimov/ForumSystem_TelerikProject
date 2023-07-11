using WebForum.Models.Dtos;

namespace WebForum.Models.ViewModels
{
	public class PostViewModel : PostDtoCreateUpdate
	{
		public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
	}
}
