using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedBankType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "1",
                column: "BankType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "2",
                column: "BankType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "3",
                column: "BankType",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "1",
                column: "BankType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "2",
                column: "BankType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: "3",
                column: "BankType",
                value: 0);
        }
    }
}
