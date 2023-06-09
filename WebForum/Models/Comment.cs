using System.ComponentModel.DataAnnotations;

namespace WebForum.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int postId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MinLength(32, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(8192, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        //[Range(0, int.MaxValue, ErrorMessage = "The {0} field must be between {1} and {2}.")]
        public int Likes { get; set; }

        //[Range(0, int.MaxValue, ErrorMessage = "The {0} field must be between {1} and {2}.")]
        public int Dislikes { get; set; }
        public User Autor { get; set; }
        public Post Post { get; set; }
    }
}
