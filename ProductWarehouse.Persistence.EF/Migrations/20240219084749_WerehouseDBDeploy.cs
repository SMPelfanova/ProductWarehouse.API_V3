using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseDBDeploy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketLines_Baskets_BasketId",
                table: "BasketLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketLines_Products_ProductId",
                table: "BasketLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketLines_Sizes_SizeId",
                table: "BasketLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Sizes_SizeId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines");

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("3dbc5af7-f015-437d-9731-dead1be11a1d"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("d6f201af-cf75-40d9-814a-1e0d17e9796c"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e8c25c64-44a8-4481-84fb-29718c37c6b4"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f5f4aa66-8cd9-4c7f-8669-5b7dcd64b402"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("0e596ec6-bc97-4e5d-9593-69387ac3cb03"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("cd95a5b4-efb0-4755-9379-73a81a3a2f9f"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("6ee5e273-82f0-40a0-aa0e-2f221a2588b0"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("a8ca1a90-32fe-49f7-8906-a45987a3d5db"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("10c96071-d5d0-4915-aba0-f52585132de4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("2aef86e1-2190-455a-890f-c19b276c97e1"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("7aee3527-c299-4c13-b907-ecaa57f9a655"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("da35ec2b-24e1-4652-ab48-7671b93b5edc"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("ea88c493-9e58-47c7-80cd-766ac89a7a01"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eb1bd4c7-0b80-40a9-a462-2b5a487bddfd"));

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "OrderLines",
                newName: "OrderLine");

            migrationBuilder.RenameTable(
                name: "Baskets",
                newName: "Basket");

            migrationBuilder.RenameTable(
                name: "BasketLines",
                newName: "BasketLine");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_SizeId",
                table: "OrderLine",
                newName: "IX_OrderLine_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLine",
                newName: "IX_OrderLine_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLine",
                newName: "IX_OrderLine_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_UserId",
                table: "Basket",
                newName: "IX_Basket_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketLines_SizeId",
                table: "BasketLine",
                newName: "IX_BasketLine_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketLines_ProductId",
                table: "BasketLine",
                newName: "IX_BasketLine_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketLines_BasketId",
                table: "BasketLine",
                newName: "IX_BasketLine_BasketId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                type: "Date",
                nullable: false,
                defaultValueSql: "decimal(18, 2)",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketLine",
                table: "BasketLine",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Users_UserId",
                table: "Basket",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLine_Basket_BasketId",
                table: "BasketLine",
                column: "BasketId",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLine_Products_ProductId",
                table: "BasketLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLine_Sizes_SizeId",
                table: "BasketLine",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Orders_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Products_ProductId",
                table: "OrderLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Sizes_SizeId",
                table: "OrderLine",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Users_UserId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketLine_Basket_BasketId",
                table: "BasketLine");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketLine_Products_ProductId",
                table: "BasketLine");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketLine_Sizes_SizeId",
                table: "BasketLine");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Orders_OrderId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Products_ProductId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Sizes_SizeId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketLine",
                table: "BasketLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

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

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                newName: "OrderLines");

            migrationBuilder.RenameTable(
                name: "BasketLine",
                newName: "BasketLines");

            migrationBuilder.RenameTable(
                name: "Basket",
                newName: "Baskets");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_SizeId",
                table: "OrderLines",
                newName: "IX_OrderLines_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_ProductId",
                table: "OrderLines",
                newName: "IX_OrderLines_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLines",
                newName: "IX_OrderLines_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketLine_SizeId",
                table: "BasketLines",
                newName: "IX_BasketLines_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketLine_ProductId",
                table: "BasketLines",
                newName: "IX_BasketLines_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketLine_BasketId",
                table: "BasketLines",
                newName: "IX_BasketLines_BasketId");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_UserId",
                table: "Baskets",
                newName: "IX_Baskets_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                type: "Date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValueSql: "decimal(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d6f201af-cf75-40d9-814a-1e0d17e9796c"), "Stella Nova" },
                    { new Guid("e8c25c64-44a8-4481-84fb-29718c37c6b4"), "Zara" },
                    { new Guid("f5f4aa66-8cd9-4c7f-8669-5b7dcd64b402"), "Bershka" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e596ec6-bc97-4e5d-9593-69387ac3cb03"), "Comfortable" },
                    { new Guid("cd95a5b4-efb0-4755-9379-73a81a3a2f9f"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6ee5e273-82f0-40a0-aa0e-2f221a2588b0"), "Pending" },
                    { new Guid("a8ca1a90-32fe-49f7-8906-a45987a3d5db"), "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10c96071-d5d0-4915-aba0-f52585132de4"), "L" },
                    { new Guid("2aef86e1-2190-455a-890f-c19b276c97e1"), "XS" },
                    { new Guid("7aee3527-c299-4c13-b907-ecaa57f9a655"), "XL" },
                    { new Guid("da35ec2b-24e1-4652-ab48-7671b93b5edc"), "M" },
                    { new Guid("ea88c493-9e58-47c7-80cd-766ac89a7a01"), "S" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("eb1bd4c7-0b80-40a9-a462-2b5a487bddfd"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("3dbc5af7-f015-437d-9731-dead1be11a1d"), new Guid("eb1bd4c7-0b80-40a9-a462-2b5a487bddfd") });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLines_Baskets_BasketId",
                table: "BasketLines",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLines_Products_ProductId",
                table: "BasketLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLines_Sizes_SizeId",
                table: "BasketLines",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Sizes_SizeId",
                table: "OrderLines",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
