using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseDBDeploy3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("3197fece-ecc4-4db3-9cb2-dea1a16a4b6f"), "Zara" },
                    { new Guid("b0d567a9-8648-4cc2-98ce-8938bac49ee4"), "Bershka" },
                    { new Guid("f6e4baab-2ad4-474e-9c78-84140fe0b88d"), "Stella Nova" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("254a7e0b-88fa-4d17-8c33-9e31a152521d"), "Casual" },
                    { new Guid("e44f63fa-ee64-4de0-80af-b2a3754894ab"), "Comfortable" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("22fb68fa-0224-454d-9442-a51a12e289af"), "Pending" },
                    { new Guid("3810d28a-bf6e-4732-b655-3fb43e4565f5"), "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b9b5079-9319-49c1-a04e-54397d1b3d6f"), "XS" },
                    { new Guid("2b692993-2542-4329-b5a8-98e0926687b3"), "XL" },
                    { new Guid("339638a2-ae03-4efe-8207-150f38f124d1"), "S" },
                    { new Guid("8d2d879d-6464-4919-9ebe-27e4a2955b52"), "L" },
                    { new Guid("9ea49eef-4987-4578-ae8d-801bb1ed33f0"), "M" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("9576d43e-a65a-4ecb-b576-988f70aa8d46"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("f6bc2b1e-c221-42c7-9d7b-da1520994ef3"), new Guid("9576d43e-a65a-4ecb-b576-988f70aa8d46") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Basket",
                keyColumn: "Id",
                keyValue: new Guid("f6bc2b1e-c221-42c7-9d7b-da1520994ef3"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3197fece-ecc4-4db3-9cb2-dea1a16a4b6f"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b0d567a9-8648-4cc2-98ce-8938bac49ee4"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f6e4baab-2ad4-474e-9c78-84140fe0b88d"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("254a7e0b-88fa-4d17-8c33-9e31a152521d"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("e44f63fa-ee64-4de0-80af-b2a3754894ab"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("22fb68fa-0224-454d-9442-a51a12e289af"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("3810d28a-bf6e-4732-b655-3fb43e4565f5"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("1b9b5079-9319-49c1-a04e-54397d1b3d6f"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("2b692993-2542-4329-b5a8-98e0926687b3"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("339638a2-ae03-4efe-8207-150f38f124d1"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("8d2d879d-6464-4919-9ebe-27e4a2955b52"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("9ea49eef-4987-4578-ae8d-801bb1ed33f0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9576d43e-a65a-4ecb-b576-988f70aa8d46"));

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
    }
}
