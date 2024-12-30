using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addviewcount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 11, 16, 17, 30, 8, 202, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 11, 16, 17, 30, 8, 202, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 11, 16, 17, 30, 8, 202, DateTimeKind.Local).AddTicks(5181));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 11, 14, 21, 10, 2, 867, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 11, 14, 21, 10, 2, 867, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 11, 14, 21, 10, 2, 867, DateTimeKind.Local).AddTicks(303));
        }
    }
}
