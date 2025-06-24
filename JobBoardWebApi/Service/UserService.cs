using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.FlatDto;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{   
    public interface IUserService
    {
        public Task<object> CreateDtoAsync(User user);
    }
    public class UserService : IUserService
    {
 
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
       

        public UserService( UserManager<User> userManager, ApplicationDbContext context) { 
          
            _userManager = userManager;
            _context = context;
        }

        public async Task<object> CreateDtoAsync(User user)
        {
            // 1. Role
            var roles = await _userManager.GetRolesAsync(user);      // List<string>
            var role = roles.FirstOrDefault();

            object? profile = null;
            
            switch (role)
            {
                case "Candidate":
                    var candidateFlatDtos = await _context.Set<CandidateFlatDto>()
                              .FromSqlRaw("EXEC GetCandidateByUserId @UserId = {0}", user.Id)
                              .AsNoTracking()
                              .ToListAsync();

                    var candidateToDto = candidateFlatDtos.First();

                    profile = new CandidateForIdDto
                    {
                        Id = candidateToDto.Id,
                        FullName = candidateToDto.FullName,
                        UserName = candidateToDto.UserName,
                        Email = candidateToDto.Email,
                        Gender = candidateToDto.Gender,
                        PhoneNumber = candidateToDto.PhoneNumber,
                        ProfilePicUrl = candidateToDto.ProfilePicUrl,
                        Skills = candidateFlatDtos
                          .Where(f => f.SkillId.HasValue) // chỉ add nếu có
                          .Select(f => new SkillDto
                          {
                              Id = f.SkillId.Value,
                              Name = f.SkillName
                          }).ToList()

                    };
                    break;

                case "Recruiter":
                    var recruiterFlatDtos = await _context.Set<RecruiterFlatDto>().FromSqlRaw("EXEC GetRecruiterByUserId @UserId={0}", user.Id).AsNoTracking().ToListAsync();

                    var recruiterToDto = recruiterFlatDtos.First();

                    profile = new RecruitersDto
                    {
                        Id = recruiterToDto.Id,
                        FullName = recruiterToDto.FullName,
                        Email = recruiterToDto.Email,
                        UserName = recruiterToDto.UserName,
                        ProfilePicUrl = recruiterToDto.ProfilePirUrl,
                        Company = new CompanyDto
                        {
                            Id = recruiterToDto.CompanyId,
                            Name = recruiterToDto.Company,
                            LogoUrl = recruiterToDto.LogoUrl,
                        }
                    };
                    break;

                case "Admin":
                    var adminFlatDto = await _context.Set<AdminFlatDto>().FromSqlRaw("EXEC GetAdminByUserId @UserId={0}",user.Id).AsNoTracking().ToListAsync();

                    profile = adminFlatDto.First();
                    break;
            }         

            // 4. Build DTO
            return profile;
        }
    }
}
