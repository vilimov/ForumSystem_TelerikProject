using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;
using WebForum.Tests.TestHelper;

namespace WebForum.Tests.Services.Users
{
    [TestClass]
    public class GetUserShould
    {
        [TestMethod]
        public void GetAllUsers_ReturnsAllUsers()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            List<User> testUsers = UsersHelper.GetTestUsersList();

            userRepoMock.Setup(repo => repo.GetAllUsers()).Returns(testUsers);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.GetAllUsers();

            // Assert
            Assert.AreEqual(testUsers, result);
        }

        [TestMethod]
        public void GetUserById_ReturnsCorrectUser()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.GetUserById(testUser.Id);

            // Assert
            Assert.AreEqual(testUser, result);
        }

        [TestMethod]
        public void GetByUsername_ReturnsCorrectUser()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetByUsername(testUser.Username)).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.GetByUsername(testUser.Username);

            // Assert
            Assert.AreEqual(testUser, result);
        }

        [TestMethod]
        public void GetByEmail_ReturnsCorrectUser()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetByEmail(testUser.Email)).Returns(testUser);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            var result = sut.GetByEmail(testUser.Email);

            // Assert
            Assert.AreEqual(testUser, result);
        }
    }
}
