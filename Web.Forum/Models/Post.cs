﻿namespace Web.Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }

        //public List<Tag> Tags { get; set; }
    }
}
