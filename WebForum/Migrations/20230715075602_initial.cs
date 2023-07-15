using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebForum.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikePosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikePosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LikePosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "History" },
                    { 2, "Philosophy" },
                    { 3, "Medicine" },
                    { 4, "Politics" },
                    { 5, "Math" },
                    { 6, "Commedy" },
                    { 7, "Tragedy" },
                    { 8, "Games" },
                    { 9, "Friends" },
                    { 10, "Forum" },
                    { 11, "Love" },
                    { 12, "Fun" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "IsBlocked", "LastName", "Password", "Salt", "UserImage", "Username" },
                values: new object[,]
                {
                    { 1, "JC@roman.im", "Julius", true, false, "Caesar", "TN92FB8RaEOIIpl0KuIZnKctG8rZnDpQJPLI39QmFd4=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "avatar9.png", "JuliusCaesar" },
                    { 2, "MA@roman.im", "Marcus", true, false, "Aurelius", "baeAt1uoMpHNbonDbpbT1HGHDIPj23M2euFFQjnKduU=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "avatar4.png", "MarcusAurelius" },
                    { 3, "MTC@roman.im", "MarcusTullius", false, false, "Cicero", "dvs+jRh8K7KVEb1Z+yH494KbJgqEUON7jvFm03wd6tI=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "avatar5.png", "MarcusTulliusCicero" },
                    { 4, "Hipo@roman.im", "Hippocrates", false, false, "ofKos", "s244Ah9Yn6zfCRp6RmV8r8A6dYWKE5/uu2UxaPfQRA8=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "avatar1.png", "Hippocrates" },
                    { 5, "CA@roman.im", "Caesar", false, false, "Augustus", "XsPfax47c174U2EV72O6ud9XXk6pghEVoUCajfne/Ew=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "defaultProfile.png", "CaesarAugustus" },
                    { 6, "BrutusIAm@roman.im", "MarcusJunius", false, true, "Brutus", "BNcG3ehWOhKj3FOfwJgBL1m6H8gxZnUcRcPMKJAvem4=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "avatar2.png", "MarcusJuniusBrutus" },
                    { 7, "Ovid@roman.im", "PubliusOvidius", false, false, "Naso", "hRlMdgjxgf9IH2lLR+5hRlTuaRyHxAntSasO97aDjtM=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "defaultProfile.png", "PubliusOvidiusNaso" },
                    { 8, "Seneca@roman.im", "LuciusAnnaeus", false, false, "Seneca", "AIIS5YztZzHQl84dkkIpSuX+fbNd/dSb2ytilHpYDvs=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "defaultProfile.png", "LuciusAnnaeusSeneca" },
                    { 9, "admin@adm.in", "Ad", true, false, "Min", "w2h8b2yyd9aSUvYpmjFIhLojnLknzb0mU8nvHQMa2NI=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "defaultProfile.png", "Admin" },
                    { 10, "CleoQueen@greek.myth", "Cleopatra", true, false, "Philopator", "oerTRp5QHmXicuc5zT41HJHMDPoGD3R+izADPldF9Gw=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "avatar11.png", "CleoQueen" },
                    { 11, "CaesarWify@roman.im", "Calpurnia", false, false, "Caesar", "bEs2z2AKSIPWz3sqhLBjDgDpajO6jOVmaLZMW8c6Cnw=", "YHuKssVLs9Ec6fg8Bs1cpQ==", "avatar10.png", "CalpurniaJC" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AutorId", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, 3, "The beginnings of all things are small.", new DateTime(2023, 7, 14, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4875), "Omnium Rerum Principia Parva Sunt" },
                    { 2, 3, "Always the same.", new DateTime(2023, 7, 13, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4910), "Semper Idem" },
                    { 3, 4, "Art is long, life is short.", new DateTime(2023, 7, 12, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4914), "Ars Longa, Vita Brevis" },
                    { 4, 5, "The play is over, applaud!", new DateTime(2023, 7, 11, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4915), "Acta est Fabula, Plaudite!" },
                    { 5, 1, "The die is cast.", new DateTime(2023, 7, 10, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4916), "Alea Jacta Est" },
                    { 6, 10, "Etiam justo sem, porttitor posuere dignissim finibus, euismod lobortis tellus. Praesent bibendum, mauris vitae varius fermentum, nulla risus semper odio, sed tempus augue risus ut est. Vestibulum laoreet blandit pretium. Vivamus mi enim, luctus mollis blandit nec, scelerisque et leo.", new DateTime(2023, 7, 14, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4918), "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                    { 7, 11, "Quisque eu gravida nulla. Phasellus laoreet quam turpis, at condimentum arcu feugiat at. Sed eu eros sit amet quam laoreet tempor. Donec placerat est quis mauris commodo, id sagittis risus fermentum. Morbi quis est vel est efficitur ullamcorper.", new DateTime(2023, 7, 13, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4919), "Vestibulum suscipit metus urna, non pulvinar nunc faucibus eu" },
                    { 8, 10, "Nullam varius condimentum aliquam. Morbi nec tellus semper erat sollicitudin malesuada. ", new DateTime(2023, 7, 12, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4921), "Quisque a dui rutrum, mollis eros a, blandit justo" },
                    { 9, 5, "Phasellus aliquet pretium mattis :( ", new DateTime(2023, 7, 11, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4922), "Praesent malesuada accumsan!" },
                    { 10, 11, "Duis sit amet placerat turpis. Mauris eleifend dolor et lectus dictum, ut semper velit gravida. Duis eget ipsum ac nisl pretium vestibulum. Cras auctor nulla bibendum nibh tempor auctor. Mauris quis ornare massa, vel lobortis dolor. Sed et nunc massa. Ut quis volutpat magna", new DateTime(2023, 7, 9, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4924), "Duis sit amet placerat turpis" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AutorId", "Content", "CreatedAt", "PostId" },
                values: new object[,]
                {
                    { 1, 7, "Exitus Acta Probat – The result justifies the deed", new DateTime(2023, 7, 14, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4952), 1 },
                    { 2, 8, "Veritas Odit Moras – Truth hates delay", new DateTime(2023, 7, 13, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4957), 1 },
                    { 3, 8, "Timendi Causa Est Nescire – The cause of fear is ignorance", new DateTime(2023, 7, 12, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4959), 1 },
                    { 4, 8, "Vivamus, Moriendum Est – Let us live, since we must die", new DateTime(2023, 7, 11, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4960), 2 },
                    { 5, 8, "Nemo Sine Vitio Est – No one is without fault", new DateTime(2023, 7, 10, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4962), 2 },
                    { 6, 8, "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery", new DateTime(2023, 7, 9, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4964), 3 },
                    { 7, 1, "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!", new DateTime(2023, 7, 8, 10, 56, 2, 456, DateTimeKind.Local).AddTicks(4965), 3 }
                });

            migrationBuilder.InsertData(
                table: "LikePosts",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 3, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 },
                    { 6, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "Id", "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 3, 3 },
                    { 5, 4, 4 },
                    { 6, 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "Id", "CommentId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 8 },
                    { 2, 1, 7 },
                    { 3, 1, 6 },
                    { 4, 1, 5 },
                    { 5, 2, 4 },
                    { 6, 2, 3 },
                    { 7, 2, 2 },
                    { 8, 3, 1 },
                    { 9, 3, 2 },
                    { 10, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentId",
                table: "CommentLikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AutorId",
                table: "Comments",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_PostId",
                table: "LikePosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_UserId",
                table: "LikePosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AutorId",
                table: "Posts",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "LikePosts");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
