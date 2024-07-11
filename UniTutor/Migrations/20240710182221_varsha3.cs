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
            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    tutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x._id);
                    table.ForeignKey(
                        name: "FK_TodoLists_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoLists_Tutors_tutorId",
                        column: x => x.tutorId,
                        principalTable: "Tutors",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_studentId",
                table: "TodoLists",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_tutorId",
                table: "TodoLists",
                column: "tutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoLists");
        }
    }
}
