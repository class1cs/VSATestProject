using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATestProject.Migrations
{
    /// <inheritdoc />
    public partial class Addedbalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("87d41237-d0e1-4cf7-a60c-cebc17272fa2"));

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Accounts",
                type: "numeric",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "Login", "PasswordHash" },
                values: new object[] { new Guid("02e78a08-aab2-43d8-baf9-0e4a68b0af09"), "Administrator", "admin", "ISMvKXpXpadDiUoOSoAfww==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("02e78a08-aab2-43d8-baf9-0e4a68b0af09"));

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "Login", "PasswordHash" },
                values: new object[] { new Guid("87d41237-d0e1-4cf7-a60c-cebc17272fa2"), "Administrator", "admin", "ISMvKXpXpadDiUoOSoAfww==" });
        }
    }
}
