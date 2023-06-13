using Microsoft.EntityFrameworkCore;
using WebForum.Models;

namespace WebForum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var users = new List<User>()
            {
                new User { Id = 1, Name = "First Person ... shooter", AddressId = 1 },
                new User { Id = 2, Name = "Second Person ... whaaat", AddressId = 2 },
                new User { Id = 3, Name = "this is funny... or not :(", AddressId = 3 }
            };
            modelBuilder.Entity<User>().HasData(users);
        }*/
    }
}
