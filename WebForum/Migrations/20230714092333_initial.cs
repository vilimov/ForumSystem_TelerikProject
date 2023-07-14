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
                    { 4, "Politics" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "IsBlocked", "LastName", "Password", "Salt", "UserImage", "Username" },
                values: new object[,]
                {
                    { 1, "JC@roman.im", "Julius", true, false, "Caesar", "7Thd5iXjuEFRxbPsLdB8C5PBnF9O0Ax4PmlQyqft2xE=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "JuliusCaesar" },
                    { 2, "MA@roman.im", "Marcus", true, false, "Aurelius", "TBYxGqZ081UA9HPcb0gFPEaC4JWiytD/VnXSQZ2H8dE=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "MarcusAurelius" },
                    { 3, "MTC@roman.im", "MarcusTullius", false, false, "Cicero", "gTwYEFcKwPvg6IkLGcNKIaROSbMtfU4mObZrg03y4Ic=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "MarcusTulliusCicero" },
                    { 4, "Hipo@roman.im", "Hippocrates", false, false, "ofKos", "FQ74srzr3qsrEHaQZC/LplZ7AKfTaNLhKqSiKjdVSe8=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "Hippocrates" },
                    { 5, "CA@roman.im", "Caesar", false, false, "Augustus", "FFL4JMFySXGCbwO37USe3QOtBmE+PPWUNk0YXPfaP1Y=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "CaesarAugustus" },
                    { 6, "BrutusIAm@roman.im", "MarcusJunius", false, true, "Brutus", "GShEoMfoQgvpkvScxunY6ulRuPtTvcnMl9cdxWGYEkE=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "MarcusJuniusBrutus" },
                    { 7, "Ovid@roman.im", "PubliusOvidius", false, false, "Naso", "Vhm5SBnGII5AaFTUw3EIL/MO2h0YDFuOMRxlvOSEqDs=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "PubliusOvidiusNaso" },
                    { 8, "Seneca@roman.im", "LuciusAnnaeus", false, false, "Seneca", "UEVIQv3ZwDm5GaKleZ4uWr1Rxt6FDAE5RoVY17SanDE=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "LuciusAnnaeusSeneca" },
                    { 9, "admin@adm.in", "Ad", true, false, "Min", "jfKWoc8grSkHUcikJsYnL1YOt/rmZXV5eKYQ5XHxGUU=", "dx6Dn10bB0Bgwr2RuUJHMA==", "defaultProfile.png", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AutorId", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, 3, "The beginnings of all things are small.", new DateTime(2023, 7, 13, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(628), "Omnium Rerum Principia Parva Sunt" },
                    { 2, 3, "Always the same.", new DateTime(2023, 7, 12, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(669), "Semper Idem" },
                    { 3, 4, "Art is long, life is short.", new DateTime(2023, 7, 11, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(671), "Ars Longa, Vita Brevis" },
                    { 4, 5, "The play is over, applaud!", new DateTime(2023, 7, 10, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(674), "Acta est Fabula, Plaudite!" },
                    { 5, 1, "The die is cast.", new DateTime(2023, 7, 9, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(676), "Alea Jacta Est" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AutorId", "Content", "CreatedAt", "PostId" },
                values: new object[,]
                {
                    { 1, 7, "Exitus Acta Probat – The result justifies the deed", new DateTime(2023, 7, 13, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(724), 1 },
                    { 2, 8, "Veritas Odit Moras – Truth hates delay", new DateTime(2023, 7, 12, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(728), 1 },
                    { 3, 8, "Timendi Causa Est Nescire – The cause of fear is ignorance", new DateTime(2023, 7, 11, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(731), 1 },
                    { 4, 8, "Vivamus, Moriendum Est – Let us live, since we must die", new DateTime(2023, 7, 10, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(733), 2 },
                    { 5, 8, "Nemo Sine Vitio Est – No one is without fault", new DateTime(2023, 7, 9, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(735), 2 },
                    { 6, 8, "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery", new DateTime(2023, 7, 8, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(738), 3 },
                    { 7, 1, "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!", new DateTime(2023, 7, 7, 12, 23, 33, 219, DateTimeKind.Local).AddTicks(741), 3 }
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
