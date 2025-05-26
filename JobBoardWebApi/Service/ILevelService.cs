using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface ILevelService
    {
        Task<IEnumerable<LevelsDto>> GetLevels();
        Task AddLevel(LevelAction level);
        Task UpdateLevel(Guid id, LevelAction level);
        Task DeleteLevel(Guid id);
    }
}
