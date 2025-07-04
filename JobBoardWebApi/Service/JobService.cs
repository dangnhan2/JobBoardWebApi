﻿using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;


namespace JobBoardWebApi.Service
{

    public class JobService : IJobRepo
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task CreateJobAsync(JobRequest jobAction)
        {
            var jobs = _context.Jobs.AsQueryable();

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
                Status = StatusEnum.Pending,
                SkillId = jobAction.SkillId,
                LevelId = jobAction.LevelId,
                CompanyId = jobAction.CompanyId,
            };

            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(Guid id)
        {
            var isExistJob = await _context.Jobs.FindAsync(id) ?? throw new KeyNotFoundException("Job not found");

            _context.Jobs.Remove(isExistJob);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobDto>> GetAllJobAsync(JobQueryParams jobParams)
        {
            var jobs = _context.Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(jobParams.Title))
            {
                jobs = jobs.Where(j => j.Title.Trim().ToLower().Contains(jobParams.Title.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Location))
            {
                jobs = jobs.Where(j => j.Location.Trim().ToLower().Contains(jobParams.Location.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Skill))
            {
                jobs = jobs.Where(j => j.Skill.Name.ToLower().Contains(jobParams.Skill.ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Level))
            {
                jobs = jobs.Where(j => j.Level.Name.ToLower().Contains(jobParams.Level.ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Company))
            {
                jobs = jobs.Where(j => j.Company.Name.ToLower().Contains(jobParams.Company.ToLower()));
            }


            var jobsToDto =  jobs.Select(j => new JobDto
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

            }).Paged(jobParams.Page, jobParams.PageSize);

            return  await jobsToDto.ToListAsync();
        }

        public async Task<IEnumerable<JobDto>> GetAllJobApprovedAsync(JobQueryParams jobParams)
        {
            var jobs = _context.Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(jobParams.Title))
            {
                jobs = jobs.Where(j => j.Title.Trim().ToLower().Contains(jobParams.Title.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Location))
            {
                jobs = jobs.Where(j => j.Location.Trim().ToLower().Contains(jobParams.Location.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Skill))
            {
                jobs = jobs.Where(j => j.Skill.Name.ToLower().Contains(jobParams.Skill.ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Level))
            {
                jobs = jobs.Where(j => j.Level.Name.ToLower().Contains(jobParams.Level.ToLower()));
            }

            if (!string.IsNullOrEmpty(jobParams.Company))
            {
                jobs = jobs.Where(j => j.Company.Name.ToLower().Contains(jobParams.Company.ToLower()));
            }

            var jobsToDto = await jobs.Where(j => j.Status == StatusEnum.Approved).Select(j => new JobDto
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

            }).Paged(jobParams.Page, jobParams.PageSize).ToListAsync();
            return jobsToDto;
        }

        public async Task<JobDto> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<JobDto>().FromSqlRaw("EXEC GetJobById @JobId={0}", id).AsNoTracking().FirstOrDefaultAsync();

           if(result == null)
            {
                throw new KeyNotFoundException("Job not found!");
            }

            return result;
        }

        public async Task UpdateJobForAdminAsync(Guid id, JobRequestForAdmin jobActionforAdmin)
        {
            var isExistJob = await _context.Jobs.FindAsync(id) ?? throw new KeyNotFoundException("Id not found");

            isExistJob.Status = jobActionforAdmin.Status;
            isExistJob.Updated_At = DateTime.UtcNow;

            _context.Jobs.Update(isExistJob);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobForRecruiterAsync(Guid id, JobRequest jobAction)
        {
            var jobs = _context.Jobs.AsQueryable();

            if (await jobs.AnyAsync(j => j.Title == jobAction.Title && j.Id != id))
            {
                throw new Exception("Job already exists");
            }

            var job = await _context.Jobs.Include(j => j.Company).Include(j => j.Level).Include(j => j.Skill).FirstOrDefaultAsync(j => j.Id == id) ?? throw new KeyNotFoundException("Id not found!");

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

            _context.Jobs.Update(job);

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalApprovedAsync()
        {
            return await _context.Jobs.Where(j => j.Status.Equals(StatusEnum.Approved)).CountAsync();
        }

        public async Task<int> GetTotalAsync()
        {
            return await _context.Jobs.CountAsync();
        }
    }
}
