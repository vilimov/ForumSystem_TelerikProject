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
    public class DeletePostShould
    {
        [TestMethod]
        public void VerifyPostDeletion_WhenPostIsDeleted()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();

            // Set the post's author
            testPost.Autor = testUser;

            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);
            repositoryMock.Setup(repo => repo.DeletePost(testPost.Id))
                           .Returns(testPost);

            var sut = new PostServices(repositoryMock.Object);

            // Act
            Post actualPost = sut.DeletePost(testPost.Id, testUser);

            // Assert
            Assert.AreEqual(testPost, actualPost);
        }

        [TestMethod]
        public void Throw_WhenInvalidUser()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[2];

            // Set the post's author
            testPost.Autor = testUser;

            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock.Setup(repo => repo.GetPostById(testPost.Id))
                            .Returns(testPost);

            repositoryMock.Setup(repo => repo.DeletePost(testPost.Id))
                            .Returns(testPost);

            var sut = new PostServices(repositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.DeletePost(testPost.Id, otherUser));
        }

        [TestMethod]
        public void VerifyPostDeletion_WhenUserIsAdmin()
        {
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[1];
            // Set the post's author
            testPost.Autor = testUser;

            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);
            repositoryMock.Setup(repo => repo.DeletePost(testPost.Id))
                .Returns(testPost);
            var sut = new PostServices(repositoryMock.Object);

            // Act
            Post actualPost = sut.DeletePost(testPost.Id, otherUser);

            // Assert
            Assert.AreEqual(testPost, actualPost);
           
        }
    
    }
}
