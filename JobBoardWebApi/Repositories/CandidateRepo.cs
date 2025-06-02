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

        public void DeleteSavedJob(SavedJob savedJob)
        {
            _context.SavedJobs.Remove(savedJob);
        }

        public IQueryable<Candidate> GetAll()
        {
            return _context.Candidates.AsQueryable();
        }

        public async Task<Candidate?> GetById(Guid id)
        {
            return await _context.Candidates
                  .Include(x => x.User)
                  .Include(c => c.candidateSkillMappings)
                    .ThenInclude(cs => cs.Skill)
                  .Include(c => c.Applications)
                    .ThenInclude(c => c.ApplicationJobMapping)
                    .ThenInclude(c => c.Job.Company)
                  .Include(c => c.SavedJobs)
                    .ThenInclude( c => c.Job.Company)
                  .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<SavedJob?> GetSavedJobById(Guid id)
        {
            return await _context.SavedJobs.FirstOrDefaultAsync(sj => sj.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SaveJob(SavedJob savedJob)
        {
            await _context.SavedJobs.AddAsync(savedJob);
        }

        public void Update(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
        }
    }
}
