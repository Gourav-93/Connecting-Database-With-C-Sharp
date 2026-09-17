using System.Text.Json;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services;

public class StudentService
{
    private readonly string filePath = "Data/students.json";

    private List<Student> students = new();

    public StudentService()
    {
        LoadData();
    }

    public void AddStudent(Student student)
    {
        student.CalculateResult();

        students.Add(student);

        SaveData();

        Console.WriteLine("\nStudent added successfully!");
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    public Student? GetStudentById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> SearchStudents(string name)
    {
        return students
            .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void UpdateStudent(int id, string name, int age, string course, double marks)
    {
        Student? student = GetStudentById(id);

        if (student == null)
        {
            Console.WriteLine("\nStudent not found!");
            return;
        }

        student.Name = name;
        student.Age = age;
        student.Course = course;
        student.Marks = marks;

        student.CalculateResult();

        SaveData();

        Console.WriteLine("\nStudent updated successfully!");
    }

    public void DeleteStudent(int id)
    {
        Student? student = GetStudentById(id);

        if (student == null)
        {
            Console.WriteLine("\nStudent not found!");
            return;
        }

        students.Remove(student);

        SaveData();

        Console.WriteLine("\nStudent deleted successfully!");
    }

    public Student? GetTopper()
    {
        return students
            .OrderByDescending(s => s.Percentage)
            .FirstOrDefault();
    }

    private void SaveData()
    {
        string json = JsonSerializer.Serialize(
            students,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(filePath, json);
    }

    private void LoadData()
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        string json = File.ReadAllText(filePath);

        if (!string.IsNullOrWhiteSpace(json))
        {
            students = JsonSerializer.Deserialize<List<Student>>(json)
                       ?? new List<Student>();
        }
    }
}