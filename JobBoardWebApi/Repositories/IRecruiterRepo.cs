using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;

namespace JobBoardWebApi.Repositories
{
    public interface IRecruiterRepo
    {
        Task<IEnumerable<RecruiterDto>> GetAllRecruiterAsync(RecruiterQueryParams recruiterParams);
        Task<RecruitersDto> GetByIdAsync(Guid id);
        Task CreateRecruiterAsync(RecruiterRequest recruiterPostDto);
        Task UpdateRecruiterAsync(Guid id, RecruiterPutRequest recruiterPostDto);
        Task DeleteRecruiterAsync(Guid id);
    }
}
