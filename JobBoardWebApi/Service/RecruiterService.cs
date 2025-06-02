using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobBoardWebApi.Service
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepo _recruiterRepo;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IFileService _fileService;
        private readonly string directory = "profilepic";
        private readonly string[] allowedExtensions = [".jpg", ".jpeg", ".png"];
        public RecruiterService(IRecruiterRepo recruiterRepo, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IFileService fileService)
        {
            _recruiterRepo = recruiterRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _fileService = fileService;
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
                Created_At = DateTime.UtcNow,
                ProfilePicUrl = "user.png",
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
        public async Task DeleteRecruiterAsync(Guid id)
        {
            var isExistRecruiter = await _recruiterRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found");

            if(isExistRecruiter.User.ProfilePicUrl == "user.png")
            _fileService.DeleteImage(isExistRecruiter.User.ProfilePicUrl, directory);
            _recruiterRepo.Delete(isExistRecruiter);

            await _userManager.DeleteAsync(isExistRecruiter.User);
            await _recruiterRepo.Save();
        }

        public async Task<IEnumerable<RecruiterDto>> GetAllRecruiterAsync(int page , int pageSize)
        {
            var recruiters = _recruiterRepo.GetAll();

            var recruitersToDto = recruiters.Select(r => new RecruiterDto
            {
                Id = r.Id,
                FullName = r.User.FullName,
                Email = r.User.Email!,
                UserName = r.User.UserName!,
                Company = r.Company.Name,
            }).Paged(page, pageSize);

            return await recruitersToDto.ToListAsync();
        }

        public async Task<RecruitersDto> GetByIdAsync(Guid id)
        {
            var isExistRecruiter = await _recruiterRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found");


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
            var isExistRecruiter = await _recruiterRepo.GetById(id) ?? throw new KeyNotFoundException("Recruiter not found");
            var isExistUser = await _userManager.FindByIdAsync(isExistRecruiter.UserId);

            var extension = Path.GetExtension(recruiterPostDto.file.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} extensions are allowed");
            }

            if (recruiterPostDto.file == null || recruiterPostDto.file.Length == 0)
            {
                throw new ArgumentNullException(nameof(recruiterPostDto.file), "File path cannot be null");
            }

            _fileService.DeleteImage(isExistUser.ProfilePicUrl, directory);

            var fileString = _fileService.UploadImage(recruiterPostDto.file, directory, allowedExtensions);

            isExistRecruiter.CompanyId = recruiterPostDto.CompanyId;

            isExistUser.Email = recruiterPostDto.Email;
            isExistUser.UserName = recruiterPostDto.UserName;
            isExistUser.PhoneNumber = recruiterPostDto.PhoneNumber;
            isExistUser.FullName = recruiterPostDto.FullName;
            isExistUser.ProfilePicUrl = fileString;

            _recruiterRepo.Update(isExistRecruiter);
            await _userManager.UpdateAsync(isExistUser);
            await _recruiterRepo.Save();
        }
    }
}
