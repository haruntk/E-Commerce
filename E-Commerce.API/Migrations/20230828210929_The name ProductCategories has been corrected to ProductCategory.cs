using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.API.Migrations
{
    /// <inheritdoc />
    public partial class ThenameProductCategorieshasbeencorrectedtoProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "ProductCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("02407c5a-6d82-4871-a0d0-3caef0788b6f"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("15a31c0c-90dc-4644-9937-b141cd1f6a40"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("16f5c4a1-37ec-415b-8f04-e04901bed64c"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("1ac24ac7-2cd0-4938-bab7-2ecde095c376"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2031fdc5-1993-48af-a725-7e4800156646"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("24785e18-a10e-4f03-9b6f-8a2a1e4b3db2"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("2480f729-a5f9-49ad-893a-46c16297d842"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("267100eb-4130-4ca7-b9d4-91c09de46b89"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("3dc85019-1a68-44d8-8b57-d05bd3b9b209"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("4ae2f6d8-1501-462e-a496-b1fec213fa95"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("6055b824-7292-4a19-a406-d5e78927a80f"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("8bc18ea6-d216-4ceb-9928-a75190a21246"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("c703843d-0a13-4a7b-b4d8-ed5563c0436b"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("ca98e177-383f-4617-877b-b88d34a60805"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("d64723a7-7e2a-4404-a1df-f6a15d2752cd"),
                column: "IsMain",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("dae8721c-8b4f-4e4c-bec5-0ec5e299ab4f"),
                column: "IsMain",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "ProductCategories");
        }
    }
}
