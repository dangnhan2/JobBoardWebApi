using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface IRecruiterRepo
    {
        public IQueryable<Recruiter> GetAll();
        public Task<Recruiter?> GetById(Guid id);
        public Task Add(Recruiter recruiter);
        public void Update (Recruiter recruiter);
        public void Delete(Recruiter recruiter);
        public Task Save();
    }
}
