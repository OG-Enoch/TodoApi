using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TodoItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToDo",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "ToDo",
                table: "TodoItems");
        }
    }
}
