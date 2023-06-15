﻿using Microsoft.Extensions.Hosting;
using WebForum.Data;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
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
            return context.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            Comment comment = context.Comments.FirstOrDefault(c => c.Id == id);
            return comment ?? throw new EntityNotFoundException($"Comment with ID:{id} does not exist!");
        }

        public IEnumerable<Comment> GetByPostId(int postId)
        {
            IEnumerable<Comment> result = context.Comments.Where(c => c.PostId == postId);
            return result.ToList() ?? throw new EntityNotFoundException($"Post with ID:{postId} does not have any comments!");
        }

        public IEnumerable<Comment> GetByAuthorId(int authorId)
        {
            IEnumerable<Comment> result = context.Comments.Where(c => c.AutorId == authorId);
            return result.ToList() ?? throw new EntityNotFoundException($"No comments from author with ID: {authorId}!");
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
            commentToUpdate.Likes = comment.Likes;

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
            IEnumerable<Comment> result = context.Comments;

            result = FilterByContent(result, filterParameters.Content);
            result = FilterByMinLikes(result, filterParameters.MinLikes);
            result = SortBy(result, filterParameters.SortBy);
            result = Order(result, filterParameters.SortOrder);

            return result.ToList();
        }
        private static IEnumerable<Comment> FilterByContent(IEnumerable<Comment> comments, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                return comments.Where(c => c.Content.Contains(content));
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
            switch (sortCriteria)
            {
                case "likes":
                    return comments.OrderBy(c => c.Likes);
                default:
                    return comments;
            }
        }

        private static IEnumerable<Comment> Order(IEnumerable<Comment> comments, string sortOrder)
        {
            return (sortOrder == "desc") ? comments.Reverse() : comments;
        }
    }
}