using Microsoft.Extensions.Hosting;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository;
using WebForum.Repository.Contracts;

namespace WebForum.Services
{
    public class CommentsServices : ICommentsServices
    {
        private const string ModifyCommentErrorMessage = "Only author or admin can update or delete a comment!";
        private readonly ICommentRepository repository;
        private readonly IPostRepository postRepository;

        public CommentsServices(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public List<Comment> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public List<Comment> FilterBy(CommentQueryParameters filterParameters)
        {
            return repository.FilterBy(filterParameters).ToList();
        }

        public Comment GetCommentById(int id)
        {
            return repository.GetCommentById(id);
        }

        public List<Comment> GetByPostId(int postId)
        {
            List<Comment> result = repository.GetByPostId(postId).ToList();
            return result;
        }

        public List<Comment> GetByAuthorId(int id)
        {
            List<Comment> result = repository.GetByAuthorId(id).ToList();
            return result;
        }

        public Comment CreateComment(Comment comment, Post post, User autor)
        {
            //hack Mila
            comment.Post = post;
            comment.Autor = autor;
            comment.CreatedAt = DateTime.Now;
            //postRepository.GetPostById(postId);
            Comment createdComment = repository.Create(comment);
            return createdComment;
        }

        public Comment Update(int id, Comment comment, User author)
        {
            Comment commentToUpdate = repository.GetCommentById(id);
            if (!commentToUpdate.Autor.Equals(author) && !author.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyCommentErrorMessage);
            }

            Comment updatedComment = repository.Update(id, comment);
            return updatedComment;
        }

        public Comment Delete(int id, User author)
        {
            Comment commentToDelete = repository.GetCommentById(id);
            if (!commentToDelete.Autor.Equals(author) && !author.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyCommentErrorMessage);
            }

            Comment deletedComment = repository.Delete(id);
            return deletedComment;
        }

    }
}
