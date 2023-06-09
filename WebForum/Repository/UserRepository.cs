using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users;

        private int nextId = 1;

        public UserRepository()
        {
            users = new List<User>()
        {
            new User { Id = 1, FirstName = "Pesho", LastName = "Peshov", Email = "Pesho123@example.com",
                       Username = "PesheP", Password = "password123", IsAdmin = false, IsBlocked = false},
            new User { Id = 2, FirstName = "Tosho", LastName = "Toshov", Email = "Tosho123@example.com",
                       Username = "ToshoT", Password = "password456", IsAdmin = false, IsBlocked = false},
            new User { Id = 3, FirstName = "Gosho", LastName = "Goshov", Email = "Gosho123@example.com",
                       Username = "GoshoG", Password = "password789", IsAdmin = true, IsBlocked = false},
        };
        }
        
        public List<User> GetAllUsers()
        {
            return this.users;
        }
        public User GetUserById(int id)
        {
            var user = this.users.Where(u => u.Id == id).FirstOrDefault();
            return user ?? throw new EntityNotFoundException($"User with id {id} does not exist");
        }
        public User GetByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }
        public User GetByEmail(string email)
        {
            var user = this.users.FirstOrDefault(u => u.Email == email);
            return user ?? throw new EntityNotFoundException($"User with email {email} does not exist");
        }
        public User CreateUser(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "New user cannot be null");
            }

            newUser.Id = users.Count + 1;
            users.Add(newUser);
            return newUser;
        }
        public User DeleteUser(int id)
        {
            var userToDelete = this.GetUserById(id);
            if (userToDelete == null)
            {
                throw new EntityNotFoundException($"User with id {id} does not exist");
            }
            this.users.Remove(userToDelete);

            return userToDelete;
        }
        public User AddUser(User newUser)
        {
            if (users.Any(u => u.Email == newUser.Email))
            {
                throw new ArgumentException("A user with this email already exists.");
            }
            newUser.Id = ++nextId;
            users.Add(newUser);
            return newUser;
        }
        public User UpdateUser(int id, User updatedUser)
        {
            User userToUpdate = this.GetUserById(id);
            if (userToUpdate == null)
            {
                throw new EntityNotFoundException($"User with id {id} does not exist");
            }
            if (updatedUser.Email != null)
            {
                userToUpdate.Email = updatedUser.Email;
            }

            return userToUpdate;
        }
    }
}
