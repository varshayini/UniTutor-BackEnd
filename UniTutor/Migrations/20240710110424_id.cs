using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTutor.Migrations
{
    /// <inheritdoc />
    public partial class id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tutors",
                newName: "_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "_id");

            migrationBuilder.RenameColumn(
                name: "subjectRequestId",
                table: "Requests",
                newName: "_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Tutors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Requests",
                newName: "subjectRequestId");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Admin",
                newName: "Id");
        }
    }
}
