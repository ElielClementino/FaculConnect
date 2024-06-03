using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FaculConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseToDisciplineDeleteCourseDiscipline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDisciplines");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Disciplines",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Disciplines");

            migrationBuilder.CreateTable(
                name: "CourseDisciplines",
                columns: table => new
                {
                    CourseDisciplineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: true),
                    DisciplineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDisciplines", x => x.CourseDisciplineId);
                    table.ForeignKey(
                        name: "FK_CourseDisciplines_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_CourseDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDisciplines_CourseId",
                table: "CourseDisciplines",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDisciplines_DisciplineId",
                table: "CourseDisciplines",
                column: "DisciplineId");
        }
    }
}
