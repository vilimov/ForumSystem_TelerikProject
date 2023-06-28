using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Posts
{
    [TestClass]
    public class CreatePostShould
    {
        [TestMethod]
        public void ReturnCorrectPost_WhenParamsAreValid()
        {
            //Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
           
            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock
                .Setup(repo => repo.CreatePost(testPost))
                                   .Returns(testPost);
            var sut = new PostServices(repositoryMock.Object);

            //Act 
            Post actualPost = sut.CreatePost(testPost, testUser);

            //Assert
            Assert.AreEqual(testPost, actualPost);
        }
    }
}
