using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    public partial class DeletedLessonTypeTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonTypeId",
                table: "Schedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonTypeId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
