using Microsoft.Extensions.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.LikesModels;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Posts
{
    [TestClass]
    public class PostLikeShould
    {

        [TestMethod]
        public void AddLikeToPost_WhenParamsAreValid()
        {
            //Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            var likePost = new LikePost { Post = testPost, User = testUser };
            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock
                .Setup(repo => repo.AddLikePost(testPost, likePost))
                                   .Returns(testPost);
            var sut = new PostServices(repositoryMock.Object);

            //Act 
            Post actualPost = sut.AddLikePost(testPost, testUser);

            //Assert
            Assert.AreEqual(testPost, actualPost);
        }

        [TestMethod]
        public void IncreaseCountOfLikesToPost_WhenParamsAreValid()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            var likePost = new LikePost { Post = testPost, User = testUser };

            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock
                .Setup(repo => repo.AddLikePost(It.IsAny<Post>(), It.IsAny<LikePost>()))
                .Callback<Post, LikePost>((post, like) => post.LikePosts.Add(like))
                .Returns((Post post, LikePost like) => post);

            var sut = new PostServices(repositoryMock.Object);

            // Act 
            Post actualPost = sut.AddLikePost(testPost, testUser);

            // Assert
            Assert.AreEqual(1, actualPost.LikePosts.Count);

        }

        [TestMethod]
        public void Throw_When_InvalidPost()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = null; // Set the testPost to null

            var repositoryMock = new Mock<IPostRepository>();

            var sut = new PostServices(repositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.AddLikePost(testPost, testUser));
        }

        [TestMethod]
        public void Throw_When_DuplicateLike()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();

            var likePost = new LikePost { Post = testPost, User = testUser };
            likePost.Post.Id = 1;
            likePost.UserId = 1;
            testPost.LikePosts.Add(likePost);

            var repositoryMock = new Mock<IPostRepository>();

            var sut = new PostServices(repositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<DuplicateEntityException>(() => sut.AddLikePost(testPost, testUser));
        }


        [TestMethod]
        public void Throw_When_DislikeAndInvalidPost()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = null; // Set the testPost to null

            var repositoryMock = new Mock<IPostRepository>();

            var sut = new PostServices(repositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.RemoveLikePost(testPost, testUser));
        }

        [TestMethod]
        public void Throw_When_DislikeNullLike()
        {
            // Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();

            var likePost = new LikePost { Post = testPost, User = null };
            testPost.LikePosts.Add(likePost);

            var repositoryMock = new Mock<IPostRepository>();

            var sut = new PostServices(repositoryMock.Object);

            // Act and Assert
            Assert.ThrowsException<EntityNotFoundException>(() => sut.RemoveLikePost(testPost, testUser));
        }

        [TestMethod]
        public void RemoveLikeToPost_WhenParamsAreValid()
        {
            //Arrange
            User testUser = TestHelper.UsersHelper.GetTestUser();
            Post testPost = TestHelper.PostsHelper.GetTestPost();
            var likePost = new LikePost { Post = testPost, User = testUser };
            
            likePost.Post.Id = 1;
            likePost.UserId = 1;
            testPost.LikePosts.Add(likePost);

            var repositoryMock = new Mock<IPostRepository>();

            repositoryMock
                .Setup(repo => repo.RemoveLikePost(testPost, likePost))
                                   .Returns(testPost);
            var sut = new PostServices(repositoryMock.Object);

            //Act 
            Post actualPost = sut.RemoveLikePost(testPost, testUser);

            //Assert
            Assert.AreEqual(testPost, actualPost);
        }


    }
}
