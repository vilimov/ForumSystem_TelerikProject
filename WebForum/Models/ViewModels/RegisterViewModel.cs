using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
		[MinLength(5, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string Username { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "The {0} must contain Uppercase, Lowercase, Digit, Symbol and be at least 8 characters")]
		[MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string Password { get; set; }

		//[DataType(DataType.Password)]
		//[Display(Name = "Confirm password")]
		//[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		//public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Email is required!")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string Email { get; set; }

		[Required]
		[MinLength(2, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string FirstName { get; set; }

		[Required]
		[MinLength(2, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string LastName { get; set; }


		// public string ProfileImage { get; set; }
	}
}
