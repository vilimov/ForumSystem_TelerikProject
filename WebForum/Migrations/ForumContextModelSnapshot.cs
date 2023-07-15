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
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebForum.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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
                            CreatedAt = new DateTime(2023, 7, 14, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4952),
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 8,
                            Content = "Veritas Odit Moras – Truth hates delay",
                            CreatedAt = new DateTime(2023, 7, 13, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4957),
                            PostId = 1
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 8,
                            Content = "Timendi Causa Est Nescire – The cause of fear is ignorance",
                            CreatedAt = new DateTime(2023, 7, 12, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4959),
                            PostId = 1
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 8,
                            Content = "Vivamus, Moriendum Est – Let us live, since we must die",
                            CreatedAt = new DateTime(2023, 7, 11, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4960),
                            PostId = 2
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 8,
                            Content = "Nemo Sine Vitio Est – No one is without fault",
                            CreatedAt = new DateTime(2023, 7, 10, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4962),
                            PostId = 2
                        },
                        new
                        {
                            Id = 6,
                            AutorId = 8,
                            Content = "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery",
                            CreatedAt = new DateTime(2023, 7, 9, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4964),
                            PostId = 3
                        },
                        new
                        {
                            Id = 7,
                            AutorId = 1,
                            Content = "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!",
                            CreatedAt = new DateTime(2023, 7, 8, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4965),
                            PostId = 3
                        });
                });

            modelBuilder.Entity("WebForum.Models.LikesModels.CommentLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentLikes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentId = 1,
                            UserId = 8
                        },
                        new
                        {
                            Id = 2,
                            CommentId = 1,
                            UserId = 7
                        },
                        new
                        {
                            Id = 3,
                            CommentId = 1,
                            UserId = 6
                        },
                        new
                        {
                            Id = 4,
                            CommentId = 1,
                            UserId = 5
                        },
                        new
                        {
                            Id = 5,
                            CommentId = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            CommentId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 7,
                            CommentId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 8,
                            CommentId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            CommentId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 10,
                            CommentId = 4,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("WebForum.Models.LikesModels.LikePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

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
                            CreatedAt = new DateTime(2023, 7, 14, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4875),
                            Title = "Omnium Rerum Principia Parva Sunt"
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 3,
                            Content = "Always the same.",
                            CreatedAt = new DateTime(2023, 7, 13, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4910),
                            Title = "Semper Idem"
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 4,
                            Content = "Art is long, life is short.",
                            CreatedAt = new DateTime(2023, 7, 12, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4914),
                            Title = "Ars Longa, Vita Brevis"
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 5,
                            Content = "The play is over, applaud!",
                            CreatedAt = new DateTime(2023, 7, 11, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4915),
                            Title = "Acta est Fabula, Plaudite!"
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 1,
                            Content = "The die is cast.",
                            CreatedAt = new DateTime(2023, 7, 10, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4916),
                            Title = "Alea Jacta Est"
                        },
                        new
                        {
                            Id = 6,
                            AutorId = 10,
                            Content = "Etiam justo sem, porttitor posuere dignissim finibus, euismod lobortis tellus. Praesent bibendum, mauris vitae varius fermentum, nulla risus semper odio, sed tempus augue risus ut est. Vestibulum laoreet blandit pretium. Vivamus mi enim, luctus mollis blandit nec, scelerisque et leo.",
                            CreatedAt = new DateTime(2023, 7, 14, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4918),
                            Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                        },
                        new
                        {
                            Id = 7,
                            AutorId = 11,
                            Content = "Quisque eu gravida nulla. Phasellus laoreet quam turpis, at condimentum arcu feugiat at. Sed eu eros sit amet quam laoreet tempor. Donec placerat est quis mauris commodo, id sagittis risus fermentum. Morbi quis est vel est efficitur ullamcorper.",
                            CreatedAt = new DateTime(2023, 7, 13, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4919),
                            Title = "Vestibulum suscipit metus urna, non pulvinar nunc faucibus eu"
                        },
                        new
                        {
                            Id = 8,
                            AutorId = 10,
                            Content = "Nullam varius condimentum aliquam. Morbi nec tellus semper erat sollicitudin malesuada. ",
                            CreatedAt = new DateTime(2023, 7, 12, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4921),
                            Title = "Quisque a dui rutrum, mollis eros a, blandit justo"
                        },
                        new
                        {
                            Id = 9,
                            AutorId = 5,
                            Content = "Phasellus aliquet pretium mattis :( ",
                            CreatedAt = new DateTime(2023, 7, 11, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4922),
                            Title = "Praesent malesuada accumsan!"
                        },
                        new
                        {
                            Id = 10,
                            AutorId = 11,
                            Content = "Duis sit amet placerat turpis. Mauris eleifend dolor et lectus dictum, ut semper velit gravida. Duis eget ipsum ac nisl pretium vestibulum. Cras auctor nulla bibendum nibh tempor auctor. Mauris quis ornare massa, vel lobortis dolor. Sed et nunc massa. Ut quis volutpat magna",
                            CreatedAt = new DateTime(2023, 7, 9, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4924),
                            Title = "Duis sit amet placerat turpis"
                        });
                });

            modelBuilder.Entity("WebForum.Models.PostTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 1,
                            TagId = 1
                        },
                        new
                        {
                            Id = 2,
                            PostId = 1,
                            TagId = 2
                        },
                        new
                        {
                            Id = 3,
                            PostId = 2,
                            TagId = 2
                        },
                        new
                        {
                            Id = 4,
                            PostId = 3,
                            TagId = 3
                        },
                        new
                        {
                            Id = 5,
                            PostId = 4,
                            TagId = 4
                        },
                        new
                        {
                            Id = 6,
                            PostId = 5,
                            TagId = 4
                        });
                });

            modelBuilder.Entity("WebForum.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "History"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Philosophy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Medicine"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Politics"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Commedy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Tragedy"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Games"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Friends"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Forum"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Love"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Fun"
                        });
                });

            modelBuilder.Entity("WebForum.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("UserImage")
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
                            Password = "TN92FB8RaEOIIpl0KuIZnKctG8rZnDpQJPLI39QmFd4=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "avatar9.png",
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
                            Password = "baeAt1uoMpHNbonDbpbT1HGHDIPj23M2euFFQjnKduU=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "avatar4.png",
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
                            Password = "dvs+jRh8K7KVEb1Z+yH494KbJgqEUON7jvFm03wd6tI=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "avatar5.png",
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
                            Password = "s244Ah9Yn6zfCRp6RmV8r8A6dYWKE5/uu2UxaPfQRA8=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "avatar1.png",
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
                            Password = "XsPfax47c174U2EV72O6ud9XXk6pghEVoUCajfne/Ew=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "defaultProfile.png",
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
                            Password = "BNcG3ehWOhKj3FOfwJgBL1m6H8gxZnUcRcPMKJAvem4=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "avatar2.png",
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
                            Password = "hRlMdgjxgf9IH2lLR+5hRlTuaRyHxAntSasO97aDjtM=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "defaultProfile.png",
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
                            Password = "AIIS5YztZzHQl84dkkIpSuX+fbNd/dSb2ytilHpYDvs=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "defaultProfile.png",
                            Username = "LuciusAnnaeusSeneca"
                        },
                        new
                        {
                            Id = 9,
                            Email = "admin@adm.in",
                            FirstName = "Ad",
                            IsAdmin = true,
                            IsBlocked = false,
                            LastName = "Min",
                            Password = "w2h8b2yyd9aSUvYpmjFIhLojnLknzb0mU8nvHQMa2NI=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "defaultProfile.png",
                            Username = "Admin"
                        },
                        new
                        {
                            Id = 10,
                            Email = "CleoQueen@greek.myth",
                            FirstName = "Cleopatra",
                            IsAdmin = true,
                            IsBlocked = false,
                            LastName = "Philopator",
                            Password = "oerTRp5QHmXicuc5zT41HJHMDPoGD3R+izADPldF9Gw=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "avatar11.png",
                            Username = "CleoQueen"
                        },
                        new
                        {
                            Id = 11,
                            Email = "CaesarWify@roman.im",
                            FirstName = "Calpurnia",
                            IsAdmin = false,
                            IsBlocked = false,
                            LastName = "Caesar",
                            Password = "bEs2z2AKSIPWz3sqhLBjDgDpajO6jOVmaLZMW8c6Cnw=",
                            Salt = "YHuKssVLs9Ec6fg8Bs1cpQ==",
                            UserImage = "avatar10.png",
                            Username = "CalpurniaJC"
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

            modelBuilder.Entity("WebForum.Models.LikesModels.CommentLike", b =>
                {
                    b.HasOne("WebForum.Models.Comment", "Comment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId");

                    b.HasOne("WebForum.Models.User", "User")
                        .WithMany("CommentLikes")
                        .HasForeignKey("UserId");

                    b.Navigation("Comment");

                    b.Navigation("User");
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

            modelBuilder.Entity("WebForum.Models.PostTag", b =>
                {
                    b.HasOne("WebForum.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebForum.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("WebForum.Models.Comment", b =>
                {
                    b.Navigation("CommentLikes");
                });

            modelBuilder.Entity("WebForum.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikePosts");

                    b.Navigation("PostTags");
                });

            modelBuilder.Entity("WebForum.Models.Tag", b =>
                {
                    b.Navigation("PostTags");
                });

            modelBuilder.Entity("WebForum.Models.User", b =>
                {
                    b.Navigation("CommentLikes");

                    b.Navigation("Comments");

                    b.Navigation("LikePosts");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
