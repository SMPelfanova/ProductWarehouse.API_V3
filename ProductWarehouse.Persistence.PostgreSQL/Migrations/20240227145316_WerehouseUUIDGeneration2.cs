using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseUUIDGeneration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("2c769bc2-b2a5-4525-964b-6b7c9dc2604f"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("186a0f6f-a5f5-42b7-a1ee-f22799d29626"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("29527ab5-5136-4761-9d27-f8c459819c50"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c74d468d-2b87-4733-b5f5-be79f34cd68a"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("66b6bb23-df67-46b1-bbe4-352121ee4940"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("f7b8956c-11d8-402b-bcbb-0a1aa8bbb213"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("18082ebf-cce4-4701-83a6-bafb8e5fbcfe"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("28cfcd84-ec1e-480e-a864-2a4bf56657bd"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("bccc4969-3fb1-447f-a8d0-da17fda76210"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("686f70c6-2bdf-4c60-8e98-7ac838a8ede1"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("6f4d3b1e-ab02-4efa-886f-1b03c03e298e"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("9b2d68d5-06f8-4ff2-9406-73a1647227ed"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("9cd63124-a950-4c79-96b8-2d4bfca36046"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("da37cfb8-5caf-4c4a-839e-8088afc5947f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("df23f7d7-f563-40f0-a8fe-d0320d9eb1b6"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6296c5ca-a75d-4c91-a8fd-d467e38edb63"), "Stella Nova" },
                    { new Guid("8d5b008f-88ba-43b4-b80b-f06a38070713"), "Zara" },
                    { new Guid("bde0aee3-a170-459a-b268-a1d91be223fe"), "Bershka" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7fed3643-3638-4a45-b243-91be1de21203"), "Comfortable" },
                    { new Guid("ab95df5e-0fb6-4c9c-8a9e-d698b1e472a2"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("49cb8222-b017-4e12-a98d-7ed54d8f6be9"), "Initial" },
                    { new Guid("4b6368e9-513e-456b-b77f-2c77a8523744"), "Pending" },
                    { new Guid("6db3a4fa-52b2-4f1b-9ad1-73aeef39d135"), "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("094cb9fe-9dde-46cf-92af-6dfa7f4404b8"), "S" },
                    { new Guid("12f9dfa5-0dc4-4d29-986e-bf580d20d8a4"), "XL" },
                    { new Guid("5d260013-25c1-4d70-8b21-d29adb19a5e5"), "M" },
                    { new Guid("d0a626b7-43ff-419b-b7b3-649d71ca7e88"), "XS" },
                    { new Guid("eedf3f54-529d-4de8-8a44-05689ecc9221"), "L" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("95d931ad-7ac9-4d76-b29c-634324ece69c"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("240fa885-e110-4d36-928a-6b4f93722a58"), new Guid("95d931ad-7ac9-4d76-b29c-634324ece69c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("240fa885-e110-4d36-928a-6b4f93722a58"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6296c5ca-a75d-4c91-a8fd-d467e38edb63"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8d5b008f-88ba-43b4-b80b-f06a38070713"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("bde0aee3-a170-459a-b268-a1d91be223fe"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("7fed3643-3638-4a45-b243-91be1de21203"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("ab95df5e-0fb6-4c9c-8a9e-d698b1e472a2"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("49cb8222-b017-4e12-a98d-7ed54d8f6be9"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("4b6368e9-513e-456b-b77f-2c77a8523744"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("6db3a4fa-52b2-4f1b-9ad1-73aeef39d135"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("094cb9fe-9dde-46cf-92af-6dfa7f4404b8"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("12f9dfa5-0dc4-4d29-986e-bf580d20d8a4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("5d260013-25c1-4d70-8b21-d29adb19a5e5"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("d0a626b7-43ff-419b-b7b3-649d71ca7e88"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("eedf3f54-529d-4de8-8a44-05689ecc9221"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95d931ad-7ac9-4d76-b29c-634324ece69c"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("186a0f6f-a5f5-42b7-a1ee-f22799d29626"), "Zara" },
                    { new Guid("29527ab5-5136-4761-9d27-f8c459819c50"), "Bershka" },
                    { new Guid("c74d468d-2b87-4733-b5f5-be79f34cd68a"), "Stella Nova" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("66b6bb23-df67-46b1-bbe4-352121ee4940"), "Casual" },
                    { new Guid("f7b8956c-11d8-402b-bcbb-0a1aa8bbb213"), "Comfortable" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18082ebf-cce4-4701-83a6-bafb8e5fbcfe"), "Delivered" },
                    { new Guid("28cfcd84-ec1e-480e-a864-2a4bf56657bd"), "Initial" },
                    { new Guid("bccc4969-3fb1-447f-a8d0-da17fda76210"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("686f70c6-2bdf-4c60-8e98-7ac838a8ede1"), "L" },
                    { new Guid("6f4d3b1e-ab02-4efa-886f-1b03c03e298e"), "S" },
                    { new Guid("9b2d68d5-06f8-4ff2-9406-73a1647227ed"), "XS" },
                    { new Guid("9cd63124-a950-4c79-96b8-2d4bfca36046"), "M" },
                    { new Guid("da37cfb8-5caf-4c4a-839e-8088afc5947f"), "XL" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("df23f7d7-f563-40f0-a8fe-d0320d9eb1b6"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("2c769bc2-b2a5-4525-964b-6b7c9dc2604f"), new Guid("df23f7d7-f563-40f0-a8fe-d0320d9eb1b6") });
        }
    }
}
