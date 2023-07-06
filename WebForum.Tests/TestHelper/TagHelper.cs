using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Tests.TestHelper
{
    public static class TagsHelper
    {
        public static Tag GetTestTag()
        {
            return new Tag
            {
                Id = 1,
                Name = "testTag"
            };
        }

        public static Post GetTestPostWithTestTag()
        {
            var testUser = GetTestUserAdmin();
            var testTag = GetTestTag();

            return new Post
            {
                Id = 1,
                AutorId = 1,
                Autor = testUser,
                Title = "Test Post",
                Content = "This is a test post",
                PostTags = new List<PostTag>
        {
            new PostTag
            {
                PostId = 1,
                TagId = testTag.Id,
                Tag = testTag
            }
        }
            };
        }

        public static User GetTestUserAdmin()
        {
            return new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@example.com",
                IsAdmin = true
            };
        }

        public static User GetTestUserNonAdmin()
        {
            return new User
            {
                Id = 2,
                Username = "user",
                Email = "user@example.com",
                IsAdmin = false
            };
        }
    }
}
