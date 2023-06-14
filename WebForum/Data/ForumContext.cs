using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebForum.Models;

namespace WebForum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<User> users = new List<User>()
            {
                 new User { Id = 1, Username = "goshoG", 
                                    Email = "goshoG@example.com", 
                                    FirstName = "Gosho", 
                                    LastName = "Georgiev", 
                                    Password = "password123", 
                                    IsAdmin = true, 
                                    IsBlocked = false },

                 new User { Id = 2, Username = "peshoP", 
                                    Email = "peshoP@example.com", 
                                    FirstName = "Pesho", 
                                    LastName = "Peshov", 
                                    Password = "password456", 
                                    IsAdmin = false, 
                                    IsBlocked = false },

                 new User { Id = 3, Username = "toshoT", 
                                    Email = "toshoT@example.com", 
                                    FirstName = "Tosho", 
                                    LastName = "Toshov", 
                                    Password = "password789", 
                                    IsAdmin = false, 
                                    IsBlocked = false }
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}