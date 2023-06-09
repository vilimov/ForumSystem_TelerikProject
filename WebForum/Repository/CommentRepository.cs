using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public Comment Create(Comment newComment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetByPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public Comment Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
