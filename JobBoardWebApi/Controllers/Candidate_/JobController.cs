using JobBoardWebApi.Models;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers.Candidate
{
    [Route("api/cadidate_/[controller]")]
    [ApiController]
    [Authorize(Roles = "Candidate")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("getAllJobsApproved")]
        public async Task<IActionResult> GetAllJobsApproved([Required] int page, [Required] int pageSize)
        {
            var jobs = await _jobService.GetAllJobApprovedAsync(page, pageSize);
            return Ok(new
            {
                message = "Jobs retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = jobs
            });
        }
    }
}
