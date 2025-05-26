using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public class CandidateRepo : ICandidateRepo
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
        }

        public void Delete(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
        }

        public IQueryable<Candidate> GetAll()
        {
            return _context.Candidates.AsQueryable();
        }

        public async Task<Candidate?> GetById(Guid id)
        {
            return await _context.Candidates.Include(x => x.User).FirstOrDefaultAsync(c => c.Id == id);
            //return await _context.Candidates.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
        }
    }
}
