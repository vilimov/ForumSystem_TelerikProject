﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebForum.Data;

#nullable disable

namespace WebForum.Migrations
{
    [DbContext(typeof(ForumContext))]
    partial class ForumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebForum.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AutorId = 7,
                            Content = "Exitus Acta Probat – The result justifies the deed",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7754),
                            Likes = 8,
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 8,
                            Content = "Veritas Odit Moras – Truth hates delay",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7758),
                            Likes = 2,
                            PostId = 1
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 8,
                            Content = "Timendi Causa Est Nescire – The cause of fear is ignorance",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7761),
                            Likes = 3,
                            PostId = 1
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 8,
                            Content = "Vivamus, Moriendum Est – Let us live, since we must die",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7762),
                            Likes = 1,
                            PostId = 2
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 8,
                            Content = "Nemo Sine Vitio Est – No one is without fault",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7764),
                            Likes = 5,
                            PostId = 2
                        },
                        new
                        {
                            Id = 6,
                            AutorId = 8,
                            Content = "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7767),
                            Likes = 1,
                            PostId = 3
                        },
                        new
                        {
                            Id = 7,
                            AutorId = 1,
                            Content = "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7769),
                            Likes = 7,
                            PostId = 3
                        });
                });

            modelBuilder.Entity("WebForum.Models.LikesModels.LikePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("LikePosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            PostId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            PostId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            PostId = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            PostId = 3,
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            PostId = 4,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("WebForum.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AutorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AutorId = 3,
                            Content = "The beginnings of all things are small.",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7655),
                            Likes = 5,
                            Title = "Omnium Rerum Principia Parva Sunt"
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 3,
                            Content = "Always the same.",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7699),
                            Likes = 1,
                            Title = "Semper Idem"
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 4,
                            Content = "Art is long, life is short.",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7701),
                            Likes = 10,
                            Title = "Ars Longa, Vita Brevis"
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 5,
                            Content = "The play is over, applaud!",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7704),
                            Likes = 3,
                            Title = "Acta est Fabula, Plaudite!"
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 1,
                            Content = "The die is cast.",
                            CreatedAt = new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7706),
                            Likes = 2,
                            Title = "Alea Jacta Est"
                        });
                });

            modelBuilder.Entity("WebForum.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(170)
                        .HasColumnType("nvarchar(170)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "JC@roman.im",
                            FirstName = "Julius",
                            IsAdmin = true,
                            IsBlocked = false,
                            LastName = "Caesar",
                            Password = "mUZGl4xCcJ9ZuK6sG6AOb74LNo69qe1nhGKVUeQAzGA=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "JuliusCaesar"
                        },
                        new
                        {
                            Id = 2,
                            Email = "MA@roman.im",
                            FirstName = "Marcus",
                            IsAdmin = true,
                            IsBlocked = false,
                            LastName = "Aurelius",
                            Password = "yZ3/MMzxbGfos8TlaCkwffXPkKP+dsQbMxC89tSVBgQ=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "MarcusAurelius"
                        },
                        new
                        {
                            Id = 3,
                            Email = "MTC@roman.im",
                            FirstName = "MarcusTullius",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "Cicero",
                            Password = "XSDX7xBeqDvuKpaDh3sIEhPfi6ZaHRfFr+oQ9tIuhN4=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "MarcusTulliusCicero"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Hipo@roman.im",
                            FirstName = "Hippocrates",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "ofKos",
                            Password = "DbRoTbDK9eUZWNW3HdOF86iPF4ZWwVT1bR7BGGU6RLE=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "Hippocrates"
                        },
                        new
                        {
                            Id = 5,
                            Email = "CA@roman.im",
                            FirstName = "Caesar",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "Augustus",
                            Password = "Fg49colv1UXO8kPIlQhtn/+cw6l7I6OtzFLmupFlNNA=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "CaesarAugustus"
                        },
                        new
                        {
                            Id = 6,
                            Email = "BrutusIAm@roman.im",
                            FirstName = "MarcusJunius",
                            IsAdmin = false,
                            IsBlocked = true,
                            LastName = "Brutus",
                            Password = "5RWMx3nNTaF2WaQlemtJuZrzt7j1BQS74c18iGjKB6o=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "MarcusJuniusBrutus"
                        },
                        new
                        {
                            Id = 7,
                            Email = "Ovid@roman.im",
                            FirstName = "PubliusOvidius",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "Naso",
                            Password = "V95uoJeZETwL1ctBj0lU2dMl1vpfT3sGUNU81+stMA4=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "PubliusOvidiusNaso"
                        },
                        new
                        {
                            Id = 8,
                            Email = "Seneca@roman.im",
                            FirstName = "LuciusAnnaeus",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "Seneca",
                            Password = "KXGCzP/Plf51YW5xRZb1l63hl3cIjYqdIvuB+phY1FY=",
                            Salt = "s2yXTRxPkzjLhq5Tidgu3g==",
                            Username = "LuciusAnnaeusSeneca"
                        });
                });

            modelBuilder.Entity("WebForum.Models.Comment", b =>
                {
                    b.HasOne("WebForum.Models.User", "Autor")
                        .WithMany("Comments")
                        .HasForeignKey("AutorId");

                    b.HasOne("WebForum.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.Navigation("Autor");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("WebForum.Models.LikesModels.LikePost", b =>
                {
                    b.HasOne("WebForum.Models.Post", "Post")
                        .WithMany("LikePosts")
                        .HasForeignKey("PostId");

                    b.HasOne("WebForum.Models.User", "User")
                        .WithMany("LikePosts")
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebForum.Models.Post", b =>
                {
                    b.HasOne("WebForum.Models.User", "Autor")
                        .WithMany("Posts")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("WebForum.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikePosts");
                });

            modelBuilder.Entity("WebForum.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikePosts");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
