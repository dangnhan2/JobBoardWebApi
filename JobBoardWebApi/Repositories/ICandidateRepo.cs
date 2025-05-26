using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface ICandidateRepo
    {
        IQueryable<Candidate> GetAll();
        Task<Candidate?> GetById(Guid id);
        Task Create(Candidate candidate);
        void Update(Candidate candidate);
        void Delete(Candidate candidate);
        Task SaveChanges();
    }
}
