using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 4, 2, 10, 46, 25, 228, DateTimeKind.Local).AddTicks(9712), new DateTime(2024, 4, 2, 10, 46, 25, 228, DateTimeKind.Local).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 4, 2, 10, 46, 25, 228, DateTimeKind.Local).AddTicks(9760), new DateTime(2024, 4, 2, 10, 46, 25, 228, DateTimeKind.Local).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 4, 2, 10, 46, 25, 228, DateTimeKind.Local).AddTicks(9766), new DateTime(2024, 4, 2, 10, 46, 25, 228, DateTimeKind.Local).AddTicks(9768) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 4, 2, 10, 41, 52, 612, DateTimeKind.Local).AddTicks(1874), new DateTime(2024, 4, 2, 10, 41, 52, 612, DateTimeKind.Local).AddTicks(1919) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 4, 2, 10, 41, 52, 612, DateTimeKind.Local).AddTicks(1925), new DateTime(2024, 4, 2, 10, 41, 52, 612, DateTimeKind.Local).AddTicks(1927) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 4, 2, 10, 41, 52, 612, DateTimeKind.Local).AddTicks(1930), new DateTime(2024, 4, 2, 10, 41, 52, 612, DateTimeKind.Local).AddTicks(1932) });
        }
    }
}
