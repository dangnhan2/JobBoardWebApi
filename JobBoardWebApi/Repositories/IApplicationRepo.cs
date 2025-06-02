using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface IApplicationRepo
    {
        public IQueryable<Application> GetAll();
        public Task<Application?> GetById(Guid id);
        public Task Create(Application application);
        public void Update(Application application);
        public void Delete(Application application);
        public Task Save();
    }
}
