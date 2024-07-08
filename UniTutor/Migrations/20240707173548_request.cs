using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTutor.Migrations
{
    /// <inheritdoc />
    public partial class request : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Requests_RequestId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_RequestId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "availability",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "medium",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "mode",
                table: "Requests",
                newName: "studentEmail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Requests",
                newName: "subjectRequestId");

            migrationBuilder.AlterColumn<int>(
                name: "subjectId",
                table: "Requests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "timestamp",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_subjectId",
                table: "Requests",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Subjects_subjectId",
                table: "Requests",
                column: "subjectId",
                principalTable: "Subjects",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Subjects_subjectId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_subjectId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "timestamp",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "studentEmail",
                table: "Requests",
                newName: "mode");

            migrationBuilder.RenameColumn(
                name: "subjectRequestId",
                table: "Requests",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "subjectId",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Requests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "availability",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "medium",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_RequestId",
                table: "Subjects",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Requests_RequestId",
                table: "Subjects",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }
    }
}
