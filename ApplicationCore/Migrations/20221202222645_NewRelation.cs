using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    public partial class NewRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TeacherId",
                table: "Schedule",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TeacherId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Schedule");
        }
    }
}
