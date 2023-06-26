using System.Security.Cryptography;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Helpers.Authentication
{
    public class AuthManager
    {
        private readonly IUserServices usersService;

        public AuthManager(IUserServices usersService)
        {
            this.usersService = usersService;
        }

        public User TryGetUser(string credentials)
        {
            if (!credentials.Contains(':'))
            {
                throw new InvalidPasswordException("Invalid credentials");
            }

            string[] credentialsArray = credentials.Split(':');
            string username = credentialsArray[0];
            string enteredPassword = credentialsArray[1];

            try
            {
                var user = this.usersService.GetByUsername(username);
                if (user == null) 
                {
                    throw new EntityNotFoundException("Invalid credentials!");
                }
                //string saltedPassword = string.Concat(enteredPassword, user.Salt);
                string hashedPassword = HashPassword(enteredPassword, user.Salt);

                if (user.Password == hashedPassword)
                {
                    return user;
                }
                throw new UnauthenticatedOperationException("Invalid credentials!");
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid credentials!");
            }
            catch (UnauthenticatedOperationException e)
            {
                throw new UnauthorizedOperationException(e.Message);
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16]; // 16 bytes = 128 bits
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hashBytes = rfc2898DeriveBytes.GetBytes(32); // 32 bytes = 256 bits (recommended for bcrypt)
                return Convert.ToBase64String(hashBytes);
            }
        }


    }
}
