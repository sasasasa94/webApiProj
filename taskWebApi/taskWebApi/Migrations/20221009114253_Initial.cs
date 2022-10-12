using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taskWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "ToDoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateProperties = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usersusername = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoList_Users_usersusername",
                        column: x => x.usersusername,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datetask = table.Column<DateTime>(type: "datetime2", nullable: false),
                    done = table.Column<bool>(type: "bit", nullable: false),
                    toDoListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_ToDoList_toDoListId",
                        column: x => x.toDoListId,
                        principalTable: "ToDoList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_toDoListId",
                table: "Tasks",
                column: "toDoListId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoList_usersusername",
                table: "ToDoList",
                column: "usersusername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ToDoList");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
