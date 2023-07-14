using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.ViewModels
{
    public class EditProfileViewModel
    { 

        [MinLength(2, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string FirstName { get; set; }

        
        [MinLength(2, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string LastName { get; set; }


		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "The {0} must contain Uppercase, Lowercase, Digit, Symbol and be at least 8 characters")]
		[MinLength(8, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string Password { get; set; }

		public IFormFile AvatarImage { get; set; }

	}
}
