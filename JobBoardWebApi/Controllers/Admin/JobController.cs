using JobBoardWebApi.Dtos;
using JobBoardWebApi.Models;
using JobBoardWebApi.Service;
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
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("getAll")]
        //[Required] int page, [Required] int pageSize, [FromQuery] JobFilterPaging filter
        public async Task<IActionResult> GetAllJobs([Required] int page, [Required] int pageSize)
        {
            var jobs = await _jobService.GetAllJobAsync(page, pageSize);
            return Ok(new
            {
                message = "Jobs retrieved successfully",
                statusCode = StatusCodes.Status200OK,
                data = jobs
            });
        }

        //[Required] int page, [Required] int pageSize, [FromQuery] JobApprovedFilter filter
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

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            try
            {
                var job = await _jobService.GetByIdAsync(id);
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
                await _jobService.UpdateJobForAdminAsync(id, jobActionforAdmin);
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
                await _jobService.DeleteJobAsync(id);
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
