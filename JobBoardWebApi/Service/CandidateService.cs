using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.FlatDto;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class CandidateService : ICandidateRepo
    {
        private readonly ApplicationDbContext _context;
        
        private readonly UserManager<User> _userManager;

        public CandidateService(ApplicationDbContext context, UserManager<User> userManager)
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

            var candidatesToDto = candidates.Include(x => x.User).Select(x => new CandidatesDto { 
            
              Id = x.Id,
              FullName = x.User.FullName,
              UserName = x.User.UserName,
              Email = x.User.Email,
              Gender = x.Gender,
            }).Paged(candidateParams.Page, candidateParams.PageSize);

            return await candidatesToDto.AsNoTracking().ToListAsync();
        }

        

        public async Task<CandidateForIdDto?> GetCandidateByIdAsync(Guid id)
        {
            var flatResults = await _context.Set<CandidateFlatDto>()
                              .FromSqlRaw("EXEC GetCandidateById @CandidateID = {0}", id)
                              .AsNoTracking()
                              .ToListAsync();

            if (!flatResults.Any())
                throw new KeyNotFoundException("Candidate not found");

            var first = flatResults.First();

            var candidate = new CandidateForIdDto
            {
                Id = first.Id,
                FullName = first.FullName,
                UserName = first.UserName,
                Email = first.Email,
                Gender = first.Gender,
                PhoneNumber = first.PhoneNumber,
                ProfilePicUrl = first.ProfilePicUrl,
                Skills = flatResults
                  .Where(f => f.SkillId.HasValue) // chỉ add nếu có
                  .Select(f => new SkillDto
                    {
                      Id = f.SkillId.Value,
                      Name = f.SkillName
                    }).ToList()

            };

            return candidate;
        }

        public async Task UpdateCandidateAsync(Guid id, CandidateRequest candidate)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC UpdateCandidate @CandidateId={0}, @UserName={1}, @Email={2}, @PhoneNumber={3}, @FullName={4}, @Gender={5}, @ProfilePicUrl={6}",
                id,
                candidate.UserName,
                candidate.Email,
                candidate.PhoneNumber,
                candidate.FullName,
                candidate.Gender,
                candidate.ProfilePicUrl
                );

            foreach (var skillId in candidate.Skills)
            {
                _context.CandidateSkills.Add(new CandidateSkill
                { 
                    CandidateId = id,
                    SkillId = skillId
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveJobs(Guid id,SaveJobRequest saveJobRequest)
        {
            var isExistCandidate =  await _context.Candidates
                  .Include(c => c.SavedJobs)
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

            var jobs = new JobsTypeDto
            {
                AppliedJob = new List<JobType>(),
                SavedJob = new List<JobType>()
            };

            if(type.ToLower() == "appliedjob")
            {
                var appliedJobs = await _context.Set<JobType>().FromSqlRaw("EXEC GetAppliedJobsByCandidateId @CandidateId = {0}", id).AsNoTracking().ToListAsync();

                jobs.AppliedJob = appliedJobs.Where(a => a.Id.HasValue).ToList();
                return jobs;
            }

            var savedJobs = await _context.Set<JobType>().FromSqlRaw("EXEC GetSavedJobsByCandidateId @CandidateId={0}", id).AsNoTracking().ToListAsync();

            jobs.SavedJob = savedJobs.Where(s => s.Id.HasValue).ToList();

            return jobs;
        }

        public async Task CreateAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }
    }
}

