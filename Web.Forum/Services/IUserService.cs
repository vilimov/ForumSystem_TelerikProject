using Web.Forum.Models;

namespace Web.Forum.Services
{
    public interface IUserService
    {
        User Register(User newUser);
        User Login(string username, string password);
        User UpdateProfile(User user);
        IList<Post> GetUserPosts(int userId);
        IList<Post> GetAllPosts();
    }
}
