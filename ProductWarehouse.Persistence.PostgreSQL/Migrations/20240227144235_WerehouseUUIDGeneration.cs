using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseUUIDGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("8be53f04-cb10-46ff-a703-91737621e899"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("656b14b5-849b-4f18-b149-3391429960cb"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("9499fc71-2228-4a5f-9edf-77c945806cb5"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("a72c2afc-884a-4b8c-ad86-85b3f24c30f5"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("597b7de6-62a3-4fe2-969b-2ecd18b42892"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("6306dd20-9279-4715-932f-8baa92a10235"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("4ed37c1c-caeb-434b-8d76-8f1fcaf28c22"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("7da8cf0f-cd9d-49c7-9e86-69d74c0f42b7"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("aa1fce0b-076a-4f20-9e08-71e5d5fa7f73"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("248d56c5-0f13-4ef4-a259-bc6f951788a4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("25badb4e-f7f6-4486-bf58-cb99d57a13a0"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("9082a2cc-3235-4aed-89ac-c63d67203894"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("e12acf55-0f96-4316-98ad-5db8fd8b2cfe"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("e157eb9a-f8c0-4bbb-a1bc-5972e27031e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fd3d9f7-c171-4596-b332-fa0f65d0f057"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("656b14b5-849b-4f18-b149-3391429960cb"), "Stella Nova" },
                    { new Guid("9499fc71-2228-4a5f-9edf-77c945806cb5"), "Bershka" },
                    { new Guid("a72c2afc-884a-4b8c-ad86-85b3f24c30f5"), "Zara" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("597b7de6-62a3-4fe2-969b-2ecd18b42892"), "Comfortable" },
                    { new Guid("6306dd20-9279-4715-932f-8baa92a10235"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4ed37c1c-caeb-434b-8d76-8f1fcaf28c22"), "Pending" },
                    { new Guid("7da8cf0f-cd9d-49c7-9e86-69d74c0f42b7"), "Delivered" },
                    { new Guid("aa1fce0b-076a-4f20-9e08-71e5d5fa7f73"), "Initial" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("248d56c5-0f13-4ef4-a259-bc6f951788a4"), "S" },
                    { new Guid("25badb4e-f7f6-4486-bf58-cb99d57a13a0"), "XS" },
                    { new Guid("9082a2cc-3235-4aed-89ac-c63d67203894"), "L" },
                    { new Guid("e12acf55-0f96-4316-98ad-5db8fd8b2cfe"), "M" },
                    { new Guid("e157eb9a-f8c0-4bbb-a1bc-5972e27031e8"), "XL" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("1fd3d9f7-c171-4596-b332-fa0f65d0f057"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("8be53f04-cb10-46ff-a703-91737621e899"), new Guid("1fd3d9f7-c171-4596-b332-fa0f65d0f057") });
        }
    }
}
