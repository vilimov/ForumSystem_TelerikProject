using WebForum.Models;

namespace WebForum.Repository.Contracts
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetByUsername(string username);
        List<User> GetAllUsers();
        User CreateUser(User newUser);
        User UpdateUser(User updatedUser);
        User DeleteUser(int id);
        User GetByEmail(string email);
    }
}
