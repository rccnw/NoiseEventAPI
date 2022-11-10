using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoiseEventApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentityTablesForReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42358d3e-3c22-45e1-be81-6caa7ba865ef", null, "User", "USER" },
                    { "d1b5952a-2162-46c7-b29e-1a2a68922c14", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f4631bd-f907-4409-b416-ba356312e659", 0, "48fba3aa-993a-477d-913f-d52235e712c9", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAPWqsxCFIbV8/bBmqfwSOLfAMSKR8XmfQoXkhwJYF3edbsL+JvQ8I7ydIWpTT0/4A==", null, false, "87a18473-f131-4637-a975-339ac1a7ef8d", false, "user@localhost.com" },
                    { "408aa945-3d84-4421-8342-7269ec64d949", 0, "ac95fff9-af4f-434f-b555-9a224d1d9d9c", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBnq4u4+NDZiQNQv6IuGE5qyhQuIasn7hLvt5xakxiqMJ9l2InegZVvE1+oSnsP0vQ==", null, false, "d27d8305-d2f9-4fdc-b655-e6efa9286fa0", false, "admin@localhost.com" }
                });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UtcTime",
                value: "11/9/2022 7:42:55 PM");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { 47.534050074149732, -122.3756040651044, "11/9/2022 7:42:55 PM" });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Data", "Latitude", "Longitude", "UtcTime" },
                values: new object[] { "event 2", 47.536847222433394, -122.3639542838912, "11/9/2022 7:42:55 PM" });

            migrationBuilder.InsertData(
                table: "NoiseEvents",
                columns: new[] { "Id", "Data", "Latitude", "Longitude", "Type", "UtcTime" },
                values: new object[] { 4, "event 3", 47.53168586589171, -122.37644247129047, "", "11/9/2022 7:42:55 PM" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "42358d3e-3c22-45e1-be81-6caa7ba865ef", "3f4631bd-f907-4409-b416-ba356312e659" },
                    { "d1b5952a-2162-46c7-b29e-1a2a68922c14", "408aa945-3d84-4421-8342-7269ec64d949" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "42358d3e-3c22-45e1-be81-6caa7ba865ef", "3f4631bd-f907-4409-b416-ba356312e659" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d1b5952a-2162-46c7-b29e-1a2a68922c14", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42358d3e-3c22-45e1-be81-6caa7ba865ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1b5952a-2162-46c7-b29e-1a2a68922c14");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UtcTime",
                value: "11/9/2022 2:02:47 AM");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "UtcTime" },
                values: new object[] { 0.0, 0.0, "11/9/2022 2:02:47 AM" });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Data", "Latitude", "Longitude", "UtcTime" },
                values: new object[] { "event 3", 0.0, 0.0, "11/9/2022 2:02:47 AM" });
        }
    }
}
