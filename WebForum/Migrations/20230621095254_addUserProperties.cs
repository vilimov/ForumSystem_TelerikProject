using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForum.Migrations
{
    public partial class addUserProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 6, 21, 12, 21, 49, 23, DateTimeKind.Local).AddTicks(636));
        }
    }
}
