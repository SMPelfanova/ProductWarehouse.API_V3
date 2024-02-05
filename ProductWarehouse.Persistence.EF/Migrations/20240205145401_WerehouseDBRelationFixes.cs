using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseDBRelationFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_Id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BasketLines");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserRoles",
                newName: "RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("64d0b670-0224-4a52-ba91-a50210e0f060"), "Bershka" },
                    { new Guid("cabb3b71-67d1-423d-97d1-24ad195e8f93"), "Zara" },
                    { new Guid("cc3ba321-cbfc-43a2-a63e-dd30b6f59d5a"), "Stella Nova" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("51945acd-123c-4ded-be93-1980493d8aab"), "Casual" },
                    { new Guid("ab42bf33-1860-418a-aa0f-4656abf962eb"), "Comfortable" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("066ebde3-ed9f-409f-9e3a-a6d565af31de"), "Delivered" },
                    { new Guid("3f88493d-c546-4e63-8d27-5a90a608f800"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("40b7d31a-1ce7-4194-b485-59484ada6472"), "XL" },
                    { new Guid("6a6a8330-b769-401e-8d7d-6e68c5ca30ff"), "S" },
                    { new Guid("6ee74602-7b69-400c-8d01-5a48267a3fa2"), "L" },
                    { new Guid("784f031d-f568-4725-89cc-612ef01c92ca"), "XS" },
                    { new Guid("a463beb0-547f-4440-b1be-7110525c862d"), "M" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("64d0b670-0224-4a52-ba91-a50210e0f060"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("cabb3b71-67d1-423d-97d1-24ad195e8f93"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("cc3ba321-cbfc-43a2-a63e-dd30b6f59d5a"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("51945acd-123c-4ded-be93-1980493d8aab"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("ab42bf33-1860-418a-aa0f-4656abf962eb"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("066ebde3-ed9f-409f-9e3a-a6d565af31de"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("3f88493d-c546-4e63-8d27-5a90a608f800"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("40b7d31a-1ce7-4194-b485-59484ada6472"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("6a6a8330-b769-401e-8d7d-6e68c5ca30ff"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("6ee74602-7b69-400c-8d01-5a48267a3fa2"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("784f031d-f568-4725-89cc-612ef01c92ca"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("a463beb0-547f-4440-b1be-7110525c862d"));

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoles",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserRoles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BasketLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_Id",
                table: "Users",
                column: "Id",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
