using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security;
using WebForum.Models.LikesModels;

namespace WebForum.Models.Dtos
{
    public class PostShowDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public int Likes { get; set; }
        public string AutorName { get; set; }
        public List<CommentToPostDto> Comments { get; set; } = new List<CommentToPostDto>();
        public List<string> UsersWhoLiked { get; set; }

        public List<string> TagsAddedToPost { get; set; }
    }
}
