namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TimeSent = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Materials = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Student_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CourseStudents", new[] { "Student_Id" });
            DropIndex("dbo.CourseStudents", new[] { "Course_Id" });
            DropIndex("dbo.Homework", new[] { "StudentId" });
            DropForeignKey("dbo.CourseStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Courses");
            DropTable("dbo.Homework");
            DropTable("dbo.Students");
        }
    }
}
