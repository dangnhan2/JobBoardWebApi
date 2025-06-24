using JobBoardWebApi.Dtos.Request;
using JobBoardWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers.Candidate_
{
    [Route("api/candidate/[controller]")]
    [ApiController]
    [Authorize(Roles = "Candidate")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepo _applicationRepo;

        public ApplicationController(IApplicationRepo applicationRepo)
        {
            _applicationRepo = applicationRepo;
        }

        [HttpPost("createApplication")]
        public async Task<IActionResult> Create(ApplicationPostRequest application)
        {
            try
            {
                await _applicationRepo.CreateApplicationAsync(application);


                return Ok(new
                {
                    msg = "Application created successful",
                    statusCode = StatusCodes.Status201Created,
                });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message,
                    statusCode = StatusCodes.Status400BadRequest,

                });
            }
            catch (InvalidOperationException ex)
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
