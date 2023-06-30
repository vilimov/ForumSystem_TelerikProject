using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;
using WebForum.Tests.TestHelper;

namespace WebForum.Tests.Services.Users
{
    [TestClass]
    public class UpdateUserShould
    {
        [TestMethod]
        public void UpdateUserProfile_WhenUserExists()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
            userRepoMock.Setup(repo => repo.UpdateUser(It.IsAny<User>())).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.UpdateProfile(testUser);

            // Assert
            Assert.AreEqual(testUser, result);
            userRepoMock.Verify(repo => repo.UpdateUser(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void ThrowEntityNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();
            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns<User?>(null);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act & Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.UpdateProfile(testUser));
        }
    }
}
