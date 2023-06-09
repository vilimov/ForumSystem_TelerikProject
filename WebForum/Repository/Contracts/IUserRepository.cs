using WebForum.Models;

namespace WebForum.Repository.Contracts
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User AddUser(User newUser);
        User CreateUser(User newUser);
        User UpdateUser(int id, User updatedUser);
        User DeleteUser(int id);
        User GetByEmail(string email);
    }
}
