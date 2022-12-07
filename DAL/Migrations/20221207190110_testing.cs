using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories");

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

            migrationBuilder.InsertData(
                table: "Debits",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[,]
                {
                    { new Guid("1d1923f8-3cdf-4f8b-88f8-379110974182"), 750m, new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"), null, "Film o Pizza kväll", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("5f73e748-5401-4058-bc6d-e489b963a5c4"), 850m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), null, "Ny Köksbord", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("6e98adac-870a-4093-abea-a0ac5bb97738"), 180m, null, null, "Spotify", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("7a54d9a4-a0d2-4d15-9b9a-4437809af6a2"), 1500m, null, null, "Storhandla BBQ", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("ad58ca61-dea4-4535-8d60-6bd434a97a96"), 2500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), null, "Ny Moderkort", new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("d4ab2bc1-812e-4af1-98b8-28785f308442"), 7000m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), null, "Ny Soffa", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("d75f1dca-e8f2-476d-8c27-78c439393bc5"), 8500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), null, "Ny Grafikkort", new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("dd958a6e-98f1-4d1b-8096-7a4d99046f20"), 400m, null, null, "Bredband", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("e9de5e9f-9843-4e7f-a798-86af15c5e349"), 500m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), null, "Lego", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("ec20c991-9caf-4be6-ba41-77f00c1ba025"), 150m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), null, "Mjukisdjur", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("1d1923f8-3cdf-4f8b-88f8-379110974182"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("5f73e748-5401-4058-bc6d-e489b963a5c4"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("6e98adac-870a-4093-abea-a0ac5bb97738"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("7a54d9a4-a0d2-4d15-9b9a-4437809af6a2"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("ad58ca61-dea4-4535-8d60-6bd434a97a96"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("d4ab2bc1-812e-4af1-98b8-28785f308442"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("d75f1dca-e8f2-476d-8c27-78c439393bc5"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("dd958a6e-98f1-4d1b-8096-7a4d99046f20"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("e9de5e9f-9843-4e7f-a798-86af15c5e349"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("ec20c991-9caf-4be6-ba41-77f00c1ba025"));

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
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
