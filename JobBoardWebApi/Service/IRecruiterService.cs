using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface IRecruiterService
    {
        Task<IEnumerable<RecruiterDto>> GetAllRecruiter();
        Task<RecruiterDto> GetById(Guid id);
        Task CreateRecruiter(RecruiterAction recruiterPostDto);
        Task UpdateRecruiter(Guid id, RecruiterAction recruiterPostDto);
        Task DeleteRecruiter(Guid id);
    }
}
