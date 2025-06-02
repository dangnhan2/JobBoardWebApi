using JobBoardWebApi.Dtos;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Mapper;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;


namespace JobBoardWebApi.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepo _applicationRepo;
        private readonly IFileService _fileService;
        private readonly string directory = "resume";
        private readonly string[] allowedExtensions = [".pdf", ".docx"];

        public ApplicationService(IApplicationRepo applicationRepo, IFileService fileService)
        {
            _applicationRepo = applicationRepo;
            _fileService = fileService;
        }

        public async Task CreateApplicationAsync(ApplicationPostRequest application)
        {
            if(application.File == null || application.File.Length == 0)
            {
                throw new ArgumentNullException(nameof(application.File), "File path cannot be null");
            }

            var extension = Path.GetExtension(application.File.FileName);

            if (!allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException($"Only {string.Join(",", allowedExtensions)} extensions are allowed");
            }

            var fileString = _fileService.UploadImage(application.File, directory, allowedExtensions);

            var newApplication = new Application
            {
                Status = StatusEnum.Pending.ToString(),
                CoverLetter = application.CoverLetter,
                FileUrl = fileString,
                CandidateId = application.CandidateId,
                ApplicationJobMapping = new List<AppliedJob>()
            };

            foreach(var job in application.JobIds)
            {
                newApplication.ApplicationJobMapping.Add(new AppliedJob
                {
                    ApplicationId = newApplication.Id,
                    JobId = job,
                });
            }

            await _applicationRepo.Create(newApplication);
            await _applicationRepo.Save();
        }

        public async Task DeleteApplicationAsync(Guid id)
        {
            var isExistApplication = await _applicationRepo.GetById(id) ??  throw new KeyNotFoundException("Application not found!");

            _fileService.DeleteImage(isExistApplication.FileUrl, directory);

            _applicationRepo.Delete(isExistApplication);

            await _applicationRepo.Save();
        }

        public async Task<IEnumerable<ApplicationsDto>> GetAllApplicationsAsync(int page, int pageSize)
        {
            var applications = _applicationRepo.GetAll();

            var applicationsToDto = applications.Select(a => new ApplicationsDto
            {
                Id = a.Id,
                Status = a.Status,
                CandidateName = a.Candidate.User.FullName
            });

            return await applicationsToDto.Paged(page, pageSize).ToListAsync();
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(Guid id)
        {
            var isExistApplication = await _applicationRepo.GetById(id) ?? throw new KeyNotFoundException("Application not found!");

            var applicationToDto = new ApplicationDto
            {
                Id = isExistApplication.Id,
                Status = isExistApplication.Status,
                CoverLetter = isExistApplication.CoverLetter,
                FileUrl = isExistApplication.FileUrl,
                FullName = isExistApplication.Candidate.User.FullName,
                Email = isExistApplication.Candidate.User.Email,
                PhoneNumber = isExistApplication.Candidate.User.PhoneNumber
            };

            return applicationToDto;
        }

        public async Task UpdateApplicationForRecruiterAsync(Guid id, ApplicationPutRequest application)
        {
            var isExistApplication = await _applicationRepo.GetById(id) ?? throw new KeyNotFoundException("Application not found!");

            isExistApplication.Status = application.Status;

            _applicationRepo.Update(isExistApplication);
            await _applicationRepo.Save();
        }
    }
}
