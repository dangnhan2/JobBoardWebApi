using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies(string searching);
        Task<CompanyByIdDto> GetById(Guid id);
        Task CreateCompany(CompanyAction company);
        Task UpdateCompany(Guid id, CompanyAction company);
        Task DeleteCompany(Guid id);
    }
}
