using JobBoardWebApi.Dtos;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Service
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies(int page, int pageSize, string searching);
        Task<CompanyByIdDto> GetById(Guid id);
        Task CreateCompany(CompanyRequest company);
        Task UpdateCompany(Guid id, CompanyRequest company);
        Task DeleteCompany(Guid id);
    }
}
