using WebForum.Models;

namespace WebForum.Services
{
    public interface IPostServices
    {
        Post CreatePost(Post post, User user);
        Post UpdatePost(int id, Post post, User user);
        Post DeletePost(int id, User user);
        Post GetPost(int id);
        IList<Post> GetAllPosts();
        IList<Post> GetPostsByUserId(int id);

    }
}
