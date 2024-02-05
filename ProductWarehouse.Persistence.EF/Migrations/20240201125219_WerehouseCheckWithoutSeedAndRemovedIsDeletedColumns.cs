using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseCheckWithoutSeedAndRemovedIsDeletedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("687ddee8-7c7f-4b45-8b4a-bb1c9d0b9825"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("df8a011a-9ee2-4be9-8839-e0417f28a4ca"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e817a652-089f-4b57-b660-b7945835b240"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("aa3e9ee8-1593-4179-a437-563f4aff36fd"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("bcad06c2-d57b-4993-affb-c09c0a3d1815"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("23e04c0b-15e5-491b-b8b9-fdf1bc4742a0"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("8d55d3bd-b286-4531-9fa8-1400db122e44"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("08f9c644-e67b-4cdb-82ca-ab4da1abe6f2"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("4390c6b6-018f-4617-b824-730bbe66b07e"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("aa7f8462-7936-4868-a927-537cb87789bc"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("d7171574-2fb4-4df6-a419-adb50f3d1df0"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("e87925be-f409-4c72-9778-206277062262"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("687ddee8-7c7f-4b45-8b4a-bb1c9d0b9825"), "Zara" },
                    { new Guid("df8a011a-9ee2-4be9-8839-e0417f28a4ca"), "Bershka" },
                    { new Guid("e817a652-089f-4b57-b660-b7945835b240"), "Stella Nova" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aa3e9ee8-1593-4179-a437-563f4aff36fd"), "Comfortable" },
                    { new Guid("bcad06c2-d57b-4993-affb-c09c0a3d1815"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("23e04c0b-15e5-491b-b8b9-fdf1bc4742a0"), "Pending" },
                    { new Guid("8d55d3bd-b286-4531-9fa8-1400db122e44"), "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08f9c644-e67b-4cdb-82ca-ab4da1abe6f2"), "S" },
                    { new Guid("4390c6b6-018f-4617-b824-730bbe66b07e"), "M" },
                    { new Guid("aa7f8462-7936-4868-a927-537cb87789bc"), "XL" },
                    { new Guid("d7171574-2fb4-4df6-a419-adb50f3d1df0"), "XS" },
                    { new Guid("e87925be-f409-4c72-9778-206277062262"), "L" }
                });
        }
    }
}
