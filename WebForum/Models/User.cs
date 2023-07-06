using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebForum.Models.LikesModels;

namespace WebForum.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [RegularExpression(@"^([a-zA-Z0-9-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([a-zA-Z0-9-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
        [MinLength(5, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
        //Hack Mila User
        //[MinLength(8, ErrorMessage = "The {0} field must be at least {1} characters.")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "The {0} must contain Uppercase, Lowercase, Digit, Symbol and be at least 8 characters")]
        //[MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
        [MaxLength(170)]
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; }     
        public bool IsBlocked { get; set; }
        //public bool IsDeleted { get; set; }
        [JsonIgnore]
        public List<Post> Posts { get; set; }
        [JsonIgnore]
        public List<Comment> Comments { get; set; }
        [JsonIgnore]
        public List<LikePost> LikePosts { get; set; } = new List<LikePost>();
		[JsonIgnore]
		public List<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

    }
}
