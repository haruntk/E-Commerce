using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforProductCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("02407c5a-6d82-4871-a0d0-3caef0788b6f"), new Guid("df12a7fc-670c-4220-9f4a-6e93993eee26"), new Guid("b38db405-80fa-4347-9359-bfc513e578a8") },
                    { new Guid("15a31c0c-90dc-4644-9937-b141cd1f6a40"), new Guid("28dcc80f-fad6-472b-ad40-4e1ddb175612"), new Guid("34f6f251-0b70-4535-89f6-6c8cead48531") },
                    { new Guid("16f5c4a1-37ec-415b-8f04-e04901bed64c"), new Guid("28dcc80f-fad6-472b-ad40-4e1ddb175612"), new Guid("4bd9f24d-8f1c-4124-8b63-3a13196199b0") },
                    { new Guid("1ac24ac7-2cd0-4938-bab7-2ecde095c376"), new Guid("914ef09e-b3aa-4e3f-8b2c-fb08cb5d7da7"), new Guid("1cf2a3da-ee1c-426a-a97a-8cd603768771") },
                    { new Guid("2031fdc5-1993-48af-a725-7e4800156646"), new Guid("f7521b70-9b2d-41f1-88d6-6b3ac1d1e085"), new Guid("ca451dc9-13b7-4f80-9122-576183146c3e") },
                    { new Guid("24785e18-a10e-4f03-9b6f-8a2a1e4b3db2"), new Guid("69bf082d-ed81-47fa-8d48-bf2f0ffa90c5"), new Guid("1d31b89e-5456-4476-b3e0-a6d25ce795ed") },
                    { new Guid("2480f729-a5f9-49ad-893a-46c16297d842"), new Guid("8b51ee91-c293-4e05-8d8b-9fbef15adae4"), new Guid("34f6f251-0b70-4535-89f6-6c8cead48531") },
                    { new Guid("267100eb-4130-4ca7-b9d4-91c09de46b89"), new Guid("914ef09e-b3aa-4e3f-8b2c-fb08cb5d7da7"), new Guid("1cf2a3da-ee1c-426a-a97a-8cd603768771") },
                    { new Guid("3dc85019-1a68-44d8-8b57-d05bd3b9b209"), new Guid("914ef09e-b3aa-4e3f-8b2c-fb08cb5d7da7"), new Guid("88431346-6e71-4c97-b2e9-b06761230f33") },
                    { new Guid("4ae2f6d8-1501-462e-a496-b1fec213fa95"), new Guid("8b51ee91-c293-4e05-8d8b-9fbef15adae4"), new Guid("4bd9f24d-8f1c-4124-8b63-3a13196199b0") },
                    { new Guid("6055b824-7292-4a19-a406-d5e78927a80f"), new Guid("ebb74345-cb5c-4248-ad6e-7c4466129db1"), new Guid("6160bde1-34ea-4680-b8bc-62a960aeb15c") },
                    { new Guid("8bc18ea6-d216-4ceb-9928-a75190a21246"), new Guid("914ef09e-b3aa-4e3f-8b2c-fb08cb5d7da7"), new Guid("88431346-6e71-4c97-b2e9-b06761230f33") },
                    { new Guid("c703843d-0a13-4a7b-b4d8-ed5563c0436b"), new Guid("69bf082d-ed81-47fa-8d48-bf2f0ffa90c5"), new Guid("1d31b89e-5456-4476-b3e0-a6d25ce795ed") },
                    { new Guid("ca98e177-383f-4617-877b-b88d34a60805"), new Guid("a7cb98f0-cff6-4d74-a1d5-184033271c18"), new Guid("6160bde1-34ea-4680-b8bc-62a960aeb15c") },
                    { new Guid("d64723a7-7e2a-4404-a1df-f6a15d2752cd"), new Guid("df12a7fc-670c-4220-9f4a-6e93993eee26"), new Guid("ca451dc9-13b7-4f80-9122-576183146c3e") },
                    { new Guid("dae8721c-8b4f-4e4c-bec5-0ec5e299ab4f"), new Guid("2bbd6301-a90f-4dc5-b02f-58be57be4f17"), new Guid("266a9fd0-b089-4230-ac51-4560f83f58e5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("02407c5a-6d82-4871-a0d0-3caef0788b6f"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("15a31c0c-90dc-4644-9937-b141cd1f6a40"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("16f5c4a1-37ec-415b-8f04-e04901bed64c"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("1ac24ac7-2cd0-4938-bab7-2ecde095c376"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2031fdc5-1993-48af-a725-7e4800156646"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("24785e18-a10e-4f03-9b6f-8a2a1e4b3db2"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2480f729-a5f9-49ad-893a-46c16297d842"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("267100eb-4130-4ca7-b9d4-91c09de46b89"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("3dc85019-1a68-44d8-8b57-d05bd3b9b209"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("4ae2f6d8-1501-462e-a496-b1fec213fa95"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("6055b824-7292-4a19-a406-d5e78927a80f"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("8bc18ea6-d216-4ceb-9928-a75190a21246"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("c703843d-0a13-4a7b-b4d8-ed5563c0436b"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("ca98e177-383f-4617-877b-b88d34a60805"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("d64723a7-7e2a-4404-a1df-f6a15d2752cd"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("dae8721c-8b4f-4e4c-bec5-0ec5e299ab4f"));
        }
    }
}
