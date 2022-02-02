using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_UserId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Expense");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryRefId",
                table: "Expense",
                column: "CategoryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserRefId",
                table: "Expense",
                column: "UserRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_CategoryRefId",
                table: "Expense",
                column: "CategoryRefId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_User_UserRefId",
                table: "Expense",
                column: "UserRefId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_CategoryRefId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserRefId",
                table: "Expense");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Expense_CategoryRefId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_UserRefId",
                table: "Expense");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Expense",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserId",
                table: "Expense",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_User_UserId",
                table: "Expense",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
