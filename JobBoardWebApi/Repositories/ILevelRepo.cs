using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Repositories
{
    public interface ILevelRepo
    {
        Task<IEnumerable<LevelsDto>> GetLevels();
        Task AddLevel(LevelRequest level);
        Task UpdateLevel(Guid id, LevelRequest level);
        Task DeleteLevel(Guid id);
    }
}
