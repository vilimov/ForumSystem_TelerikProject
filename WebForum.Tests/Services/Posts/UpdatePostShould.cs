using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Posts
{
    [TestClass]
    public class UpdatePostShould
    {
        [TestMethod]
        public void ReturnCorrectPost_WhenParamsAreValid()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            testPost.Autor = testUser;

            //Tag new
            var tagServiceMock = new Mock<ITagService>();

            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);

            // Mock the behavior of GetPostByTitle to return a list with one or more posts
            repositoryMock.Setup(repo => repo.GetPostByTitle(testPost.Title)).Returns(new List<Post> { });

            repositoryMock.Setup(repo => repo.UpdatePost(testPost.Id, testPost)).Returns(testPost);

            //var sut = new PostServices(repositoryMock.Object);
            var sut = new PostServices(repositoryMock.Object, tagServiceMock.Object);

            // Act 
            Post actualPost = sut.UpdatePost(testPost.Id, testPost, testUser);

            // Assert
            Assert.AreEqual(testPost, actualPost);
        }

		[TestMethod]
		public void Throw_When_DuplicateOnTitle()
		{
			// Arrange
			User testUser = TestHelper.UsersHelper.GetTestUser();
			Post testPost = TestHelper.PostsHelper.GetTestPost();
			testPost.Autor = testUser;

			// Tag new
			var tagServiceMock = new Mock<ITagService>();

			var repositoryMock = new Mock<IPostRepository>();

			repositoryMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);

			// Mock the behavior of GetPostByTitle to return a list with one or more posts excluding the post being updated
			repositoryMock.Setup(repo => repo.GetPostByTitle(testPost.Title))
				.Returns((string title) =>
				{
					var posts = new List<Post> { testPost };
					posts.Add(new Post { Id = 2, Title = testPost.Title }); // Adding a dummy post with the same title
					return posts;
				});

			repositoryMock.Setup(repo => repo.UpdatePost(testPost.Id, testPost)).Returns(testPost);

			var sut = new PostServices(repositoryMock.Object, tagServiceMock.Object);

			// Act & Assert
			Assert.ThrowsException<DuplicateEntityException>(() => sut.UpdatePost(testPost.Id, testPost, testUser));
		}



		[TestMethod]
        public void Throw_When_UserNotAutorOrAdmin()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            testPost.Autor = testUser;
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[2];

            //Tag new
            var tagServiceMock = new Mock<ITagService>();

            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);

            // Mock the behavior of GetPostByTitle to return a list with one or more posts
            repositoryMock.Setup(repo => repo.GetPostByTitle(testPost.Title)).Returns(new List<Post> { testPost });

            repositoryMock.Setup(repo => repo.UpdatePost(testPost.Id, testPost)).Returns(testPost);

            //var sut = new PostServices(repositoryMock.Object);
            var sut = new PostServices(repositoryMock.Object, tagServiceMock.Object);

            //Act & Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.UpdatePost(testPost.Id, testPost, otherUser));
        }

        [TestMethod]
        public void UpdatePost_WhenUserIsAdmin()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            testPost.Autor = testUser;
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[1];

            //Tag new
            var tagServiceMock = new Mock<ITagService>();

            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);

            // Mock the behavior of GetPostByTitle to return a list with one or more posts
            repositoryMock.Setup(repo => repo.GetPostByTitle(testPost.Title)).Returns(new List<Post> { });

            repositoryMock.Setup(repo => repo.UpdatePost(testPost.Id, testPost)).Returns(testPost);

            //var sut = new PostServices(repositoryMock.Object);
            var sut = new PostServices(repositoryMock.Object, tagServiceMock.Object);

            // Act 
            Post actualPost = sut.UpdatePost(testPost.Id, testPost, otherUser);

            // Assert
            Assert.AreEqual(testPost, actualPost);
        }
    }
}
