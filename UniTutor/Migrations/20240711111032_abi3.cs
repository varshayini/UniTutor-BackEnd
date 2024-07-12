using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTutor.Migrations
{
    /// <inheritdoc />
    public partial class abi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senderMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tutorId = table.Column<int>(type: "int", nullable: true),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    Student_id = table.Column<int>(type: "int", nullable: true),
                    Tutor_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x._id);
                    table.ForeignKey(
                        name: "FK_Reports_Students_Student_id",
                        column: x => x.Student_id,
                        principalTable: "Students",
                        principalColumn: "_id");
                    table.ForeignKey(
                        name: "FK_Reports_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Tutors_Tutor_id",
                        column: x => x.Tutor_id,
                        principalTable: "Tutors",
                        principalColumn: "_id");
                    table.ForeignKey(
                        name: "FK_Reports_Tutors_tutorId",
                        column: x => x.tutorId,
                        principalTable: "Tutors",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x._id);
                    table.ForeignKey(
                        name: "FK_Reviews_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Subjects_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subjects",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    tutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x._id);
                    table.ForeignKey(
                        name: "FK_TodoItems_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "_id");
                    table.ForeignKey(
                        name: "FK_TodoItems_Tutors_tutorId",
                        column: x => x.tutorId,
                        principalTable: "Tutors",
                        principalColumn: "_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Student_id",
                table: "Reports",
                column: "Student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_studentId",
                table: "Reports",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Tutor_id",
                table: "Reports",
                column: "Tutor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_tutorId",
                table: "Reports",
                column: "tutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_studentId",
                table: "Reviews",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_subjectId",
                table: "Reviews",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_studentId",
                table: "TodoItems",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_tutorId",
                table: "TodoItems",
                column: "tutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
