using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebForum.Migrations
{
    /// <inheritdoc />
    public partial class moreTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 13, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 12, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 11, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 10, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 9, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 8, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 7, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 13, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 12, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 11, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 10, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 9, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 13, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 12, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 11, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 10, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 8, 14, 41, 9, 638, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Games" },
                    { 9, "Friends" },
                    { 10, "Forum" },
                    { 11, "Love" },
                    { 12, "Fun" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "pHn4Yv9OahWu29eqYiziAq2oR/CxbIBvbzshwMLpdac=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3vIlK8PtVnZshtgJU3PEEANaOrtOiWT5ha5pIjzEGjs=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "0fVZm02sydFP4Ya5fTKzmQ5mfWjmAP4jmPAQN0JOzlY=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "TkWe21UL4kmVViAKk9ZPz1b78TaJheHd8g2P5lDLTyg=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "qk5x3V9defnEd/b66BBxyMsU8UBCFkTFT4fR6eB2emc=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mjiOqG5FWhJ3clx98kCRlvtqqj8+ukEwoQ6vwDT0+ps=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "cXE+HSVrEPsj+U8pisfvAVshrjCab28XPs9jsqFA7us=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "95B3wPwrmlPk6VRJQQwuJzDwznjY307OcblbTN/PUjw=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "5ActQ8fnz1jlZJu0Tam7PS2tlferh9u1r96tDUtlkP4=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Jo9+uwPDtTm0+MymNGBmPzDp5x7MANLMgc38McG0hQ0=", "pNkAh4hII8m/ewlb/hM1Bw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "5GT36keob5FY6ZQS/SpBL0IJsVxU5xYzyBw3U9k7Dgs=", "pNkAh4hII8m/ewlb/hM1Bw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 13, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 12, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 11, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 10, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 9, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 8, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 7, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 13, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 12, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 11, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9688));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 10, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 9, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 13, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 12, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 11, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 10, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 7, 8, 14, 9, 49, 923, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "orY6wuoA8+xwyVFe4OF2jv1EhtGrCMZf74pgfW9Drbw=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "oaOlIVIy/hConWqN+OJRtgYb+WRmpsHb+jp1LNQlTug=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3PwARN7A4Z4oDIJCPuEqWlwPka9NxCRO4x2VkCtjZV0=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "eI2h31JTofNNbd3XgLzE2Lh4Z8OtAEr839ZDpkDRJFo=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "oYH0NXQZQC6Q4nqiOFsao7JctoOicejSB72J9AdrYnQ=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "rMPctRRXhqc5g5oo0kY0rsmOHRKqhLlxNeqLqlbRtuw=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "mGL+4bC3/VBeBRydXN/aGzJL+wsBbwk8WbQ/HfhlqXc=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "YgDS7vDku9ajgUtfQM3O7v1X+j5dmHnKtrgFslbpmq8=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "Z4JrkfOcYkfBAoUI+92zZG6ucs7wKoFMegQcEZE9efA=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "7Y3BMbDl4RMQEhgZACMn/zMaGoqqh7l4UcbedMmC0uU=", "Q4LpBUxWFTeypQTARaE8Dg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "PUJ4YWq9OQj9GJD+uMuTMHI1nbwLAOtBwQyoeRBe6Jo=", "Q4LpBUxWFTeypQTARaE8Dg==" });
        }
    }
}
