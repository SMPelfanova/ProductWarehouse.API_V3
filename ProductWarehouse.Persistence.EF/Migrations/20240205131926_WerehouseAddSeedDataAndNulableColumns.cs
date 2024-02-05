using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseAddSeedDataAndNulableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductSizes");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2f77702d-6e45-4410-bbf4-b4391c6eedf5"), "Bershka" },
                    { new Guid("941b7ad4-018d-4c57-9c39-f56bf6e7705e"), "Stella Nova" },
                    { new Guid("ae9a0433-d14e-4afb-a426-8ac9d4dec43b"), "Zara" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2de8ef85-45d6-4853-8b46-34a55bb9ed5e"), "Casual" },
                    { new Guid("496ca0ac-0933-4d20-9a02-7c50af5fc946"), "Comfortable" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("102e2835-f81b-4451-a0ef-10c8d93c3dcb"), "Pending" },
                    { new Guid("c95a1488-b79e-421c-94df-b93bc232e153"), "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0663c983-db43-4848-89d1-4289cc0bbb16"), "XS" },
                    { new Guid("56005af8-3ae8-4f2b-9f76-e961166773e1"), "S" },
                    { new Guid("87f8aa05-d90e-4bf1-bf32-54372968e052"), "L" },
                    { new Guid("c761edf7-9d6e-4117-ae7c-082ed7ff05de"), "M" },
                    { new Guid("ddf505ac-9535-41fd-a66a-3eb421ad0694"), "XL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2f77702d-6e45-4410-bbf4-b4391c6eedf5"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("941b7ad4-018d-4c57-9c39-f56bf6e7705e"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("ae9a0433-d14e-4afb-a426-8ac9d4dec43b"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("2de8ef85-45d6-4853-8b46-34a55bb9ed5e"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("496ca0ac-0933-4d20-9a02-7c50af5fc946"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("102e2835-f81b-4451-a0ef-10c8d93c3dcb"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("c95a1488-b79e-421c-94df-b93bc232e153"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("0663c983-db43-4848-89d1-4289cc0bbb16"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("56005af8-3ae8-4f2b-9f76-e961166773e1"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("87f8aa05-d90e-4bf1-bf32-54372968e052"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("c761edf7-9d6e-4117-ae7c-082ed7ff05de"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("ddf505ac-9535-41fd-a66a-3eb421ad0694"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductSizes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
