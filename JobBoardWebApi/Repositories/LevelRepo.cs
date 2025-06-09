using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public interface ILevelService
    {
        Task<IEnumerable<LevelsDto>> GetLevels();
        Task AddLevel(LevelRequest level);
        Task UpdateLevel(Guid id, LevelRequest level);
        Task DeleteLevel(Guid id);
    }

    public class LevelRepo : ILevelService
    {
        private readonly ApplicationDbContext _context;

        public LevelRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task AddLevel(LevelRequest level)
        {
            var levels = _context.Levels.AsQueryable();

            if (await levels.AnyAsync(l => l.Name.ToLower() == level.Name.ToLower()))
            {
                throw new Exception("Level already exists");
            }

            var newLevel = new Level
            {
                Name = level.Name,
            };

           await _context.Levels.AddAsync(newLevel);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteLevel(Guid id)
        {
            var isExist = await _context.Levels.FindAsync(id) ?? throw new KeyNotFoundException("Level not found!");

            _context.Levels.Remove(isExist);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LevelsDto>> GetLevels()
        {
           var levels = _context.Levels.AsQueryable();

            return await levels.Select(l => LevelMapper.MapLevelToDto(l)).ToListAsync();
        }

        public async Task UpdateLevel(Guid id, LevelRequest level)
        {
            var isExist = await _context.Levels.FindAsync(id) ?? throw new KeyNotFoundException("Level not found!");

            var levels = _context.Levels.AsQueryable();

            if (await levels.AnyAsync(l => l.Name.ToLower() == level.Name.ToLower() && l.Id != id)) {
                throw new Exception("Level already exists");
            }

            isExist.Name = level.Name;

            _context.Levels.Update(isExist);
            await _context.SaveChangesAsync();
        }
    }
}
