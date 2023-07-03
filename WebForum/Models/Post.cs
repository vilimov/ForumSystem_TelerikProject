using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using WebForum.Models.LikesModels;

namespace WebForum.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MinLength(16, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(64, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MinLength(32, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(8192, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }             //CreatedAt = DateTime.Now  

        [Required(ErrorMessage = "The {0} field is required")]

        public int? AutorId { get; set; }
        public User Autor { get; set; }

        [JsonIgnore]
        public List<Comment> Comments { get; set; }
        [JsonIgnore]
        public List<LikePost> LikePosts { get; set; } = new List<LikePost>();

        [Range(0, int.MaxValue, ErrorMessage = "The {0} field must be between {1} and {2}.")]
        public int Likes => LikePosts.Count;

        //TODO Tags on posts
        //public List<Tag> Tags { get; set; }
    }
}
