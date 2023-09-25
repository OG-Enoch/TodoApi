using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class ModelMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDo",
                table: "TodoItems",
                newName: "ToDoTitle");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoItems",
                newName: "ToDoDescription");

            migrationBuilder.Sql("ALTER TABLE [TodoItems] DROP CONSTRAINT [PK_TodoItems]");
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TodoItems");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TodoItems",
                nullable: false,
                defaultValueSql: "NEWID()");
            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDoTitle",
                table: "TodoItems",
                newName: "ToDo");

            migrationBuilder.RenameColumn(
                name: "ToDoDescription",
                table: "TodoItems",
                newName: "Name");

            migrationBuilder.Sql("ALTER TABLE [TodoItems] DROP CONSTRAINT [PK_TodoItems]"); 
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TodoItems");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "TodoItems",
                type: "bigint",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");
        }
    }
}
