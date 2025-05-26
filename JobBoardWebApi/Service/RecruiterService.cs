using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepo _recruiterRepo;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RecruiterService(IRecruiterRepo recruiterRepo, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _recruiterRepo = recruiterRepo;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateRecruiter(RecruiterAction recruiterAction)
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
                Created_At = DateTime.UtcNow,
                EmailConfirmed = true
            };

            if (!await _roleManager.RoleExistsAsync(SD.Recruiter))
            {
                var role = new IdentityRole(SD.Recruiter);
                await _roleManager.CreateAsync(role);
            }

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

            await _recruiterRepo.Add(recruiter);
            await _recruiterRepo.Save();

        }
        public async Task DeleteRecruiter(Guid id)
        {
            var isExistRecruiter = await _recruiterRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found");

            _recruiterRepo.Delete(isExistRecruiter);

            await _userManager.DeleteAsync(isExistRecruiter.User);
            await _recruiterRepo.Save();
        }

        public async Task<IEnumerable<RecruiterDto>> GetAllRecruiter()
        {
            var recruiters = _recruiterRepo.GetAll();

           return await recruiters.Select(r => new RecruiterDto
           {
               Id = r.Id,
               Email = r.User.Email,
               UserName = r.User.UserName,
               Company = new CompanyDto
               {
                   Id = r.Company.Id,
                   Name = r.Company.Name,
               }
           }).ToListAsync();
        }

        public async Task<RecruiterDto> GetById(Guid id)
        {
            var isExistRecruiter = await _recruiterRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found");


            var result = new RecruiterDto
            {
                Id = isExistRecruiter.Id,
                Email = isExistRecruiter.User.Email,
                UserName = isExistRecruiter.User.UserName,
                Company = new CompanyDto
                {
                    Id = isExistRecruiter.Company.Id,
                    Name = isExistRecruiter.Company.Name,
                }
            };

            return result;
        }

        public async Task UpdateRecruiter(Guid id, RecruiterAction recruiterPostDto)
        {
            var isExistRecruiter = await _recruiterRepo.GetById(id) ?? throw new KeyNotFoundException("Recruiter not found");
            var isExistUser = await _userManager.FindByIdAsync(isExistRecruiter.UserId);

            isExistRecruiter.CompanyId = recruiterPostDto.CompanyId;

            isExistUser.Email = recruiterPostDto.Email;
            isExistUser.UserName = recruiterPostDto.UserName;
            isExistUser.PhoneNumber = recruiterPostDto.PhoneNumber;
            isExistUser.FullName = recruiterPostDto.FullName;

            _recruiterRepo.Update(isExistRecruiter);
            await _userManager.UpdateAsync(isExistUser);
            await _recruiterRepo.Save();
        }
    }
}
