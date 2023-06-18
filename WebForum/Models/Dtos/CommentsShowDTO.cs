using System.ComponentModel.DataAnnotations;
using WebForum.Repository;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Models.Dtos
{
    public class CommentsShowDTO
    {
        public CommentsShowDTO(Comment commentModel)
        {
            Content = commentModel.Content;
            Likes = commentModel.Likes;
            CreatedAt = commentModel.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            Autor = commentModel.Autor.Username;
            PostTitle = commentModel.Post.Title;
            PostContent = commentModel.Post.Content;
        }

        public string Content { get; set; }
        public int Likes { get; set; }
        public string CreatedAt { get; set; }
        public string Autor { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }

    }
}
