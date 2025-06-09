using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidatesDto>> GetAllCandidatesAsync(CandidateQueryParams candidateParams);
        Task CreateAsync(Candidate candidate);
        Task<CandidateForIdDto> GetCandidateByIdAsync(Guid id);
        Task UpdateCandidateAsync(Guid id, CandidateRequest candidate);
        Task DeleteCandidateAsync(Guid id);
        Task<JobsTypeDto> GetJobByCandidate(Guid id, string type);
        Task SaveJobs(Guid id, SaveJobRequest saveJobRequest);
        Task DeleteSavedJob(Guid id);
    }

    public class CandidateRepo : ICandidateService
    {
        private readonly ApplicationDbContext _context;
        
        private readonly UserManager<User> _userManager;

        public CandidateRepo(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task DeleteCandidateAsync(Guid id)
        {
            var isExist = await _context.Candidates.FindAsync(id) ?? throw new KeyNotFoundException("Candidate not found!");

            _context.Candidates.Remove(isExist);
            await _userManager.DeleteAsync(isExist.User);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CandidatesDto>> GetAllCandidatesAsync(CandidateQueryParams candidateParams)
        {
            var candidates = _context.Candidates.AsQueryable();

            if (!string.IsNullOrEmpty(candidateParams.FullName))
            {
                candidates = candidates.Where(c => c.User.FullName.Trim().ToLower().Contains(candidateParams.FullName.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(candidateParams.Email))
            {
                candidates = candidates.Where(c => c.User.Email.ToLower().Contains(candidateParams.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(candidateParams.Phone))
            {
                candidates = candidates.Where(c => c.User.PhoneNumber.Contains(candidateParams.Phone));
            }

            var candidatesToDto = candidates.Include(x => x.User).Select(x => CandidateMapper.MapCandidateToDto(x)).Paged(candidateParams.Page, candidateParams.PageSize);

            return await candidatesToDto.ToListAsync();
        }

        public async Task<CandidateForIdDto> GetCandidateByIdAsync(Guid id)
        {
            var isExist = await _context.Candidates
                  .Include(x => x.User)
                  .Include(c => c.candidateSkillMappings)
                    .ThenInclude(cs => cs.Skill)
                  .Include(c => c.Applications)
                    .ThenInclude(c => c.ApplicationJobMapping)
                    .ThenInclude(c => c.Job.Company)
                  .Include(c => c.SavedJobs)
                    .ThenInclude(c => c.Job.Company)
                  .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException("Candidate not found!");

            //Console.WriteLine(isExist.candidateSkillMappings.ToList());

            var candidateForId = new CandidateForIdDto
            {
                Id = isExist.Id,
                FullName = isExist.User.FullName,
                UserName = isExist.User.UserName,
                Email = isExist.User.Email,
                Gender = isExist.Gender,
                ProfilePicUrl = isExist.User.ProfilePicUrl,
                Skills =  isExist.candidateSkillMappings
                .Select(s => new SkillDto
                {
                    Name = s.Skill.Name,
                }).ToList(),

            };

            return candidateForId;

        }

        public async Task UpdateCandidateAsync(Guid id, CandidateRequest candidate)
        {
            var isExist = await _context.Candidates
                  .Include(x => x.User)
                  .Include(c => c.candidateSkillMappings)
                    .ThenInclude(cs => cs.Skill)
                  .Include(c => c.Applications)
                    .ThenInclude(c => c.ApplicationJobMapping)
                    .ThenInclude(c => c.Job.Company)
                  .Include(c => c.SavedJobs)
                    .ThenInclude(c => c.Job.Company)
                  .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException("Candidate not found!");

            isExist.User.ProfilePicUrl = candidate.ProfilePicUrl;
            isExist.User.UserName = candidate.UserName;
            isExist.User.Email = candidate.Email;
            isExist.User.NormalizedEmail = candidate.Email;
            isExist.User.PhoneNumber = candidate.PhoneNumber;
            isExist.User.FullName = candidate.FullName;
            isExist.Gender = candidate.Gender;
            isExist.candidateSkillMappings = new List<CandidateSkillMapping>();

            foreach(var skillId in candidate.Skills)
            {
                isExist.candidateSkillMappings.Add(new CandidateSkillMapping
                { 
                    CandidateId = isExist.Id,
                    SkillId = skillId
                });
            }

            _context.Candidates.Update(isExist);
            await _context.SaveChangesAsync();
        }

        public async Task SaveJobs(Guid id,SaveJobRequest saveJobRequest)
        {
            var isExistCandidate =  await _context.Candidates
                  .Include(x => x.User)
                  .Include(c => c.candidateSkillMappings)
                    .ThenInclude(cs => cs.Skill)
                  .Include(c => c.Applications)
                    .ThenInclude(c => c.ApplicationJobMapping)
                    .ThenInclude(c => c.Job.Company)
                  .Include(c => c.SavedJobs)
                    .ThenInclude(c => c.Job.Company)
                  .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException("Candidate not found");

            var jobSaved = new SavedJob
            {  
                Id = Guid.NewGuid(),
                JobId = saveJobRequest.JobId,
            };

            isExistCandidate.SavedJobs.Add(jobSaved);

            _context.Candidates.Update(isExistCandidate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSavedJob(Guid id)
        {
            var isExistSavedJob = await _context.SavedJobs.FirstOrDefaultAsync(sj => sj.Id == id) ?? throw new KeyNotFoundException("Job not found");

            _context.SavedJobs.Remove(isExistSavedJob);

            await _context.SaveChangesAsync();
        }

        public async Task<JobsTypeDto> GetJobByCandidate(Guid id, string type)
        {
            var candidate =  await _context.Candidates
                  .Include(x => x.User)
                  .Include(c => c.candidateSkillMappings)
                    .ThenInclude(cs => cs.Skill)
                  .Include(c => c.Applications)
                    .ThenInclude(c => c.ApplicationJobMapping)
                    .ThenInclude(c => c.Job.Company)
                  .Include(c => c.SavedJobs)
                    .ThenInclude(c => c.Job.Company)
                  .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException("Candidate not found");

            var jobs = new JobsTypeDto
            {
                AppliedJob = new HashSet<JobType>(),
                SavedJob = new HashSet<JobType>()
            };

            if(type.ToLower() == "appliedjob")
            {
                foreach(var appliedJob in candidate.Applications)
                {   
                    foreach(var job in appliedJob.ApplicationJobMapping)
                    {
                        jobs.AppliedJob.Add(new JobType
                        {
                            Id = job.JobId,
                            Title = job.Job.Title,
                            LogoUrl = job.Job.Company.LogoUrl,
                            Location = job.Job.Location,
                            Salary = job.Job.Salary,
                        });
                    }
                }

                jobs.SavedJob = null;
                return jobs;
            }
               

            foreach(var savedJob in candidate.SavedJobs)
            {
                jobs.SavedJob.Add(new JobType
                {
                    Id = savedJob.JobId,
                    Title = savedJob.Job.Title,
                    LogoUrl = savedJob.Job.Company.LogoUrl,
                    Location = savedJob.Job.Location,
                    Salary = savedJob.Job.Salary,
                });
            }

            //Console.Write(jobs.SavedJob);
            jobs.AppliedJob = null;

            return jobs;
        }

        public async Task CreateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }
    }
}
                            
              


