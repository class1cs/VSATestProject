using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATestProject.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPurchases_Books_BookId",
                table: "BookPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_BookPurchases_FinalPurchases_PurchaseId",
                table: "BookPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalPurchases_Accounts_UserId",
                table: "FinalPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinalPurchases",
                table: "FinalPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPurchases",
                table: "BookPurchases");

            migrationBuilder.RenameTable(
                name: "FinalPurchases",
                newName: "Purchases");

            migrationBuilder.RenameTable(
                name: "BookPurchases",
                newName: "BookProducts");

            migrationBuilder.RenameIndex(
                name: "IX_FinalPurchases_UserId",
                table: "Purchases",
                newName: "IX_Purchases_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookPurchases_PurchaseId",
                table: "BookProducts",
                newName: "IX_BookProducts_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_BookPurchases_BookId",
                table: "BookProducts",
                newName: "IX_BookProducts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookProducts",
                table: "BookProducts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Discriminator", "Login", "PasswordHash" },
                values: new object[] { new Guid("6bdf5037-c5f8-4292-8f27-9a034ba2c630"), "Administrator", "admin", "ISMvKXpXpadDiUoOSoAfww==" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookProducts_Books_BookId",
                table: "BookProducts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookProducts_Purchases_PurchaseId",
                table: "BookProducts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Accounts_UserId",
                table: "Purchases",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookProducts_Books_BookId",
                table: "BookProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BookProducts_Purchases_PurchaseId",
                table: "BookProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Accounts_UserId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookProducts",
                table: "BookProducts");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("6bdf5037-c5f8-4292-8f27-9a034ba2c630"));

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "FinalPurchases");

            migrationBuilder.RenameTable(
                name: "BookProducts",
                newName: "BookPurchases");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_UserId",
                table: "FinalPurchases",
                newName: "IX_FinalPurchases_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookProducts_PurchaseId",
                table: "BookPurchases",
                newName: "IX_BookPurchases_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_BookProducts_BookId",
                table: "BookPurchases",
                newName: "IX_BookPurchases_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinalPurchases",
                table: "FinalPurchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPurchases",
                table: "BookPurchases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPurchases_Books_BookId",
                table: "BookPurchases",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
