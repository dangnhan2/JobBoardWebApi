using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;


namespace JobBoardWebApi.Repositories
{
    public interface IRecruiterService
    {
        Task<IEnumerable<RecruiterDto>> GetAllRecruiterAsync(RecruiterQueryParams recruiterParams);
        Task<RecruitersDto> GetByIdAsync(Guid id);
        Task CreateRecruiterAsync(RecruiterRequest recruiterPostDto);
        Task UpdateRecruiterAsync(Guid id, RecruiterPutRequest recruiterPostDto);
        Task DeleteRecruiterAsync(Guid id);
    }

    public class RecruiterRepo : IRecruiterService
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

            await _userManager.AddToRoleAsync(user, SD.Recruiter);


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
                    .Include(r => r.Company)
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
            var isExistRecruiter =  await _context.Recruiters
                    .Include(r => r.Company)
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r => r.Id == id) ?? throw new KeyNotFoundException("Id not found");


            var result = new RecruitersDto
            {
                Id = isExistRecruiter.Id,
                FullName = isExistRecruiter.User.FullName,
                Email = isExistRecruiter.User.Email!,
                UserName = isExistRecruiter.User.UserName!,
                Company = new CompanyDto
                {
                    Id = isExistRecruiter.Company.Id,
                    Name = isExistRecruiter.Company.Name,
                }
            };
            

            return result;
        }

        public async Task UpdateRecruiterAsync(Guid id, RecruiterPutRequest recruiterPostDto)
        {
            var isExistRecruiter =  await _context.Recruiters
                    .Include(r => r.Company)
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r => r.Id == id) ?? throw new KeyNotFoundException("Recruiter not found");
            var isExistUser = await _userManager.FindByIdAsync(isExistRecruiter.UserId);

            isExistRecruiter.CompanyId = recruiterPostDto.CompanyId;

            isExistUser.Email = recruiterPostDto.Email;
            isExistUser.UserName = recruiterPostDto.UserName;
            isExistUser.PhoneNumber = recruiterPostDto.PhoneNumber;
            isExistUser.FullName = recruiterPostDto.FullName;
            isExistUser.ProfilePicUrl = recruiterPostDto.ProfilePicUrl;

            _context.Recruiters.Update(isExistRecruiter);
            await _userManager.UpdateAsync(isExistUser);
            await _context.SaveChangesAsync();
        }
    }
}
