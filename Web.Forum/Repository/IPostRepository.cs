using Web.Forum.Models;

namespace Web.Forum.Repository
{
    public interface IPostRepository
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetByUserId(int userId);
        Post Create(Post newPost);
        Post Update(Post post);
        void Delete(int id);
    }
}
