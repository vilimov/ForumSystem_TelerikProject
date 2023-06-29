using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Tests.TestHelper
{
    public class CommentsHelper
    {
        public static Comment GetTestComment()
        {
            return new Comment
            {
                Id = 1,
                Content = "TestContent",
                CreatedAt = DateTime.Now,
                Likes = 5,
                AutorId = 1,
                PostId = 1
            };
        }

        public static List<Comment> GetTestComments()
        {
            return new List<Comment>
            {
                new Comment 
                {
                Id = 1,
                Content = "TestContent 1",
                CreatedAt = DateTime.Now,
                Likes = 1,
                AutorId = 1,
                PostId = 1
                },

                new Comment
                {
                Id = 2,
                Content = "TestContent 2",
                CreatedAt = DateTime.Now,
                Likes = 2,
                AutorId = 2,
                PostId = 2
                },

                new Comment
                {
                Id = 3,
                Content = "TestContent 3",
                CreatedAt = DateTime.Now,
                Likes = 3,
                AutorId = 3,
                PostId = 3
                },

                new Comment
                {
                Id = 4,
                Content = "TestContent 4",
                CreatedAt = DateTime.Now,
                Likes = 1,
                AutorId = 1,
                PostId = 1
                },
            };
        }
    }
}
