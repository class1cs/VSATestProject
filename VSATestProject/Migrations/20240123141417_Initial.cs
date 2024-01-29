using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSATestProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalPurchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalPurchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPurchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    FinalPurchaseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPurchases_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPurchases_FinalPurchases_FinalPurchaseId",
                        column: x => x.FinalPurchaseId,
                        principalTable: "FinalPurchases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPurchases_BookId",
                table: "BookPurchases",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPurchases_FinalPurchaseId",
                table: "BookPurchases",
                column: "FinalPurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPurchases");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "FinalPurchases");
        }
    }
}
