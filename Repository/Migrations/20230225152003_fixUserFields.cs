using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class fixUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("07d63881-42cf-4fa4-8db9-3351c5e07f6e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("4d57ed17-b1a4-4fd4-ae99-097486fe34bb"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("4d888760-d5fc-4e8e-be18-8427c3e21b58"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("44a2834d-66e3-4b31-8aac-afe141b2cad1"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("4f08b49b-ffc5-459b-bbc0-ef5fe25bb444"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "PermissionID", "PermissionName", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1ac4f79a-d2ef-4755-a4e1-23371c43841d"), "Update", "Admin" },
                    { new Guid("36631d84-9cff-478e-b0ff-8f272699b473"), "Delete", "Admin" },
                    { new Guid("d2eb49e4-3d0c-4c4f-8428-f6504ffea214"), "Edit", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductID", "Description", "Image", "Price", "ProductName" },
                values: new object[,]
                {
                    { new Guid("340ccd90-9cbe-4018-9a49-443e349661f7"), "Description", "Image", 50.049999999999997, "A Regular Table" },
                    { new Guid("eef1c3f4-3a1c-42a7-94cb-5a7dab4c78e8"), "Description a little bit different from above", "Irregular Image", 1.0069999999999999, "A Irregular Table" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Username",
                keyValue: "Admin",
                column: "Avatar",
                value: "./Images/Khalid.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("1ac4f79a-d2ef-4755-a4e1-23371c43841d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("36631d84-9cff-478e-b0ff-8f272699b473"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("d2eb49e4-3d0c-4c4f-8428-f6504ffea214"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("340ccd90-9cbe-4018-9a49-443e349661f7"));

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductID",
                keyValue: new Guid("eef1c3f4-3a1c-42a7-94cb-5a7dab4c78e8"));

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "users");

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "PermissionID", "PermissionName", "RoleName" },
                values: new object[,]
                {
                    { new Guid("07d63881-42cf-4fa4-8db9-3351c5e07f6e"), "Update", "Admin" },
                    { new Guid("4d57ed17-b1a4-4fd4-ae99-097486fe34bb"), "Delete", "Admin" },
                    { new Guid("4d888760-d5fc-4e8e-be18-8427c3e21b58"), "Edit", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductID", "Description", "Image", "Price", "ProductName" },
                values: new object[,]
                {
                    { new Guid("44a2834d-66e3-4b31-8aac-afe141b2cad1"), "Description", "Image", 50.049999999999997, "A Regular Table" },
                    { new Guid("4f08b49b-ffc5-459b-bbc0-ef5fe25bb444"), "Description a little bit different from above", "Irregular Image", 1.0069999999999999, "A Irregular Table" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Username",
                keyValue: "Admin",
                column: "Gender",
                value: true);
        }
    }
}
