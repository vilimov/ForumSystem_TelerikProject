using WebForum.Models;

namespace WebForum.Services
{
    public interface IPostServices
    {
        Post CreatePost(int userId, Post newPost);
        Post UpdatePost(int userId, Post updatedPost);
        void DeletePost(int userId, int postId);
        Post GetPost(int postId);
        IList<Post> GetAllPosts();
    }
}
