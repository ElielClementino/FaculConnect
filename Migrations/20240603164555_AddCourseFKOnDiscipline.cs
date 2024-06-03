using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaculConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseFKOnDiscipline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_CourseId",
                table: "Disciplines",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Courses_CourseId",
                table: "Disciplines",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Courses_CourseId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_CourseId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Disciplines");
        }
    }
}
