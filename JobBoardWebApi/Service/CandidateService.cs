using JobBoardWebApi.Dtos;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepo _candidateRepo;
        
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;
        private readonly string directory = "profilepic";
        private readonly string[] allowedExtensions = [".jpg", ".jpeg", ".png"];

        public CandidateService(ICandidateRepo candidateRepo, UserManager<User> userManager, IFileService fileService)
        {
            _candidateRepo = candidateRepo;
            _userManager = userManager;
            _fileService = fileService;
          
        }

        public async Task DeleteCandidateAsync(Guid id)
        {
            var isExist = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found!");

            if (!isExist.User.ProfilePicUrl.Contains("user.png"))
            {
                _fileService.DeleteImage(isExist.User.ProfilePicUrl, directory);
            }

            _candidateRepo.Delete(isExist);
            await _userManager.DeleteAsync(isExist.User);

            await _candidateRepo.SaveChanges();
        }

        public async Task<IEnumerable<CandidatesDto>> GetAllCandidatesAsync(int page, int pageSize)
        {
            var candidates = _candidateRepo.GetAll();

            var candidatesToDto = candidates.Include(x => x.User).Select(x => CandidateMapper.MapCandidateToDto(x)).Paged(page, pageSize);
            return await candidatesToDto.ToListAsync();
        }

        public async Task<CandidateForIdDto> GetCandidateByIdAsync(Guid id)
        {
            var isExist = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found!");

            Console.WriteLine(isExist.candidateSkillMappings.ToList());

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
            var isExist = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found!");

            var extension = Path.GetExtension(candidate.File.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} extensions are allowed");
            }

            if (candidate.File == null || candidate.File.Length == 0)
            {
                throw new ArgumentNullException(nameof(candidate.File), "File path cannot be null");
            }


            if (!isExist.User.ProfilePicUrl.Contains("user.png"))
            {
                _fileService.DeleteImage(isExist.User.ProfilePicUrl, directory);
            }

            var fileString = _fileService.UploadImage(candidate.File, directory, allowedExtensions);

            isExist.User.ProfilePicUrl = fileString;
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

            _candidateRepo.Update(isExist);
            await _candidateRepo.SaveChanges();
        }

        public async Task SaveJobs(Guid id,SaveJobRequest saveJobRequest)
        {
            var isExistCandidate = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found");

            var jobSaved = new SavedJob
            {  
                Id = Guid.NewGuid(),
                JobId = saveJobRequest.JobId,
            };

            isExistCandidate.SavedJobs.Add(jobSaved);

            _candidateRepo.Update(isExistCandidate);
            await _candidateRepo.SaveChanges();
        }

        public async Task DeleteSavedJob(Guid id)
        {
            var isExistSavedJob = await _candidateRepo.GetSavedJobById(id) ?? throw new KeyNotFoundException("Job not found");

            _candidateRepo.DeleteSavedJob(isExistSavedJob);

            await _candidateRepo.SaveChanges();
        }

        public async Task<JobsTypeDto> GetJobByCandidate(Guid id, string type)
        {
            var candidate = await _candidateRepo.GetById(id) ?? throw new KeyNotFoundException("Candidate not found");

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

            Console.Write(jobs.SavedJob);
            jobs.AppliedJob = null;

            return jobs;
        }
    }
}
                            
              


