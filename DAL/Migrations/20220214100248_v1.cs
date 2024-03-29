﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAge = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    BudgetEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    BudgetMaxAmountMoney = table.Column<decimal>(type: "money", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budgets_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryMaxAmount = table.Column<decimal>(type: "money", nullable: false),
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseRecipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseAmount = table.Column<decimal>(type: "money", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpenseComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expense_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "UserAge", "UserEmail", "UserName", "UserPassword" },
                values: new object[] { 1, 20, "adam_01@hotmail.com", "adam", "123" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "UserAge", "UserEmail", "UserName", "UserPassword" },
                values: new object[] { 2, 30, "berit_02@msn.com", "berit", "123" });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "BudgetEndDate", "BudgetMaxAmountMoney", "BudgetName", "BudgetStartDate", "UserId" },
                values: new object[] { 1, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, "Default", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "BudgetId", "CategoryMaxAmount", "CategoryName" },
                values: new object[] { 1, 1, 1000m, "Default" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "BudgetId", "CategoryMaxAmount", "CategoryName" },
                values: new object[] { 2, 1, 1500m, "Hem & Hushåll" });

            migrationBuilder.InsertData(
                table: "Expense",
                columns: new[] { "ExpenseId", "CategoryId", "ExpenseAmount", "ExpenseComment", "ExpenseDate", "ExpenseRecipient" },
                values: new object[] { 1, 1, 500m, null, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ICA" });

            migrationBuilder.InsertData(
                table: "Expense",
                columns: new[] { "ExpenseId", "CategoryId", "ExpenseAmount", "ExpenseComment", "ExpenseDate", "ExpenseRecipient" },
                values: new object[] { 2, 1, 250m, null, new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hemköp" });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_BudgetId",
                table: "Category",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryId",
                table: "Expense",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
