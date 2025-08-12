using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KD25_BitirmeProjesi.InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class ArzuDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "SalaryAdvances",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9f04c0ef-c08b-45d0-85f1-174ac148129e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "eaaaf376-1ba7-41b9-b635-abc6143ac50d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1c6b056d-bea3-4ee5-8a2a-b44f1b895c6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d7f90d8-1e7b-43cd-aa15-56c14572a3e0", "AQAAAAIAAYagAAAAEIEao0+2tGOetktIVV+vKgAHkICYV6XpE4Euj4C6VkqYVZ7H03wFKzQ9BLHk2RlT2A==", "4f014f4e-f58f-4b6a-8e64-797558bae264" });

            migrationBuilder.UpdateData(
                table: "LeaveRecordTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 27, 19, 21, 38, 311, DateTimeKind.Local).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "LeaveRecordTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 27, 19, 21, 38, 311, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "LeaveRecordTypes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 27, 19, 21, 38, 311, DateTimeKind.Local).AddTicks(6010));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "SalaryAdvances",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6e07d419-b6e7-4ceb-a463-a16cc8edb822");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0074fdeb-886d-469e-849e-831c3e039e86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6dc94b39-07bf-480f-9c3d-8f49e284f4e3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67dd1bc5-96bd-4c40-b801-624807dd94fa", "AQAAAAIAAYagAAAAEGgPSz/KZQJZHJZIQbX76KMCv+JaZpQfIebxeP4wbBf2VF+PRIsMTJcHnGM1WZexTw==", "80292ca8-c988-45db-99f5-9d6d4c05d6ef" });

            migrationBuilder.UpdateData(
                table: "LeaveRecordTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 16, 12, 51, 17, 489, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "LeaveRecordTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 16, 12, 51, 17, 489, DateTimeKind.Local).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "LeaveRecordTypes",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 16, 12, 51, 17, 489, DateTimeKind.Local).AddTicks(1607));
        }
    }
}
