using System.ComponentModel.DataAnnotations;
using WebForum.Repository;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Models.Dtos
{
    public class CommentsShowDTO
    {
        private static UserServices userService;
        private static PostServices postService;
        public CommentsShowDTO(Comment commentModel)
        {
            Content = commentModel.Content;
            CreatedAt = commentModel.CreatedAt;
            //Autor = userService.GetUserById((int)commentModel.AutorId).Username;
            Autor = commentModel.Autor;
            Likes = commentModel.Likes;
            Post = commentModel.Post;
            //Post = postService.GetPost((int)commentModel.PostId).Autor;
        }

        public string Content { get; set; }        
        public DateTime CreatedAt { get; set; }
        public User Autor { get; set; }
        public int Likes { get; set; }
        public Post Post { get; set; }
    }
}
