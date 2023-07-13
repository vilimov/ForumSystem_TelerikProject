using WebForum.Models.Dtos;
using WebForum.Models;
using WebForum.Models.ViewModels;

namespace WebForum.Helpers.Mappers
{
    public static class UserMappers
    {
        public static User ToEntity(UserRegisterDto registerDto)
        {
            return new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = registerDto.Password,
            };
        }
        public static UserPublicDataDto ToUserPublicDataDto(this User user)
        {
            return new UserPublicDataDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email
            };
        }
        public static void ApplyUpdate(this User user, UserUpdateDto updateDto)
        {
            if (!string.IsNullOrEmpty(updateDto.FirstName))
            {
                user.FirstName = updateDto.FirstName;
            }

            if (!string.IsNullOrEmpty(updateDto.LastName))
            {
                user.LastName = updateDto.LastName;
            }

            if (!string.IsNullOrEmpty(updateDto.Email))
            {
                user.Email = updateDto.Email;
            }

            if (!string.IsNullOrEmpty(updateDto.Password))
            {
                user.Password = updateDto.Password;
            }
        }
    }
}
