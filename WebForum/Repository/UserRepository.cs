using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebForum.Data;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumContext context;
        private readonly IPostRepository postsRepository;
        private readonly ICommentRepository commentRepository;
        public UserRepository(ForumContext context, IPostRepository postsRepository, ICommentRepository commentRepository)
        {
            this.context = context;
            this.postsRepository = postsRepository;
            this.commentRepository = commentRepository;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.Username == username);
        }

        public User GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User CreateUser(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "New user cannot be null");
            }

            context.Users.Add(newUser);
            context.SaveChanges();

            return newUser;
        }

        public User DeleteUser(int id)
        {
            var userToDelete = context.Users
                               .Include(u => u.Posts)
                               .ThenInclude(p => p.Comments)
                               .Include(c => c.Comments)
                               .ThenInclude(c => c.CommentLikes)
                               .Include(u => u.Posts)
                               .ThenInclude(p => p.LikePosts)
                               .Include(u => u.LikePosts)
                               .SingleOrDefault(u => u.Id == id);

            if (userToDelete == null)
            {
                throw new EntityNotFoundException($"User with id {id} does not exist");
            }
            var userLikes = context.LikePosts.Where(lp => lp.UserId == id);
            context.LikePosts.RemoveRange(userLikes);

            var userCommentLikes = context.CommentLikes.Where(cl => cl.UserId == id);
            context.CommentLikes.RemoveRange(userCommentLikes);

            context.SaveChanges();
            var postIdsToDelete = userToDelete.Posts.Select(p => p.Id).ToList();
            foreach (var postId in postIdsToDelete)
            {
                postsRepository.DeletePost(postId);
            }
            //var listOfPosts = userToDelete.Posts;
            //int i = listOfPosts.Count-1;
            //while (listOfPosts.Count > 0)
            //{
            //    var post = listOfPosts[i];
            //    postsRepository.DeletePost(post.Id);
            //    i--;
            //}
            var commentIdsToDelete = userToDelete.Comments.Select(c => c.Id).ToList();
            foreach (var commentId in commentIdsToDelete)
            {
                commentRepository.Delete(commentId);
            }

            //var listOfComments = userToDelete.Comments;
            //int iComments = listOfComments.Count - 1;
            //while (listOfComments.Count > 0)
            //{
            //    var comment = listOfComments[iComments];
            //    commentRepository.Delete(comment.Id);
            //    iComments--;
            //}

            context.Users.Remove(userToDelete);
            context.SaveChanges();

            return userToDelete;
        }

        public User UpdateUser(User updatedUser)
        {
            User userToUpdate = this.GetUserById(updatedUser.Id);
            if (userToUpdate == null)
            {
                throw new EntityNotFoundException($"User with id {updatedUser.Id} does not exist");
            }

            if (updatedUser.Email != null && userToUpdate.Email != updatedUser.Email)
            {
                // Проверява дали новият e-mail е вече използван от друг user
                var existingUserWithSameEmail = context.Users.FirstOrDefault(u => u.Email == updatedUser.Email);
                if (existingUserWithSameEmail != null)
                {
                    throw new ArgumentException("A user with this email already exists.");
                }
                userToUpdate.Email = updatedUser.Email;
            }

            if (updatedUser.Password != null)
            {
                userToUpdate.Password = updatedUser.Password;
            }

            if (updatedUser.FirstName != null)
            {
                userToUpdate.FirstName = updatedUser.FirstName;
            }

            if (updatedUser.LastName != null)
            {
                userToUpdate.LastName = updatedUser.LastName;
            }

            context.Users.Update(userToUpdate);
            context.SaveChanges();

            return userToUpdate;
        }
    }
}
