using Microsoft.AspNetCore.DataProtection.KeyManagement;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.LikesModels;
using WebForum.Models.QueryParameters;
using WebForum.Repository;
using WebForum.Repository.Contracts;

namespace WebForum.Services
{
    public class PostServices : IPostServices
    {
        private const string UpdatePostWrongUserErrorMessage = "Only owner or admin can modify a post.";
        private const string DuplicateTitleErrorMessage = "This title already exists";
        private const string DuplicateLikeErrorMessage = "You already give your Like for this post";
        private const string InvalidPostErrorMessage = "Invalid Post!";
        private const string RemoveLikeErrorMessage = "You did not liked this post";

        private readonly IPostRepository repository;

        // Tags new
        private readonly ITagService tagService;

        public PostServices(IPostRepository repository, ITagService tagService)
        {
            this.repository = repository;
            this.tagService = tagService;
        }

        public Post CreatePost(Post post, User user)
        {
            List<Post> postsByTitle = this.repository.GetPostByTitle(post.Title);
            if (postsByTitle == null)
            {
                postsByTitle = new List<Post>();
            }
            if (postsByTitle.Count > 0)
            {
                throw new DuplicateEntityException(DuplicateTitleErrorMessage);
            }

            post.Autor = user;
            post.CreatedAt = DateTime.Now;  //string formattedDate = date.ToString("yyyy-MM-dd HH:mm");

            //Tags new
            // Handle post tags
            if (post.PostTags != null && post.PostTags.Count > 0)
            {
                foreach (var postTag in post.PostTags)
                {
                    var existingTag = this.tagService.GetTagByName(postTag.Tag.Name.ToLower());
                    if (existingTag == null)
                    {
                        // Create new tag if it does not exist
                        existingTag = new Tag { Name = postTag.Tag.Name.ToLower() };
                        this.tagService.CreateTag(existingTag);
                    }
                    // Add the tag to the post
                    postTag.TagId = existingTag.Id;
                }
            }

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

        public Post GetPostById(int id)
        {
            return this.repository.GetPostById(id);
        }

        public IList<Post> GetPostsByUserId(int id)
        {
            return this.repository.GetPostByUserId(id);
        }

        public IList<Post> FilterPostsBy(PostFilterQueryParameters filterQueryParameters)
        {
            //todo POST filter
            return this.repository.FilterPostsBy(filterQueryParameters);
        }

        public Post UpdatePost(int id, Post post, User user)
        {
            Post postToUpdate = this.repository.GetPostById(id);

            if (postToUpdate.Autor.Id != user.Id && user.IsAdmin == false)
            {
                throw new UnauthorizedOperationException(UpdatePostWrongUserErrorMessage);
            }

            var postsByTitle = this.repository.GetPostByTitle(post.Title);
			var samePostChecker = postsByTitle.Where(post=>post.Id != postToUpdate.Id).ToList();

			if (postsByTitle.Count > 0 && samePostChecker.Count > 0)
            {
                throw new DuplicateEntityException(DuplicateTitleErrorMessage);
            }

            var updatedPost = this.repository.UpdatePost(id, post);
            return updatedPost;
        }

        public Post AddLikePost(Post post, User user)
        {
            if (post == null) 
            {
                throw new EntityNotFoundException(InvalidPostErrorMessage);
            };
            if (post.LikePosts.Any(lp => lp.UserId == user.Id))
            {
                throw new DuplicateEntityException(DuplicateLikeErrorMessage);
            }
            var likePost = new LikePost { Post = post, User = user };
            this.repository.AddLikePost(post, likePost);
            //post.Likes++;

            return post;
        }

        public Post RemoveLikePost(Post post, User user)
        {
            if (post == null)
            {
                throw new EntityNotFoundException(InvalidPostErrorMessage);
            }

            var likePost = post.LikePosts.FirstOrDefault(lp => lp.UserId == user.Id);
            if (likePost == null)
            {
                throw new EntityNotFoundException(RemoveLikeErrorMessage);
            }

            this.repository.RemoveLikePost(post, likePost);
            //post.Likes--;

            return post;
        }

    }
}
