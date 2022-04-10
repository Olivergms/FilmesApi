using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "bf00e7a3-60b3-4776-93a5-9468968142f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "e607ace7-b4b5-436b-a919-583d6bcfe81f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ccb8edd-4f34-4350-b638-bde1b67f3e4a", "AQAAAAEAACcQAAAAEB53frVWB0CYgJ9BVJpTZmyRgyv4cLH0QrXkZ4Gyatdj6xKwiA0mUyPufE2eu2DOMg==", "db06c29b-17fe-47fd-b3fd-a37f3bcf5aaf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "f3292db9-67e1-49cf-bab9-eabe6e38f67e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "89d5a7f4-9821-453e-8893-06d2fa7fb58c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a50b3b1-c21b-4668-8819-1b374cd1136e", "AQAAAAEAACcQAAAAEDO/ICvTYjvktl5W3hkUEY6fUJrbV0b8pG+tX++l80v1Ochm1Zv4qsYImyfTvIuUBQ==", "d4e6867c-f7a7-4e0f-8872-a867fb15543f" });
        }
    }
}
