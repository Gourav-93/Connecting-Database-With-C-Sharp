using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

StudentService studentService = new StudentService();

while (true)
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("     STUDENT MANAGEMENT SYSTEM");
    Console.WriteLine("=================================");

    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Student");
    Console.WriteLine("4. Find Student By ID");
    Console.WriteLine("5. Update Student");
    Console.WriteLine("6. Delete Student");
    Console.WriteLine("7. Find Topper");
    Console.WriteLine("8. Exit");

    Console.Write("\nEnter your choice: ");

    string? choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                AddStudent();
                break;

            case "2":
                ViewStudents();
                break;

            case "3":
                SearchStudent();
                break;

            case "4":
                FindStudent();
                break;

            case "5":
                UpdateStudent();
                break;

            case "6":
                DeleteStudent();
                break;

            case "7":
                FindTopper();
                break;

            case "8":
                Console.WriteLine("\nThank you!");
                return;

            default:
                Console.WriteLine("\nInvalid choice!");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError: {ex.Message}");
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}


// ===============================
// ADD STUDENT
// ===============================

void AddStudent()
{
    Console.Clear();

    Console.WriteLine("========== ADD STUDENT ==========");

    Console.Write("Enter ID: ");
    int id = int.Parse(Console.ReadLine()!);

    if (studentService.GetStudentById(id) != null)
    {
        Console.WriteLine("\nStudent ID already exists!");
        return;
    }

    Console.Write("Enter Name: ");
    string name = Console.ReadLine()!;

    Console.Write("Enter Age: ");
    int age = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Course: ");
    string course = Console.ReadLine()!;

    Console.Write("Enter Marks: ");
    double marks = double.Parse(Console.ReadLine()!);

    if (marks < 0 || marks > 100)
    {
        Console.WriteLine("\nMarks must be between 0 and 100.");
        return;
    }

    Student student = new Student
    {
        Id = id,
        Name = name,
        Age = age,
        Course = course,
        Marks = marks
    };

    studentService.AddStudent(student);
}


// ===============================
// VIEW STUDENTS
// ===============================

void ViewStudents()
{
    Console.Clear();

    Console.WriteLine("========== ALL STUDENTS ==========\n");

    List<Student> students = studentService.GetAllStudents();

    if (students.Count == 0)
    {
        Console.WriteLine("No students found.");
        return;
    }

    foreach (Student student in students)
    {
        DisplayStudent(student);
    }
}


// ===============================
// SEARCH STUDENT
// ===============================

void SearchStudent()
{
    Console.Clear();

    Console.WriteLine("========== SEARCH STUDENT ==========");

    Console.Write("Enter name: ");
    string name = Console.ReadLine()!;

    List<Student> results = studentService.SearchStudents(name);

    if (results.Count == 0)
    {
        Console.WriteLine("\nNo student found.");
        return;
    }

    foreach (Student student in results)
    {
        DisplayStudent(student);
    }
}


// ===============================
// FIND BY ID
// ===============================

void FindStudent()
{
    Console.Clear();

    Console.WriteLine("========== FIND STUDENT ==========");

    Console.Write("Enter Student ID: ");
    int id = int.Parse(Console.ReadLine()!);

    Student? student = studentService.GetStudentById(id);

    if (student == null)
    {
        Console.WriteLine("\nStudent not found.");
        return;
    }

    DisplayStudent(student);
}


// ===============================
// UPDATE STUDENT
// ===============================

void UpdateStudent()
{
    Console.Clear();

    Console.WriteLine("========== UPDATE STUDENT ==========");

    Console.Write("Enter Student ID: ");
    int id = int.Parse(Console.ReadLine()!);

    Student? existingStudent = studentService.GetStudentById(id);

    if (existingStudent == null)
    {
        Console.WriteLine("\nStudent not found.");
        return;
    }

    Console.Write("Enter New Name: ");
    string name = Console.ReadLine()!;

    Console.Write("Enter New Age: ");
    int age = int.Parse(Console.ReadLine()!);

    Console.Write("Enter New Course: ");
    string course = Console.ReadLine()!;

    Console.Write("Enter New Marks: ");
    double marks = double.Parse(Console.ReadLine()!);

    if (marks < 0 || marks > 100)
    {
        Console.WriteLine("\nMarks must be between 0 and 100.");
        return;
    }

    studentService.UpdateStudent(
        id,
        name,
        age,
        course,
        marks
    );
}


// ===============================
// DELETE STUDENT
// ===============================

void DeleteStudent()
{
    Console.Clear();

    Console.WriteLine("========== DELETE STUDENT ==========");

    Console.Write("Enter Student ID: ");
    int id = int.Parse(Console.ReadLine()!);

    studentService.DeleteStudent(id);
}


// ===============================
// TOPPER
// ===============================

void FindTopper()
{
    Console.Clear();

    Console.WriteLine("========== TOPPER ==========\n");

    Student? topper = studentService.GetTopper();

    if (topper == null)
    {
        Console.WriteLine("No students available.");
        return;
    }

    Console.WriteLine($"Topper: {topper.Name}");
    Console.WriteLine($"ID: {topper.Id}");
    Console.WriteLine($"Course: {topper.Course}");
    Console.WriteLine($"Marks: {topper.Marks}");
    Console.WriteLine($"Grade: {topper.Grade}");
}


// ===============================
// DISPLAY STUDENT
// ===============================

void DisplayStudent(Student student)
{
    Console.WriteLine("---------------------------------");
    Console.WriteLine($"ID         : {student.Id}");
    Console.WriteLine($"Name       : {student.Name}");
    Console.WriteLine($"Age        : {student.Age}");
    Console.WriteLine($"Course     : {student.Course}");
    Console.WriteLine($"Marks      : {student.Marks}");
    Console.WriteLine($"Percentage : {student.Percentage}%");
    Console.WriteLine($"Grade      : {student.Grade}");
}