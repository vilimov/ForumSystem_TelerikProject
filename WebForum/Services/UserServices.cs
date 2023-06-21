using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Repository.Contracts;

namespace WebForum.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;

        public UserServices(IUserRepository userRepository, IPostRepository postRepository)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public User GetByUsername(string username)
        {
            return userRepository.GetByUsername(username);
        }

        public User GetByEmail(string email)
        {
            return userRepository.GetByEmail(email);
        }

        public User Register(User newUser)
        {
            var existingUserEmail = userRepository.GetByEmail(newUser.Email);
            var existingUserUsername = userRepository.GetByUsername(newUser.Username);

            if (existingUserEmail != null)
            {
                throw new DuplicateEntityException($"A user with email {newUser.Email} already exists.");
            }

            if (existingUserUsername != null)
            {
                throw new DuplicateEntityException($"A user with username {newUser.Username} already exists.");
            }
            
            // Generate salt
            string salt = AuthManager.GenerateSalt();

            // Concatenate salt with password and generate hashed password
            string hashedPassword = AuthManager.HashPassword(newUser.Password, salt);

            // Assign salt and hashed password to user object
            newUser.Salt = salt;
            newUser.HashedPassword = hashedPassword;

            return userRepository.CreateUser(newUser);
        }

        public User Login(string username, string password)
        {
            var user = userRepository.GetByUsername(username);

            if (user == null)
            {
                throw new EntityNotFoundException($"User with username {username} does not exist.");
            }

            if (user.Password != password)
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }

            return user;
        }

        public User UpdateProfile(User userUpdate)
        {
            var existingUser = userRepository.GetUserById(userUpdate.Id);

            if (existingUser == null)
            {
                throw new EntityNotFoundException($"User with id {userUpdate.Id} does not exist.");
            }

            if (userUpdate.Password != null)
            {
                // Generate new salt
                string newSalt = AuthManager.GenerateSalt();

                // Hash the new password with the new salt
                string newHashedPassword = AuthManager.HashPassword(userUpdate.Password, newSalt);

                // Update the user's salt and hashed password
                existingUser.Salt = newSalt;
                existingUser.HashedPassword = newHashedPassword;
            }

            return userRepository.UpdateUser(userUpdate);
        }

        public IList<Post> GetUserPosts(int userId)
        {
            return postRepository.GetPostByUserId(userId);
        }

        public IList<Post> GetAllPosts()
        {
            return postRepository.GetAllPosts();
        }
    }
}
