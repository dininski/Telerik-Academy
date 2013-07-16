namespace StudentSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Models;

    // TODO: Fix connection
    public class AcademyContext : DbContext
    {
        public AcademyContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
