using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobBoardWebApi.Repositories
{
    public class JobRepo : IJobRepo
    {
        private readonly ApplicationDbContext _context;

        public JobRepo(ApplicationDbContext context) { 
          _context = context;
        }

        public async Task Create(Job job)
        {
          await _context.Jobs.AddAsync(job);
        }

        public void Delete(Job job)
        {
            _context.Jobs.Remove(job);
        }

        public IQueryable<Job> GetAllJob()
        {
           return _context.Jobs.AsQueryable();
        }

        public async Task<Job?> GetById(Guid id)
        {
            return await _context.Jobs.Include(j => j.Company).Include(j => j.Level).Include(j => j.Skill).FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Job job)
        {
           _context.Jobs.Update(job);
        }
    }
}
