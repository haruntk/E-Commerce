using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.API.Migrations.ECommerceAuthDb
{
    /// <inheritdoc />
    public partial class tiny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c74e7ece-7000-40b7-b81d-02902cf85dc1",
                column: "NormalizedName",
                value: "ADMIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c74e7ece-7000-40b7-b81d-02902cf85dc1",
                column: "NormalizedName",
                value: "ADMİN");
        }
    }
}
