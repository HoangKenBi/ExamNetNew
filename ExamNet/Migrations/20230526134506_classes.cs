using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamNet.Migrations
{
    /// <inheritdoc />
    public partial class classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    classesId = table.Column<int>(type: "int", nullable: true),
                    facultysId = table.Column<int>(type: "int", nullable: true),
                    subjectsId = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_exams_classes_classesId",
                        column: x => x.classesId,
                        principalTable: "classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_exams_faculty_facultysId",
                        column: x => x.facultysId,
                        principalTable: "faculty",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_exams_subject_subjectsId",
                        column: x => x.subjectsId,
                        principalTable: "subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_exams_classesId",
                table: "exams",
                column: "classesId");

            migrationBuilder.CreateIndex(
                name: "IX_exams_facultysId",
                table: "exams",
                column: "facultysId");

            migrationBuilder.CreateIndex(
                name: "IX_exams_subjectsId",
                table: "exams",
                column: "subjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "faculty");

            migrationBuilder.DropTable(
                name: "subject");
        }
    }
}
