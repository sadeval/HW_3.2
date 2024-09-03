using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW_3._2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 9, 3, 19, 12, 35, 223, DateTimeKind.Local).AddTicks(2664), new DateTime(2024, 9, 10, 19, 12, 35, 223, DateTimeKind.Local).AddTicks(2716) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 9, 3, 18, 55, 4, 291, DateTimeKind.Local).AddTicks(8732), new DateTime(2024, 9, 10, 18, 55, 4, 291, DateTimeKind.Local).AddTicks(8786) });
        }
    }
}
