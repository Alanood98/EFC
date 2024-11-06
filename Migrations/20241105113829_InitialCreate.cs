using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    F_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_no = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.F_id);
                });

            migrationBuilder.CreateTable(
                name: "Hostels",
                columns: table => new
                {
                    Hostel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hostel_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    No_of_seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.Hostel_id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Subject_id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Departments",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Exam_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Exam_code);
                    table.ForeignKey(
                        name: "FK_Exams_Departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Departments",
                        principalColumn: "Department_id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    S_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone_no = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostel_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.S_id);
                    table.ForeignKey(
                        name: "FK_Students_Hostels_Hostel_id",
                        column: x => x.Hostel_id,
                        principalTable: "Hostels",
                        principalColumn: "Hostel_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultySubject",
                columns: table => new
                {
                    FacultiesF_id = table.Column<int>(type: "int", nullable: false),
                    SubjectsSubject_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySubject", x => new { x.FacultiesF_id, x.SubjectsSubject_id });
                    table.ForeignKey(
                        name: "FK_FacultySubject_Faculties_FacultiesF_id",
                        column: x => x.FacultiesF_id,
                        principalTable: "Faculties",
                        principalColumn: "F_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultySubject_Subjects_SubjectsSubject_id",
                        column: x => x.SubjectsSubject_id,
                        principalTable: "Subjects",
                        principalColumn: "Subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseFaculty",
                columns: table => new
                {
                    CoursesCourse_id = table.Column<int>(type: "int", nullable: false),
                    FacultiesF_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFaculty", x => new { x.CoursesCourse_id, x.FacultiesF_id });
                    table.ForeignKey(
                        name: "FK_CourseFaculty_Courses_CoursesCourse_id",
                        column: x => x.CoursesCourse_id,
                        principalTable: "Courses",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseFaculty_Faculties_FacultiesF_id",
                        column: x => x.FacultiesF_id,
                        principalTable: "Faculties",
                        principalColumn: "F_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesCourse_id = table.Column<int>(type: "int", nullable: false),
                    StudentsS_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesCourse_id, x.StudentsS_id });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesCourse_id",
                        column: x => x.CoursesCourse_id,
                        principalTable: "Courses",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsS_id",
                        column: x => x.StudentsS_id,
                        principalTable: "Students",
                        principalColumn: "S_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamsStudent",
                columns: table => new
                {
                    ExamsExam_code = table.Column<int>(type: "int", nullable: false),
                    StudentsS_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamsStudent", x => new { x.ExamsExam_code, x.StudentsS_id });
                    table.ForeignKey(
                        name: "FK_ExamsStudent_Exams_ExamsExam_code",
                        column: x => x.ExamsExam_code,
                        principalTable: "Exams",
                        principalColumn: "Exam_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamsStudent_Students_StudentsS_id",
                        column: x => x.StudentsS_id,
                        principalTable: "Students",
                        principalColumn: "S_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFaculty_FacultiesF_id",
                table: "CourseFaculty",
                column: "FacultiesF_id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Department_id",
                table: "Courses",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsS_id",
                table: "CourseStudent",
                column: "StudentsS_id");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Department_id",
                table: "Exams",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_ExamsStudent_StudentsS_id",
                table: "ExamsStudent",
                column: "StudentsS_id");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySubject_SubjectsSubject_id",
                table: "FacultySubject",
                column: "SubjectsSubject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Hostel_id",
                table: "Students",
                column: "Hostel_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseFaculty");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "ExamsStudent");

            migrationBuilder.DropTable(
                name: "FacultySubject");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Hostels");
        }
    }
}
