using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW_3._2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "DueDate", "IsCompleted", "Status", "Title" },
                values: new object[] { 1, new DateTime(2024, 9, 3, 18, 55, 4, 291, DateTimeKind.Local).AddTicks(8732), "This is an initial task.", new DateTime(2024, 9, 10, 18, 55, 4, 291, DateTimeKind.Local).AddTicks(8786), false, 0, "Initial Task" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedDate",
                table: "Tasks",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Title",
                table: "Tasks",
                column: "Title",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Task_DueDate",
                table: "Tasks",
                sql: "[DueDate] >= [CreatedDate]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatedDate",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_Title",
                table: "Tasks");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Task_DueDate",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
