using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTutor.Migrations
{
    /// <inheritdoc />
    public partial class varsha3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Students_Student_id",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Students_studentId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Tutors_Tutor_id",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Tutors_tutorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Subjects_subjectId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Student_id",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Tutor_id",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Student_id",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Tutor_id",
                table: "Reports");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    tutorId = table.Column<int>(type: "int", nullable: false),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Tutors_tutorId",
                        column: x => x.tutorId,
                        principalTable: "Tutors",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_tutorId",
                table: "Transactions",
                column: "tutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Students_studentId",
                table: "Reports",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Tutors_tutorId",
                table: "Reports",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Subjects_subjectId",
                table: "Requests",
                column: "subjectId",
                principalTable: "Subjects",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Students_studentId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Tutors_tutorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Subjects_subjectId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "Student_id",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tutor_id",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Student_id",
                table: "Reports",
                column: "Student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Tutor_id",
                table: "Reports",
                column: "Tutor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Students_Student_id",
                table: "Reports",
                column: "Student_id",
                principalTable: "Students",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Students_studentId",
                table: "Reports",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Tutors_Tutor_id",
                table: "Reports",
                column: "Tutor_id",
                principalTable: "Tutors",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Tutors_tutorId",
                table: "Reports",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Students_studentId",
                table: "Requests",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Subjects_subjectId",
                table: "Requests",
                column: "subjectId",
                principalTable: "Subjects",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
