using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("15cd7b09-3f0e-4dd3-8fb4-72a7c00d7b3a"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("180009c3-9a02-47cc-8351-09c72c860be7"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("49352ad7-4aa5-4947-a1d5-13ec1f6e543e"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("5a718118-d8da-4006-80ab-a700ce694d57"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("8c76010f-4e2b-4b49-908e-51e413c6e530"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("9e15cd08-777d-46e1-b891-6c75a1b646ea"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("a75369ac-5456-4ca9-a9e0-32eb7f116118"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("b712fcc0-0039-413b-b00f-8b3245aa84d6"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("d52f9aa3-7ae4-462c-8282-8986aaf24fc1"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("f726a427-0d72-4a8f-bdf5-8f8feb23f007"));

            migrationBuilder.CreateTable(
                name: "UserCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    { new Guid("0f09b6fc-f8ab-4069-bd79-82805fe4b6ff"), 850m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Köksbord", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("1e5a26ec-99f3-41ce-be38-04266251a830"), 8500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Grafikkort", new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("3a36ac98-6f49-43b9-ae2d-c29c9e813b26"), 400m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Bredband", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("6b46680c-796e-4a7a-b9ac-fb66c53f4130"), 150m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Mjukisdjur", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("6da5f9ab-2ced-475a-8e7d-472e4446d4f3"), 180m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Spotify", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("7a8398b9-7afd-41ce-b454-e71a32000a6d"), 1500m, null, new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"), "Storhandla BBQ", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("bf1e0fef-8973-4ca6-a9b1-78ece8d8f424"), 750m, new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Film o Pizza kväll", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("c1d48360-2aef-44ca-8db7-ff87878aabb2"), 2500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Moderkort", new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("e72961eb-9e1a-4fe0-8b08-35de33ef07e8"), 500m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Lego", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("fad735b5-025e-43af-a05f-66e6bee46cfc"), 7000m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Soffa", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") }
                });

            migrationBuilder.InsertData(
                table: "UserCategories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"), "Nöje", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"), "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"), "Leksaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"), "Räkningar", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_UserId",
                table: "UserCategories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCategories");

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("0f09b6fc-f8ab-4069-bd79-82805fe4b6ff"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("1e5a26ec-99f3-41ce-be38-04266251a830"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("3a36ac98-6f49-43b9-ae2d-c29c9e813b26"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("6b46680c-796e-4a7a-b9ac-fb66c53f4130"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("6da5f9ab-2ced-475a-8e7d-472e4446d4f3"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("7a8398b9-7afd-41ce-b454-e71a32000a6d"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("bf1e0fef-8973-4ca6-a9b1-78ece8d8f424"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("c1d48360-2aef-44ca-8db7-ff87878aabb2"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("e72961eb-9e1a-4fe0-8b08-35de33ef07e8"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("fad735b5-025e-43af-a05f-66e6bee46cfc"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"), "Nöje", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"), "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"), "Leksaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"), "Räkningar", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") }
                });

            migrationBuilder.InsertData(
                table: "Debits",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[,]
                {
                    { new Guid("15cd7b09-3f0e-4dd3-8fb4-72a7c00d7b3a"), 750m, new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Film o Pizza kväll", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("180009c3-9a02-47cc-8351-09c72c860be7"), 150m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Mjukisdjur", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("49352ad7-4aa5-4947-a1d5-13ec1f6e543e"), 7000m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Soffa", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("5a718118-d8da-4006-80ab-a700ce694d57"), 850m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Köksbord", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("8c76010f-4e2b-4b49-908e-51e413c6e530"), 2500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Moderkort", new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("9e15cd08-777d-46e1-b891-6c75a1b646ea"), 500m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Lego", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("a75369ac-5456-4ca9-a9e0-32eb7f116118"), 180m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Spotify", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("b712fcc0-0039-413b-b00f-8b3245aa84d6"), 400m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Bredband", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("d52f9aa3-7ae4-462c-8282-8986aaf24fc1"), 1500m, null, new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"), "Storhandla BBQ", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("f726a427-0d72-4a8f-bdf5-8f8feb23f007"), 8500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Grafikkort", new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") }
                });
        }
    }
}
