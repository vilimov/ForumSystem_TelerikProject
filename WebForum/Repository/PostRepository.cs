﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WebForum.Data;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Models.LikesModels;
using WebForum.Models.QueryParameters;
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
            //Delete Comments of Post in Comments Database
            foreach(var c in postToDelete.Comments)
            {
                context.Comments.Remove(c);
            }
            //Delete Likes of Posts in Likes database
            foreach (var like in postToDelete.LikePosts)
            {
                this.context.LikePosts.Remove(like);
            }

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
									 .Include(l => l.LikePosts)
                                        .ThenInclude(likeUser => likeUser.User)
                                    .Include(pt=>pt.PostTags)
                                        .ThenInclude(tag=>tag.Tag)
									.Include(cl => cl.Comments)
                                    .ThenInclude(dd=>dd.CommentLikes)
                                    .ThenInclude(ul=>ul.User)
									.ToList();
        }

        public IList<Post> FilterPostsBy(PostFilterQueryParameters filterQueryParameters)
        {
            List<Post> posts = GetAllPosts();
            if(!string.IsNullOrEmpty(filterQueryParameters.Title))
            {
                posts = posts.FindAll(p => p.Title.Contains(filterQueryParameters.Title, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!string.IsNullOrEmpty(filterQueryParameters.UserName))
            {
                posts = posts.FindAll(p => p.Autor.Username.Contains(filterQueryParameters.UserName, StringComparison.InvariantCultureIgnoreCase));
            }
			if (!string.IsNullOrEmpty(filterQueryParameters.Tag))
			{
				posts = posts.FindAll(p => p.PostTags.Any(t => t.Tag.Name.Contains(filterQueryParameters.Tag, StringComparison.InvariantCultureIgnoreCase)));
			}
			if (!string.IsNullOrEmpty(filterQueryParameters.OrderByComments))
            {
                posts = posts.OrderBy(p => p.Comments.Count).ToList();
                posts.Reverse();
				posts = posts.Take(3).ToList();
			}

            if (!string.IsNullOrEmpty(filterQueryParameters.OrderByDate))
            {
                posts = posts.OrderBy(p => p.CreatedAt).ToList();
                posts.Reverse();
				posts = posts.Take(3).ToList();

			}

            if (!string.IsNullOrEmpty(filterQueryParameters.OrderByLikes))
            {
                posts = posts.OrderBy(p => p.Likes).ToList();
                posts.Reverse();
            }

            return posts;
        }
        public Post GetPostById(int id)
        {
            var post = this.context.Posts
                .Include(p => p.Autor)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Autor)
                .Include(p => p.LikePosts)
                    .ThenInclude(lp => lp.User)
				.Include(cl => cl.Comments)
					.ThenInclude(dd => dd.CommentLikes)
					.ThenInclude(uu => uu.User)
				.Include(p => p.PostTags) // Include the PostTags
                    .ThenInclude(pt => pt.Tag) // Include the related Tag for each PostTag
                .FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id {id} doesn't exist.");
            }

            return post;
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
        
        public Post AddLikePost(Post post, LikePost likePost)
        {
            post.LikePosts.Add(likePost);
            this.context.LikePosts.Add(likePost);
            this.context.SaveChanges();

            return post;
        }

        public Post RemoveLikePost(Post post, LikePost likePost)
        {
            post.LikePosts.Remove(likePost);
            this.context.LikePosts.Remove(likePost);
            this.context.SaveChanges();

            return post;
        }

    }
}
