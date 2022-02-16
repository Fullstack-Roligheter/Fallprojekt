using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_moar_seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetEndDate", "BudgetMaxAmountMoney", "BudgetName", "BudgetStartDate", "UserId" },
                values: new object[] { 2, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Vår 2022", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetEndDate", "BudgetMaxAmountMoney", "BudgetName", "BudgetStartDate", "UserId" },
                values: new object[] { 3, new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Sommar 2022", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetEndDate", "BudgetMaxAmountMoney", "BudgetName", "BudgetStartDate", "UserId" },
                values: new object[] { 4, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Default", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "BudgetId", "CategoryMaxAmount", "CategoryName" },
                values: new object[,]
                {
                    { 3, 2, 1500m, "Home Stuff Vår 2022" },
                    { 4, 2, 1500m, "Other Stuff Vår 2022" },
                    { 5, 3, 1500m, "Home Stuff Sommar 2022" },
                    { 6, 3, 1500m, "Other Stuff Sommar 2022" },
                    { 7, 4, 1000m, "Default" }
                });

            migrationBuilder.InsertData(
                table: "Expense",
                columns: new[] { "ExpenseId", "CategoryId", "ExpenseAmount", "ExpenseComment", "ExpenseDate", "ExpenseRecipient" },
                values: new object[,]
                {
                    { 3, 3, 250m, null, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vår HOME ICA 2022" },
                    { 4, 3, 250m, null, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vår HOME IKEA 2022" },
                    { 5, 4, 250m, null, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vår OTHER Hemköp 2022" },
                    { 6, 4, 250m, null, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vår OTHER ICA 2022" },
                    { 7, 5, 250m, null, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sommar HOME ICA 2022" },
                    { 8, 5, 250m, null, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sommar HOME IKEA 2022" },
                    { 9, 6, 250m, null, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sommar OTHER Hemköp 2022" },
                    { 10, 6, 250m, null, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sommar OTHER ICA 2022" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Expense",
                keyColumn: "ExpenseId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: 3);
        }
    }
}
