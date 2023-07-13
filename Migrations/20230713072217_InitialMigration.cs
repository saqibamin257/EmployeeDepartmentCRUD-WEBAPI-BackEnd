using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDepartment_CRUD_WEBAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Sales" },
                    { 2, "Production" },
                    { 3, "IT" },
                    { 4, "Accounts" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "DepartmentId", "EmployeeName", "PhotoFileName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5890), 1, "Saqib", "anonymous.png" },
                    { 2, new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5940), 2, "Malik", "anonymous.png" },
                    { 3, new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5957), 3, "Imran", "anonymous.png" },
                    { 4, new DateTime(2023, 7, 13, 12, 22, 17, 17, DateTimeKind.Local).AddTicks(5970), 4, "Farhan", "anonymous.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
