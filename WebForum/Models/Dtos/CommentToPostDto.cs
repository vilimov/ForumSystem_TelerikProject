namespace WebForum.Models.Dtos
{
    public class CommentToPostDto
    {
        public string Content { get; set; }
        public int Likes { get; set; }
        public string CreatedAt { get; set; }
        public string Autor { get; set; }
    }
}
