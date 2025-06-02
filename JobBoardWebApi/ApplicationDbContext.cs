using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JobBoardWebApi
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<AppliedJob> AppliedJobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<SavedJob> SavedJobs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppliedJob>()
                .HasKey(aj =>new { aj.JobId, aj.ApplicationId});

            builder.Entity<CandidateSkillMapping>()
                .HasKey(ck => new {ck.CandidateId, ck.SkillId });

            builder.Entity<SavedJob>()
                .HasKey(sj => new {sj.JobId, sj.CandidateId });

            builder.Entity<SavedJob>()
                .HasOne(sj => sj.Job)
                .WithMany(sj => sj.SavedJobs)
                .HasForeignKey(sj => sj.JobId);

            builder.Entity<SavedJob>()
                .HasOne(sj => sj.Candidate)
                .WithMany(sj => sj.SavedJobs)
                .HasForeignKey(sj => sj.CandidateId);
                

            builder.Entity<CandidateSkillMapping>()
                .HasOne(ck => ck.Skill)
                .WithMany(ck => ck.candidateSkillMappings)
                .HasForeignKey(ck => ck.SkillId);

            builder.Entity<CandidateSkillMapping>()
                .HasOne(ck => ck.Candidate)
                .WithMany(ck => ck.candidateSkillMappings)
                .HasForeignKey(ck => ck.CandidateId);

            builder.Entity<AppliedJob>()
                .HasOne(aj => aj.Application)
                .WithMany(aj => aj.ApplicationJobMapping)
                .HasForeignKey(aj => aj.ApplicationId);

            builder.Entity<AppliedJob>()
                .HasOne(aj => aj.Job)
                .WithMany(aj => aj.ApplicationJobMapping)
                .HasForeignKey(aj => aj.JobId);

            builder.Entity<Application>()
               .HasOne(a => a.Candidate)
               .WithMany(a => a.Applications)
               .HasForeignKey(a => a.CandidateId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Level>()
                .HasMany(l => l.Jobs)
                .WithOne(l => l.Level)
                .HasForeignKey(l => l.LevelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Skill>()
                .HasMany(c => c.Jobs)
                .WithOne(c => c.Skill)
                .HasForeignKey(c => c.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Level>()
                .HasData(
                 new Level { Id = Guid.NewGuid(), Name = "Intern" },
                 new Level { Id = Guid.NewGuid(), Name = "Fresher" },
                 new Level { Id = Guid.NewGuid(), Name = "Junior" },
                 new Level { Id = Guid.NewGuid(), Name = "Middle" },
                 new Level { Id = Guid.NewGuid(), Name = "Senior" },
                 new Level { Id = Guid.NewGuid(), Name = "Leader" });

            builder.Entity<Skill>()
                .HasData(
                new Skill { Id = Guid.NewGuid(), Name = "C#" },
                new Skill { Id = Guid.NewGuid(), Name = "JavaScript" },
                new Skill { Id = Guid.NewGuid(), Name = "Python" },
                new Skill { Id = Guid.NewGuid(), Name = "SQL" },
                new Skill { Id = Guid.NewGuid(), Name = "HTML/CSS" },
                new Skill { Id = Guid.NewGuid(), Name = "React" },
                new Skill { Id = Guid.NewGuid(), Name = "ASP.NET Core" },
                new Skill { Id = Guid.NewGuid(), Name = "Java" },
                new Skill { Id = Guid.NewGuid(), Name = "Kubernetes" },
                new Skill { Id = Guid.NewGuid(), Name = "Azure" });

        }
    }
}
