using WebForum.Models;

namespace WebForum.Repository.Contracts
{
    public interface ICommentRepository
    {
        Comment GetById(int id);
        IEnumerable<Comment> GetAll();
        IEnumerable<Comment> GetByPostId(int postId);
        Comment Create(Comment newComment);
        Comment Update(Comment comment);
        void Delete(int id);
    }
}
