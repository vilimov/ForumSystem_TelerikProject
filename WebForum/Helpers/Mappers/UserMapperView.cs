using WebForum.Models.ViewModels;
using WebForum.Models;

namespace WebForum.Helpers.Mappers
{
    public class UserMapperView
    {
        public static UserViewModel MapToViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
                Role = user.IsAdmin ? "Admin" : "User"
            };
        }
    }
}
