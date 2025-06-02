using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepo(ApplicationDbContext context) { 
          _context = context;   
        }

        public async Task Create(Application application)
        {
            await _context.Applications.AddAsync(application);
        }

        public void Delete(Application application)
        {
            _context.Applications.Remove(application);
        }

        public IQueryable<Application> GetAll()
        {
           return _context.Applications.AsQueryable();
        }

        public async Task<Application?> GetById(Guid id)
        {
            return await _context.Applications.Include(a => a.Candidate).ThenInclude(a => a.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Application application)
        {
            _context.Applications.Update(application);
        }
    }
}
