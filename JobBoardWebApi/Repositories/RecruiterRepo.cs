using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public class RecruiterRepo : IRecruiterRepo
    {
        private readonly ApplicationDbContext _context;

        public RecruiterRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Recruiter recruiter)
        {
            await _context.Recruiters.AddAsync(recruiter);
        }

        public void Delete(Recruiter recruiter)
        {
            _context.Recruiters.Remove(recruiter);
        }

        public IQueryable<Recruiter> GetAll()
        {
            return _context.Recruiters.AsQueryable();
        }

        public async Task<Recruiter?> GetById(Guid id)
        {
            return await _context.Recruiters
                    .Include(r => r.Company)
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Recruiter recruiter)
        {
            _context.Recruiters.Update(recruiter);
        }
    }
}
