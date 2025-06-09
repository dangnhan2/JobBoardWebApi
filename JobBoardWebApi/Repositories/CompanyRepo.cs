using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(CompanyQueryParams companyQueryParams);
        Task<CompanyByIdDto> GetByIdAsync(Guid id);
        Task CreateCompanyAsync(CompanyRequest company);
        Task UpdateCompanyAsync(Guid id, CompanyRequest company);
        Task DeleteCompanyAsync(Guid id);
    }

    public class CompanyRepo : ICompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepo(ApplicationDbContext context)
        {
            _context = context;
        }
            

        public async Task CreateCompanyAsync(CompanyRequest company)
        {

            var companies = _context.Companies.AsQueryable();

            if (await companies.AnyAsync(c => c.Name.ToLower().Trim() == company.Name.ToLower().Trim()))
            {
                throw new Exception("Company already exists");
            }

          

            var newCompany = new Company
            {
                Name = company.Name,
                LogoUrl = company.LogoUrl,
            };

            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(Guid id)
        {
            var isExist = await _context.Companies.FindAsync(id) ?? throw new KeyNotFoundException("Company not found!");

            _context.Companies.Remove(isExist);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(CompanyQueryParams companyQueryParams)
        {
            var companies = _context.Companies.AsQueryable();

            if (!string.IsNullOrEmpty(companyQueryParams.Name))
            {
                companies = companies.Where(c => c.Name.ToLower().Trim() == companyQueryParams.Name.ToLower().Trim());
            }

            var companiesToDto = companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name,
                LogoUrl = c.LogoUrl,
            }).Paged(companyQueryParams.Page, companyQueryParams.PageSize);
            return await companiesToDto.ToListAsync();
        }

        public async Task<CompanyByIdDto> GetByIdAsync(Guid id)
        {
            var isExist =  await _context.Companies
                .Include(c => c.Jobs).ThenInclude(c => c.Skill)
                .Include(c => c.Jobs).ThenInclude(c => c.Level)
                .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException("Company not found!");

            var companyDto = new CompanyByIdDto
            {
                Id = isExist.Id,
                Name = isExist.Name,
                Jobs = isExist.Jobs.Select(j => JobMapper.MapJobToDto(j)).ToList(),
            };

            return companyDto;
        }

        public async Task UpdateCompanyAsync(Guid id, CompanyRequest company)
        {
            var companies = _context.Companies.AsQueryable();

            if (await companies.AnyAsync(c => c.Name.ToLower().Trim() == company.Name.ToLower().Trim() && c.Id != id))
            {
                throw new Exception("Company already exists");
            }

            var isExistCompany = await _context.Companies.FindAsync(id) ?? throw new KeyNotFoundException("Company does not exist!");

            isExistCompany.Name = company.Name;
            isExistCompany.LogoUrl = company.LogoUrl;

            _context.Companies.Update(isExistCompany);
            await _context.SaveChangesAsync();
        }
    }
}

            
