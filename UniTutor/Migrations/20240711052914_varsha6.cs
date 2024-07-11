using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniTutor.Migrations
{
    /// <inheritdoc />
    public partial class varsha6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Students_studentId",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Tutors_tutorId",
                table: "TodoItems");

            migrationBuilder.AlterColumn<int>(
                name: "tutorId",
                table: "TodoItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "TodoItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Students_studentId",
                table: "TodoItems",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Tutors_tutorId",
                table: "TodoItems",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Students_studentId",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Tutors_tutorId",
                table: "TodoItems");

            migrationBuilder.AlterColumn<int>(
                name: "tutorId",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Students_studentId",
                table: "TodoItems",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Tutors_tutorId",
                table: "TodoItems",
                column: "tutorId",
                principalTable: "Tutors",
                principalColumn: "_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
