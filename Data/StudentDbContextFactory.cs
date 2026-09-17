using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentManagementSystem.Data
{
    public class StudentDbContextFactory
        : IDesignTimeDbContextFactory<StudentDbContext>
    {
        public StudentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<StudentDbContext>();

            optionsBuilder.UseMySQL(
                "Server=localhost;Port=3306;Database=StudentManagementDb;User=root;Password=Gourav;"
            );

            return new StudentDbContext(optionsBuilder.Options);
        }
    }
}