using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{

    public class LevelService : ILevelRepo
    {
        private readonly ApplicationDbContext _context;

        public LevelService(ApplicationDbContext context)
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

            return await levels.Select(l => new LevelsDto
            {   
                Id = l.Id,
                Name = l.Name,

            }).ToListAsync();
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
