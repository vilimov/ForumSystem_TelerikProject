using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Helpers.Authentication;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Services;

namespace WebForum.Tests.Services.AuthMagaer
{
    [TestClass]
    public class AuthManagerShould
    {
        [TestMethod]
        public void Return_CorrectUser_WhenParamsAreValid()
        {
            //Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();

            var userServiceMock = new Mock<IUserServices>();
            userServiceMock.Setup(userService => userService
                .GetByUsername(testUser.Username))
                .Returns(testUser);

            var sut = new AuthManager(userServiceMock.Object);

            // Act
            User actualUser = sut.TryGetUser($"{testUser.Username}:Cleopatra");

            //Assert
            Assert.AreSame(testUser, actualUser);

        }

        [TestMethod]
        public void Throw_WhenCredentialsAreInvalid()
        {
            //Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();

            var userServiceMock = new Mock<IUserServices>();
            userServiceMock.Setup(userService => userService
                .GetByUsername(testUser.Username))
                .Returns(testUser);

            var sut = new AuthManager(userServiceMock.Object);

            // Act
            //User actualUser = sut.TryGetUser($"{testUser.Username}:Cleopatra");

            //Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.TryGetUser($"{testUser.Username}:Cleopatr"));

        }
        [TestMethod]
        public void Throw_WhenCredentialsAreEmpty()
        {
            //Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();

            var userServiceMock = new Mock<IUserServices>();
            userServiceMock.Setup(userService => userService
                .GetByUsername(testUser.Username))
                .Returns(testUser);

            var sut = new AuthManager(userServiceMock.Object);

            // Act
            //User actualUser = sut.TryGetUser($"{testUser.Username}:Cleopatra");

            //Assert
            Assert.ThrowsException<InvalidPasswordException>(() => sut.TryGetUser($"{testUser.Username}Cleopatr"));

        }
        [TestMethod]
        public void Throw_WhenUsernameNotFound()
        {
            //Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();

            var userServiceMock = new Mock<IUserServices>();
            userServiceMock.Setup(userService => userService
                .GetByUsername(testUser.Username))
                .Returns(testUser);

            var sut = new AuthManager(userServiceMock.Object);

            // Act
            //User actualUser = sut.TryGetUser($"{testUser.Username}:Cleopatra");
            
            //Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.TryGetUser($"wrongUsername:Cleopatra"));

        }

        [TestMethod]
        public void Return_ValidSalt()
        {
            // Act
            string salt = AuthManager.GenerateSalt();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(salt), "Salt should not be null or empty.");
            Assert.AreEqual(24, salt.Length, "Salt should have a length of 24 characters.");
            Assert.IsTrue(IsValidBase64String(salt), "Salt should only contain valid base64 characters.");
        }

        private static bool IsValidBase64String(string input)
        {
            // Check if the input string contains only valid base64 characters
            return input.All(c => c == '+' || c == '/' || c == '=' || (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
        }

    }

}
