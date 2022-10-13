using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"),
                column: "Name",
                value: "Bilar");

            migrationBuilder.UpdateData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Flygresor", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") });

            migrationBuilder.UpdateData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"),
                column: "Name",
                value: "Kryssningar");

            migrationBuilder.InsertData(
                table: "UserCategories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0dddc255-e362-4b71-8177-14a9df9e5373"), "Husköp", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("1ce05fc8-29b2-4ce6-af6c-5eee53bfd3a5"), "Hundleksaker", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("c229efe0-45cd-46bb-ab96-d9de8588ea0f"), "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("efbf7bb5-ac81-4bf2-a5cd-3e66c2171186"), "Papegojfoder", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("0dddc255-e362-4b71-8177-14a9df9e5373"));

            migrationBuilder.DeleteData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("1ce05fc8-29b2-4ce6-af6c-5eee53bfd3a5"));

            migrationBuilder.DeleteData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("c229efe0-45cd-46bb-ab96-d9de8588ea0f"));

            migrationBuilder.DeleteData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("efbf7bb5-ac81-4bf2-a5cd-3e66c2171186"));

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

            migrationBuilder.UpdateData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"),
                column: "Name",
                value: "Nöje");

            migrationBuilder.UpdateData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") });

            migrationBuilder.UpdateData(
                table: "UserCategories",
                keyColumn: "Id",
                keyValue: new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"),
                column: "Name",
                value: "Räkningar");
        }
    }
}
