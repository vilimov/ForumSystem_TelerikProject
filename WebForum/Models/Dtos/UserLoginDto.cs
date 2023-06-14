using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.Dtos
{
    public class UserLoginDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
        [MinLength(5), MaxLength(20)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
        [MinLength(8), MaxLength(20)]
        public string Password { get; set; }
    }
}
