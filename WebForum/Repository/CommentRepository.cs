using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebForum.Data;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.LikesModels;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumContext context;

        public CommentRepository(ForumContext context)
        {
            this.context = context;
        }
        public IEnumerable<Comment> GetAll()
        {
            IEnumerable<Comment> result = context.Comments
                                                  .Include(c => c.Autor)
                                                  .Include(c => c.Post)
                                                  .Include(l => l.CommentLikes)
                                                    .ThenInclude(l => l.User);
            return result.ToList() ?? throw new EntityNotFoundException($"No comments were found!");
        }

        public Comment GetCommentById(int id)
        {
            Comment comment = GetAll().FirstOrDefault(c => c.Id == id);
            return comment ?? throw new EntityNotFoundException($"Comment with ID:{id} does not exist!");
        }

        public IEnumerable<Comment> GetByPostId(int postId)
        {
            IEnumerable<Comment> result = GetAll().Where(c => c.PostId == postId);
            if (!result.Any()) 
            {
                throw new EntityNotFoundException($"Post with ID:{postId} does not have any comments!");
            }
            return result;
        }

        public IEnumerable<Comment> GetByAuthorId(int autorId)
        {
            IEnumerable<Comment> result = GetAll().Where(c => c.AutorId == autorId).ToList();
            if (!result.Any())
            {
                throw new EntityNotFoundException($"Autor with ID:{autorId} does not have any comments!");
            }
            return result;
        }

        public Comment Create(Comment newComment)
        {
            context.Comments.Add(newComment);
            context.SaveChanges();

            return newComment;
        }

        public Comment Update(int id, Comment comment)
        {
            Comment commentToUpdate = GetCommentById(id);

            if (comment.Content != null)
            {
                commentToUpdate.Content = comment.Content;
                commentToUpdate.CreatedAt = DateTime.Now;
            }
            //commentToUpdate.Likes = comment.Likes;

            context.Update(commentToUpdate);
            context.SaveChanges();

            return commentToUpdate;
        }

        public Comment Delete(int id)
        {
            Comment commentToRemove = GetCommentById(id);
            Comment removedComment = context.Comments.Remove(commentToRemove).Entity;
            context.SaveChanges();
            return removedComment;
        }

        public IEnumerable<Comment> FilterBy(CommentQueryParameters filterParameters)
        {
            IEnumerable<Comment> result = context.Comments
                                                  .Include(c => c.Autor)
                                                  .Include(c => c.Post)
												  .Include(l => l.CommentLikes)
													.ThenInclude(l => l.User); ;

            result = FilterByContent(result, filterParameters.Content);
            result = FilterByMinLikes(result, filterParameters.MinLikes);
            result = SortBy(result, filterParameters.SortBy);
            result = Order(result, filterParameters.SortOrder);

            return result;
        }
        private static IEnumerable<Comment> FilterByContent(IEnumerable<Comment> comments, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                return comments.Where(c => c.Content.Contains(content, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return comments;
            }
        }

        private static IEnumerable<Comment> FilterByMinLikes(IEnumerable<Comment> comments, int? minLikes)
        {
            if (minLikes.HasValue)
            {
                return comments.Where(c => c.Likes >= minLikes);
            }
            else
            {
                return comments;
            }
        }


        private static IEnumerable<Comment> SortBy(IEnumerable<Comment> comments, string sortCriteria)
        {
            if (sortCriteria != null)
            {
                sortCriteria = sortCriteria.ToLower();
            }

            switch (sortCriteria)
            {
                case "content":
                    return comments.OrderBy(c => c.Content);
                case "likes":
                    return comments.OrderBy(c => c.Likes);
                case "date":
                    return comments.OrderBy(c => c.CreatedAt);
                case "autor":
                    return comments.OrderBy(c => c.Autor.Username);
                case "posttitle":
                    return comments.OrderBy(c => c.Post.Title);
                case "postcontent":
                    return comments.OrderBy(c => c.Post.Content);
                default:
                    return comments;
            }
        }

        private static IEnumerable<Comment> Order(IEnumerable<Comment> comments, string sortOrder)
        {
            return (string.Equals(sortOrder, "desc", StringComparison.InvariantCultureIgnoreCase)) ? comments.Reverse() : comments;
        }


		public Comment AddLikeComment(Comment comment, CommentLike commentLike)
		{
			comment.CommentLikes.Add(commentLike);
			comment.CommentLikes.Add(commentLike);
			this.context.SaveChanges();

			return comment;
		}

		public Comment RemoveLikeComment(Comment comment, CommentLike commentLike)
		{
			comment.CommentLikes.Remove(commentLike);
			this.context.CommentLikes.Remove(commentLike);
			this.context.SaveChanges();

			return comment;
		}
	}
}
