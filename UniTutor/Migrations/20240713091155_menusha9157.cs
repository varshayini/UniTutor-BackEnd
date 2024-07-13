using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTutor.Migrations
{
    /// <inheritdoc />
    public partial class menusha9157 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Students_stuId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tutors_tutId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "numberofcomplain",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Student_id",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Tutor_id",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Tutors",
                newName: "universityMail");

            migrationBuilder.RenameColumn(
                name: "about",
                table: "Tutors",
                newName: "universityID");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Tutors",
                newName: "Coins");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Tutors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "cv",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "occupation",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "qualifications",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "FK_Comments_Students_stuId",
                table: "Comments",
                column: "stuId",
                principalTable: "Students",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tutors_tutId",
                table: "Comments",
                column: "tutId",
                principalTable: "Tutors",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Students_stuId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tutors_tutId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "cv",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "occupation",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "qualifications",
                table: "Tutors");

            migrationBuilder.RenameColumn(
                name: "universityMail",
                table: "Tutors",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "universityID",
                table: "Tutors",
                newName: "about");

            migrationBuilder.RenameColumn(
                name: "Coins",
                table: "Tutors",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "numberofcomplain",
                table: "Tutors",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Students_stuId",
                table: "Comments",
                column: "stuId",
                principalTable: "Students",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tutors_tutId",
                table: "Comments",
                column: "tutId",
                principalTable: "Tutors",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tutors_tutorId",
                table: "Requests",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
