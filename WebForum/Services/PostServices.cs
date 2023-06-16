using Microsoft.AspNetCore.DataProtection.KeyManagement;
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
            var postsByTitle = this.repository.GetPostByTitle(post.Title);
            if (postsByTitle.Count > 0)
            {
                throw new DuplicateEntityException(DuplicateTitleErrorMessage);
            }

            post.Autor = user;
            post.CreatedAt = DateTime.Now;  //string formattedDate = date.ToString("yyyy-MM-dd HH:mm");
            post.Likes = 0;
            var createdPost = this.repository.CreatePost(post);

            return createdPost;
        }

        public Post DeletePost(int id, User user)
        {
            Post postTodelete = repository.GetPostById(id);
            if (user.Id != postTodelete.Autor.Id && !user.IsAdmin) 
            {
                throw new UnauthorizedOperationException("Only the Autor of the post or Admin can delete this post");
            }
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

        public IList<Post> GetPostsByUserId(int id)
        {
            return this.repository.GetPostByUserId(id);
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
