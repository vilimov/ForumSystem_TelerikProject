using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Helpers.Mappers;
using WebForum.Models;
using WebForum.Models.Dtos;
using WebForum.Models.ViewModels;
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
            //newUser.HashedPassword = hashedPassword;
            newUser.Password = hashedPassword;

            return userRepository.CreateUser(newUser);
        }

        public User Login(string username, string password)
        {
            var user = userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with username {username} does not exist.");
            }

            string salt = user.Salt;
            string hashedPassword = AuthManager.HashPassword(password, salt);

            if (user.Password != hashedPassword)
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

			// Check if the first name is updated
			if (!string.IsNullOrEmpty(userUpdate.FirstName))
			{
				existingUser.FirstName = userUpdate.FirstName;
			}

			// Check if the last name is updated
			if (!string.IsNullOrEmpty(userUpdate.LastName))
			{
				existingUser.LastName = userUpdate.LastName;
			}

			return userRepository.UpdateUser(existingUser);
		}
		public void UpdatePassword(int userId, string plainTextPassword)
		{
			var existingUser = userRepository.GetUserById(userId);

			if (existingUser == null)
			{
				throw new EntityNotFoundException($"User with id {userId} does not exist.");
			}

			if (plainTextPassword.Length >= 8 && plainTextPassword.Length <= 20)
			{
				// Generate new salt
				string newSalt = AuthManager.GenerateSalt();

				// Hash the new password with the new salt
				string newHashedPassword = AuthManager.HashPassword(plainTextPassword, newSalt);

				// Update the user's salt and hashed password
				existingUser.Salt = newSalt;
				existingUser.Password = newHashedPassword;

				userRepository.UpdateUser(existingUser);
			}
		}
		public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with id {id} does not exist");
            }

            userRepository.DeleteUser(id);
        }

        public void PromoteToAdmin(int userId, User currentUser)
        {
            if (!currentUser.IsAdmin)
            {
                throw new UnauthorizedAccessException("Only admins can promote users to admin status.");
            }

            var userToPromote = userRepository.GetUserById(userId);

            if (userToPromote == null)
            {
                throw new EntityNotFoundException($"User with id {userId} does not exist.");
            }

            userToPromote.IsAdmin = true;

            userRepository.UpdateUser(userToPromote);
        }

        public void DemoteFromAdmin(int userId, User currentUser)
        {
            if (!currentUser.IsAdmin)
            {
                throw new UnauthorizedAccessException("Only admins can demote users from admin status.");
            }

            var userToDemote = userRepository.GetUserById(userId);

            if (userToDemote == null)
            {
                throw new EntityNotFoundException($"User with id {userId} does not exist.");
            }

            userToDemote.IsAdmin = false;

            userRepository.UpdateUser(userToDemote);
        }

        public IList<Post> GetUserPosts(int userId)
        {
            return postRepository.GetPostByUserId(userId);
        }

        public IList<Post> GetAllPosts()
        {
            return postRepository.GetAllPosts();
        }
        public List<UserViewModel> GetAllUserViewModels()
        {
            var users = userRepository.GetAllUsers();
            return users.Select(UserMapperView.MapToViewModel).ToList();
        }

        public UserViewModel GetUserViewModelById(int id)
        {
            var user = userRepository.GetUserById(id);
            return UserMapperView.MapToViewModel(user);
        }

        public UserViewModel GetUserViewModelByUsername(string username)
        {
            var user = userRepository.GetByUsername(username);
            return UserMapperView.MapToViewModel(user);
        }

        public UserViewModel GetUserViewModelByEmail(string email)
        {
            var user = userRepository.GetByEmail(email);
            return UserMapperView.MapToViewModel(user);
        }
    }
}
