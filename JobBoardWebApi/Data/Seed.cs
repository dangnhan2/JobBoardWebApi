using JobBoardWebApi.Migrations;
using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Data
{
    public class Seed
    {
        private readonly ModelBuilder _builder;

        public Seed(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void SeedInitialData()
        {
            _builder.Entity<Level>()
                .HasData(
                 new Level { Id = Guid.NewGuid(), Name = "Intern" },
                 new Level { Id = Guid.NewGuid(), Name = "Fresher" },
                 new Level { Id = Guid.NewGuid(), Name = "Junior" },
                 new Level { Id = Guid.NewGuid(), Name = "Middle" },
                 new Level { Id = Guid.NewGuid(), Name = "Senior" },
                 new Level { Id = Guid.NewGuid(), Name = "Leader" });

            _builder.Entity<Skill>()
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

            _builder.Entity<Company>()
                .HasData(
                new Company { Id = Guid.NewGuid(), Name = "FPT Software", LogoUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136395/fpt-software_uorpkb.png" },
                new Company { Id = Guid.NewGuid(), Name = "VNPT Technology", LogoUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136683/VNPT-logo_ngjek0.jpg" },
                new Company { Id = Guid.NewGuid(), Name = "KMS Technology", LogoUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136592/kms-logo_mnuae3.png" },
                new Company { Id = Guid.NewGuid(), Name = "Haravan", LogoUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136149/haranvan_l9df1x.png" });

            var adminRoleId = Guid.NewGuid().ToString();
            var recruiterRoleId = Guid.NewGuid().ToString();
            var candidateRoleId = Guid.NewGuid().ToString();

            _builder.Entity<IdentityRole>().HasData(
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

            _builder.Entity<User>().HasData(adminUser);

            // Assign Admin Role
            _builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });
        }
    }
}
