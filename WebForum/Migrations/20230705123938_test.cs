using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebForum.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 15, 39, 38, 354, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "4CmiJHyIjzDqdoA9Oygm2R43853bf7acuIpKAbDtogw=", "BopWEknFqX5R+XXCnmw3UA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "fQFVDQYFgdUqA34h3JSNn7x6JQRnkp0niRnONlL7dBY=", "BopWEknFqX5R+XXCnmw3UA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "SfFFs5ztQqLTz7IXe8L+/ev1Ksq14QjvHXVOjJgFVrM=", "BopWEknFqX5R+XXCnmw3UA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "DwecbSBmD4O28VzNZatjvzYG8bB60KN4fmCIPhXhv5E=", "BopWEknFqX5R+XXCnmw3UA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Qf5KwGO7SFFF05kAbcgTVYPL++BAk8ukKeqBb0vlBqM=", "BopWEknFqX5R+XXCnmw3UA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "JrjKvMqCjDpVufaJX07O47zKMBhI6txFrAjlisyD8jA=", "BopWEknFqX5R+XXCnmw3UA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "LHE1tRadDalBGj5wc3vxeoxHfVZ1Qtcu51T3OiabVTY=", "BopWEknFqX5R+XXCnmw3UA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "401kWYxe0koeijEWPEUva8ZhrG7hY7OMTrpIQDmKqF8=", "BopWEknFqX5R+XXCnmw3UA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 5, 10, 9, 21, 60, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "MaBx8ElZld0zqhTEFvTaJz62d5sHRWD8etQzCYIbMTo=", "+9cP8kFPuFfh12LpDISG6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/D/XBA+MTSnOARtYBtaJvhamHrNHkwxVM2DBqsA1hs=", "+9cP8kFPuFfh12LpDISG6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "XwF0D9KBjUcWAfJcwgjESx2BPGG30mMCm/jGmm5i5jY=", "+9cP8kFPuFfh12LpDISG6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "E4XEmjaoAlb+aGy22hqEj+N2LtPLxD4Nr7iKQYUAFds=", "+9cP8kFPuFfh12LpDISG6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "IjeSoAFmxzz02F/MXKgUXouIWeiOvhdktupzhH7dxms=", "+9cP8kFPuFfh12LpDISG6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "kKlTqTa1b5eXRNHg1hjNsCb7qIORJig/nlgd80uaJRk=", "+9cP8kFPuFfh12LpDISG6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "/rSdnmsQ6rj4T/TzvLbRN1JZ9lz845C7b7+SRC5OhtA=", "+9cP8kFPuFfh12LpDISG6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "e2k79CL+zoyO1u4wWAtfU10eLBIVa3ei5FAi2wj8ivw=", "+9cP8kFPuFfh12LpDISG6w==" });
        }
    }
}
