using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForum.Migrations
{
    public partial class seededUsersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9715));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 14, 4, 6, 47, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "5HCv18Z8GwDaB7SAcYhXkM/Va5EsDkghw8xTLuGEK88=", "36H4soyqRmCs4TiyKtAT9g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "vUkAVJdcY5fdoK8gCPS12OxWqlcFBdRe8wPvG7T9Jzs=", "36H4soyqRmCs4TiyKtAT9g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "koGr5Cj1n1s6uEmqAlN0P5uKNLNLjHsTsvVbELwEqj4=", "36H4soyqRmCs4TiyKtAT9g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "U1pFsY6GNa92rht6+0z3SbhTkjamm09+EIzqMzqgrhc=", "36H4soyqRmCs4TiyKtAT9g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "aFwxpyTwOxHQ4mLZJf5UrBW4WGuvrzfw7yP4bDGBNq0=", "36H4soyqRmCs4TiyKtAT9g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "ztA9BLiMinsn9BY0XEzMH03cWpp//gN7W2j04fLLoBQ=", "36H4soyqRmCs4TiyKtAT9g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "pKsEIOupFopZLi1EDxEih/L2pZM/uMTSf5LKCCy9a7U=", "36H4soyqRmCs4TiyKtAT9g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "9EZ45VY5ZM5XtgFIRnTcva8mqsgcjzmDxPNKzNqmp40=", "36H4soyqRmCs4TiyKtAT9g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 52, 54, 492, DateTimeKind.Local).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { null, null });
        }
    }
}
