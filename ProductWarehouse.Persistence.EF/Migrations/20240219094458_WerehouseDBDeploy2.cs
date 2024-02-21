using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseDBDeploy2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Basket",
                keyColumn: "Id",
                keyValue: new Guid("9ded1da9-4ad3-44af-8192-40fdecf9ff29"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("014d1da2-5dac-4620-936f-6fddaaa53bdd"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("465776d8-f3cb-4af5-b40e-a8f8ae2df4dc"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("64e35c94-facf-4b65-af8e-6e1a8f86f515"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("23b1f647-6051-417e-9878-0c3261e8e27b"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("35316bda-6956-41b8-9b89-b9df1506e9cd"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("03097b8d-2d8c-454f-b716-d5558cffa4b4"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("12616c46-2f71-4b14-b8db-48ce8a2b67cb"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("4b80794b-39bd-4bf5-9792-5c21c151a062"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("4c0a66b6-bd04-4b6d-8ea3-df94ad3f8168"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("70608050-b26f-4cea-af7b-e62ae041132d"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("7aec896d-d614-4e17-83cd-db0f48031f0c"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("7e480876-7569-4cbd-a747-ffffdf004d38"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fb76807b-3ef2-4800-952d-ff8d5396eaea"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("373f3efe-5fba-42fd-aef0-2f67771fca2b"), "Bershka" },
                    { new Guid("56116541-d10b-4327-bf20-eed57f811132"), "Zara" },
                    { new Guid("7bec32ae-ab30-4ea5-a9dd-1b65f6aa7bca"), "Stella Nova" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("980777b2-61c6-48ab-87aa-6a610c911202"), "Comfortable" },
                    { new Guid("b01ab1b2-fd93-43d3-893d-f7d8e62b1a89"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d347001-677b-420a-8c04-c96c88aa150f"), "Pending" },
                    { new Guid("994175c9-9741-4c4a-b0ac-347ddd1ca9f2"), "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05f8e093-92b0-44ad-a2a1-5c8b9319f63d"), "L" },
                    { new Guid("27f929be-38b3-458a-a6dc-5141e5c589d2"), "XL" },
                    { new Guid("5d3d7546-169c-4dec-8525-52647b5a7093"), "M" },
                    { new Guid("70b7f6cd-47cc-4577-a600-561e09ab373b"), "XS" },
                    { new Guid("75bb28be-7f64-4d5c-b88c-bd0ea3396511"), "S" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("9fcc51d1-f10e-44ec-b587-0e81c21cd4cb"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("9ea1903f-0a9e-409b-a50f-adaa0c27c493"), new Guid("9fcc51d1-f10e-44ec-b587-0e81c21cd4cb") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Basket",
                keyColumn: "Id",
                keyValue: new Guid("9ea1903f-0a9e-409b-a50f-adaa0c27c493"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("373f3efe-5fba-42fd-aef0-2f67771fca2b"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("56116541-d10b-4327-bf20-eed57f811132"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7bec32ae-ab30-4ea5-a9dd-1b65f6aa7bca"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("980777b2-61c6-48ab-87aa-6a610c911202"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("b01ab1b2-fd93-43d3-893d-f7d8e62b1a89"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("1d347001-677b-420a-8c04-c96c88aa150f"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("994175c9-9741-4c4a-b0ac-347ddd1ca9f2"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("05f8e093-92b0-44ad-a2a1-5c8b9319f63d"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("27f929be-38b3-458a-a6dc-5141e5c589d2"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("5d3d7546-169c-4dec-8525-52647b5a7093"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("70b7f6cd-47cc-4577-a600-561e09ab373b"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("75bb28be-7f64-4d5c-b88c-bd0ea3396511"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9fcc51d1-f10e-44ec-b587-0e81c21cd4cb"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("014d1da2-5dac-4620-936f-6fddaaa53bdd"), "Stella Nova" },
                    { new Guid("465776d8-f3cb-4af5-b40e-a8f8ae2df4dc"), "Zara" },
                    { new Guid("64e35c94-facf-4b65-af8e-6e1a8f86f515"), "Bershka" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("23b1f647-6051-417e-9878-0c3261e8e27b"), "Comfortable" },
                    { new Guid("35316bda-6956-41b8-9b89-b9df1506e9cd"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03097b8d-2d8c-454f-b716-d5558cffa4b4"), "Delivered" },
                    { new Guid("12616c46-2f71-4b14-b8db-48ce8a2b67cb"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4b80794b-39bd-4bf5-9792-5c21c151a062"), "XL" },
                    { new Guid("4c0a66b6-bd04-4b6d-8ea3-df94ad3f8168"), "S" },
                    { new Guid("70608050-b26f-4cea-af7b-e62ae041132d"), "M" },
                    { new Guid("7aec896d-d614-4e17-83cd-db0f48031f0c"), "XS" },
                    { new Guid("7e480876-7569-4cbd-a747-ffffdf004d38"), "L" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("fb76807b-3ef2-4800-952d-ff8d5396eaea"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("9ded1da9-4ad3-44af-8192-40fdecf9ff29"), new Guid("fb76807b-3ef2-4800-952d-ff8d5396eaea") });
        }
    }
}
