using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("0109e12c-8f41-47f9-9b6d-816e8b8cca28"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("05b7512c-2ae6-476e-8f34-cd69202256fd"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("0d73fd40-5a7e-4294-82fc-fdce085d4b46"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("13eb23c9-e888-4aaf-a5c7-8df3ef64eec4"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("1aa988b1-98eb-43ca-a52a-12052b8a769d"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("92a98b1e-ce78-45e7-b9a6-889152be1044"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("9c43ecbf-7627-435a-9108-58fd5a85aa86"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("ae3fc37c-8ccb-4291-8f26-91110afa9e9c"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("bcc5657f-8ca7-4f90-bf13-3d6c9cf245af"));

            migrationBuilder.DeleteData(
                table: "Debits",
                keyColumn: "Id",
                keyValue: new Guid("d0f7aa59-3111-49f2-8747-b57d44dda0a9"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"),
                column: "Name",
                value: "Mat");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Hushåll", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Boende", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Transport", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"), "Nöje", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"), "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"), "Leksaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("5d6b57f2-aa20-4956-9a01-fb06b26e4221"), "Sparande", null },
                    { new Guid("c6e05044-60e3-4759-9aa1-91e0e09c1dbf"), "Övrigt", null },
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("5d6b57f2-aa20-4956-9a01-fb06b26e4221"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c6e05044-60e3-4759-9aa1-91e0e09c1dbf"));

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                column: "UserId",
                value: new Guid("720892b1-b076-49ec-8ec2-88b73040b351"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"),
                column: "Name",
                value: "Default");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Hemsaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Räkningar", new Guid("720892b1-b076-49ec-8ec2-88b73040b351") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                columns: new[] { "Name", "UserId" },
                values: new object[] { "Leksaker", new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") });

            migrationBuilder.InsertData(
                table: "Debits",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "Comment", "Date", "UserId" },
                values: new object[,]
                {
                    { new Guid("0109e12c-8f41-47f9-9b6d-816e8b8cca28"), 8500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Grafikkort", new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("05b7512c-2ae6-476e-8f34-cd69202256fd"), 7000m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Soffa", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("0d73fd40-5a7e-4294-82fc-fdce085d4b46"), 180m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Spotify", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("13eb23c9-e888-4aaf-a5c7-8df3ef64eec4"), 750m, new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Film o Pizza kväll", new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("1aa988b1-98eb-43ca-a52a-12052b8a769d"), 2500m, new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"), new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"), "Ny Moderkort", new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("92a98b1e-ce78-45e7-b9a6-889152be1044"), 1500m, null, new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"), "Storhandla BBQ", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("9c43ecbf-7627-435a-9108-58fd5a85aa86"), 400m, null, new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"), "Bredband", new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("720892b1-b076-49ec-8ec2-88b73040b351") },
                    { new Guid("ae3fc37c-8ccb-4291-8f26-91110afa9e9c"), 500m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Lego", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("bcc5657f-8ca7-4f90-bf13-3d6c9cf245af"), 850m, new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"), new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"), "Ny Köksbord", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") },
                    { new Guid("d0f7aa59-3111-49f2-8747-b57d44dda0a9"), 150m, new Guid("d96f9337-0b84-4a79-9977-d27125420898"), new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"), "Mjukisdjur", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1") }
                });
        }
    }
}
