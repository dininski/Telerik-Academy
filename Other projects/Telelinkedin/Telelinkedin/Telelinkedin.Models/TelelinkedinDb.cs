using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Telelinkedin.Models
{
    public class TelelinkedinDb : DbContext
    {
        public TelelinkedinDb()
            : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasMany<Job>(u => u.Jobs)
                .WithRequired(j => j.UserProfile);

            modelBuilder.Entity<UserProfile>()
                .HasMany<Skill>(u => u.Skills)
                .WithRequired(s => s.UserProfile);

            modelBuilder.Entity<UserProfile>()
                .HasMany<Education>(u => u.Education)
                .WithRequired(e => e.UserProfile);

            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Following)
                .Map(w =>
                {
                    w.ToTable("User_Follow")
                    .MapLeftKey("UserId")
                    .MapRightKey("FollowerId");
                });
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Education> Education { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Endorsement> Endorsements { get; set; }
    }
}