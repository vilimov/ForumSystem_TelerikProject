using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Tests.TestHelper
{
    public class PostsHelper
    {

        public static Post GetTestPost()
        {
            return new Post
            {
                Id = 1,
                Title = "Test Title For Unit test2",
                Content = "Test Content for Unit test, let's see the result",
                CreatedAt = DateTime.Now,
                //Likes = 0,
                AutorId = 1
            };
        }

        public static List<Post> GetTestPostList()
        {
            return new List<Post>
            {
                new Post
                {
                Id = 1,
                Title = "Acta est Fabula, Plaudite!",
                Content = "1. The play is over, applaud! Louder applaud!!!",
                CreatedAt = DateTime.Now,
                //Likes = 10,
                AutorId = 1
                },

                new Post
                {
                Id = 2,
                Title = "Alea Jacta Est est Jacta",
                Content = "2. The play is over, applaud! Louder applaud!!!",
                CreatedAt = DateTime.Now,
                //Likes = 0,
                AutorId = 1
                },

                new Post
                {
                Id = 3,
                Title = "Omnium Rerum Principia Parva Sunt",
                Content = "3. The play is over, applaud! Louder applaud!!!",
                CreatedAt = DateTime.Now,
                //Likes = 1,
                AutorId = 2
                }
            };
        }
    }
}
