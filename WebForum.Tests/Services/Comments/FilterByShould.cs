using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models.QueryParameters;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Comments
{
    [TestClass]
    public class FilterByShould
    {
        [TestMethod]
        public void ReturnFilteredComments_When_ParametersAreValid()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            List<User> users = TestHelper.UsersHelper.GetTestUsersList();
            User otherUser = users[1];
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            Comment testComment = TestHelper.CommentsHelper.GetTestComment();
            var filterParameters = new CommentQueryParameters
            {
                Content = "TestContent"
            };

            testComment.Autor = testUser;

            List<Comment> testComments = TestHelper.CommentsHelper.GetTestComments();
            testComments[0].Autor = testUser;
            testComments[2].Autor = otherUser;

            List<Comment> expectedComments = testComments.Where(p => p.Content.Contains(filterParameters.Content)).ToList();

            var repositoryMock = new Mock<ICommentRepository>();
            repositoryMock.Setup(r => r.FilterBy(filterParameters)).Returns(testComments);

            var sut = new CommentsServices(repositoryMock.Object);

            // Act
            IList<Comment> actualComments = sut.FilterBy(filterParameters);

            // Assert

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
    }
}
