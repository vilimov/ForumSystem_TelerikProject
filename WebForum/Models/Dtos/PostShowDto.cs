using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security;

namespace WebForum.Models.Dtos
{
    public class PostShowDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public string AutorName { get; set; }
        public Dictionary<string, string> Comments { get; set; } = new Dictionary<string, string>();

    }
}
