using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeDB.Migrations
{
    /// <inheritdoc />
    public partial class secondCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseFaculty_Courses_CoursesCourse_id",
                table: "CourseFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseFaculty_Faculties_FacultiesF_id",
                table: "CourseFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Department_id",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourse_id",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsS_id",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamsStudent_Exams_ExamsExam_code",
                table: "ExamsStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamsStudent_Students_StudentsS_id",
                table: "ExamsStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySubject_Faculties_FacultiesF_id",
                table: "FacultySubject");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySubject_Subjects_SubjectsSubject_id",
                table: "FacultySubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Hostels_Hostel_id",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFaculty_Courses_CoursesCourse_id",
                table: "CourseFaculty",
                column: "CoursesCourse_id",
                principalTable: "Courses",
                principalColumn: "Course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFaculty_Faculties_FacultiesF_id",
                table: "CourseFaculty",
                column: "FacultiesF_id",
                principalTable: "Faculties",
                principalColumn: "F_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Department_id",
                table: "Courses",
                column: "Department_id",
                principalTable: "Departments",
                principalColumn: "Department_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourse_id",
                table: "CourseStudent",
                column: "CoursesCourse_id",
                principalTable: "Courses",
                principalColumn: "Course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsS_id",
                table: "CourseStudent",
                column: "StudentsS_id",
                principalTable: "Students",
                principalColumn: "S_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamsStudent_Exams_ExamsExam_code",
                table: "ExamsStudent",
                column: "ExamsExam_code",
                principalTable: "Exams",
                principalColumn: "Exam_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamsStudent_Students_StudentsS_id",
                table: "ExamsStudent",
                column: "StudentsS_id",
                principalTable: "Students",
                principalColumn: "S_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySubject_Faculties_FacultiesF_id",
                table: "FacultySubject",
                column: "FacultiesF_id",
                principalTable: "Faculties",
                principalColumn: "F_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySubject_Subjects_SubjectsSubject_id",
                table: "FacultySubject",
                column: "SubjectsSubject_id",
                principalTable: "Subjects",
                principalColumn: "Subject_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Hostels_Hostel_id",
                table: "Students",
                column: "Hostel_id",
                principalTable: "Hostels",
                principalColumn: "Hostel_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseFaculty_Courses_CoursesCourse_id",
                table: "CourseFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseFaculty_Faculties_FacultiesF_id",
                table: "CourseFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Department_id",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourse_id",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsS_id",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamsStudent_Exams_ExamsExam_code",
                table: "ExamsStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamsStudent_Students_StudentsS_id",
                table: "ExamsStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySubject_Faculties_FacultiesF_id",
                table: "FacultySubject");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySubject_Subjects_SubjectsSubject_id",
                table: "FacultySubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Hostels_Hostel_id",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFaculty_Courses_CoursesCourse_id",
                table: "CourseFaculty",
                column: "CoursesCourse_id",
                principalTable: "Courses",
                principalColumn: "Course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFaculty_Faculties_FacultiesF_id",
                table: "CourseFaculty",
                column: "FacultiesF_id",
                principalTable: "Faculties",
                principalColumn: "F_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Department_id",
                table: "Courses",
                column: "Department_id",
                principalTable: "Departments",
                principalColumn: "Department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesCourse_id",
                table: "CourseStudent",
                column: "CoursesCourse_id",
                principalTable: "Courses",
                principalColumn: "Course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsS_id",
                table: "CourseStudent",
                column: "StudentsS_id",
                principalTable: "Students",
                principalColumn: "S_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamsStudent_Exams_ExamsExam_code",
                table: "ExamsStudent",
                column: "ExamsExam_code",
                principalTable: "Exams",
                principalColumn: "Exam_code");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamsStudent_Students_StudentsS_id",
                table: "ExamsStudent",
                column: "StudentsS_id",
                principalTable: "Students",
                principalColumn: "S_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySubject_Faculties_FacultiesF_id",
                table: "FacultySubject",
                column: "FacultiesF_id",
                principalTable: "Faculties",
                principalColumn: "F_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySubject_Subjects_SubjectsSubject_id",
                table: "FacultySubject",
                column: "SubjectsSubject_id",
                principalTable: "Subjects",
                principalColumn: "Subject_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Hostels_Hostel_id",
                table: "Students",
                column: "Hostel_id",
                principalTable: "Hostels",
                principalColumn: "Hostel_id");
        }
    }
}
