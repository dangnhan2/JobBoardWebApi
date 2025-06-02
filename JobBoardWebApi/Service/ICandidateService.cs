using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidatesDto>> GetAllCandidatesAsync(int pageSize, int page);
        Task<CandidateForIdDto> GetCandidateByIdAsync(Guid id);
        Task UpdateCandidateAsync(Guid id, CandidateRequest candidate);
        Task DeleteCandidateAsync(Guid id);
        Task<JobsTypeDto> GetJobByCandidate(Guid id, string type);
        Task SaveJobs(Guid id, SaveJobRequest saveJobRequest);
        Task DeleteSavedJob(Guid id);
    }
}
