using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;

namespace JobBoardWebApi.Repositories
{
    public interface IApplicationRepo
    {
        Task<IEnumerable<ApplicationsDto>> GetAllApplicationsAsync(ApplicationQueryParams applicationParams);
        Task<ApplicationDto> GetApplicationByIdAsync(Guid id);
        Task CreateApplicationAsync(ApplicationPostRequest application);
        Task UpdateApplicationForRecruiterAsync(Guid id, ApplicationPutRequest application);
        Task DeleteApplicationAsync(Guid id);
    }
}
