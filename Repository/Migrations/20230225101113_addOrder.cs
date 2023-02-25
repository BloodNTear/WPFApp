using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail");

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("5c2b4735-569a-4eab-922c-336d55f90a56"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("5e221809-a833-4515-a553-01075cc3fd7c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "PermissionID",
                keyValue: new Guid("d91355c3-62ff-43ef-85df-5e7604ce73e3"));

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail");

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
                name: "UserName",
                table: "orders");

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "PermissionID", "PermissionName", "RoleName" },
                values: new object[,]
                {
                    { new Guid("5c2b4735-569a-4eab-922c-336d55f90a56"), "Delete", "Admin" },
                    { new Guid("5e221809-a833-4515-a553-01075cc3fd7c"), "Edit", "Admin" },
                    { new Guid("d91355c3-62ff-43ef-85df-5e7604ce73e3"), "Update", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");
        }
    }
}
