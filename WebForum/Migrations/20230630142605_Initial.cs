using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForum.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false)
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
                    Likes = table.Column<int>(type: "int", nullable: false),
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
                    Likes = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "IsBlocked", "LastName", "Password", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, "JC@roman.im", "Julius", true, false, "Caesar", "mUZGl4xCcJ9ZuK6sG6AOb74LNo69qe1nhGKVUeQAzGA=", "s2yXTRxPkzjLhq5Tidgu3g==", "JuliusCaesar" },
                    { 2, "MA@roman.im", "Marcus", true, false, "Aurelius", "yZ3/MMzxbGfos8TlaCkwffXPkKP+dsQbMxC89tSVBgQ=", "s2yXTRxPkzjLhq5Tidgu3g==", "MarcusAurelius" },
                    { 3, "MTC@roman.im", "MarcusTullius", false, false, "Cicero", "XSDX7xBeqDvuKpaDh3sIEhPfi6ZaHRfFr+oQ9tIuhN4=", "s2yXTRxPkzjLhq5Tidgu3g==", "MarcusTulliusCicero" },
                    { 4, "Hipo@roman.im", "Hippocrates", false, false, "ofKos", "DbRoTbDK9eUZWNW3HdOF86iPF4ZWwVT1bR7BGGU6RLE=", "s2yXTRxPkzjLhq5Tidgu3g==", "Hippocrates" },
                    { 5, "CA@roman.im", "Caesar", false, false, "Augustus", "Fg49colv1UXO8kPIlQhtn/+cw6l7I6OtzFLmupFlNNA=", "s2yXTRxPkzjLhq5Tidgu3g==", "CaesarAugustus" },
                    { 6, "BrutusIAm@roman.im", "MarcusJunius", false, true, "Brutus", "5RWMx3nNTaF2WaQlemtJuZrzt7j1BQS74c18iGjKB6o=", "s2yXTRxPkzjLhq5Tidgu3g==", "MarcusJuniusBrutus" },
                    { 7, "Ovid@roman.im", "PubliusOvidius", false, false, "Naso", "V95uoJeZETwL1ctBj0lU2dMl1vpfT3sGUNU81+stMA4=", "s2yXTRxPkzjLhq5Tidgu3g==", "PubliusOvidiusNaso" },
                    { 8, "Seneca@roman.im", "LuciusAnnaeus", false, false, "Seneca", "KXGCzP/Plf51YW5xRZb1l63hl3cIjYqdIvuB+phY1FY=", "s2yXTRxPkzjLhq5Tidgu3g==", "LuciusAnnaeusSeneca" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AutorId", "Content", "CreatedAt", "Likes", "Title" },
                values: new object[,]
                {
                    { 1, 3, "The beginnings of all things are small.", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7655), 5, "Omnium Rerum Principia Parva Sunt" },
                    { 2, 3, "Always the same.", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7699), 1, "Semper Idem" },
                    { 3, 4, "Art is long, life is short.", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7701), 10, "Ars Longa, Vita Brevis" },
                    { 4, 5, "The play is over, applaud!", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7704), 3, "Acta est Fabula, Plaudite!" },
                    { 5, 1, "The die is cast.", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7706), 2, "Alea Jacta Est" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AutorId", "Content", "CreatedAt", "Likes", "PostId" },
                values: new object[,]
                {
                    { 1, 7, "Exitus Acta Probat – The result justifies the deed", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7754), 8, 1 },
                    { 2, 8, "Veritas Odit Moras – Truth hates delay", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7758), 2, 1 },
                    { 3, 8, "Timendi Causa Est Nescire – The cause of fear is ignorance", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7761), 3, 1 },
                    { 4, 8, "Vivamus, Moriendum Est – Let us live, since we must die", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7762), 1, 2 },
                    { 5, 8, "Nemo Sine Vitio Est – No one is without fault", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7764), 5, 2 },
                    { 6, 8, "Magna Servitus Est Magna Fortuna – A great fortune is a great slavery", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7767), 1, 3 },
                    { 7, 1, "Ave Caesar morituri te salutant – Hail, Emperor, those who are about to die salute you!", new DateTime(2023, 6, 30, 17, 26, 5, 291, DateTimeKind.Local).AddTicks(7769), 7, 3 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LikePosts");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
