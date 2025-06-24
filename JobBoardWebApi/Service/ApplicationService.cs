using JobBoardWebApi.Data;
using JobBoardWebApi.Dtos;
using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Enum;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.EntityFrameworkCore;


namespace JobBoardWebApi.Service
{

    public class ApplicationService : IApplicationRepo
    {
        private readonly ApplicationDbContext _context;
        //private readonly IEmailService _emailService;

        public ApplicationService(ApplicationDbContext context, IEmailService emailService)
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
            var result = await _context.Set<ApplicationDto>().FromSqlRaw("EXEC GetApplicationById @ApplicationId={0}", id).AsNoTracking().FirstOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException("Application not found!");
            }

            return result;
        }

        public async Task UpdateApplicationForRecruiterAsync(Guid id, ApplicationPutRequest application)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateApplication @ApplicationId={0}, @StatusApplication={1}", id, application.Status);
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
