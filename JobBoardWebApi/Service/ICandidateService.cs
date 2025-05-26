using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateDto>> GetAllCandidates();
        Task<CandidateForIdDto> GetCandidateById(Guid id);
        Task UpdateCandidate(Guid id, CandidateAction candidate);
        Task DeleteCandidate(Guid id);
    }
}
