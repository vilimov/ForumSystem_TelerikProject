using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Comments
{
    [TestClass]
    public class CreateCommentShould
    {
        [TestMethod]
        public void CreateComment_When_ParametersAreValid()
        {
            //Arrange
            Comment testComment = TestHelper.CommentsHelper.GetTestComment();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            User testUser = TestHelper.UsersHelper.GetTestUser();

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock.Setup(r => r.Create(testComment)).Returns(testComment);

            var sut = new CommentsServices(repositoryMock.Object);

            //Act
            Comment actualComment = sut.CreateComment(testComment, testPost, testUser);

            //Assert
            Assert.AreEqual(testComment, actualComment);
            Assert.AreEqual(testComment.Id, actualComment.Id);
            Assert.AreEqual(testComment.Content, actualComment.Content);
            Assert.AreEqual(testComment.CreatedAt, actualComment.CreatedAt);
            Assert.AreEqual(testComment.Likes, actualComment.Likes);
            Assert.AreEqual(testComment.AutorId, actualComment.AutorId);
            Assert.AreEqual(testComment.PostId, actualComment.PostId);
        }
    }
}
