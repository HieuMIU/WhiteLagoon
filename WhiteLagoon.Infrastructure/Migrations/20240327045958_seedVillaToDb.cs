using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Created_Date", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "Updated_Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3846), "Beautiful villa with ocean view", "https://example.com/image1.jpg", "Villa A", 8, 500000.0, 3000, new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3889) },
                    { 2, new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3893), "Cozy villa nestled in the mountains", "https://example.com/image2.jpg", "Villa B", 6, 400000.0, 2500, new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3895) },
                    { 3, new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3898), "Luxurious villa with private pool", "https://example.com/image3.jpg", "Villa C", 10, 800000.0, 4000, new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3900) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
