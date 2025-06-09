using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{   
    public interface IUserService
    {
        public Task<T> GetUserId<T>(string id)  where T :class;
    }
    public class UserRepo : IUserService
    {
 
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepo( UserManager<User> userManager, ApplicationDbContext context) { 
          
            _userManager = userManager;
            _context = context;
        }

        public async Task<T> GetUserId<T>(string id) where T : class
        {
            var user = await _context.Users
                .Include(x => x.Candidate)
                   .ThenInclude(c => c.candidateSkillMappings)
                .Include(x => x.Recruiter)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var roles = await _userManager.GetRolesAsync(user);

            if(roles.FirstOrDefault() == SD.Recruiter)
            {
                var candidateInfo = new CandidateForIdDto
                {
                    Id = user.Candidate.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Gender = user.Candidate.Gender,
                    ProfilePicUrl = user.ProfilePicUrl,
                    Skills = user.Candidate.candidateSkillMappings.Select(c => new SkillDto
                    {
                        Id = c.SkillId,
                        Name = c.Skill.Name,
                    }).ToList()

                   
                };
                return candidateInfo as T;
            }

            var recruiterInfo = new RecruiterDto
            {
                Id = user.Recruiter.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                CompanyId = user.Recruiter.CompanyId,
                Company = user.Recruiter.Company.Name,
            };

            return recruiterInfo as T;
        }
    }
}
