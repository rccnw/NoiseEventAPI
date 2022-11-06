using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoiseEventApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoiseEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    UtcTime = table.Column<string>(type: "TEXT", nullable: false),
                    Longitude = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiseEvents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NoiseEvents",
                columns: new[] { "Id", "Data", "Latitude", "Longitude", "Type", "UtcTime" },
                values: new object[,]
                {
                    { 1, "event 1", "", "", "", "11/5/2022 6:55:29 PM" },
                    { 2, "event 2", "", "", "", "11/5/2022 6:55:29 PM" },
                    { 3, "event 3", "", "", "", "11/5/2022 6:55:29 PM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoiseEvents");
        }
    }
}
