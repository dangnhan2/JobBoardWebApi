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

            builder.Entity<Company>()
                .HasData(
                new Company {Id = Guid.NewGuid(), Name = "FPT Software", LogoUrl= "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136395/fpt-software_uorpkb.png" },
                new Company {Id = Guid.NewGuid(), Name = "VNPT Technology", LogoUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136683/VNPT-logo_ngjek0.jpg" },
                new Company {Id = Guid.NewGuid(), Name = "KMS Technology", LogoUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136592/kms-logo_mnuae3.png" },
                new Company {Id = Guid.NewGuid(), Name = "Haravan", LogoUrl= "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136149/haranvan_l9df1x.png" });

            var adminRoleId = Guid.NewGuid().ToString();
            var recruiterRoleId = Guid.NewGuid().ToString();
            var candidateRoleId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = recruiterRoleId, Name = "Recruiter", NormalizedName = "RECRUITER" },
                new IdentityRole { Id = candidateRoleId, Name = "Candidate", NormalizedName = "CANDIDATE" }
            );

            var adminUserId = Guid.NewGuid().ToString(); // static GUID or string
            var adminEmail = "admin@example.com";
            var hasher = new PasswordHasher<User>();

            var adminUser = new User
            {
                Id = adminUserId,
                FullName = "admin",
                ProfilePicUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749112264/user_vga2r2.png",
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"), // use strong password
                SecurityStamp = string.Empty
            };

            builder.Entity<User>().HasData(adminUser);

            // Assign Admin Role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });

        }
    }
}
