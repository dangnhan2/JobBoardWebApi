using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers.Recruiter
{   
    [Route("api/recruiter/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Recruiter")]
    public class JobController : ControllerBase
    {
        private readonly IJobRepo _jobRepo;

        public JobController(IJobRepo jobRepo)
        {
            _jobRepo = jobRepo;
        }

        [HttpGet("getAllJobsApproved")]
        public async Task<IActionResult> GetAllJobsApproved([FromQuery] JobQueryParams jobParams)
        {
            var jobs = await _jobRepo.GetAllJobApprovedAsync(jobParams);
            return Ok(new
            {
                message = "Jobs retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = jobs
            });
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            try
            {
                var job = await _jobRepo.GetByIdAsync(id);
                return Ok(new
                {
                    message = "Job retrieved successfully",
                    statusCode = StatusCodes.Status200OK,
                    data = job
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message,
                    statusCode = StatusCodes.Status404NotFound,
                });
            }

        }

        [HttpPost("addJob")]
        public async Task<IActionResult> CreateJob([FromForm] JobRequest job)
        {
            try
            {
                await _jobRepo.CreateJobAsync(job);
                return Ok(new
                {
                    message = "Job created successfully",
                    statusCode = StatusCodes.Status201Created,

                });
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    statusCode = StatusCodes.Status400BadRequest
                });


            }
        }

        [HttpPut("updateJob/{id}")]
        public async Task<IActionResult> UpdateJob(Guid id, [FromForm] JobRequest job)
        {
            try
            {
                await _jobRepo.UpdateJobForRecruiterAsync(id, job);
                return Ok(new
                {
                    message = "Job updated successfully",
                    statusCode = StatusCodes.Status200OK,
                });

            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new
                {
                    message = e.Message,
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                });

            }
        }
    }
}
