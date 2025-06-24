using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Filter;
using JobBoardWebApi.Models;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JobBoardWebApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class JobController : ControllerBase
    {
        private readonly IJobRepo _jobRepo;

        public JobController(IJobRepo jobRepo)
        {
            _jobRepo = jobRepo;
        }

        [HttpGet("getAll")]       
        public async Task<IActionResult> GetAllJobs([FromQuery] JobQueryParams jobFilter )
        {
            var jobs = await _jobRepo.GetAllJobAsync( jobFilter);
            return Ok(new
            {
                message = "Jobs retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = jobs
            });
        }

        [HttpGet("getAllJobsApproved")]
        public async Task<IActionResult> GetAllJobsApproved([FromQuery] JobQueryParams jobFilter)
        {
            var jobs = await _jobRepo.GetAllJobApprovedAsync(jobFilter);
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

        [HttpPatch("updateForAdmin/{id}")]
        public async Task<IActionResult> UpdateJobForAdmin(Guid id, [FromBody] JobRequestForAdmin jobActionforAdmin)
        {
            try
            {
                await _jobRepo.UpdateJobForAdminAsync(id, jobActionforAdmin);
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
        }

        [HttpDelete("deleteJob/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _jobRepo.DeleteJobAsync(id);
                return Ok(new
                {

                    message = "Delete job successfully",
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

        }
    }
}
