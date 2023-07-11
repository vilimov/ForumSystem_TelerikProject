using System.ComponentModel.DataAnnotations;

namespace WebForum.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
		[MinLength(3, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(15, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string Name { get; set; }
        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
