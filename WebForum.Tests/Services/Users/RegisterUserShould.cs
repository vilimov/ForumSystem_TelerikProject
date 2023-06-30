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

namespace WebForum.Tests.Services.Users
{
    [TestClass]
    public class RegisterUserShould
    {
        [TestMethod]
        public void Register_ReturnsRegisteredUser_WhenInputIsValid()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetByEmail(testUser.Email)).Returns((User)null);
            userRepoMock.Setup(repo => repo.GetByUsername(testUser.Username)).Returns((User)null);
            userRepoMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.Register(testUser);

            // Assert
            Assert.AreEqual(testUser, result);
        }

        [TestMethod]
        public void Register_ThrowsException_WhenEmailAlreadyExists()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetByEmail(testUser.Email)).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<DuplicateEntityException>(() => sut.Register(testUser));
        }

        [TestMethod]
        public void Register_ThrowsException_WhenUsernameAlreadyExists()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetByUsername(testUser.Username)).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<DuplicateEntityException>(() => sut.Register(testUser));
        }
    }
}
