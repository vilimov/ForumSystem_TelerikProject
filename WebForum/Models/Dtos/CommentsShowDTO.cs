using System.ComponentModel.DataAnnotations;
using WebForum.Repository;
using WebForum.Services;

namespace WebForum.Models.Dtos
{
    public class CommentsShowDTO
    {
        private readonly UserRepository userRepository;
        public CommentsShowDTO(Comment commentModel)
        {
            Content = commentModel.Content;
            CreatedAt = commentModel.CreatedAt;
            //
            Autor = commentModel.Autor;
            // ToDo - should take author from UserServices, but no such method there currently  
            Autor = userRepository.GetUserById(commentModel.Id);
            Likes = commentModel.Likes;
            Post = commentModel.Post;
        }

        public string Content { get; set; }        
        public DateTime CreatedAt { get; set; }
        public User Autor { get; set; }
        public int Likes { get; set; }
        public Post Post { get; set; }
    }
}
