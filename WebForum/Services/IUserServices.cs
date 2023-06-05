using WebForum.Models;

namespace WebForum.Services
{
    public interface IUserServices
    {
        User Register(User newUser);
        User Login(string username, string password);
        User UpdateProfile(User user);
        IList<Post> GetUserPosts(int userId);
        IList<Post> GetAllPosts();
    }
}
