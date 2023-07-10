using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        [MinLength(2), MaxLength(32)]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(32)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([a-zA-Z0-9-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
