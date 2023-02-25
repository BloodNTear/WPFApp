using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "permissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_permissions_RoleName",
                table: "permissions",
                column: "RoleName");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_roles_RoleName",
                table: "permissions",
                column: "RoleName",
                principalTable: "roles",
                principalColumn: "RoleName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_roles_RoleName",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_permissions_RoleName",
                table: "permissions");

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

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "permissions");
        }
    }
}
