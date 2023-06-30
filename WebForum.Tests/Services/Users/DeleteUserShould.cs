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
    public class DeleteUserShould
    {
        [TestMethod]
        public void DeleteUser_WhenIdExists()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns(testUser);
            userRepoMock.Setup(repo => repo.DeleteUser(testUser.Id));

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act
            sut.DeleteUser(testUser.Id);

            // Assert
            userRepoMock.Verify(repo => repo.DeleteUser(testUser.Id), Times.Once);
        }

        [TestMethod]
        public void ThrowEntityNotFoundException_WhenIdDoesNotExist()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var postRepoMock = new Mock<IPostRepository>();

            User testUser = UsersHelper.GetTestUser();

            userRepoMock.Setup(repo => repo.GetUserById(testUser.Id)).Returns<User?>(null);

            var sut = new UserServices(userRepoMock.Object, postRepoMock.Object);

            // Act & Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.DeleteUser(testUser.Id));
        }
    }
}
