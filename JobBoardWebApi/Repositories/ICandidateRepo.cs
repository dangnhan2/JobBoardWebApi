using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface ICandidateRepo
    {
        IQueryable<Candidate> GetAll();
        Task<Candidate?> GetById(Guid id);
        Task<SavedJob?> GetSavedJobById(Guid id);
        Task Create(Candidate candidate);
        Task SaveJob(SavedJob savedJob);
        void Update(Candidate candidate);
        void Delete(Candidate candidate);
        void DeleteSavedJob(SavedJob savedJob);
        Task SaveChanges();
    }
}

