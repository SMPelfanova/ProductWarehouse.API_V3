using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
	/// <inheritdoc />
	public partial class WerehouseDBEntityConfig : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("9e13aa2e-3bd9-4dfd-a662-6e099f3a7576"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("b38443d8-43c5-4414-8dac-0821f4d8db90"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("f4e88d85-c977-48c9-b1e0-d55bd3fc2874"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("0b994204-8a5b-4785-9eb6-8560e4d13e7a"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("8e776e21-5caa-4090-996f-a3742d907335"));

			migrationBuilder.DeleteData(
				table: "OrderStatus",
				keyColumn: "Id",
				keyValue: new Guid("222107cf-cc40-4f57-a608-2f4c81ce90d6"));

			migrationBuilder.DeleteData(
				table: "OrderStatus",
				keyColumn: "Id",
				keyValue: new Guid("96ba97df-a309-48c4-8ba6-2cf067706f20"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("1bf2a301-78f5-4254-bb69-ccbba46ec9db"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("3df94d0b-225f-4c92-808b-2e300f43b6dc"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("4cc0f471-fcd1-4586-bcda-24a2ebfdf6fb"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("d4e81e65-ece4-4dd5-bfa1-e083c64b4117"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("f9c0a320-9359-4559-8037-1d602faa3af1"));

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Users");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Sizes");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Roles");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Payments");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "OrderStatus");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Orders");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Groups");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Brands");

			migrationBuilder.DropColumn(
				name: "AssociateId",
				table: "Baskets");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Users",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Sizes",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Roles",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Products",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Payments",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "OrderStatus",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Orders",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Groups",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Brands",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Baskets",
				type: "Date",
				nullable: false,
				defaultValueSql: "GetDate()",
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.InsertData(
				table: "Brands",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("83db5644-d1e2-44cb-8def-9c59a6a43498"), "Bershka" },
					{ new Guid("aa49e975-8160-4e65-b0ff-93d9ed8a9891"), "Zara" },
					{ new Guid("b74d1a65-c18a-4703-9946-ede7edada82c"), "Stella Nova" }
				});

			migrationBuilder.InsertData(
				table: "Groups",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("0a6ae99d-40d8-4ad3-9771-12c9a04ac621"), "Comfortable" },
					{ new Guid("482ca165-22c2-4d10-854a-0aae13ebad60"), "Casual" }
				});

			migrationBuilder.InsertData(
				table: "Sizes",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ new Guid("24e3d3df-2a54-4d50-8fc3-46a55cdc4064"), "M" },
					{ new Guid("9b15417d-ff3d-4d85-8cb6-0e0c854f22b7"), "L" },
					{ new Guid("bf587050-bfc0-4c95-8625-238c27f56a3d"), "XS" },
					{ new Guid("f2da654d-4cd6-4cf9-a267-10bb8e676d25"), "S" },
					{ new Guid("f7e44ca1-13d0-4418-b3f9-2a909308dfb7"), "XL" }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("83db5644-d1e2-44cb-8def-9c59a6a43498"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("aa49e975-8160-4e65-b0ff-93d9ed8a9891"));

			migrationBuilder.DeleteData(
				table: "Brands",
				keyColumn: "Id",
				keyValue: new Guid("b74d1a65-c18a-4703-9946-ede7edada82c"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("0a6ae99d-40d8-4ad3-9771-12c9a04ac621"));

			migrationBuilder.DeleteData(
				table: "Groups",
				keyColumn: "Id",
				keyValue: new Guid("482ca165-22c2-4d10-854a-0aae13ebad60"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("24e3d3df-2a54-4d50-8fc3-46a55cdc4064"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("9b15417d-ff3d-4d85-8cb6-0e0c854f22b7"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("bf587050-bfc0-4c95-8625-238c27f56a3d"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("f2da654d-4cd6-4cf9-a267-10bb8e676d25"));

			migrationBuilder.DeleteData(
				table: "Sizes",
				keyColumn: "Id",
				keyValue: new Guid("f7e44ca1-13d0-4418-b3f9-2a909308dfb7"));

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Users",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Users",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Sizes",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Sizes",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Roles",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Roles",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Products",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Products",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Payments",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Payments",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "OrderStatus",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "OrderStatus",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Orders",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Orders",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Groups",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Groups",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Brands",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Brands",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AlterColumn<DateTime>(
				name: "CreatedAt",
				table: "Baskets",
				type: "datetime2",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "Date",
				oldDefaultValueSql: "GetDate()");

			migrationBuilder.AddColumn<long>(
				name: "AssociateId",
				table: "Baskets",
				type: "bigint",
				nullable: false,
				defaultValue: 0L)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.InsertData(
				table: "Brands",
				columns: new[] { "Id", "CreatedAt", "Name" },
				values: new object[,]
				{
					{ new Guid("9e13aa2e-3bd9-4dfd-a662-6e099f3a7576"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara" },
					{ new Guid("b38443d8-43c5-4414-8dac-0821f4d8db90"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stella Nova" },
					{ new Guid("f4e88d85-c977-48c9-b1e0-d55bd3fc2874"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bershka" }
				});

			migrationBuilder.InsertData(
				table: "Groups",
				columns: new[] { "Id", "CreatedAt", "Name" },
				values: new object[,]
				{
					{ new Guid("0b994204-8a5b-4785-9eb6-8560e4d13e7a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable" },
					{ new Guid("8e776e21-5caa-4090-996f-a3742d907335"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Casual" }
				});

			migrationBuilder.InsertData(
				table: "OrderStatus",
				columns: new[] { "Id", "CreatedAt", "Name" },
				values: new object[,]
				{
					{ new Guid("222107cf-cc40-4f57-a608-2f4c81ce90d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
					{ new Guid("96ba97df-a309-48c4-8ba6-2cf067706f20"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" }
				});

			migrationBuilder.InsertData(
				table: "Sizes",
				columns: new[] { "Id", "CreatedAt", "Name" },
				values: new object[,]
				{
					{ new Guid("1bf2a301-78f5-4254-bb69-ccbba46ec9db"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L" },
					{ new Guid("3df94d0b-225f-4c92-808b-2e300f43b6dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XL" },
					{ new Guid("4cc0f471-fcd1-4586-bcda-24a2ebfdf6fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "S" },
					{ new Guid("d4e81e65-ece4-4dd5-bfa1-e083c64b4117"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M" },
					{ new Guid("f9c0a320-9359-4559-8037-1d602faa3af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XS" }
				});
		}
	}
}