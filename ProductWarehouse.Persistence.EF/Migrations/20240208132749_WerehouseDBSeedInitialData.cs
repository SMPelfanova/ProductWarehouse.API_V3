using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.EF.Migrations
{
	/// <inheritdoc />
	public partial class WerehouseDBSeedInitialData : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
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
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
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
	}
}