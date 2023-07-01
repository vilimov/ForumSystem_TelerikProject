using WebForum.Models;
using WebForum.Models.LikesModels;
using WebForum.Models.QueryParameters;

namespace WebForum.Services
{
    public interface IPostServices
    {
        Post CreatePost(Post post, User user);
        Post UpdatePost(int id, Post post, User user);
        Post DeletePost(int id, User user);
        Post GetPostById(int id);
        IList<Post> GetAllPosts();
        IList<Post> GetPostsByUserId(int id);
        IList<Post> FilterPostsBy(PostFilterQueryParameters filterQueryParameters);

        public Post AddLikePost(Post post, User user);
        public Post RemoveLikePost(Post post, User user);

    }
}
