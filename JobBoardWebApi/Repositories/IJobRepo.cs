using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface IJobRepo
    {
        public IQueryable<Job> GetAllJob();
        public Task<Job?> GetById(Guid id);
        public Task Create(Job job);
        public void Update(Job job);
        public void Delete(Job job);
        public Task Save();
    }
}
