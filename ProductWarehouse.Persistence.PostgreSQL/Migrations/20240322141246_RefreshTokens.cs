using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Baskets",
            //    keyColumn: "Id",
            //    keyValue: new Guid("983ce5b2-2dcd-42de-b63c-2b7edac31ef0"));

            //migrationBuilder.DeleteData(
            //    table: "Brands",
            //    keyColumn: "Id",
            //    keyValue: new Guid("62262d18-7d45-4347-8994-d276fff745fa"));

            //migrationBuilder.DeleteData(
            //    table: "Brands",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8c6f38a4-e069-4f45-8542-9a4637fa68e2"));

            //migrationBuilder.DeleteData(
            //    table: "Brands",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f4b9e0a7-c4b3-4689-a473-98667c13ddc1"));

            //migrationBuilder.DeleteData(
            //    table: "Groups",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c6d8c25e-2810-439c-960d-a34191d8f46c"));

            //migrationBuilder.DeleteData(
            //    table: "Groups",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d2fe068c-6f02-4ed5-b911-bb2692547310"));

            //migrationBuilder.DeleteData(
            //    table: "OrderStatus",
            //    keyColumn: "Id",
            //    keyValue: new Guid("39d5fe6d-a149-43df-96aa-a7700ae13fae"));

            //migrationBuilder.DeleteData(
            //    table: "OrderStatus",
            //    keyColumn: "Id",
            //    keyValue: new Guid("552daa0a-66c1-46c6-b669-88e6cbf9758e"));

            //migrationBuilder.DeleteData(
            //    table: "OrderStatus",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c663435d-eb64-4275-a0e0-7e07d2a12f9d"));

            //migrationBuilder.DeleteData(
            //    table: "Sizes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("2c61ac65-03b1-4342-98f8-515563d342b4"));

            //migrationBuilder.DeleteData(
            //    table: "Sizes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6bec10ff-0fbd-4881-99f4-6acf188d2bea"));

            //migrationBuilder.DeleteData(
            //    table: "Sizes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6f75ae87-a517-4a3c-b625-900dbeb22582"));

            //migrationBuilder.DeleteData(
            //    table: "Sizes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dcee68c7-65c7-4870-9897-404581548128"));

            //migrationBuilder.DeleteData(
            //    table: "Sizes",
            //    keyColumn: "Id",
            //    keyValue: new Guid("de75ba98-3197-485b-b9a8-40593d6bd5e3"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b491e486-c1b1-44b8-9e83-6e226073d7f2"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiresAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "Brands",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("56700e76-c53d-451f-8245-df7d388db2a6"), "Stella Nova" },
            //        { new Guid("e2215a03-db68-40ce-b344-a3424e1a1303"), "Zara" },
            //        { new Guid("f8633ea5-1c40-4f0d-b8cb-eed3af6c1976"), "Bershka" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Groups",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("2ee73763-9557-4b79-8f93-a2e3feb7c0b2"), "Casual" },
            //        { new Guid("a0ac7b3c-553e-4074-8e08-c185689ff659"), "Comfortable" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "OrderStatus",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("286402b1-1fa3-43b5-ab03-2d96fdbb2d6d"), "Initial" },
            //        { new Guid("a76004a8-4c62-4a78-9e5e-a8a1df38a244"), "Pending" },
            //        { new Guid("c8614241-7d2c-4b84-97b9-13fa7934dc3a"), "Delivered" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Sizes",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("1552035a-040c-4815-994c-f77d3aa010b5"), "S" },
            //        { new Guid("356348fe-cafc-4ea0-b847-47f5bd72ebc0"), "L" },
            //        { new Guid("3cf92a33-5f53-4a72-83b2-d5d137f12ccc"), "XL" },
            //        { new Guid("5be7f765-0b6f-4142-89a2-a42af325d6fe"), "M" },
            //        { new Guid("6b748f83-62b8-4aa5-a590-f9f986dd544b"), "XS" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "RefreshToken", "RefreshTokenExpiresAt" },
            //    values: new object[] { new Guid("50eda43a-8be9-4eb2-af24-7c57f8d8ff18"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877", null, null });

            //migrationBuilder.InsertData(
            //    table: "Baskets",
            //    columns: new[] { "Id", "UserId" },
            //    values: new object[] { new Guid("e7a93749-a3da-429c-86aa-de0578c07c1a"), new Guid("50eda43a-8be9-4eb2-af24-7c57f8d8ff18") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("e7a93749-a3da-429c-86aa-de0578c07c1a"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("56700e76-c53d-451f-8245-df7d388db2a6"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e2215a03-db68-40ce-b344-a3424e1a1303"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f8633ea5-1c40-4f0d-b8cb-eed3af6c1976"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("2ee73763-9557-4b79-8f93-a2e3feb7c0b2"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("a0ac7b3c-553e-4074-8e08-c185689ff659"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("286402b1-1fa3-43b5-ab03-2d96fdbb2d6d"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("a76004a8-4c62-4a78-9e5e-a8a1df38a244"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("c8614241-7d2c-4b84-97b9-13fa7934dc3a"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("1552035a-040c-4815-994c-f77d3aa010b5"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("356348fe-cafc-4ea0-b847-47f5bd72ebc0"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("3cf92a33-5f53-4a72-83b2-d5d137f12ccc"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("5be7f765-0b6f-4142-89a2-a42af325d6fe"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("6b748f83-62b8-4aa5-a590-f9f986dd544b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50eda43a-8be9-4eb2-af24-7c57f8d8ff18"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiresAt",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("62262d18-7d45-4347-8994-d276fff745fa"), "Stella Nova" },
                    { new Guid("8c6f38a4-e069-4f45-8542-9a4637fa68e2"), "Zara" },
                    { new Guid("f4b9e0a7-c4b3-4689-a473-98667c13ddc1"), "Bershka" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c6d8c25e-2810-439c-960d-a34191d8f46c"), "Casual" },
                    { new Guid("d2fe068c-6f02-4ed5-b911-bb2692547310"), "Comfortable" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("39d5fe6d-a149-43df-96aa-a7700ae13fae"), "Delivered" },
                    { new Guid("552daa0a-66c1-46c6-b669-88e6cbf9758e"), "Initial" },
                    { new Guid("c663435d-eb64-4275-a0e0-7e07d2a12f9d"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c61ac65-03b1-4342-98f8-515563d342b4"), "XL" },
                    { new Guid("6bec10ff-0fbd-4881-99f4-6acf188d2bea"), "L" },
                    { new Guid("6f75ae87-a517-4a3c-b625-900dbeb22582"), "S" },
                    { new Guid("dcee68c7-65c7-4870-9897-404581548128"), "XS" },
                    { new Guid("de75ba98-3197-485b-b9a8-40593d6bd5e3"), "M" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("b491e486-c1b1-44b8-9e83-6e226073d7f2"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("983ce5b2-2dcd-42de-b63c-2b7edac31ef0"), new Guid("b491e486-c1b1-44b8-9e83-6e226073d7f2") });
        }
    }
}
