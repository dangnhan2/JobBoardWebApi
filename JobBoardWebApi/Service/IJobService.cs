using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Service
{
    public interface IJobService
    {
        public Task<IEnumerable<JobDto>> GetAllJobAsync(int page, int pageSize);
        public Task<IEnumerable<JobDto>> GetAllJobApprovedAsync(int page, int pageSize);
        public Task<JobDto> GetByIdAsync(Guid id);
        public Task CreateJobAsync(JobRequest jobAction);
        public Task UpdateJobForRecruiterAsync(Guid id, JobRequest jobAction);
        public Task UpdateJobForAdminAsync(Guid id, JobRequestForAdmin jobActionforAdmin);
        public Task DeleteJobAsync(Guid id);
        
    }
}
