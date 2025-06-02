using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationsDto>> GetAllApplicationsAsync(int page, int pageSize);
        Task<ApplicationDto> GetApplicationByIdAsync(Guid id);
        Task CreateApplicationAsync(ApplicationPostRequest application);
        Task UpdateApplicationForRecruiterAsync(Guid id, ApplicationPutRequest application);
        Task DeleteApplicationAsync(Guid id);
    }
}
