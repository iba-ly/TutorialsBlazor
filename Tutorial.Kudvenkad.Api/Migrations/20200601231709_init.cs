using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial.Kudvenkad.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Payroll" },
                    { 4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Birthday", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "Photo" },
                values: new object[,]
                {
                    { 1, new DateTime(1994, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "eslam.alhiki94@gmail.com", "Islam", 0, "Alshiki", "image.jpg" },
                    { 2, new DateTime(1994, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Abdulrahman.Alfaydi@gmail.com", "Abdulrahman", 0, "Alfaydi", "image.jpg" },
                    { 3, new DateTime(1991, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ali.Alawami@gmail.com", "Ali", 0, "Alawami", "image.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
