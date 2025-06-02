using JobBoardWebApi.Dtos;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace JobBoardWebApi.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepo _jobRepo;

        public JobService(IJobRepo jobRepo) { 
          _jobRepo = jobRepo;
        }

        public async Task CreateJobAsync(JobRequest jobAction)
        {
            var jobs = _jobRepo.GetAllJob();

            if(await jobs.AnyAsync(j => j.Title == jobAction.Title))
            {
                throw new Exception("Job already exists");
            }

            var newJob = new Job
            {
                Title = jobAction.Title,
                Description = jobAction.Description,
                Location = jobAction.Location,
                Salary = jobAction.Salary,
                Status = StatusEnum.Pending.ToString(),
                Created_At = DateTime.UtcNow,
                SkillId = jobAction.SkillId,
                LevelId = jobAction.LevelId,
                CompanyId = jobAction.CompanyId,
            };

            await _jobRepo.Create(newJob);
            await _jobRepo.Save();
        }

        public async Task DeleteJobAsync(Guid id)
        {
            var isExistJob = await _jobRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found");
            
            _jobRepo.Delete(isExistJob);
            await _jobRepo.Save();
        }

        public async Task<IEnumerable<JobDto>> GetAllJobAsync(int page, int pageSize)
        {
            var jobs = _jobRepo.GetAllJob();

            var jobsToDto = await jobs.Select(j => new JobDto
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                Location = j.Location,
                Salary = j.Salary,
                Status = j.Status,
                Created_At = j.Created_At,
                Company = j.Company.Name,
                Level = j.Level.Name,
                Skill = j.Skill.Name,

            }).Paged(page, pageSize).ToListAsync();
            return  jobsToDto;
        }

        public async Task<IEnumerable<JobDto>> GetAllJobApprovedAsync(int page, int pageSize)
        {
            var jobs = _jobRepo.GetAllJob();

            var jobsToDto = await jobs.Where(j => j.Status == StatusEnum.Approved.ToString()).Select(j => new JobDto
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                Location = j.Location,
                Salary = j.Salary,
                Status = j.Status,
                Created_At = j.Created_At,
                Company = j.Company.Name,
                Level = j.Level.Name,
                Skill = j.Skill.Name,

            }).Paged(page, pageSize).ToListAsync();
            return jobsToDto;
        }

        public async Task<JobDto> GetByIdAsync(Guid id)
        {
            var isExistJob = await _jobRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found!");

            var jobToDto = new JobDto
            {
                Id = isExistJob.Id,
                Title = isExistJob.Title,
                Description = isExistJob.Description,
                Location = isExistJob.Location,
                Salary = isExistJob.Salary,
                Status = isExistJob.Status,
                Created_At = isExistJob.Created_At,
                Company = isExistJob.Company.Name,
                Level = isExistJob.Level.Name,
                Skill = isExistJob.Skill.Name,

            };
            return jobToDto;
        }

        public async Task UpdateJobForAdminAsync(Guid id, JobRequestForAdmin jobActionforAdmin)
        {
            var isExistJob = await _jobRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found");

            isExistJob.Status = jobActionforAdmin.Status;
            isExistJob.Updated_At = DateTime.UtcNow;

            _jobRepo.Update(isExistJob);
            await _jobRepo.Save();
        }

        public async Task UpdateJobForRecruiterAsync(Guid id, JobRequest jobAction)
        {
            var jobs = _jobRepo.GetAllJob();

            if (await jobs.AnyAsync(j => j.Title == jobAction.Title && j.Id != id))
            {
                throw new Exception("Job already exists");
            }

            var job = await _jobRepo.GetById(id) ?? throw new KeyNotFoundException("Id not found!");

            if (job.Status.Equals(StatusEnum.Approved))
            {
                throw new InvalidOperationException("Cannot update a job that has been approved.");
            }
            job.Title = jobAction.Title;
            job.Description = jobAction.Description;
            job.Location = jobAction.Location;
            job.Salary = jobAction.Salary;
            job.Updated_At = DateTime.UtcNow;
            job.LevelId = jobAction.LevelId;
            job.SkillId = jobAction.SkillId;

            _jobRepo.Update(job);

            await _jobRepo.Save();
        }

    }
}
