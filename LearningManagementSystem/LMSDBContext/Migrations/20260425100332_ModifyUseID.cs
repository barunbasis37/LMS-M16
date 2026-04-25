using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystem.LMSDBContext.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUseID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_User_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_User_StudentId",
                table: "StudentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_User_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments");

            migrationBuilder.DropIndex(
                name: "IX_StudentAssignments_StudentId",
                table: "StudentAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments",
                columns: new[] { "StudentId", "AssignmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ModificationDate", "UserId" },
                values: new object[] { new DateTime(2026, 4, 25, 16, 3, 31, 675, DateTimeKind.Local).AddTicks(6738), null });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_Users_StudentId",
                table: "StudentAssignments",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Users_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_Users_StudentId",
                table: "StudentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Users_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "InstructorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InstructorId", "ModificationDate", "ModifiedDate" },
                values: new object[] { "INSBD6DAD3B", new DateTime(2026, 4, 25, 15, 42, 14, 356, DateTimeKind.Local).AddTicks(7187), null });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_StudentId",
                table: "StudentAssignments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_User_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_User_StudentId",
                table: "StudentAssignments",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_User_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
