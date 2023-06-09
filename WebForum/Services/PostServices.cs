using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Services
{
    public class PostServices : IPostServices
    {
        private const string UpdatePostWrongUserErrorMessage = "Only owner or admin can modify a post.";
        private const string DuplicateTitleErrorMessage = "This title already exists";
        private readonly IPostRepository repository;

        public PostServices(IPostRepository repository)
        {
            this.repository = repository;
        }

        public Post CreatePost(Post post, User user)
        {
            throw new NotImplementedException();
        }

        public Post DeletePost(int id, User user)
        {
            return this.repository.DeletePost(id);
        }

        public IList<Post> GetAllPosts()
        {
            return repository.GetAllPosts();
        }

        public Post GetPost(int id)
        {
            return this.repository.GetPostById(id);
        }

        public Post UpdatePost(int id, Post post, User user)
        {
            Post postToUpdate = this.repository.GetPostById(id);

            if (postToUpdate.Autor.Id != user.Id)
            {
                throw new UnauthorizedOperationException(UpdatePostWrongUserErrorMessage);
            }

            var postsByTitle = this.repository.GetPostByTitle(post.Title);
            if(postsByTitle.Count > 0)
            {
                throw new DuplicateEntityException(DuplicateTitleErrorMessage);
            }

            var updatedPost = this.repository.UpdatePost(id, post);
            return updatedPost;
        }
    }
}
