using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;

namespace JobBoardWebApi.Repositories
{
    public interface IJobRepo
    {
        public Task<IEnumerable<JobDto>> GetAllJobAsync(JobQueryParams jobParams);
        public Task<IEnumerable<JobDto>> GetAllJobApprovedAsync(JobQueryParams jobParams);
        public Task<JobDto> GetByIdAsync(Guid id);
        public Task CreateJobAsync(JobRequest jobAction);
        public Task UpdateJobForRecruiterAsync(Guid id, JobRequest jobAction);
        public Task UpdateJobForAdminAsync(Guid id, JobRequestForAdmin jobActionforAdmin);
        public Task DeleteJobAsync(Guid id);
        public Task<int> GetTotalApprovedAsync();
        public Task<int> GetTotalAsync();
    }
}
