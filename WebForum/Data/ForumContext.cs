using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebForum.Helpers.Authentication;
using WebForum.Models;
using WebForum.Models.LikesModels;

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
        public DbSet<LikePost> LikePosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           *base.OnModelCreating(modelBuilder);

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
        }*/

        //new User { Id = 1, FirstName = "Pesho", LastName = "Peshov", Email = "Pesho123@example.com",
        //               Username = "PesheP", Password = "password123", IsAdmin = false, IsBlocked = false},
        //    new User { Id = 2, FirstName = "Tosho", LastName = "Toshov", Email = "Tosho123@example.com",
        //               Username = "ToshoT", Password = "password456", IsAdmin = false, IsBlocked = false},
        //    new User
        //    {
        //        Id = 3,
        //        FirstName = "Gosho",
        //        LastName = "Goshov",
        //        Email = "Gosho123@example.com",
        //        Username = "GoshoG",
        //        Password = "password789",
        //        IsAdmin = true,
        //        IsBlocked = false
        //
        //
        //   },
        /*new User { Id = 1, FirstName = "Julius", LastName = "Caesar", Username = "JuliusCaesar", Email = "JC@roman.im", Salt = salt, Password = "Cleopatra", HashedPassword = AuthManager.HashPassword("Cleopatra", salt), IsAdmin = true },
                new User { Id = 2, FirstName = "Marcus", LastName = "Aurelius", Username = "MarcusAurelius", Email = "MA@roman.im", Salt = salt, Password = "Antoninus", HashedPassword = AuthManager.HashPassword("Antoninus", salt), IsAdmin = true },
                new User { Id = 3, FirstName = "MarcusTullius", LastName = "Cicero", Username = "MarcusTulliusCicero", Email = "MTC@roman.im", Salt = salt, Password = "Tullius123", HashedPassword = AuthManager.HashPassword("Tullius123", salt), IsAdmin = false },
                new User { Id = 4, FirstName = "Hippocrates", LastName = "ofKos", Username = "Hippocrates", Email = "Hipo@roman.im", Salt = salt, Password = "CorpusHippocraticum", HashedPassword = AuthManager.HashPassword("CorpusHippocraticum", salt), IsAdmin = false },
                new User { Id = 5, FirstName = "Caesar", LastName = "Augustus", Username = "CaesarAugustus", Email = "CA@roman.im", Salt = salt, Password = "GaiusOctavius", HashedPassword = AuthManager.HashPassword("GaiusOctavius", salt), IsAdmin = false },
                new User { Id = 6, FirstName = "MarcusJunius", LastName = "Brutus", Username = "MarcusJuniusBrutus", Email = "BrutusIAm@roman.im", Salt = salt, Password = "MeToo", HashedPassword = AuthManager.HashPassword("MeToo", salt), IsAdmin = false, IsBlocked = true },
                new User { Id = 7, FirstName = "PubliusOvidius", LastName = "Naso", Username = "PubliusOvidiusNaso", Email = "Ovid@roman.im", Salt = salt, Password = "Metamorphoses", HashedPassword = AuthManager.HashPassword("Metamorphoses", salt), IsAdmin = false },
                new User { Id = 8, FirstName = "LuciusAnnaeus", LastName = "Seneca", Username = "LuciusAnnaeusSeneca", Email = "Seneca@roman.im", Salt = salt, Password = "EpistulaeMorales", HashedPassword = AuthManager.HashPassword("EpistulaeMorales", salt), IsAdmin = false }
            
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var salt = AuthManager.GenerateSalt();
            var users = new List<User>()
            {
                new User { Id = 1, FirstName = "Julius", LastName = "Caesar", Username = "JuliusCaesar", Email = "JC@roman.im", Salt = salt, Password = AuthManager.HashPassword("Cleopatra", salt), IsAdmin = true },
                new User { Id = 2, FirstName = "Marcus", LastName = "Aurelius", Username = "MarcusAurelius", Email = "MA@roman.im", Salt = salt, Password = AuthManager.HashPassword("Antoninus", salt), IsAdmin = true },
                new User { Id = 3, FirstName = "MarcusTullius", LastName = "Cicero", Username = "MarcusTulliusCicero", Email = "MTC@roman.im", Salt = salt, Password = AuthManager.HashPassword("Tullius123", salt), IsAdmin = false },
                new User { Id = 4, FirstName = "Hippocrates", LastName = "ofKos", Username = "Hippocrates", Email = "Hipo@roman.im", Salt = salt, Password = AuthManager.HashPassword("CorpusHippocraticum", salt), IsAdmin = false },
                new User { Id = 5, FirstName = "Caesar", LastName = "Augustus", Username = "CaesarAugustus", Email = "CA@roman.im", Salt = salt, Password = AuthManager.HashPassword("GaiusOctavius", salt), IsAdmin = false },
                new User { Id = 6, FirstName = "MarcusJunius", LastName = "Brutus", Username = "MarcusJuniusBrutus", Email = "BrutusIAm@roman.im", Salt = salt, Password = AuthManager.HashPassword("MeToo", salt), IsAdmin = false, IsBlocked = true },
                new User { Id = 7, FirstName = "PubliusOvidius", LastName = "Naso", Username = "PubliusOvidiusNaso", Email = "Ovid@roman.im", Salt = salt, Password = AuthManager.HashPassword("Metamorphoses", salt), IsAdmin = false },
                new User { Id = 8, FirstName = "LuciusAnnaeus", LastName = "Seneca", Username = "LuciusAnnaeusSeneca", Email = "Seneca@roman.im", Salt = salt, Password = AuthManager.HashPassword("EpistulaeMorales", salt), IsAdmin = false }
            };
            modelBuilder.Entity<User>().HasData(users);



            List<Post> posts = new List<Post>()
            {
                new Post { Id = 1, Title = "Omnium Rerum Principia Parva Sunt", Content = "The beginnings of all things are small.", AutorId = 3, CreatedAt = DateTime.Now},
                new Post { Id = 2, Title = "Semper Idem", Content = "Always the same.", AutorId = 3, CreatedAt = DateTime.Now},
                new Post { Id = 3, Title = "Ars Longa, Vita Brevis", Content = "Art is long, life is short.", AutorId = 4, CreatedAt = DateTime.Now},
                new Post { Id = 4, Title = "Acta est Fabula, Plaudite!", Content = "The play is over, applaud!", AutorId = 5, CreatedAt = DateTime.Now},
                new Post { Id = 5, Title = "Alea Jacta Est", Content = "The die is cast.", AutorId = 1, CreatedAt = DateTime.Now},
            };
            modelBuilder.Entity<Post>().HasData(posts);

            List<Comment> comments = new List<Comment>()
            {
                new Comment { Id = 1, Content = "Exitus Acta Probat – The result justifies the deed", AutorId = 7, PostId = 1, CreatedAt = DateTime.Now, Likes = 8 },
                new Comment { Id = 2, Content = "Veritas Odit Moras – Truth hates delay", AutorId = 8, PostId = 1, CreatedAt = DateTime.Now, Likes = 2 },
                new Comment { Id = 3, Content = "Timendi Causa Est Nescire – The cause of fear is ignorance", AutorId = 8, PostId = 1, CreatedAt = DateTime.Now, Likes = 3 },
                new Comment { Id = 4, Content = "Vivamus, Moriendum Est – Let us live, since we must die", AutorId = 8, PostId = 2, CreatedAt = DateTime.Now, Likes = 1 },
                new Comment { Id = 5, Content = "Nemo Sine Vitio Est – No one is without fault", AutorId = 8, PostId = 2, CreatedAt = DateTime.Now, Likes = 5 },
                new Comment { Id = 6, Content = "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery", AutorId = 8, PostId = 3, CreatedAt = DateTime.Now, Likes = 1 },
                new Comment { Id = 7, Content = "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!", AutorId = 1, PostId = 3, CreatedAt = DateTime.Now, Likes = 7 },
            };
            modelBuilder.Entity<Comment>().HasData(comments);

            List<LikePost> list = new List<LikePost>()
            {
                new LikePost { Id = 1, PostId = 1, UserId = 2},
                new LikePost { Id = 2, PostId = 1, UserId = 3},
                new LikePost { Id = 3, PostId = 3, UserId = 3},
                new LikePost { Id = 4, PostId = 3, UserId = 4},
                new LikePost { Id = 5, PostId = 3, UserId = 5},
                new LikePost { Id = 6, PostId = 4, UserId = 2},
            };
            modelBuilder.Entity<LikePost>().HasData(list);

            var tags = new List<Tag>()
            {
                new Tag { Id = 1, Name = "History"},
                new Tag { Id = 2, Name = "Philosophy"},
                new Tag { Id = 3, Name = "Medicine"},
                new Tag { Id = 4, Name = "Politics"}
            };
            modelBuilder.Entity<Tag>().HasData(tags);

            var postTags = new List<PostTag>()
            {
                new PostTag { Id = 1, PostId = 1, TagId = 1 },
                new PostTag { Id = 2, PostId = 1, TagId = 2 },
                new PostTag { Id = 3, PostId = 2, TagId = 2 },
                new PostTag { Id = 4, PostId = 3, TagId = 3 },
                new PostTag { Id = 5, PostId = 4, TagId = 4 },
                new PostTag { Id = 6, PostId = 5, TagId = 4 },
            };
            modelBuilder.Entity<PostTag>().HasData(postTags);
        }
    }
}