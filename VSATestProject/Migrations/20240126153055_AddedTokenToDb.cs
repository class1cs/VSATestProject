using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATestProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedTokenToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("6bdf5037-c5f8-4292-8f27-9a034ba2c630"));

            migrationBuilder.AddColumn<string>(
                name: "JwtAuthorizationToken",
                table: "Accounts",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "JwtAuthorizationToken", "Login", "PasswordHash" },
                values: new object[] { new Guid("dd56fa68-0b06-4e36-91e7-4420902052fd"), "Administrator", "", "admin", "ISMvKXpXpadDiUoOSoAfww==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dd56fa68-0b06-4e36-91e7-4420902052fd"));

            migrationBuilder.DropColumn(
                name: "JwtAuthorizationToken",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "Login", "PasswordHash" },
                values: new object[] { new Guid("6bdf5037-c5f8-4292-8f27-9a034ba2c630"), "Administrator", "admin", "ISMvKXpXpadDiUoOSoAfww==" });
        }
    }
}
