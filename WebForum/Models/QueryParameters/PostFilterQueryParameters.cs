namespace WebForum.Models.QueryParameters
{
    public class PostFilterQueryParameters
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public string OrderByComments { get; set; }
        public string OrderByDate { get; set; }
        public string OrderByLikes { get; set; }
		public string Tag { get; set; }
	}
}
