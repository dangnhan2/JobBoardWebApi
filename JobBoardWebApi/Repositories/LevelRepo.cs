using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public class LevelRepo : ILevelRepo
    {
        private readonly ApplicationDbContext _context;

        public LevelRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Level level)
        {
            await _context.Levels.AddAsync(level);
        }

        public void Delete(Level level)
        {
            _context.Levels.Remove(level);
        }

        public IQueryable<Level> GetAll()
        {
            return _context.Levels.AsQueryable();
        }

        public void Update(Level level)
        {
            _context.Levels.Update(level);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Level?> GetById(Guid id)
        {
            return await _context.Levels.FindAsync(id);
        }
    }
}
