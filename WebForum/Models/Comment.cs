using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebForum.Repository;

namespace WebForum.Models
{
    public class Comment
    {
        public int Id { get; set; }

        /*[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MinLength(32, ErrorMessage = "The {0} field must be at least {1} characters.")]
        [MaxLength(8192, ErrorMessage = "The {0} field must be less than {1} characters.")]*/
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public int? AutorId { get; set; }
        
        public User Autor { get; set; }

        public int Likes { get; set; }
        //public List<Rating> Rating { get; set; }
                
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
