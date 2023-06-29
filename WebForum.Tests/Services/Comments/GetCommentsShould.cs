using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Comments
{
    [TestClass]
    public class GetCommentsShould
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
        public void ThrowException_When_CommentsNotFound()
        {
            //Arrange

            var repositoryMock = new Mock<ICommentRepository>();

            repositoryMock
                .Setup(r => r.GetAll())
                .Throws(new EntityNotFoundException("Comment Not Found!"));

            var sut = new CommentsServices(repositoryMock.Object);

            //Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetAll());
            //Assert.ThrowsException<EntityNotFoundException>(() => sut.GetCommentById(It.IsAny<int>()));
        }
    }
}