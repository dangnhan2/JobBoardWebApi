using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface ILevelRepo
    {
        IQueryable<Level> GetAll();
        Task<Level?> GetById(Guid id);
        Task Add(Level level);
        void Update(Level level);
        void Delete(Level level);
        Task Save();
    }
}

