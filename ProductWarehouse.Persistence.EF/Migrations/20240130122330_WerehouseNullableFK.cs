using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
	/// <inheritdoc />
	public partial class WerehouseNullableFK : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Payments_PaymentId",
				table: "Orders");

			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Users_Userid",
				table: "Orders");

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("3f31c3eb-19eb-49ad-b6bd-4336ca404a58"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("6b59cdc2-f178-48e3-bec6-b8dbdb6cf9f3"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("8454e24f-8dda-4be9-b6b9-ab03f94a4f39"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("50d7e6ea-f259-4222-93ab-400d5bee7de8"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("fb086129-98b8-4ef0-bebd-612dbdaf37b2"));

			migrationBuilder.DeleteData(
				table: "OrderStatus",
				keyColumn: "Id",
				keyValue: new Guid("0843b8ed-b929-401b-b41f-24e6c4099d35"));

			migrationBuilder.DeleteData(
				table: "OrderStatus",
				keyColumn: "Id",
				keyValue: new Guid("7e084488-6cb3-460b-8542-7225e2794d59"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("64161ff0-d23e-4275-9e87-42c84659acf0"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("7700abc9-25a4-4a89-a405-5e1c759301af"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("9b750f43-4710-4c09-b619-7fc0c371b2db"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("a6dc1b2b-ab3d-429d-b4ab-d02f12b20d2b"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("f4caab1a-06b2-4561-88d7-afac3072ca99"));

			migrationBuilder.AlterColumn<Guid>(
				name: "Userid",
				table: "Orders",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier");

			migrationBuilder.AlterColumn<Guid>(
				name: "PaymentId",
				table: "Orders",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier");

			migrationBuilder.InsertData(
				table: "Brands",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("1bbef41e-edbe-46e1-8647-438b36592b1b"), "Zara" },
					{ new Guid("32d7937e-d655-4f7f-896d-a6803ff89469"), "Bershka" },
					{ new Guid("b54374fd-d751-47e6-9046-ed3791b95b2e"), "Stella Nova" }
				});

			migrationBuilder.InsertData(
				table: "Groups",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("5e2d79ca-02e1-485b-a5c3-eb9410e668cb"), "Comfortable" },
					{ new Guid("cf229d36-f421-46db-b6b9-b4f118eb4e81"), "Casual" }
				});

			migrationBuilder.InsertData(
				table: "OrderStatus",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("07faf2a1-3b1c-4065-a49a-d587afa7b251"), "Delivered" },
					{ new Guid("fa2f6a50-b884-43d9-8d61-e11da958d5e7"), "Pending" }
				});

			migrationBuilder.InsertData(
				table: "Sizes",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("0b28d08c-b209-4436-a990-89d934f00eac"), "XS" },
					{ new Guid("57767a17-7abb-404b-aa7e-0512ba82c907"), "S" },
					{ new Guid("5d5a9f85-6edf-40d3-b5b3-4e6f69e4c2e1"), "M" },
					{ new Guid("d11dd3ed-3506-43df-81a4-bcc9cd3e639c"), "L" },
					{ new Guid("f4978666-30f8-4f3b-9205-3a7c76749800"), "XL" }
				});

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Payments_PaymentId",
				table: "Orders",
				column: "PaymentId",
				principalTable: "Payments",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Users_Userid",
				table: "Orders",
				column: "Userid",
				principalTable: "Users",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Payments_PaymentId",
				table: "Orders");

			migrationBuilder.DropForeignKey(
				name: "FK_Orders_Users_Userid",
				table: "Orders");

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("1bbef41e-edbe-46e1-8647-438b36592b1b"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("32d7937e-d655-4f7f-896d-a6803ff89469"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("b54374fd-d751-47e6-9046-ed3791b95b2e"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("5e2d79ca-02e1-485b-a5c3-eb9410e668cb"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("cf229d36-f421-46db-b6b9-b4f118eb4e81"));

			migrationBuilder.DeleteData(
				table: "OrderStatus",
				keyColumn: "Id",
				keyValue: new Guid("07faf2a1-3b1c-4065-a49a-d587afa7b251"));

			migrationBuilder.DeleteData(
				table: "OrderStatus",
				keyColumn: "Id",
				keyValue: new Guid("fa2f6a50-b884-43d9-8d61-e11da958d5e7"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("0b28d08c-b209-4436-a990-89d934f00eac"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("57767a17-7abb-404b-aa7e-0512ba82c907"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("5d5a9f85-6edf-40d3-b5b3-4e6f69e4c2e1"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("d11dd3ed-3506-43df-81a4-bcc9cd3e639c"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("f4978666-30f8-4f3b-9205-3a7c76749800"));

			migrationBuilder.AlterColumn<Guid>(
				name: "Userid",
				table: "Orders",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.AlterColumn<Guid>(
				name: "PaymentId",
				table: "Orders",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.InsertData(
				table: "Brands",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("3f31c3eb-19eb-49ad-b6bd-4336ca404a58"), "Zara" },
					{ new Guid("6b59cdc2-f178-48e3-bec6-b8dbdb6cf9f3"), "Bershka" },
					{ new Guid("8454e24f-8dda-4be9-b6b9-ab03f94a4f39"), "Stella Nova" }
				});

			migrationBuilder.InsertData(
				table: "Groups",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("50d7e6ea-f259-4222-93ab-400d5bee7de8"), "Casual" },
					{ new Guid("fb086129-98b8-4ef0-bebd-612dbdaf37b2"), "Comfortable" }
				});

			migrationBuilder.InsertData(
				table: "OrderStatus",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("0843b8ed-b929-401b-b41f-24e6c4099d35"), "Pending" },
					{ new Guid("7e084488-6cb3-460b-8542-7225e2794d59"), "Delivered" }
				});

			migrationBuilder.InsertData(
				table: "Sizes",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("64161ff0-d23e-4275-9e87-42c84659acf0"), "L" },
					{ new Guid("7700abc9-25a4-4a89-a405-5e1c759301af"), "S" },
					{ new Guid("9b750f43-4710-4c09-b619-7fc0c371b2db"), "M" },
					{ new Guid("a6dc1b2b-ab3d-429d-b4ab-d02f12b20d2b"), "XL" },
					{ new Guid("f4caab1a-06b2-4561-88d7-afac3072ca99"), "XS" }
				});

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Payments_PaymentId",
				table: "Orders",
				column: "PaymentId",
				principalTable: "Payments",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Orders_Users_Userid",
				table: "Orders",
				column: "Userid",
				principalTable: "Users",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}