using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KHQ.Repo.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86ae6794-e925-4c40-b277-7d00b75f30e7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd257dbd-5dc4-4108-a14c-f5d4f215008d", null, "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff1f181b-e078-40a2-b200-5fbaee09b7a2", "AQAAAAIAAYagAAAAEH1PYXzDt355w+ACJVLrlNkhSnlOurUMFzP81UIW7VqIVxAqHQO3lGLd2YzKZH5wvg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd257dbd-5dc4-4108-a14c-f5d4f215008d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86ae6794-e925-4c40-b277-7d00b75f30e7", null, "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0564053f-e4be-4ece-b2f8-3f60de22751d", "AQAAAAIAAYagAAAAEO93SA2fOv10Ed54DgcgpgxJSBu8Clten6ZPaCC50I+CvSsOz9xacN9Urkj0YKlE1A==" });
        }
    }
}
