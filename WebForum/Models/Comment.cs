using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebForum.Models.LikesModels;
using WebForum.Repository;

namespace WebForum.Models
{
    public class Comment
    {
        private int likes;
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MinLength(32, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(8192, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh:mm:ss}")]
        public DateTime CreatedAt { get; set; }

        public int? AutorId { get; set; }
        
        public User Autor { get; set; }

		[JsonIgnore]
		public List<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

		[JsonIgnore]
		public int Likes => CommentLikes.Count;

		public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
