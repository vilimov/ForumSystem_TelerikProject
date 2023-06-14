﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var users = new List<User>()
            {
                new User { Id = 1, Username = "JuliusCaesar", Email = "JC@roman.im", Password = "Cleopatra", IsAdmin = true },
                new User { Id = 2, Username = "MarcusAurelius", Email = "MA@roman.im", Password = "Antoninus", IsAdmin = true },
                new User { Id = 3, Username = "MarcusTulliusCicero", Email = "MTC@roman.im", Password = "Tullius123", IsAdmin = false },
                new User { Id = 4, Username = "Hippocrates", Email = "Hipo@roman.im", Password = "CorpusHippocraticum", IsAdmin = false },
                new User {Id = 5, Username = "CaesarAugustus", Email = "CA@roman.im", Password = "GaiusOctavius", IsAdmin = false},
                new User {Id = 6, Username = "MarcusJuniusBrutus", Email = "BrutusIAm@roman.im", Password = "MeToo", IsAdmin = false},
                new User {Id = 7, Username = "PubliusOvidiusNaso", Email = "Ovid@roman.im", Password = "Metamorphoses", IsAdmin = false},
                new User {Id = 8, Username = "LuciusAnnaeusSeneca", Email = "Seneca@roman.im", Password = "EpistulaeMorales", IsAdmin = false},
            };
            modelBuilder.Entity<User>().HasData(users);

            List<Post> posts = new List<Post>()
            {
                new Post { Id = 1, Title = "Omnium Rerum Principia Parva Sunt", Content = "The beginnings of all things are small.", AutorId = 3 },
                new Post { Id = 2, Title = "Semper Idem", Content = "Always the same.", AutorId = 3 },
                new Post { Id = 3, Title = "Ars Longa, Vita Brevis", Content = "Art is long, life is short.", AutorId = 4 },
                new Post { Id = 4, Title = "Acta est Fabula, Plaudite!", Content = "The play is over, applaud!", AutorId = 5 },
                new Post { Id = 5, Title = "Alea Jacta Est", Content = "The die is cast.", AutorId = 1 },
            };
            modelBuilder.Entity<Post>().HasData(posts);

            List<Comment> comments = new List<Comment>()
            {
                new Comment { Id = 1, Content = "Exitus Acta Probat – The result justifies the deed", AutorId = 7, PostId = 1 },
                new Comment { Id = 2, Content = "Veritas Odit Moras – Truth hates delay", AutorId = 8, PostId = 1 },
                new Comment { Id = 3, Content = "Timendi Causa Est Nescire – The cause of fear is ignorance", AutorId = 8, PostId = 1 },
                new Comment { Id = 4, Content = "Vivamus, Moriendum Est – Let us live, since we must die", AutorId = 8, PostId = 2 },
                new Comment { Id = 5, Content = "Nemo Sine Vitio Est – No one is without fault", AutorId = 8, PostId = 2 },
                new Comment { Id = 6, Content = "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery", AutorId = 8, PostId = 3 },
                new Comment { Id = 7, Content = "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!", AutorId = 1, PostId = 3 },
            };
            modelBuilder.Entity<Comment>().HasData(comments);
        }
    }
}