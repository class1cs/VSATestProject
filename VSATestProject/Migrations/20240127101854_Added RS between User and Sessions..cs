using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATestProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedRSbetweenUserandSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("dd56fa68-0b06-4e36-91e7-4420902052fd"));

            migrationBuilder.DropColumn(
                name: "JwtAuthorizationToken",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "Login", "PasswordHash" },
                values: new object[] { new Guid("87d41237-d0e1-4cf7-a60c-cebc17272fa2"), "Administrator", "admin", "ISMvKXpXpadDiUoOSoAfww==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_AccountId",
                table: "UserSessions",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("87d41237-d0e1-4cf7-a60c-cebc17272fa2"));

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
    }
}
