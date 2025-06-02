using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies.AsQueryable();
        }

        public async Task<Company?> GetById(Guid id)
        {
            return await _context.Companies
                .Include(c => c.Jobs).ThenInclude(c => c.Skill)
                .Include(c => c.Jobs).ThenInclude(c => c.Level)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
