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
    public class GetCommentByIdShould
    {
        [TestMethod]
        public void ReturnCorrectComment_When_CommentIdIsValid()
        {
            //Arrange

            //Comment expectedComment = new Comment { Id = 1, AutorId = 1, Content = "TestContent", CreatedAt = DateTime.Now, Likes = 5, PostId = 1};
            Comment expectedComment = TestHelper.CommentsHelper.GetTestComment();

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock
                .Setup(r => r.GetCommentById(1))
                .Returns(expectedComment);

            var sut = new CommentsServices(repositoryMock.Object);

            //Act

            Comment actualComment = sut.GetCommentById(expectedComment.Id);

            //Assert

            //Assert.AreEqual(expectedComment, actualComment);
            Assert.AreEqual(expectedComment.Id, actualComment.Id);
            Assert.AreEqual(expectedComment.Content, actualComment.Content);
            Assert.AreEqual(expectedComment.CreatedAt, actualComment.CreatedAt);
            Assert.AreEqual(expectedComment.Likes, actualComment.Likes);
            Assert.AreEqual(expectedComment.AutorId, actualComment.AutorId);
            Assert.AreEqual(expectedComment.PostId, actualComment.PostId);
        }

        [TestMethod]
        public void ThrowException_When_CommentIdNotFound()
        {
            //Arrange

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock
                .Setup(r => r.GetCommentById(It.IsAny<int>()))
                .Throws(new EntityNotFoundException("Comment Not Found!"));

            var sut = new CommentsServices(repositoryMock.Object);

            //Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetCommentById(1));
            //Assert.ThrowsException<EntityNotFoundException>(() => sut.GetCommentById(It.IsAny<int>()));
        }
    }
}
