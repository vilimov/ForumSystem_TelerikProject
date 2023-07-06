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
    public class GetTagShould
    {
        [TestMethod]
        public void GetAllTags_ShouldReturnAllTags()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            List<Tag> testTags = new List<Tag> { TagsHelper.GetTestTag() };
            tagRepoMock.Setup(repo => repo.GetAllTags()).Returns(testTags);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act
            var result = sut.GetAllTags();

            // Assert
            Assert.AreEqual(testTags, result);
        }
        [TestMethod]
        public void GetTagById_ReturnsTag_WhenTagExists()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            Tag testTag = TagsHelper.GetTestTag();
            tagRepoMock.Setup(repo => repo.GetTagById(testTag.Id)).Returns(testTag);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act
            var result = sut.GetTagById(testTag.Id);

            // Assert
            Assert.AreEqual(testTag, result);
        }
        [TestMethod]
        public void GetTagById_ThrowsException_WhenTagDoesNotExist()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            Tag testTag = TagsHelper.GetTestTag();
            tagRepoMock.Setup(repo => repo.GetTagById(testTag.Id)).Returns((Tag)null);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetTagById(testTag.Id));
        }
        [TestMethod]
        public void GetTagByName_ReturnsTag_WhenTagExists()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            Tag testTag = TagsHelper.GetTestTag();
            tagRepoMock.Setup(repo => repo.GetTagByName(testTag.Name.ToLower())).Returns(testTag);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act
            var result = sut.GetTagByName(testTag.Name);

            // Assert
            Assert.AreEqual(testTag, result);
        }
        [TestMethod]
        public void GetTagByName_ThrowsException_WhenTagDoesNotExist()
        {
            // Arrange
            var tagRepoMock = new Mock<ITagRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            var userRepoMock = new Mock<IUserRepository>();

            Tag testTag = TagsHelper.GetTestTag();
            tagRepoMock.Setup(repo => repo.GetTagByName(testTag.Name)).Returns((Tag)null);

            var sut = new TagService(tagRepoMock.Object, postRepoMock.Object, userRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetTagByName(testTag.Name));
        }
    }
}
