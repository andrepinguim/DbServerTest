using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dbst.Transaction.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Agency = table.Column<string>(nullable: true),
                    Digit = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    FromAccountId = table.Column<int>(nullable: false),
                    ToAccountId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Agency", "Balance", "Digit", "Number" },
                values: new object[] { 1, "1234", 1000.0, "0", "012345" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Agency", "Balance", "Digit", "Number" },
                values: new object[] { 2, "4567", 2500.0, "1", "123456" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Agency", "Balance", "Digit", "Number" },
                values: new object[] { 3, "7890", 350.5, "2", "150000" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Created", "FromAccountId", "ToAccountId", "Value" },
                values: new object[] { 999, new DateTime(2020, 4, 15, 3, 48, 51, 634, DateTimeKind.Utc).AddTicks(5392), 1, 2, 100.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Number",
                table: "Accounts",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
