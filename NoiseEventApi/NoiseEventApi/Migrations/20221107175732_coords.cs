using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoiseEventApi.Migrations
{
    /// <inheritdoc />
    public partial class coords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "NoiseEvents",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "NoiseEvents",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { 47.609721999999998, -122.333056, "11/7/2022 5:57:32 PM" });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { 0.0, 0.0, "11/7/2022 5:57:32 PM" });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { 0.0, 0.0, "11/7/2022 5:57:32 PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "NoiseEvents",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "NoiseEvents",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { "", "", "11/5/2022 6:55:29 PM" });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { "", "", "11/5/2022 6:55:29 PM" });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { "", "", "11/5/2022 6:55:29 PM" });
        }
    }
}
