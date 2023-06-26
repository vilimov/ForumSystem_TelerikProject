using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Comments
{
    [TestClass]
    public class GetCommentShould
    {
        [TestMethod]
        public void ReturnAllComments_When_ParametersAreValid()
        {
            //Arrange

            List<Comment> expectedComments = TestHelper.CommentsHelper.GetTestComments();

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock
                .Setup(r => r.GetAll())
                .Returns(expectedComments);

            var sut = new CommentsServices(repositoryMock.Object);

            //Act

            List<Comment> actualComments = sut.GetAll();

            //Assert

            Assert.AreEqual(expectedComments.Count, actualComments.Count);
            for (int i = 0; i < expectedComments.Count; i++) 
            {
                Assert.AreEqual(expectedComments[i].Id, actualComments[i].Id);
                Assert.AreEqual(expectedComments[i].Content, actualComments[i].Content);
                Assert.AreEqual(expectedComments[i].CreatedAt, actualComments[i].CreatedAt);
                Assert.AreEqual(expectedComments[i].Likes, actualComments[i].Likes);
                Assert.AreEqual(expectedComments[i].AutorId, actualComments[i].AutorId);
                Assert.AreEqual(expectedComments[i].PostId, actualComments[i].PostId);
            }
        }

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