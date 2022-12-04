using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    public partial class Exp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsentList_Students_StudentId",
                table: "AbsentList");

            migrationBuilder.DropForeignKey(
                name: "FK_AbsentList_Subject_SubjectId",
                table: "AbsentList");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeacher_Class_ClassId",
                table: "ClassTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeacher_Subject_SubjectId",
                table: "ClassTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeacher_Teachers_TeacherId",
                table: "ClassTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Students_StudentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Subject_SubjectId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Teachers_TeacherId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Users_UserId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Class_ClassId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_LessonType_LessonTypeId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Class_ClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonType",
                table: "LessonType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassTeacher",
                table: "ClassTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbsentList",
                table: "AbsentList");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameTable(
                name: "LessonType",
                newName: "LessonTypes");

            migrationBuilder.RenameTable(
                name: "Grade",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "ClassTeacher",
                newName: "ClassesTeachers");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "AbsentList",
                newName: "AbsentLists");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_TeacherId",
                table: "Schedules",
                newName: "IX_Schedules_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_SubjectId",
                table: "Schedules",
                newName: "IX_Schedules_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_LessonTypeId",
                table: "Schedules",
                newName: "IX_Schedules_LessonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_ClassId",
                table: "Schedules",
                newName: "IX_Schedules_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Note_UserId",
                table: "Notes",
                newName: "IX_Notes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_TeacherId",
                table: "Grades",
                newName: "IX_Grades_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_SubjectId",
                table: "Grades",
                newName: "IX_Grades_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_StudentId",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassTeacher_TeacherId",
                table: "ClassesTeachers",
                newName: "IX_ClassesTeachers_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassTeacher_SubjectId",
                table: "ClassesTeachers",
                newName: "IX_ClassesTeachers_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassTeacher_ClassId",
                table: "ClassesTeachers",
                newName: "IX_ClassesTeachers_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_AbsentList_SubjectId",
                table: "AbsentLists",
                newName: "IX_AbsentLists_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AbsentList_StudentId",
                table: "AbsentLists",
                newName: "IX_AbsentLists_StudentId");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonTypes",
                table: "LessonTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassesTeachers",
                table: "ClassesTeachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbsentLists",
                table: "AbsentLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsentLists_Students_StudentId",
                table: "AbsentLists",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbsentLists_Subjects_SubjectId",
                table: "AbsentLists",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesTeachers_Classes_ClassId",
                table: "ClassesTeachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesTeachers_Subjects_SubjectId",
                table: "ClassesTeachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesTeachers_Teachers_TeacherId",
                table: "ClassesTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Teachers_TeacherId",
                table: "Grades",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Classes_ClassId",
                table: "Schedules",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_LessonTypes_LessonTypeId",
                table: "Schedules",
                column: "LessonTypeId",
                principalTable: "LessonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Subjects_SubjectId",
                table: "Schedules",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsentLists_Students_StudentId",
                table: "AbsentLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AbsentLists_Subjects_SubjectId",
                table: "AbsentLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesTeachers_Classes_ClassId",
                table: "ClassesTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesTeachers_Subjects_SubjectId",
                table: "ClassesTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesTeachers_Teachers_TeacherId",
                table: "ClassesTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Teachers_TeacherId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Classes_ClassId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_LessonTypes_LessonTypeId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Subjects_SubjectId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonTypes",
                table: "LessonTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassesTeachers",
                table: "ClassesTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbsentLists",
                table: "AbsentLists");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameTable(
                name: "LessonTypes",
                newName: "LessonType");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grade");

            migrationBuilder.RenameTable(
                name: "ClassesTeachers",
                newName: "ClassTeacher");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");

            migrationBuilder.RenameTable(
                name: "AbsentLists",
                newName: "AbsentList");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedule",
                newName: "IX_Schedule_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_SubjectId",
                table: "Schedule",
                newName: "IX_Schedule_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_LessonTypeId",
                table: "Schedule",
                newName: "IX_Schedule_LessonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_ClassId",
                table: "Schedule",
                newName: "IX_Schedule_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_UserId",
                table: "Note",
                newName: "IX_Note_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_TeacherId",
                table: "Grade",
                newName: "IX_Grade_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_SubjectId",
                table: "Grade",
                newName: "IX_Grade_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grade",
                newName: "IX_Grade_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassesTeachers_TeacherId",
                table: "ClassTeacher",
                newName: "IX_ClassTeacher_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassesTeachers_SubjectId",
                table: "ClassTeacher",
                newName: "IX_ClassTeacher_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassesTeachers_ClassId",
                table: "ClassTeacher",
                newName: "IX_ClassTeacher_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_AbsentLists_SubjectId",
                table: "AbsentList",
                newName: "IX_AbsentList_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AbsentLists_StudentId",
                table: "AbsentList",
                newName: "IX_AbsentList_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonType",
                table: "LessonType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                table: "Grade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassTeacher",
                table: "ClassTeacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbsentList",
                table: "AbsentList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsentList_Students_StudentId",
                table: "AbsentList",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbsentList_Subject_SubjectId",
                table: "AbsentList",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacher_Class_ClassId",
                table: "ClassTeacher",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacher_Subject_SubjectId",
                table: "ClassTeacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeacher_Teachers_TeacherId",
                table: "ClassTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Students_StudentId",
                table: "Grade",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Subject_SubjectId",
                table: "Grade",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Teachers_TeacherId",
                table: "Grade",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Users_UserId",
                table: "Note",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Class_ClassId",
                table: "Schedule",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_LessonType_LessonTypeId",
                table: "Schedule",
                column: "LessonTypeId",
                principalTable: "LessonType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                table: "Schedule",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Teachers_TeacherId",
                table: "Schedule",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Class_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
