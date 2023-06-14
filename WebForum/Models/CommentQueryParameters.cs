namespace WebForum.Models
{
    public class CommentQueryParameters
    {
        public string Content { get; set; }
        public int? MinLikes  { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}
