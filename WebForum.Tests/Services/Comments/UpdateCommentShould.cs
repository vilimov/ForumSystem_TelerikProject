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
    public class UpdateCommentShould
    {
        [TestMethod]
        public void UpdateComment_When_ParametersAreValid()
        {
            //Arrange
            Comment testComment = TestHelper.CommentsHelper.GetTestComment();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            User testUser = TestHelper.UsersHelper.GetTestUser();

            testComment.Autor = testUser;

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock.Setup(r => r.GetCommentById(testComment.Id)).Returns(testComment);
            repositoryMock.Setup(r => r.Update(testComment.Id, testComment)).Returns(testComment);

            var sut = new CommentsServices(repositoryMock.Object);

            //Act
            Comment actualComment = sut.Update(testComment.Id, testComment, testUser);

            //Assert
            Assert.AreEqual(testComment, actualComment);
            Assert.AreEqual(testComment.Id, actualComment.Id);
            Assert.AreEqual(testComment.Content, actualComment.Content);
            Assert.AreEqual(testComment.CreatedAt, actualComment.CreatedAt);
            Assert.AreEqual(testComment.Likes, actualComment.Likes);
            Assert.AreEqual(testComment.AutorId, actualComment.AutorId);
            Assert.AreEqual(testComment.PostId, actualComment.PostId);
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
            repositoryMock.Setup(r => r.Update(testComment.Id, testComment)).Returns(testComment);

            var sut = new CommentsServices(repositoryMock.Object);

            //Act & Assert

            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.Update(testComment.Id, testComment, otherUser));
        }
    }
}
