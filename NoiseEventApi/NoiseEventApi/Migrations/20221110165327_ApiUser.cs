using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoiseEventApi.Migrations
{
    /// <inheritdoc />
    public partial class ApiUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41ae4fb5-360d-4862-ae08-daac4848786f", "Rob", "Campbell", "AQAAAAIAAYagAAAAEKs2fngXo2LaI3pT/58oqYvv/WQHJP+dqgMNHwpbCdeXpSk17A/fy51pW+m6Wi9ujg==", "6ec0acea-05e1-4208-8256-881c12701291" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49b90177-4e03-4e0c-9986-1c1b285cb3a3", "Rob", "Campbell", "AQAAAAIAAYagAAAAEPTqcVP0Jvft/q9EeYQjWaFZuC3kIE2orxDJZGURLLqIvNWDtUsF48DzkK1EmR5Z+Q==", "02d83394-1312-4865-95c8-a69b7e6cc8f2" });

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UtcTime",
                value: "11/10/2022 4:53:27 PM");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "UtcTime",
                value: "11/10/2022 4:53:27 PM");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "UtcTime",
                value: "11/10/2022 4:53:27 PM");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 4,
                column: "UtcTime",
                value: "11/10/2022 4:53:27 PM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48fba3aa-993a-477d-913f-d52235e712c9", "AQAAAAIAAYagAAAAEAPWqsxCFIbV8/bBmqfwSOLfAMSKR8XmfQoXkhwJYF3edbsL+JvQ8I7ydIWpTT0/4A==", "87a18473-f131-4637-a975-339ac1a7ef8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac95fff9-af4f-434f-b555-9a224d1d9d9c", "AQAAAAIAAYagAAAAEBnq4u4+NDZiQNQv6IuGE5qyhQuIasn7hLvt5xakxiqMJ9l2InegZVvE1+oSnsP0vQ==", "d27d8305-d2f9-4fdc-b655-e6efa9286fa0" });

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
                column: "UtcTime",
                value: "11/9/2022 7:42:55 PM");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "UtcTime",
                value: "11/9/2022 7:42:55 PM");

            migrationBuilder.UpdateData(
                table: "NoiseEvents",
                keyColumn: "Id",
                keyValue: 4,
                column: "UtcTime",
                value: "11/9/2022 7:42:55 PM");
        }
    }
}
