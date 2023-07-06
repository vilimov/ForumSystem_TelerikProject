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
using WebForum.Tests.TestHelper;

namespace WebForum.Tests.Services.Tags
{
    [TestClass]
    public class AddTagShould
    {
        [TestMethod]
        public void AddTagToPost_Succeeds_WhenPostAuthorIsUserAndTagDoesNotExist()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            var testUser = TagsHelper.GetTestUserAdmin();
            var testPost = TagsHelper.GetTestPostWithTestTag();
            testPost.Autor = testUser;

            postRepoMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);
            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);

            var newTag = new Tag { Name = "newTag" };
            tagRepoMock.Setup(repo => repo.GetTagByName(newTag.Name.ToLower())).Returns((Tag)null);
            tagRepoMock.Setup(repo => repo.CreateTag(It.IsAny<Tag>())).Returns(newTag);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act
            sut.AddTagToPost(testPost.Id, newTag.Name, testUser.Id);

            // Assert
            tagRepoMock.Verify(repo => repo.AddTagToPost(testPost, newTag), Times.Once);
        }
        [TestMethod]
        public void AddTagToPost_ThrowsEntityNotFoundException_WhenPostOrUserDoesNotExist()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            var testUser = TagsHelper.GetTestUserAdmin();
            var testPost = TagsHelper.GetTestPostWithTestTag();

            postRepoMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns((Post)null);
            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns((User)null);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.AddTagToPost(testPost.Id, "newTag", testUser.Id));
        }
        [TestMethod]
        public void AddTagToPost_ThrowsUnauthorizedOperationException_WhenUserIsNotPostAuthor()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            var testUser = TagsHelper.GetTestUserNonAdmin();
            var testPost = TagsHelper.GetTestPostWithTestTag();

            postRepoMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);
            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.AddTagToPost(testPost.Id, "newTag", testUser.Id));
        }
        [TestMethod]
        public void AddTagToPost_ThrowsDuplicateEntityException_WhenTagAlreadyAssignedToPost()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            var testUser = TagsHelper.GetTestUserAdmin();
            var testPost = TagsHelper.GetTestPostWithTestTag();
            var testTag = TagsHelper.GetTestTag();

            postRepoMock.Setup(repo => repo.GetPostById(testPost.Id)).Returns(testPost);
            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
            tagRepoMock.Setup(repo => repo.GetTagByName(testTag.Name.ToLower())).Returns(testTag);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<DuplicateEntityException>(() => sut.AddTagToPost(testPost.Id, testTag.Name, testUser.Id));
        }
    }
}
