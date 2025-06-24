using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.FlatDto;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;


namespace JobBoardWebApi.Service
{

    public class RecruiterRepo : IRecruiterRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        public RecruiterRepo(ApplicationDbContext context, UserManager<User> userManager, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task CreateRecruiterAsync(RecruiterRequest recruiterAction)
        {

            if (await _userManager.FindByEmailAsync(recruiterAction.Email) != null)
            {
                throw new InvalidOperationException("Email already exists");
            }

            if (await _userManager.Users.AnyAsync(u => u.PhoneNumber == recruiterAction.PhoneNumber))
            {
                throw new InvalidOperationException("Phone number already exists");
            }


            var user = new User
            {
                UserName = recruiterAction.UserName,
                Email = recruiterAction.Email,
                FullName = recruiterAction.FullName,
                PhoneNumber = recruiterAction.PhoneNumber,
                ProfilePicUrl = "https://res.cloudinary.com/dtihvekmn/image/upload/v1749112264/user_vga2r2.png",
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(user, "123456");

            if (!createResult.Succeeded)
                throw new InvalidOperationException($"User creation failed: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");

            await _userManager.AddToRoleAsync(user, "Recruiter");


            var recruiter = new Recruiter
            {
                Id = Guid.NewGuid(),
                CompanyId = recruiterAction.CompanyId,
                UserId = user.Id,

            };

            await _context.Recruiters.AddAsync(recruiter);
            await _context.SaveChangesAsync();

            string emailBody = $@"
            <h2>Welcome {user.FullName},</h2>
            <p>Your account has been created.</p>
            <p><strong>Email:</strong> {user.Email}</p>
            <p><strong>Password:</strong> {123456}</p>
            <p>Please sign up and change your password.</p>
            <p>Thank you,</p>
            <p><em>MadoCoffee</em></p>";

            await _emailService.SendEmailAsync(user.Email, "Account Information", emailBody);

        }
        public async Task DeleteRecruiterAsync(Guid id)
        {
            var isExistRecruiter = await _context.Recruiters
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r => r.Id == id) ?? throw new KeyNotFoundException("Id not found");

            _context.Recruiters.Remove(isExistRecruiter);

            await _userManager.DeleteAsync(isExistRecruiter.User);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecruiterDto>> GetAllRecruiterAsync(RecruiterQueryParams recruiterParams)
        {
            var recruiters = _context.Recruiters.AsQueryable();

            if (!string.IsNullOrEmpty(recruiterParams.FullName))
            {
                recruiters = recruiters.Where(c => c.User.FullName.Trim().ToLower().Contains(recruiterParams.FullName.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(recruiterParams.Email))
            {
                recruiters = recruiters.Where(c => c.User.Email.ToLower().Contains(recruiterParams.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(recruiterParams.Phone))
            {
                recruiters = recruiters.Where(c => c.User.PhoneNumber.Contains(recruiterParams.Phone));
            }

            if (!string.IsNullOrEmpty(recruiterParams.Company))
            {
                recruiters = recruiters.Where(c => c.Company.Name.ToLower().Trim().Contains(recruiterParams.Company.ToLower().Trim()));
            }

            var recruitersToDto = recruiters.Select(r => new RecruiterDto
            {
                Id = r.Id,
                FullName = r.User.FullName,
                Email = r.User.Email!,
                UserName = r.User.UserName!,
                CompanyId = r.CompanyId,
                Company = r.Company.Name,
            }).Paged(recruiterParams.Page, recruiterParams.PageSize);

            return await recruitersToDto.ToListAsync();
        }

        public async Task<RecruitersDto> GetByIdAsync(Guid id)
        {

            var result = await _context.Set<RecruiterFlatDto>().FromSqlRaw("EXEC GetRecruiterById @RecruiterId={0}", id).AsNoTracking().FirstOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException("Id not found");
            }

            var recruiterToDto = new RecruitersDto
            {
                Id = result.Id,
                FullName = result.FullName,
                Email = result.Email,
                UserName = result.UserName,
                Company = new CompanyDto
                {
                    Id = result.CompanyId,
                    Name = result.Company,
                    LogoUrl = result.LogoUrl,
                }
            };
            

            return recruiterToDto;
        }

        public async Task UpdateRecruiterAsync(Guid id, RecruiterPutRequest recruiterPostDto)
        {
            await _context.Database
               .ExecuteSqlRawAsync("EXEC UpdateRecruiter @RecruiterId={0}, @CompanyId={1}, @Username={2}, @Email={3}, @FullName={4}, @PhoneNumber={5}, @ProfilePicUrl={6}",
               id,
               recruiterPostDto.CompanyId,
               recruiterPostDto.UserName,
               recruiterPostDto.Email,
               recruiterPostDto.FullName,
               recruiterPostDto.PhoneNumber,
               recruiterPostDto.ProfilePicUrl);

            await _context.Recruiters.AddAsync(new Recruiter
            {
                CompanyId = recruiterPostDto.CompanyId,
            });

            await _context.SaveChangesAsync();
        }
    }
}
