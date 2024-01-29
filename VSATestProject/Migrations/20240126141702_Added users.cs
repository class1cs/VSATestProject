using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATestProject.Migrations
{
    /// <inheritdoc />
    public partial class Addedusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPurchases_FinalPurchases_FinalPurchaseId",
                table: "BookPurchases");

            migrationBuilder.RenameColumn(
                name: "FinalPurchaseId",
                table: "BookPurchases",
                newName: "PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_BookPurchases_FinalPurchaseId",
                table: "BookPurchases",
                newName: "IX_BookPurchases_PurchaseId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FinalPurchases",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalPurchases_UserId",
                table: "FinalPurchases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPurchases_FinalPurchases_PurchaseId",
                table: "BookPurchases",
                column: "PurchaseId",
                principalTable: "FinalPurchases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalPurchases_Accounts_UserId",
                table: "FinalPurchases",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPurchases_FinalPurchases_PurchaseId",
                table: "BookPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalPurchases_Accounts_UserId",
                table: "FinalPurchases");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_FinalPurchases_UserId",
                table: "FinalPurchases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FinalPurchases");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "BookPurchases",
                newName: "FinalPurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_BookPurchases_PurchaseId",
                table: "BookPurchases",
                newName: "IX_BookPurchases_FinalPurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPurchases_FinalPurchases_FinalPurchaseId",
                table: "BookPurchases",
                column: "FinalPurchaseId",
                principalTable: "FinalPurchases",
                principalColumn: "Id");
        }
    }
}
