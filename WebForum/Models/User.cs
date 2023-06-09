using System.ComponentModel.DataAnnotations;

namespace WebForum.Models
{
    public class User
    {
        public int Id { get; set; }

        [MinLength(1, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string FirstName { get; set; }
        
        [MinLength(1, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [RegularExpression(@"^([a-zA-Z0-9-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([a-zA-Z0-9-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty.")]
        [MinLength(5, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty.")]
        [MinLength(8, ErrorMessage = "The {0} field must be at least {1} characters.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "The {0} field is required.")]
        public bool IsAdmin { get; set; }

        //[Required(ErrorMessage = "The {0} field is required.")]
        public bool IsBlocked { get; set; }

        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
