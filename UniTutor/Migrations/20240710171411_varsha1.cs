﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTutor.Migrations
{
    /// <inheritdoc />
    public partial class varsha1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    schoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numberofcomplain = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    universityMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    universityID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stuId = table.Column<int>(type: "int", nullable: true),
                    tutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x._id);
                    table.ForeignKey(
                        name: "FK_Comments_Students_stuId",
                        column: x => x.stuId,
                        principalTable: "Students",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Tutors_tutId",
                        column: x => x.tutId,
                        principalTable: "Tutors",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senderMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiverMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Subjects",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    availability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x._id);
                    table.ForeignKey(
                        name: "FK_Subjects_Tutors_tutorId",
                        column: x => x.tutorId,
                        principalTable: "Tutors",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    tutorId = table.Column<int>(type: "int", nullable: false),
                    studentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x._id);
                    table.ForeignKey(
                        name: "FK_Requests_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Subjects_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subjects",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Tutors_tutorId",
                        column: x => x.tutorId,
                        principalTable: "Tutors",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_stuId",
                table: "Comments",
                column: "stuId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_tutId",
                table: "Comments",
                column: "tutId");

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
                name: "IX_Requests_studentId",
                table: "Requests",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_subjectId",
                table: "Requests",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_tutorId",
                table: "Requests",
                column: "tutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_tutorId",
                table: "Subjects",
                column: "tutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Tutors");
        }
    }
}