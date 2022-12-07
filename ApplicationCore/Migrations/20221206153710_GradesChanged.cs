using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    public partial class GradesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsentLists");

            migrationBuilder.RenameColumn(
                name: "StudentGrade",
                table: "Grades",
                newName: "GradeTwo");

            migrationBuilder.AddColumn<int>(
                name: "Courses",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "GradeFour",
                table: "Grades",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GradeOne",
                table: "Grades",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GradeThree",
                table: "Grades",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Labs",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seminars",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courses",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeFour",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeOne",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeThree",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Labs",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Seminars",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "GradeTwo",
                table: "Grades",
                newName: "StudentGrade");

            migrationBuilder.CreateTable(
                name: "AbsentLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Courses = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Labs = table.Column<int>(type: "int", nullable: false),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Seminars = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsentLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbsentLists_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbsentLists_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbsentLists_StudentId",
                table: "AbsentLists",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbsentLists_SubjectId",
                table: "AbsentLists",
                column: "SubjectId");
        }
    }
}
