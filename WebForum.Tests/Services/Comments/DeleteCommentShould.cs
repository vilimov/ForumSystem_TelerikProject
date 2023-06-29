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

namespace WebForum.Tests.Services.Comments
{
    [TestClass]
    public class DeleteCommentShould
    {
        [TestMethod]
        public void DeleteComment_When_ParametersAreValid()
        {
            // Arrange
            Comment testComment = TestHelper.CommentsHelper.GetTestComment();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            User testUser = TestHelper.UsersHelper.GetTestUser();

            testComment.Autor = testUser;

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock.Setup(r => r.GetCommentById(testComment.Id)).Returns(testComment);
            repositoryMock.Setup(r => r.Delete(testComment.Id)).Returns(testComment);

            var sut = new CommentsServices(repositoryMock.Object);

            // Act
            Comment deletedComment = sut.Delete(testComment.Id, testUser);

            // Assert
            Assert.AreEqual(testComment, deletedComment);
            Assert.AreEqual(testComment.Id, deletedComment.Id);
            Assert.AreEqual(testComment.Content, deletedComment.Content);
            Assert.AreEqual(testComment.CreatedAt, deletedComment.CreatedAt);
            Assert.AreEqual(testComment.Likes, deletedComment.Likes);
            Assert.AreEqual(testComment.AutorId, deletedComment.AutorId);
            Assert.AreEqual(testComment.PostId, deletedComment.PostId);
        }

        [TestMethod]
        public void ThrowException_When_AutorNotValid()
        {
            //Arrange
            Comment testComment = TestHelper.CommentsHelper.GetTestComment();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            User testUser = TestHelper.UsersHelper.GetTestUser();
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[2];


            testComment.Autor = testUser;

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock.Setup(r => r.GetCommentById(testComment.Id)).Returns(testComment);
            repositoryMock.Setup(r => r.Delete(testComment.Id)).Returns(testComment);

            var sut = new CommentsServices(repositoryMock.Object);

            //Act & Assert

            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.Delete(testComment.Id, otherUser));
        }
    }    
}
