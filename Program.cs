using System;
using System.Numerics;
using System.Security.Cryptography;
using CollegeDB;
using CollegeDB.Repositories;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using var dbContext = new AppDBcon();

        // Create repositories
        var studentRepository = new StudentRepository(dbContext);
        var facultyRepository = new FacultyRepository(dbContext);
        var courseRepository = new CourseRepository(dbContext);
        var departmentRepository = new DepartmentRepository(dbContext);
       // var examRepository = new ExamRepository(dbContext);
        var hostelRepository = new HostelRepository(dbContext);
        var subjectRepository = new SubjectRepository(dbContext);

        // User interaction loop
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Display all students");
            Console.WriteLine("2. Add new student");
            Console.WriteLine("3. Display all departments");
            Console.WriteLine("4. Add new department");
            Console.WriteLine("5. Display all courses");
            Console.WriteLine("6. Add new course");
            Console.WriteLine("7. Add new faculty");
            Console.WriteLine("8. Display all faculty");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllStudents(studentRepository);
                    break;
                case "2":
                    AddNewStudent(studentRepository);
                    break;
                case "3":
                    DisplayAllDepartments(departmentRepository);
                    break;
                case "4":
                    AddNewDepartment(departmentRepository);
                    break;
                case "5":
                    DisplayAllCourses(courseRepository);
                    break;
                case "6":
                    AddNewCourse(courseRepository);
                    break;
                case "7":
                    AddNewFaculty(facultyRepository);
                    break;
                case "8":
                    DisplayAllFaculty(facultyRepository);
                case "9":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayAllStudents(StudentRepository repository)
    {
        var students = repository.GetAll();
        Console.WriteLine("\nStudents:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.S_id}: {student.Name}: - DOB: {student.DOB.ToShortDateString()}- {student.Address}:");
        }
    }

    static void AddNewStudent(StudentRepository repository)
    {
        Console.Write("\nEnter student Address: ");
        var adress = Console.ReadLine();
        Console.Write("\nEnter student name: ");
        var name = Console.ReadLine();
        Console.Write("Enter date of birth (yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out var dob))
        {
            Console.Write("Enter phone number: ");
            if (int.TryParse(Console.ReadLine(), out var phoneNo))
            {
                var student = new Student { Address = adress, Name = name, DOB = dob, Phone_no = phoneNo  };
                
                repository.Add(student);
                Console.WriteLine("Student added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid phone number input.");
            }
        }
        else
        {
            Console.WriteLine("Invalid date format.");
        }
    }

    static void DisplayAllDepartments(DepartmentRepository repository)
    {
        var departments = repository.GetAllDepartments();
        Console.WriteLine("\nDepartments:");
        foreach (var department in departments)
        {
            Console.WriteLine($"{department.Department_id}: {department.D_name}");
        }
    }

    static void AddNewDepartment(DepartmentRepository repository)
    {
        Console.Write("\nEnter department name: ");
        var dName = Console.ReadLine();
        var department = new Department { D_name = dName };
        repository.AddDepartment(department);
        Console.WriteLine("Department added successfully!");
    }

    static void DisplayAllCourses(CourseRepository repository)
    {
        var courses = repository.GetAllCourses();
        Console.WriteLine("\nCourses:");
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Course_id}: {course.Course_name} - Duration: {course.Duration}");
        }
    }

    static void AddNewCourse(CourseRepository repository)
    {
        Console.Write("\nEnter course name: ");
        var courseName = Console.ReadLine();
        Console.Write("Enter duration: ");
        var duration = Console.ReadLine();
        Console.Write("Enter department ID: ");
        if (int.TryParse(Console.ReadLine(), out var departmentId))
        {
            var course = new Course { Course_name = courseName, Duration = duration, Department_id = departmentId };
            repository.AddCourse(course);
            Console.WriteLine("Course added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid department ID input.");
        }
        static void AddNewFaculty(FacultyRepository repository)
        {
            Console.Write("\nEnter faculty name: ");
            var fucName = Console.ReadLine();
            Console.Write("\nEnter the salary: ");
            var salary = decimal.Parse(Console.ReadLine());
            Console.Write("\nEnter deparID: ");
            var departmentId = int.Parse(Console.ReadLine());

            try
            {
                var faculty = new Faculty { Name = fucName, Salary = salary, Department_id = departmentId };
                repository.Add(faculty);
                Console.WriteLine("faculty added successfully!");
            }
            catch (Exception ex) { Console.WriteLine("no  faculty add!"); }

        }
        static void DisplayAllFaculty(FacultyRepository repository)
        {
            var faculties = repository.GetAll();
            Console.WriteLine("\nFaculties:");
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"{faculty.F_id}: {faculty.Name} - Salary: {faculty.Salary}" +
                    $" - PhoneNum: {faculty.Mobile_no} - DepartmentId: {faculty.Department_id} ");
            }
        }

    }
}
