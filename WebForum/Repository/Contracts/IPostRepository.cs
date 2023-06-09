using WebForum.Models;

namespace WebForum.Repository.Contracts
{
    public interface IPostRepository
    {
        Post GetPostById(int id);
        List<Post> GetAllPosts();
        List<Post> GetPostByUserId(int userId);
        List<Post> GetPostByTitle(string title);
        Post CreatePost(Post newPost);
        Post UpdatePost(int id, Post post);
        Post DeletePost(int id);
        //List<Comment> GetPostComments();
    }
}
