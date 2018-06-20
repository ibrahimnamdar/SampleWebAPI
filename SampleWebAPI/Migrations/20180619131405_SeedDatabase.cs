using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleWebAPI.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO DEPARTMENTS (Name) VALUES ('Department1')");
            migrationBuilder.Sql("INSERT INTO DEPARTMENTS (Name) VALUES ('Department2')");
            migrationBuilder.Sql("INSERT INTO DEPARTMENTS (Name) VALUES ('Department3')");

            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname,Address , DepartmentID) Values ('Dep1-UserA','password','firstname','lastname','address' ,(SELECT ID FROM Departments WHERE Name='Department1'))");
            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname,Address , DepartmentID) Values ('Dep1-UserB','password','firstname','lastname', 'address' ,(SELECT ID FROM Departments WHERE Name='Department1'))");
            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname, Address ,DepartmentID) Values ('Dep1-UserC','password','firstname','lastname', 'address' ,(SELECT ID FROM Departments WHERE Name='Department1'))");

            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname,Address , DepartmentID) Values ('Dep2-UserA','password','firstname','lastname','address' , (SELECT ID FROM Departments WHERE Name='Department2'))");
            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname,Address , DepartmentID) Values ('Dep2-UserB','password','firstname','lastname', 'address' ,(SELECT ID FROM Departments WHERE Name='Department2'))");
            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname, Address ,DepartmentID) Values ('Dep2-UserC','password','firstname','lastname', 'address' ,(SELECT ID FROM Departments WHERE Name='Department2'))");

            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname,Address , DepartmentID) Values ('Dep3-UserA','password','firstname','lastname', (SELECT ID FROM Departments WHERE Name='Department3'))");
            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname, Address ,DepartmentID) Values ('Dep3-UserB','password','firstname','lastname', (SELECT ID FROM Departments WHERE Name='Department3'))");
            migrationBuilder.Sql("INSERT INTO Users (Username, Password, Firstname, Lastname, Address ,DepartmentID) Values ('Dep3-UserC','password','firstname','lastname', (SELECT ID FROM Departments WHERE Name='Department3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Departments where in ('Department1','Department2','Department3')");
            migrationBuilder.Sql("delete from Users");
        }
    }
}
