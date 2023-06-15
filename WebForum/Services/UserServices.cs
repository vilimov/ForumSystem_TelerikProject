using WebForum.Helpers.Exceptions;
using WebForum.Models;
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

        public User Register(User newUser)
        {
            if (userRepository.GetByEmail(newUser.Email) != null)
            {
                throw new DuplicateEntityException($"A user with email {newUser.Email} already exists.");
            }

            if (userRepository.GetByUsername(newUser.Username) != null)
            {
                throw new DuplicateEntityException($"A user with username {newUser.Username} already exists.");
            }

            return userRepository.CreateUser(newUser);
        }

        public User Login(string username, string password)
        {
            // ToDo
            throw new NotImplementedException();
        }

        public User UpdateProfile(User user)
        {
            var existingUser = userRepository.GetUserById(user.Id);

            if (existingUser == null)
            {
                throw new EntityNotFoundException($"User with id {user.Id} does not exist.");
            }

            return userRepository.UpdateUser(user);
        }

        public IList<Post> GetUserPosts(int userId)
        {
            return postRepository.GetPostByUserId(userId).ToList();
        }

        public IList<Post> GetAllPosts()
        {
            return postRepository.GetAllPosts().ToList();
        }
    }
}
