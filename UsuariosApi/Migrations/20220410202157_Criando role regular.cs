using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "89d5a7f4-9821-453e-8893-06d2fa7fb58c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "f3292db9-67e1-49cf-bab9-eabe6e38f67e", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a50b3b1-c21b-4668-8819-1b374cd1136e", "AQAAAAEAACcQAAAAEDO/ICvTYjvktl5W3hkUEY6fUJrbV0b8pG+tX++l80v1Ochm1Zv4qsYImyfTvIuUBQ==", "d4e6867c-f7a7-4e0f-8872-a867fb15543f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f0490f61-86d7-4d48-8524-8cbbc4571ffa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1996ecf6-902b-45f0-b984-3dcd2283f725", "AQAAAAEAACcQAAAAEBGH6a5bBxrWk7Cxh3cVaAr2NUqO3zvmX9R8wfsPV2XRlB4FS4fxtQF82fYCrIuCUQ==", "7aac9f39-d299-4626-a321-941a36d3bbb4" });
        }
    }
}
