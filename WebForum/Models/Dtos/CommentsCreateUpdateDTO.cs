using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.Dtos
{
    public class CommentsCreateUpdateDTO
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [Range(32, 8192, ErrorMessage = "The {0} field must be between {1} and {2} characters.")]
        public string Content { get; set; }

       /* [Required(ErrorMessage = "The {0} field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The {0} field must be a valid integer.")]
        public int AutorId { get; set; }*/

        [Required (ErrorMessage = "The {0} field is required")]
        [Range (1, int.MaxValue, ErrorMessage = "The {0} field must be a valid integer.")]
        public int PostId { get; set; }
    }
}
