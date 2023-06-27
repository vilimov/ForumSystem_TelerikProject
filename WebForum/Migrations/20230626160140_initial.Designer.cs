﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebForum.Data;

#nullable disable

namespace WebForum.Migrations
{
    [DbContext(typeof(ForumContext))]
    [Migration("20230626160140_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3581),
                            Likes = 8,
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 8,
                            Content = "Veritas Odit Moras – Truth hates delay",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3585),
                            Likes = 2,
                            PostId = 1
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 8,
                            Content = "Timendi Causa Est Nescire – The cause of fear is ignorance",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3588),
                            Likes = 3,
                            PostId = 1
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 8,
                            Content = "Vivamus, Moriendum Est – Let us live, since we must die",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3590),
                            Likes = 1,
                            PostId = 2
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 8,
                            Content = "Nemo Sine Vitio Est – No one is without fault",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3592),
                            Likes = 5,
                            PostId = 2
                        },
                        new
                        {
                            Id = 6,
                            AutorId = 8,
                            Content = "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3594),
                            Likes = 1,
                            PostId = 3
                        },
                        new
                        {
                            Id = 7,
                            AutorId = 1,
                            Content = "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3596),
                            Likes = 7,
                            PostId = 3
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
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3497),
                            Likes = 5,
                            Title = "Omnium Rerum Principia Parva Sunt"
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 3,
                            Content = "Always the same.",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3541),
                            Likes = 1,
                            Title = "Semper Idem"
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 4,
                            Content = "Art is long, life is short.",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3543),
                            Likes = 10,
                            Title = "Ars Longa, Vita Brevis"
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 5,
                            Content = "The play is over, applaud!",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3545),
                            Likes = 3,
                            Title = "Acta est Fabula, Plaudite!"
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 1,
                            Content = "The die is cast.",
                            CreatedAt = new DateTime(2023, 6, 26, 19, 1, 40, 28, DateTimeKind.Local).AddTicks(3547),
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
                            Password = "JYsZJWP5TqklkDluhFzlPHDW2U4x4FOjEOpSKyMmNrI=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                            Password = "CcnsLZbvplUGt0uFoLaGJUdosrOoTyJx2a0HHKgV1bg=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                            Password = "TLPqUrVrizp0aCJR1MwX1Ede38HdmJd54hBNnedJ4Ps=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                            Password = "X/9NSoqFZA84vGm/RM8QOyiAzzqCuiMa0P9APOqiSR0=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                            Password = "04zVzUHKgu+eXJZFZdlZ6SgH3Sq/XGqnNJ17wctxg94=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                            Password = "AKG2/vTppTxxNl6XUtH1vHLEhqHJnBwHiEu9B++Nl/E=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                            Password = "bbcr4bL3Rsz2X+VcLib67eRlptG/wb7aFUetJ2QbOuw=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                            Password = "8tXHH+AvBxmJfPfmb+SBQgmBOdJdO53ygoewa24/HT8=",
                            Salt = "hgao85Qg9j0urKyL1stcjw==",
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
                });

            modelBuilder.Entity("WebForum.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}