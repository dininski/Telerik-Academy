namespace Telelinkedin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ProfileId = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employer = c.String(),
                        Description = c.String(),
                        Position = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(x => x.UserProfileId);

            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Institution = c.String(),
                        Specialty = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(x => x.UserProfileId);

            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(x => x.UserProfileId);

        }

        public override void Down()
        {
            DropIndex("dbo.UserProfile", new[] { "Skill_Id" });
            DropForeignKey("dbo.Skills", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.UserProfile");
            DropTable("dbo.Skills");
            DropTable("dbo.Educations");
            DropTable("dbo.Jobs");
            DropTable("dbo.UserProfile");
        }
    }
}
