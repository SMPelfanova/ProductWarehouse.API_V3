using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
	/// <inheritdoc />
	public partial class WerehouseDBOrderFixes : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_OrderLines",
				table: "OrderLines");

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

			migrationBuilder.AddColumn<Guid>(
				name: "Id",
				table: "OrderLines",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AlterColumn<int>(
				name: "Quantity",
				table: "BasketLines",
				type: "int",
				nullable: false,
				defaultValue: 1,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AddPrimaryKey(
				name: "PK_OrderLines",
				table: "OrderLines",
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

			migrationBuilder.CreateIndex(
				name: "IX_OrderLines_OrderId",
				table: "OrderLines",
				column: "OrderId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_OrderLines",
				table: "OrderLines");

			migrationBuilder.DropIndex(
				name: "IX_OrderLines_OrderId",
				table: "OrderLines");

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

			migrationBuilder.DropColumn(
				name: "Id",
				table: "OrderLines");

			migrationBuilder.AlterColumn<int>(
				name: "Quantity",
				table: "BasketLines",
				type: "int",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldDefaultValue: 1);

			migrationBuilder.AddPrimaryKey(
				name: "PK_OrderLines",
				table: "OrderLines",
				columns: new[] { "OrderId", "ProductId" });

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
		}
	}
}