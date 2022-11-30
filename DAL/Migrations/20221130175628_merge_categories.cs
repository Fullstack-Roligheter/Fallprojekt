using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class merge_categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Savingplans_Users_UserId",
                table: "Savingplans");

            migrationBuilder.DropTable(
                name: "UserCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Savingplans",
                table: "Savingplans");

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("1fefd8b4-64b6-46d8-9396-1c2a51d15f85"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("26842a1b-3585-4fdb-b1f2-7c363a667435"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("2f4543fe-9d93-40b5-a01c-8128e1e9a051"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("379e752c-46e6-47ec-9a5d-346258ccc8f2"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("4124cc4a-63c6-4d44-bc47-73d680e739cd"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("444c6cdd-c2ab-4d35-a4a4-018ce8e4ebf6"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("9d4c1326-5f52-4cfb-81d0-29247854516c"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("a16e4528-c9c9-48e6-9e11-3141e2e97142"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("d77e1ec4-8aee-4abe-902c-2537052e6e32"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("e06441d9-b58c-4161-91cd-bc2a96a9bca9"));

            migrationBuilder.RenameTable(
                name: "Savingplans",
                newName: "SavingPlans");

            migrationBuilder.RenameIndex(
                name: "IX_Savingplans_UserId",
                table: "SavingPlans",
                newName: "IX_SavingPlans_UserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingPlans",
                table: "SavingPlans",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"),
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d6b57f2-aa20-4956-9a01-fb06b26e4221"),
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                column: "IsDefault",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c6e05044-60e3-4759-9aa1-91e0e09c1dbf"),
                column: "IsDefault",
                value: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDefault", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0dddc255-e362-4b71-8177-14a9df9e5373"), false, "Husköp", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("1ce05fc8-29b2-4ce6-af6c-5eee53bfd3a5"), false, "Hundleksaker", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"), false, "Bilar", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"), false, "Flygresor", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"), false, "Leksaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("c229efe0-45cd-46bb-ab96-d9de8588ea0f"), false, "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"), false, "Kryssningar", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("efbf7bb5-ac81-4bf2-a5cd-3e66c2171186"), false, "Papegojfoder", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") }
                });

            migrationBuilder.InsertData(
                table: "Debits",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[,]
                {
                    { new Guid("0793358f-cd6e-4a9b-927e-aafb197ba4bd"), 500m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Lego", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("0c338f2e-aa4d-4452-b0a6-e6ee1885fd72"), 180m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Spotify", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("3c9ac640-a27b-4dbf-bb43-990fdc907814"), 750m, new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Film o Pizza kväll", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("636f4e88-3e85-48ed-86eb-cfcf59806f0f"), 150m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Mjukisdjur", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("8df9e81a-10fe-4ffd-8654-7b98c18ee264"), 850m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Köksbord", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("a26c3bc9-5e5a-4289-9b57-f2d7df547471"), 2500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Moderkort", new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("b464725d-c07a-4105-993b-9e64b592bdc9"), 1500m, null, new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"), "Storhandla BBQ", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("cfa1dbab-5b3f-4da9-a9b4-74b12c0e2837"), 7000m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Soffa", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("d3b3c9fe-067c-4576-8d17-913589cddf8e"), 400m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Bredband", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("f39291eb-9e21-43fa-b422-33c54fe460f9"), 8500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Grafikkort", new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SavingPlans_Users_UserId",
                table: "SavingPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingPlans_Users_UserId",
                table: "SavingPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingPlans",
                table: "SavingPlans");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0dddc255-e362-4b71-8177-14a9df9e5373"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1ce05fc8-29b2-4ce6-af6c-5eee53bfd3a5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c229efe0-45cd-46bb-ab96-d9de8588ea0f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("efbf7bb5-ac81-4bf2-a5cd-3e66c2171186"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("0793358f-cd6e-4a9b-927e-aafb197ba4bd"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("0c338f2e-aa4d-4452-b0a6-e6ee1885fd72"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("3c9ac640-a27b-4dbf-bb43-990fdc907814"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("636f4e88-3e85-48ed-86eb-cfcf59806f0f"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("8df9e81a-10fe-4ffd-8654-7b98c18ee264"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("a26c3bc9-5e5a-4289-9b57-f2d7df547471"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("b464725d-c07a-4105-993b-9e64b592bdc9"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("cfa1dbab-5b3f-4da9-a9b4-74b12c0e2837"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("d3b3c9fe-067c-4576-8d17-913589cddf8e"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("f39291eb-9e21-43fa-b422-33c54fe460f9"));

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "SavingPlans",
                newName: "Savingplans");

            migrationBuilder.RenameIndex(
                name: "IX_SavingPlans_UserId",
                table: "Savingplans",
                newName: "IX_Savingplans_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Savingplans",
                table: "Savingplans",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Debits",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[,]
                {
                    { new Guid("1fefd8b4-64b6-46d8-9396-1c2a51d15f85"), 8500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Grafikkort", new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("26842a1b-3585-4fdb-b1f2-7c363a667435"), 750m, new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Film o Pizza kväll", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("2f4543fe-9d93-40b5-a01c-8128e1e9a051"), 400m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Bredband", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("379e752c-46e6-47ec-9a5d-346258ccc8f2"), 180m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Spotify", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("4124cc4a-63c6-4d44-bc47-73d680e739cd"), 2500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Moderkort", new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("444c6cdd-c2ab-4d35-a4a4-018ce8e4ebf6"), 500m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Lego", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("9d4c1326-5f52-4cfb-81d0-29247854516c"), 7000m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Soffa", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("a16e4528-c9c9-48e6-9e11-3141e2e97142"), 1500m, null, new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"), "Storhandla BBQ", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("d77e1ec4-8aee-4abe-902c-2537052e6e32"), 850m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Köksbord", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("e06441d9-b58c-4161-91cd-bc2a96a9bca9"), 150m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Mjukisdjur", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") }
                });

            migrationBuilder.InsertData(
                table: "UserCategories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0dddc255-e362-4b71-8177-14a9df9e5373"), "Husköp", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("1ce05fc8-29b2-4ce6-af6c-5eee53bfd3a5"), "Hundleksaker", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"), "Bilar", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"), "Flygresor", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"), "Leksaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("c229efe0-45cd-46bb-ab96-d9de8588ea0f"), "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"), "Kryssningar", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("efbf7bb5-ac81-4bf2-a5cd-3e66c2171186"), "Papegojfoder", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_UserId",
                table: "UserCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Savingplans_Users_UserId",
                table: "Savingplans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
