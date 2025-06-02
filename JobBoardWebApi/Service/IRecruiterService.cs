using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface IRecruiterService
    {
        Task<IEnumerable<RecruiterDto>> GetAllRecruiterAsync(int pageSize, int page);
        Task<RecruitersDto> GetByIdAsync(Guid id);
        Task CreateRecruiterAsync(RecruiterRequest recruiterPostDto);
        Task UpdateRecruiterAsync(Guid id, RecruiterPutRequest recruiterPostDto);
        Task DeleteRecruiterAsync(Guid id);
    }
}
