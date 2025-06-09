using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Service;
using Microsoft.EntityFrameworkCore;


namespace JobBoardWebApi.Repositories
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationsDto>> GetAllApplicationsAsync(ApplicationQueryParams applicationParams);
        Task<ApplicationDto> GetApplicationByIdAsync(Guid id);
        Task CreateApplicationAsync(ApplicationPostRequest application);
        Task UpdateApplicationForRecruiterAsync(Guid id, ApplicationPutRequest application);
        Task DeleteApplicationAsync(Guid id);
    }

    public class ApplicationRepo : IApplicationService
    {
        private readonly ApplicationDbContext _context;
        //private readonly IEmailService _emailService;

        public ApplicationRepo(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            //_emailService = emailService;
        }

        public async Task CreateApplicationAsync(ApplicationPostRequest application)
        {

            var newApplication = new Application
            {
                Status = StatusEnum.Pending,
                CoverLetter = application.CoverLetter,
                FileUrl = application.File,
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

            await _context.Applications.AddAsync(newApplication);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicationAsync(Guid id)
        {
            var isExistApplication = await _context.Applications.FindAsync(id) ??  throw new KeyNotFoundException("Application not found!");

            _context.Applications.Remove(isExistApplication);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationsDto>> GetAllApplicationsAsync(ApplicationQueryParams applicationParams)
        {
            var applications = _context.Applications.AsQueryable();

            if (applicationParams.Status != null)
            {
                applications = applications.Where(a => a.Status == applicationParams.Status);
            }

            var applicationsToDto = applications.Select(a => new ApplicationsDto
            {
                Id = a.Id,
                Status = a.Status,
                CandidateName = a.Candidate.User.FullName
            });

            return await applicationsToDto.Paged(applicationParams.Page,applicationParams.PageSize).ToListAsync();
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(Guid id)
        {
            var isExistApplication = await _context.Applications
                        .Include(a => a.Candidate)
                          .ThenInclude(a => a.User)
                        .Include(a => a.ApplicationJobMapping)
                          .ThenInclude(aj => aj.Job)
                             .ThenInclude(j => j.Company)
                               .ThenInclude(c => c.Recruiter)
                                 .ThenInclude(r => r.User)

                        .FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("Application not found!");

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
            var isExistApplication = await _context.Applications
                        .Include(a => a.Candidate)
                          .ThenInclude(a => a.User)
                        .Include(a => a.ApplicationJobMapping)
                          .ThenInclude(aj => aj.Job)
                             .ThenInclude(j => j.Company)
                               .ThenInclude(c => c.Recruiter)
                                 .ThenInclude(r => r.User)

                        .FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("Application not found!");

            var candidate = isExistApplication.Candidate.User;
            var job = isExistApplication.ApplicationJobMapping.First().Job;
            var company = job.Company;
            var recruiter = company.Recruiter.User;

            isExistApplication.Status = application.Status;

            _context.Applications.Update(isExistApplication);
            await _context.SaveChangesAsync();

            //if(isExistApplication.Status == StatusEnum.Approved)
            //{

            //string body = $@"
            //       <p>Hi {isExistApplication.Candidate.User.FullName},</p>
            //       <p>Good news! Your application for the role of <strong>{job.Title}</strong> at 
            //       <strong>{company.Name}</strong> (Location: <strong>{job.Location}</strong>) has been accepted.</p>
            //       <p>Thank you!</p>";

            //await _emailService.SendEmailToCandidateAsync(candidate.Email, "Your Application Was Accepted", body, company.Name,recruiter.Email );
            //}
        }
    }
}
