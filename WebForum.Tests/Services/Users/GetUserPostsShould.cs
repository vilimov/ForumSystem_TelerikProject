using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;
using WebForum.Tests.TestHelper;

namespace WebForum.Tests.Services.Users
{
    [TestClass]
    public class GetUserPostsShould
    {
        [TestMethod]
        public void GetUserPosts_ReturnsCorrectPosts_WhenUserIdExists()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();
            List<Post> testPosts = PostsHelper.GetTestPostList();

            postRepoMock.Setup(repo => repo.GetPostByUserId(testUser.Id)).Returns(testPosts);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.GetUserPosts(testUser.Id);

            // Assert
            CollectionAssert.AreEqual(testPosts, result.ToList());
        }

        [TestMethod]
        public void GetAllPosts_ReturnsAllPosts()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            List<Post> testPosts = PostsHelper.GetTestPostList();

            postRepoMock.Setup(repo => repo.GetAllPosts()).Returns(testPosts);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.GetAllPosts();

            // Assert
            CollectionAssert.AreEqual(testPosts, result.ToList());
        }
    }
}
