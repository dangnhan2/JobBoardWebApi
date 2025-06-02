using JobBoardWebApi.Dtos;
using JobBoardWebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Recruiter
{
    [Route("api/recruiter/[controller]")]
    [ApiController]
    [Authorize(Roles = "Recruiter")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            var result = await _applicationService.GetAllApplicationsAsync(page, pageSize);

            return Ok(new
            {
                msg = "Applications retrieved successful",
                statusCode = StatusCodes.Status200OK,
                data = result,
            });
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _applicationService.GetApplicationByIdAsync(id);

                return Ok(new
                {
                    msg = "Application retrieved successful",
                    statusCode = StatusCodes.Status200OK,
                    data = result,
                });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,

                });
            }
        }

        [HttpPatch("updateApplication/{id}")]
        public async Task<IActionResult> UpdateApplicationForRecruiter(Guid id, ApplicationPutRequest application)
        {
            try
            {
                await _applicationService.UpdateApplicationForRecruiterAsync(id, application);

                return Ok(new
                {
                    msg = "Application updated successful",
                    statusCode = StatusCodes.Status201Created,
                });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,

                });
            }
        }

        [HttpDelete("deleteApplication/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _applicationService.DeleteApplicationAsync(id);

                return Ok(new
                {
                    msg = "Application updated successful",
                    statusCode = StatusCodes.Status201Created,
                });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,

                });
            }
        }
    }
}
