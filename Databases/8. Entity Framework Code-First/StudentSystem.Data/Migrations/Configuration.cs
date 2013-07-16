namespace StudentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<AcademyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AcademyContext context)
        {
            var studentPesho = new Student()
            {
                Name = "Pesho",
                Number = 1
            };

            var studentGosho = new Student()
            {
                Name = "Gosho",
                Number = 2
            };

            var studentIvan = new Student()
            {
                Name = "Gosho",
                Number = 2
            };

            context.Courses.Add(new Course()
            {
                Name = "C#",
                Materials = "Nakov book",
                Students = new List<Student>() { 
                    studentGosho, studentPesho
                },
                Description = "C# Basics"
            });

            context.Courses.Add(new Course()
            {
                Name = "Javascript",
                Materials = "JS the good parts",
                Students = new List<Student>() { 
                    studentIvan
                },
                Description = "JS Part I"
            });
        }
    }
}
