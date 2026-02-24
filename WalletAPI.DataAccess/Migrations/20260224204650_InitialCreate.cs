using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BankType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Amount", "BankType", "Currency", "LastModified", "Type" },
                values: new object[,]
                {
                    { "1", 10m, 0, 0, new DateTime(2026, 2, 24, 20, 46, 50, 377, DateTimeKind.Utc).AddTicks(3770), 1 },
                    { "2", 20m, 0, 2, new DateTime(2026, 2, 24, 20, 46, 50, 377, DateTimeKind.Utc).AddTicks(3910), 2 },
                    { "3", 30m, 0, 1, new DateTime(2026, 2, 24, 20, 46, 50, 377, DateTimeKind.Utc).AddTicks(3910), 3 }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountId", "Amount", "LastModified", "TransactionType" },
                values: new object[,]
                {
                    { "0977f770-8c4f-4879-8415-45df8fc1e59e", "1", 1000m, new DateTime(2026, 2, 24, 20, 46, 50, 378, DateTimeKind.Utc).AddTicks(3080), 0 },
                    { "81cdd47d-cc12-470c-8cd2-b52610d6ca4c", "2", 100m, new DateTime(2026, 2, 24, 20, 46, 50, 378, DateTimeKind.Utc).AddTicks(3370), 1 },
                    { "de8282f3-a93b-4b80-85e1-b119d84291c3", "3", 500m, new DateTime(2026, 2, 24, 20, 46, 50, 378, DateTimeKind.Utc).AddTicks(3370), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
