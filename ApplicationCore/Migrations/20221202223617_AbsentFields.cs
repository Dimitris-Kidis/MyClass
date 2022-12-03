using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    public partial class AbsentFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Courses",
                table: "AbsentList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Labs",
                table: "AbsentList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seminars",
                table: "AbsentList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courses",
                table: "AbsentList");

            migrationBuilder.DropColumn(
                name: "Labs",
                table: "AbsentList");

            migrationBuilder.DropColumn(
                name: "Seminars",
                table: "AbsentList");
        }
    }
}
