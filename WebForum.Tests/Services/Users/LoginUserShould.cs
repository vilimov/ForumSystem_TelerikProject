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
    public class LoginUserShould
    {
        [TestMethod]
        public void Login_ThrowsException_WhenUsernameDoesNotExist()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetByUsername(It.IsAny<string>())).Returns<User>(null);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.Login(testUser.Username, testUser.Password));
        }

        [TestMethod]
        public void Login_ThrowsException_WhenPasswordIsInvalid()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetByUsername(testUser.Username)).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act and Assert
            Assert.ThrowsException<UnauthorizedAccessException>(() => sut.Login(testUser.Username, "WrongPassword"));
        }
    }
}
