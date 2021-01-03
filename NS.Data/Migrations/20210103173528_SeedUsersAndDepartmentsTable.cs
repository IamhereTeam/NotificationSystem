using Microsoft.EntityFrameworkCore.Migrations;

namespace NS.Data.Migrations
{
    public partial class SeedUsersAndDepartmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
              .Sql("INSERT INTO Departments (Name) Values ('HR')");
            migrationBuilder
                .Sql("INSERT INTO Departments (Name) Values ('Development')");
            migrationBuilder
                .Sql("INSERT INTO Departments (Name) Values ('DevOps')");
            migrationBuilder
                .Sql("INSERT INTO Departments (Name) Values ('Sales')");
            migrationBuilder
                .Sql("INSERT INTO Departments (Name) Values ('Management')");

            migrationBuilder
                .Sql("INSERT INTO Users (Username, DepartmentId) Values ('Manager1', (SELECT Id FROM Departments WHERE Name = 'Management'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
               .Sql("DELETE FROM Departments");

            migrationBuilder
                .Sql("DELETE FROM Users");
        }
    }
}