using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.QueryParameters;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Posts
{
    [TestClass]
    public class GetPostsShould
    {
        [TestMethod]
        public void ReturnCorrectPost_When_ParamsAreValid()
        {
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[1];
            // Set the post's author
            testPost.Autor = testUser;

            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);

            var sut = new PostServices(repositoryMock.Object);

            // Act
            Post actualPost = sut.GetPostById(testPost.Id);

            // Assert
            Assert.AreEqual(testPost, actualPost);
        }

        [TestMethod]
        public void Throw_When_PostNotFound()
        {
            //Arrange
            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock
                .Setup(repo => repo.GetPostById(It.IsAny<int>()))
                .Throws(new EntityNotFoundException("Post Not Found"));

            var sut = new PostServices(repositoryMock.Object);
            //Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetPostById(It.IsAny<int>()));
        }

        [TestMethod]
        public void ReturnAllPost_When_ParamsAreValid()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();

            // Set the post's author
            testPost.Autor = testUser;

            List<Post> allPosts = TestHelper.PostsHelper.GetTestPostList();

            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock.Setup(repo => repo.GetAllPosts()).Returns(allPosts);

            var sut = new PostServices(repositoryMock.Object);

            // Act
            IList<Post> actualPosts = sut.GetAllPosts();

            // Assert
            Assert.AreEqual(allPosts.Count, actualPosts.Count);
            Assert.AreEqual(allPosts[0], actualPosts[0]);
        }

        [TestMethod]
        public void ReturnAllPostByUserId_When_ParamsAreValid()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();

            // Set the post's author
            testPost.Autor = testUser;

            List<Post> allPosts = TestHelper.PostsHelper.GetTestPostList().Where(p => p.AutorId == testUser.Id).ToList();

            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock.Setup(repo => repo.GetPostByUserId(It.Is<int>(id => id == testUser.Id)))
                            .Returns(allPosts.Where(p => p.AutorId == testUser.Id).ToList());

            var sut = new PostServices(repositoryMock.Object);

            // Act
            IList<Post> actualPosts = sut.GetPostsByUserId(testUser.Id);

            // Assert
            Assert.AreEqual(allPosts.Count, actualPosts.Count);
           
        }

        [TestMethod]
        public void ReturnFilteredPost_When_ParamsAreValid()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[1];
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            var filterQueryParameters = new PostFilterQueryParameters
            {
                UserName = "Caesar"
            };

            // Set the post's author
            testPost.Autor = testUser;

            List<Post> allPosts = TestHelper.PostsHelper.GetTestPostList();
            allPosts[0].Autor = testUser;
            allPosts[1].Autor = testUser;
            allPosts[2].Autor = otherUser;

            allPosts = allPosts.Where(p => p.Autor.Username.Contains(filterQueryParameters.UserName)).ToList();

            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock.Setup(repo => repo.FilterPostsBy(filterQueryParameters)).Returns(allPosts);

            var sut = new PostServices(repositoryMock.Object);

            // Act
            IList<Post> actualPosts = sut.FilterPostsBy(filterQueryParameters);

            // Assert
            Assert.AreEqual(allPosts.Count, actualPosts.Count);
            Assert.AreEqual(allPosts[0], actualPosts[0]);
        }

    }
}
