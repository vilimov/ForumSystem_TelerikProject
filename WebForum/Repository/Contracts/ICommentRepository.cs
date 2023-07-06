using WebForum.Models;
using WebForum.Models.LikesModels;

namespace WebForum.Repository.Contracts
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll();
        Comment GetCommentById(int id);
        IEnumerable<Comment> GetByPostId(int postId);
        IEnumerable<Comment> GetByAuthorId(int authorId);
        Comment Create(Comment newComment);
        Comment Update(int id, Comment comment);
        Comment Delete(int id);
        IEnumerable<Comment> FilterBy(CommentQueryParameters filterParameters);
		Comment RemoveLikeComment(Comment comment, CommentLike commentLike);
		Comment AddLikeComment(Comment comment, CommentLike commentLike);
	}
}
