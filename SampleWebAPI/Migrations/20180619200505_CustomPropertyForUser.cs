using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleWebAPI.Migrations
{
    public partial class CustomPropertyForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomPropertyKey",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomPropertyValue",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomPropertyKey",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomPropertyValue",
                table: "Users");
        }
    }
}
