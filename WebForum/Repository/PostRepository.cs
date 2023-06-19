using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Linq;
using WebForum.Data;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumContext context;
       
        public PostRepository(ForumContext context)
        {
           this.context = context;
        }
        public Post CreatePost(Post newPost)
        {
            this.context.Posts.Add(newPost);
            context.SaveChanges();

            return newPost;
        }

        public Post DeletePost(int id)
        {
            var postToDelete = this.GetPostById(id);
            var deletedPost = this.context.Posts.Remove(postToDelete).Entity;
            context.SaveChanges();
            return deletedPost;
        }

        public List<Post> GetAllPosts()
        {
            return this.context.Posts
                                     .Include(u => u.Autor)
                                     .Include(c => c.Comments)
                                     .ThenInclude(a=>a.Autor)
                                    .ToList();
        }

        public Post GetPostById(int id)
        {

           var post = this.GetAllPosts().FirstOrDefault(p => p.Id == id);
           return post ?? throw new EntityNotFoundException($"Post with id {id} doesn't exist.");
        }

        public List<Post> GetPostByUserId(int userId)
        {
            //var post = this.context.Posts.Where(p => p.Autor.Id == userId).ToList();
            var posts = this.GetAllPosts().Where(p => p.Autor.Id == userId).ToList();
            return posts ?? throw new EntityNotFoundException($"Post with user id {userId}, not found");
        }

        public List<Post> GetPostByTitle(string title)
        {
            var post = this.context.Posts.Where(p => p.Title == title).ToList();
            return post ?? throw new EntityNotFoundException($"Post with title {title}, not found");
        }

        public Post UpdatePost(int id, Post post)
        {
            Post postToUpdate = this.GetPostById(id);
            if(post.Title != null)
            {
                postToUpdate.Title = post.Title;
            }
            if (post.Content != null)
            {
                postToUpdate.Content = post.Content;
            }

            context.Update(postToUpdate);
            context.SaveChanges();
            return postToUpdate;
        }

    }
}
