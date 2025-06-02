using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepo _companyRepo;
        private readonly IFileService _fileService;
        private readonly string directory = "logo";
        private readonly string[] allowedExtensions = [".jpg", ".jpeg", ".png"];

        public CompanyService(ICompanyRepo companyRepo, IFileService fileService)
        {
            _companyRepo = companyRepo;
            _fileService = fileService;
        }

        public async Task CreateCompany(CompanyRequest company)
        {

            var companies = _companyRepo.GetAll();

            if (await companies.AnyAsync(c => c.Name.ToLower().Trim() == company.Name.ToLower().Trim()))
            {
                throw new Exception("Company already exists");
            }

            if (company.file == null || company.file.Length == 0)
            {
                throw new ArgumentNullException(nameof(company.file), "File path cannot be null");
            }

            var extension = Path.GetExtension(company.file.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} extensions are allowed");
            }

            var fileString = _fileService.UploadImage(company.file, directory, allowedExtensions);

          

            var newCompany = new Company
            {
                Name = company.Name,
                LogoUrl = fileString,
            };

            await _companyRepo.Create(newCompany);
            await _companyRepo.Save();
        }

        public async Task DeleteCompany(Guid id)
        {
            var isExist = await _companyRepo.GetById(id) ?? throw new KeyNotFoundException("Company not found!");

            _fileService.DeleteImage(isExist.LogoUrl, directory);
            _companyRepo.Delete(isExist);
            await _companyRepo.Save();
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies( int page, int pageSize,string searching)
        {
            var companies = _companyRepo.GetAll();

            return await companies.Where(c => c.Name.ToLower().Trim().Contains(searching.ToLower().Trim()) || searching == "")
                .Select(c => CompanyMapper.MapCompanyToDto(c)).Paged(page, pageSize).ToListAsync();
        }

        public async Task<CompanyByIdDto> GetById(Guid id)
        {
            var isExist = await _companyRepo.GetById(id) ?? throw new KeyNotFoundException("Company not found!");

            var companyDto = new CompanyByIdDto
            {
                Id = isExist.Id,
                Name = isExist.Name,
                Jobs = isExist.Jobs.Select(j => JobMapper.MapJobToDto(j)).ToList(),
            };

            return companyDto;
        }

        public async Task UpdateCompany(Guid id, CompanyRequest company)
        {
            var companies = _companyRepo.GetAll();

            if (await companies.AnyAsync(c => c.Name.ToLower().Trim() == company.Name.ToLower().Trim() && c.Id != id))
            {
                throw new Exception("Company already exists");
            }

            var isExistCompany = await _companyRepo.GetById(id) ?? throw new KeyNotFoundException("Company does not exist!");

            var extension = Path.GetExtension(company.file.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} extensions are allowed");
            }

            if(company.file == null || company.file.Length == 0)
            {
                throw new ArgumentNullException(nameof(company.file), "File path cannot be null");
            }
            
                _fileService.DeleteImage(isExistCompany.LogoUrl, directory);

            var fileString = _fileService.UploadImage(company.file, directory, allowedExtensions);

            

            isExistCompany.Name = company.Name;
            isExistCompany.LogoUrl = fileString;
            _companyRepo.Update(isExistCompany);
            await _companyRepo.Save();
        }
    }
}
