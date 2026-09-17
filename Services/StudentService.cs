using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        // Get all students
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        // Get student by ID
        public Student? GetStudentById(int id)
        {
            return _context.Students
                .FirstOrDefault(s => s.Id == id);
        }

        // Add student
        public void AddStudent(Student student)
        {
            student.CalculateResult();

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // Update student - object version
        public bool UpdateStudent(Student student)
        {
            var existingStudent = _context.Students
                .FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent == null)
                return false;

            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Course = student.Course;
            existingStudent.Marks = student.Marks;

            existingStudent.CalculateResult();

            _context.SaveChanges();

            return true;
        }

        // Update student - parameter version
        public bool UpdateStudent(
            int id,
            string name,
            int age,
            string course,
            double marks)
        {
            var existingStudent = _context.Students
                .FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
                return false;

            existingStudent.Name = name;
            existingStudent.Age = age;
            existingStudent.Course = course;
            existingStudent.Marks = marks;

            existingStudent.CalculateResult();

            _context.SaveChanges();

            return true;
        }

        // Delete student
        public bool DeleteStudent(int id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
                return false;

            _context.Students.Remove(student);
            _context.SaveChanges();

            return true;
        }

        // Search students by name
        public List<Student> SearchStudents(string name)
        {
            return _context.Students
                .Where(s => s.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        // Get topper
        public Student? GetTopper()
        {
            return _context.Students
                .OrderByDescending(s => s.Marks)
                .FirstOrDefault();
        }
    }
}