using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepo _levelRepo;

        public LevelService(ILevelRepo levelRepo)
        {
            _levelRepo = levelRepo;
        }

        public async  Task AddLevel(LevelAction level)
        {
            var levels = _levelRepo.GetAll();

            if (await levels.AnyAsync(l => l.Name.ToLower() == level.Name.ToLower()))
            {
                throw new Exception("Level already exists");
            }

            var newLevel = new Level
            {
                Name = level.Name,
            };

           await _levelRepo.Add(newLevel);
           await _levelRepo.Save();
        }

        public async Task DeleteLevel(Guid id)
        {
            var isExist = await _levelRepo.GetById(id) ?? throw new KeyNotFoundException("Level not found!");

            _levelRepo.Delete(isExist);
            await _levelRepo.Save();
        }

        public async Task<IEnumerable<LevelsDto>> GetLevels()
        {
           var levels = _levelRepo.GetAll();

            return await levels.Select(l => LevelMapper.MapLevelToDto(l)).ToListAsync();
        }

        public async Task UpdateLevel(Guid id, LevelAction level)
        {
            var isExist = await _levelRepo.GetById(id) ?? throw new KeyNotFoundException("Level not found!");

            var levels =  _levelRepo.GetAll();

            if (await levels.AnyAsync(l => l.Name.ToLower() == level.Name.ToLower() && l.Id != id)) {
                throw new Exception("Level already exists");
            }

            isExist.Name = level.Name;

            _levelRepo.Update(isExist);
            await _levelRepo.Save();
        }
    }
}
