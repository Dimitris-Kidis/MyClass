using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    public partial class DeletedLessonTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_LessonTypes_LessonTypeId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "LessonTypes");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_LessonTypeId",
                table: "Schedules");

            migrationBuilder.AddColumn<string>(
                name: "LessonName",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonName",
                table: "Schedules");

            migrationBuilder.CreateTable(
                name: "LessonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_LessonTypeId",
                table: "Schedules",
                column: "LessonTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_LessonTypes_LessonTypeId",
                table: "Schedules",
                column: "LessonTypeId",
                principalTable: "LessonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
