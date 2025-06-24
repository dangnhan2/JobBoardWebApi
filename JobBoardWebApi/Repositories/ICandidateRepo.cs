using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;

namespace JobBoardWebApi.Repositories
{
    public interface ICandidateRepo
    {
        Task<IEnumerable<CandidatesDto>> GetAllCandidatesAsync(CandidateQueryParams candidateParams);
        Task CreateAsync(Candidate candidate);
        Task<CandidateForIdDto?> GetCandidateByIdAsync(Guid id);
        Task UpdateCandidateAsync(Guid id, CandidateRequest candidate);
        Task DeleteCandidateAsync(Guid id);
        Task<JobsTypeDto> GetJobByCandidate(Guid id, string type);
        Task SaveJobs(Guid id, SaveJobRequest saveJobRequest);
        Task DeleteSavedJob(Guid id);
    }
}
