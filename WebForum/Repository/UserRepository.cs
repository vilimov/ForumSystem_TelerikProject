using WebForum.Data;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumContext context;

        public UserRepository(ForumContext context)
        {
            this.context = context;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.Username == username);
        }

        public User GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User CreateUser(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "New user cannot be null");
            }

            context.Users.Add(newUser);
            context.SaveChanges();

            return newUser;
        }

        public User DeleteUser(int id)
        {
            var userToDelete = this.GetUserById(id);
            if (userToDelete == null)
            {
                throw new EntityNotFoundException($"User with id {id} does not exist");
            }

            context.Users.Remove(userToDelete);
            context.SaveChanges();

            return userToDelete;
        }

        public User UpdateUser(User updatedUser)
        {
            User userToUpdate = this.GetUserById(updatedUser.Id);
            if (userToUpdate == null)
            {
                throw new EntityNotFoundException($"User with id {updatedUser.Id} does not exist");
            }

            if (updatedUser.Email != null && userToUpdate.Email != updatedUser.Email)
            {
                // Проверява дали новият e-mail е вече използван от друг user
                var existingUserWithSameEmail = context.Users.FirstOrDefault(u => u.Email == updatedUser.Email);
                if (existingUserWithSameEmail != null)
                {
                    throw new ArgumentException("A user with this email already exists.");
                }
                userToUpdate.Email = updatedUser.Email;
            }

            if (updatedUser.Password != null)
            {
                userToUpdate.Password = updatedUser.Password;
            }

            if (updatedUser.FirstName != null)
            {
                userToUpdate.FirstName = updatedUser.FirstName;
            }

            if (updatedUser.LastName != null)
            {
                userToUpdate.LastName = updatedUser.LastName;
            }

            context.Users.Update(userToUpdate);
            context.SaveChanges();

            return userToUpdate;
        }
    }
}
