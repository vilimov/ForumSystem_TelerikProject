using WebForum.Models;

namespace WebForum.Services
{
    public interface ICommentsServices
    {
        List<Comment> GetAll();

        Comment GetById(int id);

        Comment GetByAuthor(User author);

        Comment GetByPost(Post post);

        Comment Create(Comment comment);
        
        Comment Update(int id, Comment comment);
        
        Comment Delete(int id);

    }
}
