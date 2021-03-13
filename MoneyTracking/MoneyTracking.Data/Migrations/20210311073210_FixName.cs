using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyTracking.Data.Migrations
{
    public partial class FixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Spend",
                table: "Transactions",
                newName: "Spent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Spent",
                table: "Transactions",
                newName: "Spend");
        }
    }
}
