using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.FlatDto;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Models;
using JobBoardWebApi.QueryParams;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class CompanyService : ICompanyRepo
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
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

            var flatResult = await _context.Set<CompanyFlatDto>().FromSqlRaw("EXEC GetCompanyById @CompanyId={0}", id).AsNoTracking().ToListAsync();

            Console.WriteLine(flatResult.Count);
            if (!flatResult.Any())
            {
                throw new KeyNotFoundException("Company not found!");
            }

            var first = flatResult.FirstOrDefault();

            var companyToDto = new CompanyByIdDto
            {
                Id = first.Id,
                Name = first.Company,
                Jobs = flatResult.Where(f => f.JobId.HasValue).Select(f => new JobDto
                {
                    Id = first.Id,
                    Title = first.Title,
                    Description = first.Description,
                    Location = first.Location,
                    Salary = first.Salary,
                    Status = first.Status,
                    Created_At = first.Created_At,
                    Company = first.Company,
                    Level = first.Level,
                    Skill = first.Skill,
                }).ToList()
            };
            return companyToDto;

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

            
