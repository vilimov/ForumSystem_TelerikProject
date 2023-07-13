using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Models.ViewModels;

namespace WebForum.Services
{
    public interface IUserServices
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetByUsername(string username);
        User GetByEmail(string email);
        User Register(User newUser);
        User Login(string username, string password);
        User UpdateProfile(User userUpdate);
        void UpdatePassword(int userId, string plainTextPassword);
        void DeleteUser(int id);
        void PromoteToAdmin(int userId, User currentUser);
        void DemoteFromAdmin(int userId, User currentUser);
        IList<Post> GetUserPosts(int userId);
        IList<Post> GetAllPosts();
        List<UserViewModel> GetAllUserViewModels();
        UserViewModel GetUserViewModelById(int id);
        UserViewModel GetUserViewModelByUsername(string username);
        UserViewModel GetUserViewModelByEmail(string email);
    }
}
