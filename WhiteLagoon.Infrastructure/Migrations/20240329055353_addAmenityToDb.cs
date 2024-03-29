using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAmenityToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "Free", "Swimming Pool", 1 },
                    { 2, "Membership", "Gym/Fitness Center", 1 },
                    { 3, "Need Reserve", "Playground", 1 },
                    { 4, "Free", "Tennis Court", 1 },
                    { 5, "VIP", "Spa", 2 },
                    { 6, "Free", "Sauna", 2 },
                    { 7, "Need reserve", "BBQ Area", 2 },
                    { 8, "Sessonal", "Movie Theater", 2 },
                    { 9, "Only Spring", "Community Garden", 3 },
                    { 10, "Free", "Yoga Studio", 3 },
                    { 11, "Free", "Billiards Room", 3 },
                    { 12, "Open from 9AM-8PM", "Library", 3 },
                    { 13, "Free", "Volleyball Court", 3 },
                    { 14, "Free", "Basketball Court", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 29, 0, 53, 51, 414, DateTimeKind.Local).AddTicks(4423), new DateTime(2024, 3, 29, 0, 53, 51, 414, DateTimeKind.Local).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 29, 0, 53, 51, 414, DateTimeKind.Local).AddTicks(4480), new DateTime(2024, 3, 29, 0, 53, 51, 414, DateTimeKind.Local).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2024, 3, 29, 0, 53, 51, 414, DateTimeKind.Local).AddTicks(4485), new DateTime(2024, 3, 29, 0, 53, 51, 414, DateTimeKind.Local).AddTicks(4487) });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

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
        }
    }
}
