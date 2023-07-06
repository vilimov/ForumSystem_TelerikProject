using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Helpers.Exceptions;
using WebForum.Models.LikesModels;
using WebForum.Models;
using WebForum.Repository.Contracts;
using WebForum.Services;

namespace WebForum.Tests.Services.Comments
{
	[TestClass]
	public class CommentLikeShould
	{

		[TestMethod]
		public void AddLikeToComment_When_ParamsAreValid()
		{
			//Arrange
			User testUser = TestHelper.UsersHelper.GetTestUser();
			Comment testComment = TestHelper.CommentsHelper.GetTestComment();
			var commentLike = new CommentLike { Comment = testComment, User = testUser };
						
			var repositoryMock = new Mock<ICommentRepository>();

			repositoryMock
				.Setup(r => r.AddLikeComment(testComment, commentLike))
								   .Returns(testComment);
			var sut = new CommentsServices(repositoryMock.Object);
			//Act 
			Comment actualComment = sut.AddLikeComment(testComment, testUser);

			//Assert
			Assert.AreEqual(testComment, actualComment);
		}

		[TestMethod]
		public void IncreaseCountOfCommentLikes_When_ParamsAreValid()
		{
			// Arrange
			User testUser = TestHelper.UsersHelper.GetTestUser();
			Comment testComment = TestHelper.CommentsHelper.GetTestComment();
			var commentLike = new CommentLike { Comment = testComment, User = testUser };

			var repositoryMock = new Mock<ICommentRepository>();

			repositoryMock
				.Setup(r => r.AddLikeComment(It.IsAny<Comment>(), It.IsAny<CommentLike>()))
				.Callback<Comment, CommentLike>((comment, like) => comment.CommentLikes.Add(like))
				.Returns((Comment comment, CommentLike like) => comment);
								   
			var sut = new CommentsServices(repositoryMock.Object);

			// Act 
			Comment actualComment = sut.AddLikeComment(testComment, testUser);

			// Assert
			Assert.AreEqual(1, actualComment.CommentLikes.Count);

		}

		[TestMethod]
		public void Throw_When_InvalidPost()
		{
			// Arrange
			User testUser = TestHelper.UsersHelper.GetTestUser();
			Comment testComment = null; 

			var repositoryMock = new Mock<ICommentRepository>();

			var sut = new CommentsServices(repositoryMock.Object);

			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() => sut.AddLikeComment(testComment, testUser));
		}

		[TestMethod]
		public void Throw_When_AlreadyLiked()
		{
			// Arrange
			User testUser = TestHelper.UsersHelper.GetTestUser();
			Comment testComment = TestHelper.CommentsHelper.GetTestComment();

			var commentLike = new CommentLike { Comment = testComment, User = testUser };
			commentLike.Comment.Id = 1;
			commentLike.UserId = 1;
			testComment.CommentLikes.Add(commentLike);

			var repositoryMock = new Mock<ICommentRepository>();

			var sut = new CommentsServices(repositoryMock.Object);

			// Act and Assert
			Assert.ThrowsException<DuplicateEntityException>(() => sut.AddLikeComment(testComment, testUser));
		}

		[TestMethod]
		public void RemoveCommentLike_When_ParamsAreValid()
		{
			//Arrange
			User testUser = TestHelper.UsersHelper.GetTestUser();
			Comment testComment = TestHelper.CommentsHelper.GetTestComment();
			var commentLike = new CommentLike { Comment = testComment, User = testUser };

			commentLike.Comment.Id = 1;
			commentLike.UserId = 1;
			testComment.CommentLikes.Add(commentLike);

			var repositoryMock = new Mock<ICommentRepository>();

			repositoryMock
				.Setup(r => r.RemoveLikeComment(testComment, commentLike))
								   .Returns(testComment);
			var sut = new CommentsServices(repositoryMock.Object);

			//Act 
			Comment actualComment = sut.RemoveLikeComment(testComment, testUser);

			//Assert
			Assert.AreEqual(testComment, actualComment);
		}
	}
}
