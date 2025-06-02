using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface ILevelService
    {
        Task<IEnumerable<LevelsDto>> GetLevels();
        Task AddLevel(LevelRequest level);
        Task UpdateLevel(Guid id, LevelRequest level);
        Task DeleteLevel(Guid id);
    }
}
