using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseDBBasketLineId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_Userid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines");

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("2c875c7a-92c4-4351-84ce-12f7d236a750"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2354f91f-aedd-4fd6-873a-c21500bfd703"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("911432ad-8cd2-41c4-83de-aba031f80dd3"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b5043bc4-3a8a-484a-8cd1-bbaccbd2b4c4"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("e842a2c4-4be9-4789-a629-6e803bb1b174"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("e8b5303c-03d4-49e6-8962-4915e936f275"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("24cd384e-e246-4329-895a-8d8d93a21fb1"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("406b7f38-6106-483a-aa9f-376556b8e77e"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("2c97cdc8-7a51-4654-82ab-b5170a7a4db4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("48f35ede-aea6-43a3-ab85-e69394f9d830"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("592dc62b-5cc6-4a6c-8620-040ff58fd87f"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("84cf8364-e52f-4a56-8f45-ff32d07202ef"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("ea3ab478-3da6-463d-8134-20ed4a12d02b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a90db8b6-cc7c-498b-a6b5-90acafb5707b"));

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Userid",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BasketLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BasketLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BasketLines",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("600ab064-037a-4878-95f1-174ffd98e2a0"), "Zara" },
                    { new Guid("bb10adea-8aad-4f88-b845-f2d4aad24287"), "Bershka" },
                    { new Guid("eb2abbfc-7076-463f-a861-8bd84c4ddfcf"), "Stella Nova" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a0655f47-9bc2-496d-ae53-92ed46426e2e"), "Comfortable" },
                    { new Guid("cc458d23-fae6-4b7b-bfc5-399e272442c6"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("25927c33-8544-4469-a534-825aed574287"), "Delivered" },
                    { new Guid("57d6b036-7447-43b2-b17a-60f1727940d6"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0234522f-d731-4660-af41-27529d538755"), "M" },
                    { new Guid("2a5b8d45-bfcd-4ae7-b351-ac6658d2bbb4"), "XS" },
                    { new Guid("3bdef82d-0fc2-463e-b1b2-936ed9747765"), "S" },
                    { new Guid("98df775d-3366-4b4c-b0b2-f83c4bccb1b9"), "XL" },
                    { new Guid("c450d469-b8fd-470e-899f-6126458af965"), "L" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("96174bfc-383a-464b-ac51-ed81fd55842c"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("8384a2d4-9abd-4690-a329-f38191721846"), new Guid("96174bfc-383a-464b-ac51-ed81fd55842c") });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_ProductId",
                table: "BasketLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines");

            migrationBuilder.DropIndex(
                name: "IX_BasketLines_ProductId",
                table: "BasketLines");

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("8384a2d4-9abd-4690-a329-f38191721846"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("600ab064-037a-4878-95f1-174ffd98e2a0"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("bb10adea-8aad-4f88-b845-f2d4aad24287"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("eb2abbfc-7076-463f-a861-8bd84c4ddfcf"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("a0655f47-9bc2-496d-ae53-92ed46426e2e"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("cc458d23-fae6-4b7b-bfc5-399e272442c6"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("25927c33-8544-4469-a534-825aed574287"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("57d6b036-7447-43b2-b17a-60f1727940d6"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("0234522f-d731-4660-af41-27529d538755"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("2a5b8d45-bfcd-4ae7-b351-ac6658d2bbb4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("3bdef82d-0fc2-463e-b1b2-936ed9747765"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("98df775d-3366-4b4c-b0b2-f83c4bccb1b9"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("c450d469-b8fd-470e-899f-6126458af965"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96174bfc-383a-464b-ac51-ed81fd55842c"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BasketLines");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BasketLines");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_Userid");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BasketLines",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines",
                columns: new[] { "ProductId", "BasketId" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2354f91f-aedd-4fd6-873a-c21500bfd703"), "Zara" },
                    { new Guid("911432ad-8cd2-41c4-83de-aba031f80dd3"), "Bershka" },
                    { new Guid("b5043bc4-3a8a-484a-8cd1-bbaccbd2b4c4"), "Stella Nova" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e842a2c4-4be9-4789-a629-6e803bb1b174"), "Casual" },
                    { new Guid("e8b5303c-03d4-49e6-8962-4915e936f275"), "Comfortable" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24cd384e-e246-4329-895a-8d8d93a21fb1"), "Delivered" },
                    { new Guid("406b7f38-6106-483a-aa9f-376556b8e77e"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c97cdc8-7a51-4654-82ab-b5170a7a4db4"), "L" },
                    { new Guid("48f35ede-aea6-43a3-ab85-e69394f9d830"), "XL" },
                    { new Guid("592dc62b-5cc6-4a6c-8620-040ff58fd87f"), "XS" },
                    { new Guid("84cf8364-e52f-4a56-8f45-ff32d07202ef"), "M" },
                    { new Guid("ea3ab478-3da6-463d-8134-20ed4a12d02b"), "S" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("a90db8b6-cc7c-498b-a6b5-90acafb5707b"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("2c875c7a-92c4-4351-84ce-12f7d236a750"), new Guid("a90db8b6-cc7c-498b-a6b5-90acafb5707b") });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_Userid",
                table: "Orders",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
