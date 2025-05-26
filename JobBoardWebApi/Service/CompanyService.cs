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

        public CompanyService(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task CreateCompany(CompanyAction company)
        {
            var companies = _companyRepo.GetAll();

            if (await companies.AnyAsync(c => c.Name.ToLower().Trim() == company.Name.ToLower().Trim())) {
                throw new Exception("Company already exists");
            }

            var newCompany = new Company
            {
                Name = company.Name,
            };

            await _companyRepo.Create(newCompany);
            await _companyRepo.Save();
        }

        public async Task DeleteCompany(Guid id)
        {
            var isExist = await _companyRepo.GetById(id) ?? throw new KeyNotFoundException("Company not found!");

            _companyRepo.Delete(isExist);
            await _companyRepo.Save();
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies(string searching)
        {
            var companies = _companyRepo.GetAll();

            return await companies.Where(c => c.Name.ToLower().Trim().Contains(searching.ToLower().Trim()) || searching == "")
                .Select(c => CompanyMapper.MapCompanyToDto(c)).ToListAsync();
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

        public async Task UpdateCompany(Guid id, CompanyAction company)
        {
            var companies = _companyRepo.GetAll();

            if (await companies.AnyAsync(c => c.Name.ToLower().Trim() == company.Name.ToLower().Trim() && c.Id != id)) {
                throw new Exception("Company already exists");
            }

            var isExistCompany = await _companyRepo.GetById(id) ?? throw new KeyNotFoundException("Company does not exist!");

            isExistCompany.Name = company.Name;
            _companyRepo.Update(isExistCompany);
            await _companyRepo.Save();
        }
    }
}
