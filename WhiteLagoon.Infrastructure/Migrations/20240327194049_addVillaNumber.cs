using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Villas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 111, null, 2 },
                    { 112, null, 2 },
                    { 201, null, 1 },
                    { 301, null, 3 },
                    { 302, null, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 27, 14, 40, 48, 76, DateTimeKind.Local).AddTicks(7719), new DateTime(2024, 3, 27, 14, 40, 48, 76, DateTimeKind.Local).AddTicks(7764) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 27, 14, 40, 48, 76, DateTimeKind.Local).AddTicks(7768), new DateTime(2024, 3, 27, 14, 40, 48, 76, DateTimeKind.Local).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 27, 14, 40, 48, 76, DateTimeKind.Local).AddTicks(7773), new DateTime(2024, 3, 27, 14, 40, 48, 76, DateTimeKind.Local).AddTicks(7774) });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3846), new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3893), new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3895) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3898), new DateTime(2024, 3, 26, 23, 59, 58, 371, DateTimeKind.Local).AddTicks(3900) });
        }
    }
}
