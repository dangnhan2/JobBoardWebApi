using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.QueryParams;

namespace JobBoardWebApi.Repositories
{
    public interface ICompanyRepo
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(CompanyQueryParams companyQueryParams);
        Task<CompanyByIdDto> GetByIdAsync(Guid id);
        Task CreateCompanyAsync(CompanyRequest company);
        Task UpdateCompanyAsync(Guid id, CompanyRequest company);
        Task DeleteCompanyAsync(Guid id);
    }
}
