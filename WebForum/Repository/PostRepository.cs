﻿using System.Text;
using System.Xml.Linq;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> posts;
        //private readonly List<Comment> comments;

        public PostRepository()
        {
            posts = new List<Post>()
                {
                    new Post { Id = 1, Title = "This is post 1",
                                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut non tincidunt lectus.",
                                CreatedAt = DateTime.Now, Likes = 0,
                                Autor = new User() },
                    new Post { Id = 2, Title = "This is post 2",
                                Content = "Phasellus dictum neque ac lacus auctor, a facilisis nibh maximus. " +
                                "Quisque a augue eros. Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                                CreatedAt = DateTime.Now, Likes = 0,
                                Autor = new User() },
                    new Post { Id = 3, Title = "This is post 3",
                                Content = "Nam massa purus, venenatis eu libero ac, scelerisque dictum est. In sed dapibus sem.",
                                CreatedAt = DateTime.Now, Likes = 0,
                                Autor = new User() },
                };
        }
        public Post CreatePost(Post newPost)
        {
            newPost.Id = posts[posts.Count - 1].Id +1;
            this.posts.Add(newPost);
            return newPost;
        }

        public Post DeletePost(int id)
        {
            var postToDelete = this.GetPostById(id);
            this.posts.Remove(postToDelete);

            return postToDelete;
        }

        public List<Post> GetAllPosts()
        {
            return this.posts;
        }

        public Post GetPostById(int id)
        {
            var post = this.posts.Where(p => p.Id == id).FirstOrDefault();
            return post ?? throw new EntityNotFoundException($"Post with id {id} doesn't exist.");
        }

        public List<Post> GetPostByUserId(int userId)
        {
            var post = this.posts.Where(p => p.Autor.Id == userId).ToList();
            return post ?? throw new EntityNotFoundException($"Post with user id {userId}, not found");
        }

        public List<Post> GetPostByTitle(string title)
        {
            var post = this.posts.Where(p => p.Title == title).ToList();
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

            return postToUpdate;
        }

        /*public List<Comment> GetPostComments()
        {
            throw new NotImplementedException();
        }*/
    }
}