using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATestProject.Migrations
{
    /// <inheritdoc />
    public partial class Addedcascadedelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Accounts_AccountId",
                table: "UserSessions");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("02e78a08-aab2-43d8-baf9-0e4a68b0af09"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "UserSessions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "Login", "PasswordHash" },
                values: new object[] { new Guid("44d6884f-bb9a-4309-b2f5-38c9231909df"), "Administrator", "admin", "ISMvKXpXpadDiUoOSoAfww==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Accounts_AccountId",
                table: "UserSessions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Accounts_AccountId",
                table: "UserSessions");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("44d6884f-bb9a-4309-b2f5-38c9231909df"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "UserSessions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "Login", "PasswordHash" },
                values: new object[] { new Guid("02e78a08-aab2-43d8-baf9-0e4a68b0af09"), "Administrator", "admin", "ISMvKXpXpadDiUoOSoAfww==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Accounts_AccountId",
                table: "UserSessions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
