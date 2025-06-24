using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.FlatDto;
using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JobBoardWebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<AppliedJob> AppliedJobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<SavedJob> SavedJobs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Seed data = new Seed(builder);

            data.SeedInitialData();

            builder.Entity<CandidateFlatDto>().HasNoKey().ToView(null);
            builder.Entity<JobType>().HasNoKey().ToView(null);
            builder.Entity<JobDto>().HasNoKey().ToView(null);
            builder.Entity<ApplicationDto>().HasNoKey().ToView(null);
            builder.Entity<RecruiterFlatDto>().HasNoKey().ToView(null);
            builder.Entity<CompanyFlatDto>().HasNoKey().ToView(null);
            builder.Entity<AdminFlatDto>().HasNoKey().ToView(null);

            builder.Entity<AppliedJob>()
                .HasKey(aj =>new { aj.JobId, aj.ApplicationId});

            builder.Entity<CandidateSkill>()
                .HasKey(ck => new {ck.CandidateId, ck.SkillId });

            builder.Entity<SavedJob>()
                .HasKey(sj => new {sj.JobId, sj.CandidateId });

            builder.Entity<CompanySkill>()
                .HasKey(ck => new { ck.SkillId, ck.CompanyId });

            builder.Entity<SavedJob>()
                .HasOne(sj => sj.Job)
                .WithMany(sj => sj.SavedJobs)
                .HasForeignKey(sj => sj.JobId);

            builder.Entity<SavedJob>()
                .HasOne(sj => sj.Candidate)
                .WithMany(sj => sj.SavedJobs)
                .HasForeignKey(sj => sj.CandidateId);

            builder.Entity<CompanySkill>()
                .HasOne(ck => ck.Skill)
                .WithMany(ck => ck.CompanySkills)
                .HasForeignKey(ck => ck.SkillId);

            builder.Entity<CompanySkill>()
                .HasOne(ck => ck.Company)
                .WithMany(ck => ck.CompanySkills)
                .HasForeignKey(ck => ck.CompanyId);

            builder.Entity<CandidateSkill>()
                .HasOne(ck => ck.Skill)
                .WithMany(ck => ck.CandidateSkills)
                .HasForeignKey(ck => ck.SkillId);

            builder.Entity<CandidateSkill>()
                .HasOne(ck => ck.Candidate)
                .WithMany(ck => ck.CandidateSkills)
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


            builder.Entity<Company>()
                .HasMany(c => c.Recruiters)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
