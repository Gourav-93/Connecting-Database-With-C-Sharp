namespace StudentManagementSystem.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Course { get; set; } = string.Empty;
    public double Marks { get; set; }
    public Double Percentage { get; set; }
    public string Grade { get; set; } = string.Empty;

    public void CalculateResult()
    {
        Percentage = Marks;
        if (Percentage >= 90)
        {
            Grade = "A+";
        }
        else if (Percentage >= 80)
        {
            Grade = "A";
        }
        else if (Percentage >= 70)
        {
            Grade = "B";
        }
        else if (Percentage >= 60)
        {
            Grade = "C";
        }
        else if (Percentage >= 50)
        {
            Grade = "D";
        }
        else
        {
            Grade = "F";
        }
    }

}