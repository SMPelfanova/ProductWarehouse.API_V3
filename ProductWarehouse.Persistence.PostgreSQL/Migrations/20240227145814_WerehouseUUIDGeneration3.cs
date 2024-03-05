using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductWarehouse.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class WerehouseUUIDGeneration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("240fa885-e110-4d36-928a-6b4f93722a58"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6296c5ca-a75d-4c91-a8fd-d467e38edb63"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8d5b008f-88ba-43b4-b80b-f06a38070713"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("bde0aee3-a170-459a-b268-a1d91be223fe"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("7fed3643-3638-4a45-b243-91be1de21203"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("ab95df5e-0fb6-4c9c-8a9e-d698b1e472a2"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("49cb8222-b017-4e12-a98d-7ed54d8f6be9"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("4b6368e9-513e-456b-b77f-2c77a8523744"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("6db3a4fa-52b2-4f1b-9ad1-73aeef39d135"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("094cb9fe-9dde-46cf-92af-6dfa7f4404b8"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("12f9dfa5-0dc4-4d29-986e-bf580d20d8a4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("5d260013-25c1-4d70-8b21-d29adb19a5e5"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("d0a626b7-43ff-419b-b7b3-649d71ca7e88"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("eedf3f54-529d-4de8-8a44-05689ecc9221"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95d931ad-7ac9-4d76-b29c-634324ece69c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sizes",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Role",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payments",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderStatus",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Groups",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Brands",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Baskets",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BasketLines",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("62262d18-7d45-4347-8994-d276fff745fa"), "Stella Nova" },
                    { new Guid("8c6f38a4-e069-4f45-8542-9a4637fa68e2"), "Zara" },
                    { new Guid("f4b9e0a7-c4b3-4689-a473-98667c13ddc1"), "Bershka" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c6d8c25e-2810-439c-960d-a34191d8f46c"), "Casual" },
                    { new Guid("d2fe068c-6f02-4ed5-b911-bb2692547310"), "Comfortable" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("39d5fe6d-a149-43df-96aa-a7700ae13fae"), "Delivered" },
                    { new Guid("552daa0a-66c1-46c6-b669-88e6cbf9758e"), "Initial" },
                    { new Guid("c663435d-eb64-4275-a0e0-7e07d2a12f9d"), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c61ac65-03b1-4342-98f8-515563d342b4"), "XL" },
                    { new Guid("6bec10ff-0fbd-4881-99f4-6acf188d2bea"), "L" },
                    { new Guid("6f75ae87-a517-4a3c-b625-900dbeb22582"), "S" },
                    { new Guid("dcee68c7-65c7-4870-9897-404581548128"), "XS" },
                    { new Guid("de75ba98-3197-485b-b9a8-40593d6bd5e3"), "M" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("b491e486-c1b1-44b8-9e83-6e226073d7f2"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("983ce5b2-2dcd-42de-b63c-2b7edac31ef0"), new Guid("b491e486-c1b1-44b8-9e83-6e226073d7f2") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("983ce5b2-2dcd-42de-b63c-2b7edac31ef0"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("62262d18-7d45-4347-8994-d276fff745fa"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8c6f38a4-e069-4f45-8542-9a4637fa68e2"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f4b9e0a7-c4b3-4689-a473-98667c13ddc1"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("c6d8c25e-2810-439c-960d-a34191d8f46c"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("d2fe068c-6f02-4ed5-b911-bb2692547310"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("39d5fe6d-a149-43df-96aa-a7700ae13fae"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("552daa0a-66c1-46c6-b669-88e6cbf9758e"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("c663435d-eb64-4275-a0e0-7e07d2a12f9d"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("2c61ac65-03b1-4342-98f8-515563d342b4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("6bec10ff-0fbd-4881-99f4-6acf188d2bea"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("6f75ae87-a517-4a3c-b625-900dbeb22582"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("dcee68c7-65c7-4870-9897-404581548128"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("de75ba98-3197-485b-b9a8-40593d6bd5e3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b491e486-c1b1-44b8-9e83-6e226073d7f2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sizes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Role",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Payments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderStatus",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Orders",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Groups",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Brands",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Baskets",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BasketLines",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6296c5ca-a75d-4c91-a8fd-d467e38edb63"), "Stella Nova" },
                    { new Guid("8d5b008f-88ba-43b4-b80b-f06a38070713"), "Zara" },
                    { new Guid("bde0aee3-a170-459a-b268-a1d91be223fe"), "Bershka" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7fed3643-3638-4a45-b243-91be1de21203"), "Comfortable" },
                    { new Guid("ab95df5e-0fb6-4c9c-8a9e-d698b1e472a2"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("49cb8222-b017-4e12-a98d-7ed54d8f6be9"), "Initial" },
                    { new Guid("4b6368e9-513e-456b-b77f-2c77a8523744"), "Pending" },
                    { new Guid("6db3a4fa-52b2-4f1b-9ad1-73aeef39d135"), "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("094cb9fe-9dde-46cf-92af-6dfa7f4404b8"), "S" },
                    { new Guid("12f9dfa5-0dc4-4d29-986e-bf580d20d8a4"), "XL" },
                    { new Guid("5d260013-25c1-4d70-8b21-d29adb19a5e5"), "M" },
                    { new Guid("d0a626b7-43ff-419b-b7b3-649d71ca7e88"), "XS" },
                    { new Guid("eedf3f54-529d-4de8-8a44-05689ecc9221"), "L" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("95d931ad-7ac9-4d76-b29c-634324ece69c"), "Street default", "test@email.com", "First", false, "Last", "asd", "0888888877" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("240fa885-e110-4d36-928a-6b4f93722a58"), new Guid("95d931ad-7ac9-4d76-b29c-634324ece69c") });
        }
    }
}
