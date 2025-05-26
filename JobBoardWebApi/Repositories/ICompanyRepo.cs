using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface ICompanyRepo
    {
        IQueryable<Company> GetAll();
        Task<Company?> GetById(Guid id);
        Task Create(Company company);
        void Update(Company company);
        void Delete(Company company);
        Task Save();
    }
}
