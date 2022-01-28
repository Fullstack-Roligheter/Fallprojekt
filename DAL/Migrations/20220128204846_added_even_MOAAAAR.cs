using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_even_MOAAAAR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: 1,
                column: "MaxAmountMoney",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryMaxAmount",
                value: 1000m);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "BudgetId", "CategoryMaxAmount", "Name" },
                values: new object[] { 2, 1, 1500m, "Hem & Hushåll" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: 1,
                column: "MaxAmountMoney",
                value: 5000m);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryMaxAmount",
                value: 0m);
        }
    }
}
