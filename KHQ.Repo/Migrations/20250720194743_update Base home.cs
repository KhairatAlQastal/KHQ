using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KHQ.Repo.Migrations
{
    /// <inheritdoc />
    public partial class updateBasehome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd257dbd-5dc4-4108-a14c-f5d4f215008d");

            migrationBuilder.DropColumn(
                name: "AboutUsDescreptionAR",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "AboutUsDescreptionEN",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "AboutUsTitleAR",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "AboutUsTitleEN",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "BrandsDescriptionAr",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "BrandsDescriptionEn",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "BrandsTitleAr",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "BrandsTitleEn",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "CategoryDescriptionAr",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "CategoryDescriptionEn",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "CategoryTitleAr",
                table: "BaseHomes");

            migrationBuilder.DropColumn(
                name: "CategoryTitleEn",
                table: "BaseHomes");

            migrationBuilder.RenameColumn(
                name: "FAQTitleEn",
                table: "BaseHomes",
                newName: "TitleEn");

            migrationBuilder.RenameColumn(
                name: "FAQTitleAr",
                table: "BaseHomes",
                newName: "TitleAr");

            migrationBuilder.RenameColumn(
                name: "FAQDescriptionEn",
                table: "BaseHomes",
                newName: "DescriptionEn");

            migrationBuilder.RenameColumn(
                name: "FAQDescriptionAr",
                table: "BaseHomes",
                newName: "DescriptionAr");

            migrationBuilder.AddColumn<int>(
                name: "SectionType",
                table: "BaseHomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0e7e790-11f7-4398-bc97-51c598d9aa41", null, "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49468694-ae9e-4042-a511-f02800042a84", "AQAAAAIAAYagAAAAEH49QNX5q67iVJpdEBnBscZ0RNM2KiUTZSDoPUlfgQFVGSly7Tei1x+JpOOY70h8ew==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0e7e790-11f7-4398-bc97-51c598d9aa41");

            migrationBuilder.DropColumn(
                name: "SectionType",
                table: "BaseHomes");

            migrationBuilder.RenameColumn(
                name: "TitleEn",
                table: "BaseHomes",
                newName: "FAQTitleEn");

            migrationBuilder.RenameColumn(
                name: "TitleAr",
                table: "BaseHomes",
                newName: "FAQTitleAr");

            migrationBuilder.RenameColumn(
                name: "DescriptionEn",
                table: "BaseHomes",
                newName: "FAQDescriptionEn");

            migrationBuilder.RenameColumn(
                name: "DescriptionAr",
                table: "BaseHomes",
                newName: "FAQDescriptionAr");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsDescreptionAR",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsDescreptionEN",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsTitleAR",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsTitleEN",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandsDescriptionAr",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandsDescriptionEn",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandsTitleAr",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandsTitleEn",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescriptionAr",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescriptionEn",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryTitleAr",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryTitleEn",
                table: "BaseHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
