using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationJobMapping> ApplicationJobMappings { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationJobMapping>()
                .HasKey(aj =>new { aj.JobId, aj.ApplicationId});

            builder.Entity<ApplicationJobMapping>()
                .HasOne(aj => aj.Application)
                .WithMany(aj => aj.ApplicationJobs)
                .HasForeignKey(aj => aj.ApplicationId);

            builder.Entity<ApplicationJobMapping>()
                .HasOne(aj => aj.Job)
                .WithMany(aj => aj.ApplicationJobs)
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

            builder.Entity<Category>()
                .HasMany(c => c.Jobs)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
